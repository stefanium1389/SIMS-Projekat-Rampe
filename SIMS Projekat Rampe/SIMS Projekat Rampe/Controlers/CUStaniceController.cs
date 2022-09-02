using System;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.MongolDb;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.Controlers
{
    public class ValidacijaException : Exception
    {
        public ValidacijaException()
        {
        }
        public ValidacijaException(string message)
            : base(message)
        {
        }
        public ValidacijaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class CUStaniceController
    {
        public NaplatnaStanica? Stanica { get; set; }
        public bool Kreiranje { get; set; }
        public List<Korisnik> Zaposleni { get; set; }
        public Dictionary<TipKorisnika, List<Korisnik>> ListBoxPodaci { get; set; }
        public Dictionary<NaplatnaStanica, float> TabelaPovezanihPodaci { get; set; }
        public Dictionary<NaplatnaStanica, Dictionary<TipVozila, float>> TabelaCenaPodaci { get; set; }

        public CUStaniceController(NaplatnaStanica stanica) 
        {
            Stanica = stanica;
            if (stanica == null) 
            {
                Kreiranje = true;
                Zaposleni = new List<Korisnik>();
            }
            else 
            {
                Kreiranje = false;
                Zaposleni = DobaviZaposleneUStanici();
            }
            InicijalizujListBox();
            TabelaPovezanihPodaci = new Dictionary<NaplatnaStanica, float>();
            TabelaCenaPodaci = new Dictionary<NaplatnaStanica, Dictionary<TipVozila, float>>();
            InicijalizujTabeluPovezanih();
            InicijalizujTabeluCena();
            
        }

        public NaplatnaStanica PretvoriUStanicu(string izbor) 
        {
            StanicaRepo sr = new StanicaRepo();
            string id_stanice = izbor.Split('[', ']')[1];
            return sr.GetById(id_stanice)[0];
        }

        public TipVozila PretvoriUTipVozila(string izbor)
        {
            
            //verovatno postoji finiji nacin da se ovo uradi
            /*
             Auto,
            Motor,
            Kamion,
            Autobus,
            Kombi*/
            switch (izbor) 
            {
                case "Auto":
                    return TipVozila.Auto;
                    break;
                case "Motor":
                    return TipVozila.Motor;
                    break;
                case "Kamion":
                    return TipVozila.Kamion;
                    break;
                case "Autobus":
                    return TipVozila.Autobus;
                    break;
                case "Kombi":
                    return TipVozila.Kombi;
                    break;
            }
            throw new KeyNotFoundException("nema tog vozila");
        }

        public Dictionary<TipVozila,float> DobaviDictionaryCena(NaplatnaStanica ns) 
        {
            DeonicaRepo dr = new DeonicaRepo();
            Dictionary<TipVozila, float> cene = new Dictionary<TipVozila, float>();
            Cenovnik c = DobaviAktivniCenovnik();
            Deonica deonica = dr.GetByStanice(Stanica.Id, ns.Id)[0];
            List<StavkaCenovnika> stavke =c.DobaviStavkePoDeonici(deonica.Id);
            foreach (var stavka in stavke) 
            {
                cene[stavka.TipVozila] = stavka.Iznos;
            }
            return cene;
        }

        public void InicijalizujTabeluCena() 
        {
            if (Kreiranje) 
            {
                foreach (var item in TabelaPovezanihPodaci)
                {
                    Dictionary<TipVozila, float> cene = new Dictionary<TipVozila, float>();
                    foreach (TipVozila tip in Enum.GetValues(typeof(TipVozila))) 
                    {
                        cene[tip] = 0;
                    }
                    TabelaCenaPodaci[item.Key] = cene;
                    System.Diagnostics.Debug.WriteLine("xdd" + item.Key);
                }
            }

            else 
            {
                foreach (var item in TabelaPovezanihPodaci)
                {
                    Dictionary<TipVozila, float> cene = DobaviDictionaryCena(item.Key);
                    TabelaCenaPodaci[item.Key] = cene;
                    System.Diagnostics.Debug.WriteLine("xdd" + item.Key);
                }
            }
            
        }

        public void InicijalizujTabeluPovezanih()
        {
            DeonicaRepo dr = new DeonicaRepo();
            StanicaRepo sr = new StanicaRepo();

            if (Kreiranje) 
            {
                List<NaplatnaStanica> stanice = sr.GetAll();
                foreach(var stanica in stanice) 
                {
                    TabelaPovezanihPodaci[stanica] = 0;
                }
            }
            else 
            {
                var deonice = dr.GetByStanica(Stanica.Id);
                foreach (var deonica in deonice)
                {
                    if (Stanica.Id == deonica.IzlazakId) 
                    {
                        NaplatnaStanica stanica = sr.GetById(deonica.UlazakId)[0];
                        TabelaPovezanihPodaci[stanica] = deonica.Duzina;
                    }
                    else 
                    {
                        NaplatnaStanica stanica = sr.GetById(deonica.IzlazakId)[0];
                        TabelaPovezanihPodaci[stanica] = deonica.Duzina;
                    }
                }
            }
        }

        public void InicijalizujListBox()
        {
            ListBoxPodaci = new Dictionary<TipKorisnika, List<Korisnik>>();
            List<Korisnik> korisnici = DobaviSlobodneRadnikeTipa(TipKorisnika.Radnik);
            ListBoxPodaci[TipKorisnika.Radnik] = korisnici;

            korisnici = DobaviSlobodneRadnikeTipa(TipKorisnika.ProdavacENP);
            ListBoxPodaci[TipKorisnika.ProdavacENP] = korisnici;

            korisnici = DobaviSlobodneRadnikeTipa(TipKorisnika.SefStanice);
            ListBoxPodaci[TipKorisnika.SefStanice] = korisnici;
        }

        public int DobaviBrojElektronskih() 
        {
            int elektronske = 0;
            foreach(NaplatnoMesto nm in Stanica.NaplatnaMesta) 
            {
                if (nm.Elektronsko) 
                {
                    elektronske += 1;
                }
            }
            return elektronske;
        }

        public int DobaviBrojObicnih()
        {
            int neelektronske = 0;
            foreach (NaplatnoMesto nm in Stanica.NaplatnaMesta)
            {
                if (nm.Elektronsko == false)
                {
                    neelektronske += 1;
                }
            }
            return neelektronske;
        }

        public List<Korisnik> DobaviSlobodneRadnikeTipa(TipKorisnika tip) 
        {
            KorisnikRepo kr = new KorisnikRepo();
            StanicaRepo sr = new StanicaRepo();
            List<NaplatnaStanica> stanice = sr.GetAll();
            List<Korisnik> korisnici = kr.GetByTip(tip);
            
            if (tip == TipKorisnika.Radnik) 
            {
                foreach(NaplatnaStanica stanica in stanice) 
                {
                    foreach(string id in stanica.RadniciUsernames) 
                    {
                        korisnici.RemoveAll(x => x.UserName == id);
                    }
                }
            }

            if (tip == TipKorisnika.ProdavacENP) 
            {
                foreach (NaplatnaStanica stanica in stanice)
                {
                    foreach (string id in stanica.ProdavciENPUsernames)
                    {
                        korisnici.RemoveAll(x => x.UserName == id);
                    }
                }
            }

            if (tip == TipKorisnika.SefStanice)
            {
                foreach (NaplatnaStanica stanica in stanice)
                {
                    korisnici.RemoveAll(x => x.UserName == stanica.SefStaniceUsername);
                }
            }

            return korisnici;

        }

        public List<Korisnik> DobaviZaposleneUStanici() 
        {
            KorisnikRepo kr = new KorisnikRepo();
            List < Korisnik > korisnici = new List<Korisnik>();
            foreach (string id in Stanica.RadniciUsernames) 
            {
                korisnici.Add(kr.GetByUsername(id)[0]);
            }
            foreach (string id in Stanica.ProdavciENPUsernames)
            {
                korisnici.Add(kr.GetByUsername(id)[0]);
            }
            if (!(Stanica.SefStaniceUsername == null)) 
            {
                korisnici.Add(kr.GetByUsername(Stanica.SefStaniceUsername)[0]);
            }
            return korisnici;
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

        public void ValidirajTbx(string naziv, string brojObicnih, string brojElektronskih) 
        {
            if (string.IsNullOrEmpty(naziv) || string.IsNullOrWhiteSpace(naziv)) 
            {
                throw new ValidacijaException("Greška - Naziv stanice je prazan.");
            }

            int br_ob = -1;
            if (Int32.TryParse(brojObicnih, out br_ob) == false) 
            {
                throw new ValidacijaException("Greška - Broj običnih nije prepoznat");
            }
            if (br_ob < 0) 
            {
                throw new ValidacijaException("Greška - Broj običnih je manji od nule");
            }

            int br_el = -1;
            if (Int32.TryParse(brojElektronskih, out br_el) == false)
            {
                throw new ValidacijaException("Greška - Broj elektronskih nije prepoznat");
            }
            if (br_el < 0)
            {
                throw new ValidacijaException("Greška - Broj elektronskih je manji od nule");
            }
        }

        public void ValidirajZaposlene() 
        {
            int br_sefova = 0;
            foreach (var zap in Zaposleni) 
            {
                if (zap.Tip == TipKorisnika.SefStanice) 
                {
                    br_sefova += 1;
                }
            }

            if (br_sefova > 1) 
            {
                throw new ValidacijaException("Greška - Stanica ima više od 1 šefa.");
            }
        }

        public void ValidirajDeonice() 
        {
            foreach(var item in TabelaPovezanihPodaci) 
            {
                if (item.Value <= 0) 
                {
                    throw new ValidacijaException("Greška - Tabela povezanih je nepopunjena ili ima pogrešnu vrednost.");
                }
            }
        }

        public void ValidirajCene() 
        {
            foreach (var item in TabelaCenaPodaci) 
            {
                foreach (var item2 in item.Value) 
                {
                    if (item2.Value <= 0) 
                    {
                        throw new ValidacijaException("Greška - Tabela cena je nepopunjena ili ima pogrešnu vrednost.");
                    }
                }
            }
        }
    }
}
