using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;
using System;
using System.Collections.Generic;

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
        public string NapraviNoviIdZaDeonicu()
        {
            DeonicaRepo dr = new DeonicaRepo();
            int broj = 0;
            foreach (var deonica in dr.GetAll())
            {
                int br = Int32.Parse(deonica.Id.Replace("d", ""));
                if (br > broj)
                {
                    broj = br;
                }
            }
            broj = broj + 1;
            return "d" + broj.ToString();
        }
        public string NapraviNoviIdZaStanicu()
        {
            StanicaRepo sr = new StanicaRepo();
            int broj = 0;
            foreach (var stanica in sr.GetAll())
            {
                int br = Int32.Parse(stanica.Id.Replace("st", ""));
                if (br > broj)
                {
                    broj = br;
                }
            }
            broj = broj + 1;
            return "st" + broj.ToString();
        }

        //ideja za unapredjenje - ne pravi novi cenovnik ako nije bio korišćen ni u jednom prolasku
        public void ZabeleziPromene(string naziv, string obicni, string elektronski)
        {
            if (Kreiranje)
            {
                NaplatnaStanica ns = KreirajStanicu(naziv, obicni, elektronski);
                List<Deonica> deonice = NapraviDeonice(ns);
                DopuniCenovnike(deonice, ns);
            }

            if (!Kreiranje)
            {
                IzmeniStanicu(naziv, obicni, elektronski);
                IzmeniDeonice();
                IzmeniCenovnike();
            }
        }
        public void IzmeniCenovnike()
        {
            List<Cenovnik> cenovnici = DobaviNoviAktivniIBuduceCenovnike();
            CenovnikRepo cr = new CenovnikRepo();
            DeonicaRepo dr = new DeonicaRepo();
            List<Deonica> deonice = new List<Deonica>();
            foreach (var item in TabelaCenaPodaci)
            {
                deonice.Add(dr.GetByStaniceActive(Stanica.Id, item.Key.Id)[0]);
            }

            foreach (Cenovnik c in cenovnici)
            {
                foreach (Deonica d in deonice)
                {
                    List<StavkaCenovnika> stavke = c.DobaviStavkePoDeonici(d.Id);
                    foreach (var stavka in stavke)
                    {
                        //boli me mozak, ovo valjda radi
                        stavka.Iznos = PronadjiIznos(d, Stanica, stavka.TipVozila);
                    }
                }
                cr.Update(c);
            }
        }

        public void IzmeniDeonice()
        {
            DeonicaRepo dr = new DeonicaRepo();
            foreach (var item in TabelaPovezanihPodaci)
            {
                Deonica d = dr.GetByStaniceActive(Stanica.Id, item.Key.Id)[0];
                d.Duzina = item.Value;
                dr.Update(d);
            }
        }

        public void IzmeniStanicu(string naziv, string obicni, string elektronski)
        {
            int br_obicni = Int32.Parse(obicni);
            int br_elektronski = Int32.Parse(elektronski);
            //promena naziva stanice
            Stanica.Naziv = naziv;
            int br_obicnih_trenutno = DobaviBrojObicnih();
            int br_elektronskih_trenutno = DobaviBrojElektronskih();

            //promena broja obicnih mesta
            if (br_obicni > br_obicnih_trenutno)
            {
                int rednibr = -1;
                for (int i = 0; i < br_obicni - br_obicnih_trenutno; i++)
                {
                    rednibr = NabaviNoviRedniBroj();
                    NaplatnoMesto novo = new NaplatnoMesto(rednibr, false, true);
                    Stanica.NaplatnaMesta.Add(novo);
                }

            }
            else if (br_obicni < br_obicnih_trenutno)
            {
                for (int i = 0; i < br_obicnih_trenutno - br_obicni; i++)
                {
                    ObrisiNaplatnoMesto(true);
                }
            }

            // ista stvar ali sa elektronskim
            if (br_elektronski > br_elektronskih_trenutno)
            {
                int rednibr = -1;
                for (int i = 0; i < br_elektronski - br_elektronskih_trenutno; i++)
                {
                    rednibr = NabaviNoviRedniBroj();
                    NaplatnoMesto novo = new NaplatnoMesto(rednibr, true, true);
                    Stanica.NaplatnaMesta.Add(novo);
                }

            }
            else if (br_elektronski < br_elektronskih_trenutno)
            {
                for (int i = 0; i < br_elektronskih_trenutno - br_elektronski; i++)
                {
                    ObrisiNaplatnoMesto(false);
                }
            }

            //prikupljanje id-ova svih
            List<string> lista_svih = new List<string>();
            foreach (var kor in Stanica.RadniciUsernames)
            {
                lista_svih.Add(kor);
            }
            foreach (var kor in Stanica.ProdavciENPUsernames)
            {
                lista_svih.Add(kor);
            }
            if (!(Stanica.SefStaniceUsername is null))
            {
                lista_svih.Add(Stanica.SefStaniceUsername);
            }

            //izbacivanje radnika
            foreach (string kor in lista_svih)
            {
                if (!(Zaposleni.Exists(x => x.UserName == kor)))
                {
                    if (Stanica.RadniciUsernames.Contains(kor))
                    {
                        Stanica.RadniciUsernames.Remove(kor);
                    }
                    else if (Stanica.ProdavciENPUsernames.Contains(kor))
                    {
                        Stanica.ProdavciENPUsernames.Remove(kor);
                    }
                    else if (!(Stanica.SefStaniceUsername is null))
                    {
                        if (Stanica.SefStaniceUsername == kor)
                        {
                            Stanica.SefStaniceUsername = null;
                        }
                    }
                    else
                    {
                        throw new KeyNotFoundException("greška u brisanju zaposlenog");
                    }
                }
            }

            //ubacivanje radnika
            foreach (Korisnik kor in Zaposleni)
            {
                if (lista_svih.Contains(kor.UserName) == false)
                {
                    if (kor.Tip == TipKorisnika.SefStanice)
                    {
                        Stanica.SefStaniceUsername = kor.UserName;
                    }
                    else if (kor.Tip == TipKorisnika.Radnik)
                    {
                        Stanica.RadniciUsernames.Add(kor.UserName);
                    }
                    else if (kor.Tip == TipKorisnika.ProdavacENP)
                    {
                        Stanica.ProdavciENPUsernames.Add(kor.UserName);
                    }
                    else
                    {
                        throw new KeyNotFoundException("dat pogresan tip radnika");
                    }
                }
            }

            //belezenje
            StanicaRepo sr = new StanicaRepo();
            sr.Update(Stanica);
        }

        public void ObrisiNaplatnoMesto(bool obicno)
        {
            NaplatnoMesto oznacenoZaBrisanje = null;

            if (obicno)
            {
                foreach (NaplatnoMesto nm in Stanica.NaplatnaMesta)
                {
                    if (nm.Elektronsko == false)
                    {
                        oznacenoZaBrisanje = nm;
                        break;
                    }
                }
            }
            else
            {
                foreach (NaplatnoMesto nm in Stanica.NaplatnaMesta)
                {
                    if (nm.Elektronsko == true)
                    {
                        oznacenoZaBrisanje = nm;
                        break;
                    }
                }
            }

            if (oznacenoZaBrisanje is null)
            {
                throw new KeyNotFoundException("greska u potrazi naplatnog mesta");
            }
            Stanica.NaplatnaMesta.Remove(oznacenoZaBrisanje);
        }

        public int NabaviNoviRedniBroj()
        {
            int redni = 0;
            foreach (NaplatnoMesto nm in Stanica.NaplatnaMesta)
            {
                if (nm.RedniBr > redni)
                {
                    redni = nm.RedniBr;
                }
            }
            redni += 1;
            return redni;
        }

        public void DopuniCenovnike(List<Deonica> deonice, NaplatnaStanica nova)
        {
            List<Cenovnik> cenovnici = DobaviNoviAktivniIBuduceCenovnike();
            CenovnikRepo cr = new CenovnikRepo();
            foreach (Cenovnik c in cenovnici)
            {
                foreach (Deonica d in deonice)
                {
                    List<StavkaCenovnika> stavke = NapraviStavke(d, nova);
                    c.Stavke.AddRange(stavke);
                }
                cr.Update(c);
            }
        }

        public List<StavkaCenovnika> NapraviStavke(Deonica d, NaplatnaStanica novaStanica)
        {
            List<StavkaCenovnika> stavke = new List<StavkaCenovnika>();
            foreach (TipVozila tip in Enum.GetValues(typeof(TipVozila)))
            {
                float iznos = PronadjiIznos(d, novaStanica, tip);
                StavkaCenovnika nova = new StavkaCenovnika(d.Id, tip, iznos);
                stavke.Add(nova);
            }
            return stavke;
        }

        public List<Deonica> NapraviDeonice(NaplatnaStanica ns)
        {
            List<Deonica> deonice = new List<Deonica>();
            DeonicaRepo dr = new DeonicaRepo();
            foreach (var item in TabelaPovezanihPodaci)
            {
                string id = NapraviNoviIdZaDeonicu();
                Deonica d = new Deonica(id, item.Value, ns.Id, item.Key.Id);
                dr.Create(d);
                deonice.Add(d);
            }

            return deonice;
        }

        public float PronadjiIznos(Deonica d, NaplatnaStanica ns, TipVozila tip)
        {
            string id = null;
            if (d.UlazakId == ns.Id)
            {
                id = d.IzlazakId;
            }
            else
            {
                id = d.UlazakId;
            }

            foreach (var item in TabelaCenaPodaci)
            {
                if (item.Key.Id == id)
                {
                    return item.Value[tip];
                }
            }
            throw new KeyNotFoundException("greska u potrazi cena");
        }

        public NaplatnaStanica KreirajStanicu(string naziv, string obicni, string elektronski)
        {
            int br_obicni = Int32.Parse(obicni);
            int br_elektronski = Int32.Parse(elektronski);
            int redniBroj = 0;

            string id = NapraviNoviIdZaStanicu();

            string sefId = null;
            foreach (var kor in Zaposleni)
            {
                if (kor.Tip == TipKorisnika.SefStanice)
                {
                    sefId = kor.UserName;
                }
            }

            List<string> radniciId = new List<string>();
            List<string> prodavciId = new List<string>();
            foreach (var kor in Zaposleni)
            {
                if (kor.Tip == TipKorisnika.Radnik)
                {
                    radniciId.Add(kor.UserName);
                }
                else if (kor.Tip == TipKorisnika.ProdavacENP)
                {
                    prodavciId.Add(kor.UserName);
                }
            }

            List<NaplatnoMesto> naplatnaMesta = new List<NaplatnoMesto>();
            for (int i = 0; i < br_obicni; i++)
            {
                NaplatnoMesto nm = new NaplatnoMesto(redniBroj, false, true);
                naplatnaMesta.Add(nm);
                redniBroj += 1;
            }
            for (int i = 0; i < br_elektronski; i++)
            {
                NaplatnoMesto nm = new NaplatnoMesto(redniBroj, true, true);
                naplatnaMesta.Add(nm);
                redniBroj += 1;
            }

            NaplatnaStanica nova = new NaplatnaStanica(id, naziv, sefId, radniciId, prodavciId, naplatnaMesta);
            StanicaRepo sr = new StanicaRepo();
            sr.Create(nova);
            return nova;
        }

        public NaplatnaStanica PretvoriUStanicu(string izbor)
        {
            StanicaRepo sr = new StanicaRepo();
            string id_stanice = izbor.Split('[', ']')[1];
            return sr.GetByIdActive(id_stanice)[0];
        }

        public TipVozila PretvoriUTipVozila(string izbor)
        {
            //verovatno postoji finiji nacin da se ovo uradi
            switch (izbor)
            {
                case "Auto":
                    return TipVozila.Auto;
                case "Motor":
                    return TipVozila.Motor;
                case "Kamion":
                    return TipVozila.Kamion;
                case "Autobus":
                    return TipVozila.Autobus;
                case "Kombi":
                    return TipVozila.Kombi;
            }
            throw new KeyNotFoundException("nema tog vozila");
        }

        public Dictionary<TipVozila, float> DobaviDictionaryCena(NaplatnaStanica ns)
        {
            DeonicaRepo dr = new DeonicaRepo();
            Dictionary<TipVozila, float> cene = new Dictionary<TipVozila, float>();
            Cenovnik c = DobaviAktivniCenovnik();
            Deonica deonica = dr.GetByStaniceActive(Stanica.Id, ns.Id)[0];
            List<StavkaCenovnika> stavke = c.DobaviStavkePoDeonici(deonica.Id);
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
                }
            }

            else
            {
                foreach (var item in TabelaPovezanihPodaci)
                {
                    Dictionary<TipVozila, float> cene = DobaviDictionaryCena(item.Key);
                    TabelaCenaPodaci[item.Key] = cene;
                }
            }

        }

        public void InicijalizujTabeluPovezanih()
        {
            DeonicaRepo dr = new DeonicaRepo();
            StanicaRepo sr = new StanicaRepo();

            if (Kreiranje)
            {
                List<NaplatnaStanica> stanice = sr.GetAllActive();
                foreach (var stanica in stanice)
                {
                    TabelaPovezanihPodaci[stanica] = 0;
                }
            }
            else
            {
                var deonice = dr.GetByStanicaActive(Stanica.Id);
                foreach (var deonica in deonice)
                {
                    if (Stanica.Id == deonica.IzlazakId)
                    {
                        NaplatnaStanica stanica = sr.GetByIdActive(deonica.UlazakId)[0];
                        TabelaPovezanihPodaci[stanica] = deonica.Duzina;
                    }
                    else
                    {
                        NaplatnaStanica stanica = sr.GetByIdActive(deonica.IzlazakId)[0];
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
            foreach (NaplatnoMesto nm in Stanica.NaplatnaMesta)
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
            List<NaplatnaStanica> stanice = sr.GetAllActive();
            List<Korisnik> korisnici = kr.GetByTip(tip);

            if (tip == TipKorisnika.Radnik)
            {
                foreach (NaplatnaStanica stanica in stanice)
                {
                    foreach (string id in stanica.RadniciUsernames)
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
            List<Korisnik> korisnici = new List<Korisnik>();
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

            List<Cenovnik> cenovnici = cr.GetAllActive();

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

        //podrazumeva da su cenovnici sortirani po datumu
        public List<Cenovnik> DobaviNoviAktivniIBuduceCenovnike()
        {
            CenovnikRepo cr = new CenovnikRepo();

            List<Cenovnik> cenovnici = cr.GetAllActive();

            Cenovnik aktivni = null;
            foreach (Cenovnik c in cenovnici)
            {
                if (c.VaziOd < DateTime.Now)
                {
                    aktivni = c;
                }
            }

            List<Cenovnik> trazeni = new List<Cenovnik>();
            Cenovnik novi_aktivni = new Cenovnik(aktivni);
            cr.Create(novi_aktivni);
            cr.Sort();

            trazeni.Add(novi_aktivni);

            foreach (Cenovnik c in cenovnici)
            {
                if (c.VaziOd > novi_aktivni.VaziOd)
                {
                    trazeni.Add(c);
                }
            }

            return trazeni;
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
            foreach (var item in TabelaPovezanihPodaci)
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
