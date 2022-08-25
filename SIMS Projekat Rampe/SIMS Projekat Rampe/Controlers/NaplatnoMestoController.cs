using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    public class NaplatnoMestoException : Exception
    {
        public NaplatnoMestoException()
        {
        }
        public NaplatnoMestoException(string message)
            : base(message)
        {
        }
        public NaplatnoMestoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NaplatnoMestoController
    {
        public Prolazak TrenutniProlazak { get; set; }
        public NaplatnaStanica Stanica { get; set; }
        public int RedniBrojMesta { get; set; }
        public string TrenutneTablice { get; set; }
        public float TrenutnaProsecnaBrzina { get; set; }
        public float TrenutniIznos { get; set; }
        public TipVozila SelektovaniTip { get; set; }

        public bool KaznaIzdata { get; set; }
        
        public NaplatnoMestoController (NaplatnaStanica stanica, int redniBroj) 
        {
            Stanica = stanica;
            RedniBrojMesta = redniBroj;
        }

        public void FinalizujProlazak() 
        {
            Cenovnik c = DobaviAktivniCenovnik();
            StavkaCenovnika s = c.PronadjiStavku(TrenutniProlazak.DeonicaId, (TipVozila)TrenutniProlazak.TipVozila);
            Naplata nova = new Naplata(DateTime.Now, s.Id);
            TrenutniProlazak.Naplata = nova;
            ProlazakRepo pr = new ProlazakRepo();
            pr.Create(TrenutniProlazak);
        }

        public float ProveriUplatu(string iznos)
        {
            double izn;
            try
            {
                izn = Double.Parse(iznos);
            }
            catch (Exception)
            {
                throw new NaplatnoMestoException("Greška u čitanju unete vrednosti");
            }

            if (izn < 0)
            {
                throw new NaplatnoMestoException("Greška - uplata je negativna");
            }

            if (izn < TrenutniIznos) 
            {
                throw new NaplatnoMestoException("Greška - uplata je manja od iznosa");
            }

            return (float)(izn - TrenutniIznos);
        }
        public string DobaviStanjeRampe() 
        {
            var mesto = Stanica.NaplatnaMesta[RedniBrojMesta];
            if (mesto.Rampa.Stanje.GetType().Equals(typeof(StatePodignuto))) 
            {
                return "podignuta";
            }
            else if (mesto.Rampa.Stanje.GetType().Equals(typeof(StatePodizeSe)))
            {
                return "podiže se";
            }
            else if (mesto.Rampa.Stanje.GetType().Equals(typeof(StateSpustaSe)))
            {
                return "spušta se";
            }
            else if (mesto.Rampa.Stanje.GetType().Equals(typeof(StateSpusteno)))
            {
                return "spuštena";
            }
            else if (mesto.Rampa.Stanje.GetType().Equals(typeof(StatePokvareno)))
            {
                return "pokvarena";
            }
            return "greska";
        }

        public string DobaviStanjeSemafora()
        {
            var mesto = Stanica.NaplatnaMesta[RedniBrojMesta];
            if (mesto.Semafor.Pokvaren == true)
            {
                return "pokvaren";
            }
            else return "radi";
        }

        public string DobaviStanjeCitacaTagova()
        {
            var mesto = Stanica.NaplatnaMesta[RedniBrojMesta];
            if (mesto.CitacTagova.Pokvaren == true)
            {
                return "pokvaren";
            }
            else return "radi";
        }

        public string DobaviStanjeCitacaTablica()
        {
            var mesto = Stanica.NaplatnaMesta[RedniBrojMesta];
            if (mesto.CitacTablice.Pokvaren == true)
            {
                return "pokvaren";
            }
            else return "radi";
        }

        public string DobaviStanjeDispleja()
        {
            var mesto = Stanica.NaplatnaMesta[RedniBrojMesta];
            if (mesto.Displej.Pokvaren == true)
            {
                return "pokvaren";
            }
            else return "radi";
        }

        public void NapraviNoviProlazak() 
        {
            ProlazakRepo pr = new ProlazakRepo();
            string kod;
            while (true) 
            {
                kod = NapraviNovKod();
                if (pr.GetByKod(kod).Count == 0) 
                {
                    break;
                }

            }
            TipVozila tip = SelektovaniTip;
            DateTime vreme = OdaberiNasumiceVreme();
            string deonica = OdaberiNasumiceDeonicu();
            string ulazna = OdrediUlaznuStanicu(deonica);
            
            TrenutniProlazak = new Prolazak(kod, tip, vreme, ulazna, deonica);

            TrenutneTablice = GenerisiNoveTablice();

            TrenutnaProsecnaBrzina = IzracunajProsecnuBrzinu();

            KaznaIzdata = GenerisiKaznu();

            TrenutniIznos = PronadjiIznos();

        }

        public void PrimeniNovTip(TipVozila tip) 
        {
            if (!(TrenutniProlazak is null)) 
            {
                TrenutniProlazak.TipVozila = tip;
                TrenutniIznos = PronadjiIznos();
            }
            
        }

        public float PronadjiIznos() 
        {
            Cenovnik c = DobaviAktivniCenovnik();
            return DobaviIznos(c, TrenutniProlazak.DeonicaId, (TipVozila)TrenutniProlazak.TipVozila);
        }

        public float DobaviIznos(Cenovnik c, string deonicaId, TipVozila tip) 
        {
            return c.PronadjiStavku(deonicaId, tip).Iznos;
        }

        //podrazumeva da su cenovnici sortirani po datumu
        public Cenovnik DobaviAktivniCenovnik() 
        {
            CenovnikRepo cr = new CenovnikRepo();

            List < Cenovnik > cenovnici = cr.GetAll();

            Cenovnik aktivni = null;
            foreach( Cenovnik c in cenovnici) 
            {
                if (c.VaziOd < DateTime.Now) 
                {
                    aktivni = c;
                }
            }

            return aktivni;
        }

        public bool GenerisiKaznu() 
        {
            if (TrenutnaProsecnaBrzina > 130)
            {
                KaznaZaPrekoracenjeBrzine kpb = new KaznaZaPrekoracenjeBrzine(TrenutneTablice,TrenutniProlazak.Kod);
                KaznaRepo kr = new KaznaRepo();
                kr.Create(kpb);
                return true;
            }
            return false;
        }

        public float IzracunajProsecnuBrzinu() 
        {
            DeonicaRepo dr = new DeonicaRepo();
            Deonica d = dr.GetByStanice(Stanica.Id, TrenutniProlazak.UlaznaStanica)[0];
            double vreme = (DateTime.Now - TrenutniProlazak.VremeUlaska).TotalHours;
            float brzina = d.Duzina / (float)vreme;
            return brzina;

        }

        /*public TipVozila OdaberiNasumiceTip() 
        {
            Array values = Enum.GetValues(typeof(TipVozila));
            Random random = new Random();
            TipVozila randomTip = (TipVozila)values.GetValue(random.Next(values.Length));
            return randomTip;
        }*/

        public DateTime OdaberiNasumiceVreme() 
        {
            Random random = new Random();
            DateTime novo = DateTime.Now;
            return novo.AddMinutes(-random.Next(50,80));
            
        }

        public string OdrediUlaznuStanicu(string deonicaId) 
        {
            DeonicaRepo dr = new DeonicaRepo();
            Deonica deonica = dr.GetById(deonicaId)[0];
            if (Stanica.Id == deonica.UlazakId)
            {
                return deonica.IzlazakId;
            }
            else 
            {
                return deonica.UlazakId;
            }
        }

        public string OdaberiNasumiceDeonicu() 
        {
            Random random = new Random();
            DeonicaRepo dr = new DeonicaRepo();
            List<Deonica> potencijalne = dr.GetByStanica(Stanica.Id);
            int index = random.Next(potencijalne.Count);
            return potencijalne[index].Id;
        }

        public string NapraviNovKod() 
        {
            int length = 8;

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        public string GenerisiNoveTablice()
        {
            int duzina = 2;

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < duzina; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
           

            int broj = random.Next(100, 999);
            str_build.Append(broj);

            for (int i = 0; i < duzina; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString().ToUpper();
        }

        public string DobaviImeUlazneStanice() 
        {
            StanicaRepo sr = new StanicaRepo();
            return sr.GetById(TrenutniProlazak.UlaznaStanica)[0].Naziv;
        }
        public void RegistrujKvar(TipUredjaja tip) 
        {
            var mesto = Stanica.NaplatnaMesta[RedniBrojMesta];

            if (tip == TipUredjaja.Rampa) 
            {
                mesto.Rampa.PromeniStanje(new StatePokvareno());
            }

            else 
            {
                switch (tip)
                {
                    case TipUredjaja.Semafor:
                        mesto.Semafor.Pokvaren = true;
                        break;
                    case TipUredjaja.Displej:
                        mesto.Displej.Pokvaren = true;
                        break;
                    case TipUredjaja.CitacTablice:
                        mesto.CitacTablice.Pokvaren = true;
                        break;
                    case TipUredjaja.CitacTagova:
                        mesto.CitacTagova.Pokvaren = true;
                        break;
                }
            }

        }
    }

}
