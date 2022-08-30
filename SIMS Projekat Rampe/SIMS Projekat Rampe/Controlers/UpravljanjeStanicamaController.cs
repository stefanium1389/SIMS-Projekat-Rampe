using System;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    public class UpravljanjeStanicamaController
    {
        public Korisnik Admin { get; set; }
        
        public UpravljanjeStanicamaController(Korisnik admin) 
        {
            Admin = admin;
        }

        public string DobaviUlogovanog() 
        {
            return Admin.Ime + " " + Admin.Prezime;
        }

        //ovo je uradjeno ovako a ne sa string reprezentacijom jer više stanica može imati isto ime pa umesto koriscenja naziva
        //ili pravljenja nekog posebnog stringa koristimo objekat stanice kojoj se može proveriti id
        public List<NaplatnaStanica> DobaviStanice() 
        {
            StanicaRepo sr = new StanicaRepo();
            return sr.GetAll();
        }

        public List<string[]> DobaviPodatkeOStanici(NaplatnaStanica stanica) 
        {
            StanicaRepo sr = new StanicaRepo();
            NaplatnaStanica ucitanaStanica = sr.GetById(stanica.Id)[0];
            List<string[]> podaci = new List<string[]>();

            podaci.Add(new string[] { "Broj naplatnih mesta", stanica.NaplatnaMesta.Count.ToString() });

            int br_obicnih = 0;
            foreach(var mesto in stanica.NaplatnaMesta) 
            {
                if (!mesto.Elektronsko) 
                {
                    br_obicnih += 1;
                }
            }

            podaci.Add(new string[] { "Broj običnih", br_obicnih.ToString()});

            podaci.Add(new string[] { "Broj elektronskih", (stanica.NaplatnaMesta.Count - br_obicnih).ToString() });

            podaci.Add(new string[] { "Broj radnika", stanica.RadniciUsernames.Count.ToString() });

            podaci.Add(new string[] { "Broj prodavaca ENP", stanica.ProdavciENPUsernames.Count.ToString()});

            return podaci;
        }

        public List<string[]> DobaviPodatkeOZaposlenima(NaplatnaStanica stanica)
        {
            StanicaRepo sr = new StanicaRepo();
            KorisnikRepo kr = new KorisnikRepo();
            NaplatnaStanica ucitanaStanica = sr.GetById(stanica.Id)[0];
            List<string[]> podaci = new List<string[]>();


            foreach (string user in ucitanaStanica.RadniciUsernames) 
            {
                Korisnik korisnik = kr.GetByUsername(user)[0];
                podaci.Add(new string[] { korisnik.Ime, korisnik.Prezime, korisnik.Tip.ToString() });
            }

            foreach (string user in ucitanaStanica.ProdavciENPUsernames)
            {
                Korisnik korisnik = kr.GetByUsername(user)[0];
                podaci.Add(new string[] { korisnik.Ime, korisnik.Prezime, korisnik.Tip.ToString() });
            }

            Korisnik sef = kr.GetByUsername(stanica.SefStaniceUsername)[0];
            podaci.Add(new string[] { sef.Ime, sef.Prezime, sef.Tip.ToString() });

            return podaci;
        }

        public List<string[]> DobaviPodatkeODeonicama(NaplatnaStanica stanica)
        {
            DeonicaRepo dr = new DeonicaRepo();
            StanicaRepo sr = new StanicaRepo();

            List<string[]> podaci = new List<string[]>();

            var deonice = dr.GetByStanica(stanica.Id);

            foreach (var deonica in deonice) 
            {
                if (deonica.UlazakId == stanica.Id) 
                {
                    NaplatnaStanica ucitana = sr.GetById(deonica.IzlazakId)[0];
                    string ispis = ucitana.Naziv + " [" + ucitana.Id + "]";
                    podaci.Add(new string[] { ispis, deonica.Duzina.ToString() });
                }
                else
                {
                    NaplatnaStanica ucitana = sr.GetById(deonica.UlazakId)[0];
                    string ispis = ucitana.Naziv + " [" + ucitana.Id + "]";
                    podaci.Add(new string[] { ispis, deonica.Duzina.ToString() });
                }
            }

            return podaci;
        }

        public List<string[]> DobaviPodatkeOCenama(string stanica1, string stanica2)
        {
            //ovo bi trebao kontroler da radi
            DeonicaRepo dr = new DeonicaRepo();
            List<string[]> podaci = new List<string[]>();

            Deonica deonica = dr.GetByStanice(stanica1, stanica2)[0];
            Cenovnik aktivni = DobaviAktivniCenovnik();

            List<StavkaCenovnika> stavke = aktivni.DobaviStavkePoDeonici(deonica.Id);

            foreach (var stavka in stavke)
            {
                podaci.Add(new string[] { stavka.TipVozila.ToString(), stavka.Iznos.ToString() } );
            }

            return podaci;
        }

        //podrazumeva da su cenovnici sortirani po datumu
        public Cenovnik DobaviAktivniCenovnik()
        {
            CenovnikRepo cr = new CenovnikRepo();

            List<Cenovnik> cenovnici = cr.GetAll();

            Cenovnik aktivni = null;
            foreach (Cenovnik c in cenovnici)
            {
                if (c.VaziOd < DateTime.Now)
                {
                    aktivni = c;
                }
            }

            return aktivni;
        }

        public NaplatnaStanica DobaviStanicuIzTabele(string izbor) 
        {
            StanicaRepo sr = new StanicaRepo();
            string id_stanice = izbor.Split('[', ']')[1];
            return sr.GetById(id_stanice)[0];
        }
    }
}
