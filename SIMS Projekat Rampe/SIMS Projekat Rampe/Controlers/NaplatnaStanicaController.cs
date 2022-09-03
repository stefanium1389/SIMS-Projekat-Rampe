using System;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    public class NaplatnaStanicaController
    {
        public Korisnik SefStanice { get; set; }
        public NaplatnaStanicaController()
        {

        }
        public NaplatnaStanicaController(Korisnik sef) 
        {
            SefStanice = sef;
        }
        public string DobaviImeStanice() 
        {
            StanicaRepo sr = new StanicaRepo();
            List<NaplatnaStanica> stanice = sr.GetBySefActive(SefStanice.UserName);

            if (stanice.Count > 0)
            {
                return stanice[0].Naziv;
            }
            else return "";
        }

        public string DobaviImeSefa() 
        {
            return SefStanice.Ime + " " + SefStanice.Prezime;
        }

        public int DobaviBrojRadnika() 
        {
            StanicaRepo sr = new StanicaRepo();
            List<NaplatnaStanica> stanice = sr.GetBySefActive(SefStanice.UserName);
            return stanice[0].RadniciUsernames.Count;
        }

        public int DobaviBrojENP()
        {
            StanicaRepo sr = new StanicaRepo();
            List<NaplatnaStanica> stanice = sr.GetBySefActive(SefStanice.UserName);
            return stanice[0].ProdavciENPUsernames.Count;
        }

        public int DobaviBrojObicnih()
        {
            StanicaRepo sr = new StanicaRepo();
            NaplatnaStanica stanica = sr.GetBySefActive(SefStanice.UserName)[0];
            int br_obicnih = 0;
            foreach(NaplatnoMesto np in stanica.NaplatnaMesta) 
            {
                if (np.Elektronsko == false) 
                {
                    br_obicnih += 1;
                }
            }
            return br_obicnih;
            
        }

        public int DobaviBrojElektronskih()
        {
            StanicaRepo sr = new StanicaRepo();
            NaplatnaStanica stanica = sr.GetBySefActive(SefStanice.UserName)[0];
            int br_el = 0;
            foreach (NaplatnoMesto np in stanica.NaplatnaMesta)
            {
                if (np.Elektronsko)
                {
                    br_el += 1;
                }
            }
            return br_el;
        }

        public List<string> DobaviImenaMesta()
        {
            StanicaRepo stanicaRepo = new StanicaRepo();
            List<string> imena = new List<string>();

            List<NaplatnaStanica> stanice = stanicaRepo.GetBySefActive(SefStanice.UserName);
            if (stanice.Count > 0)
            {
                NaplatnaStanica st = stanice[0];
                foreach (NaplatnoMesto nm in st.NaplatnaMesta)
                {
                    
                    imena.Add("naplatno mesto " + nm.RedniBr);
                    
                }
            }
            return imena;
        }

        public string DobaviStanjeUredjaja(int rednibr, TipUredjaja tip) 
        {
            StanicaRepo sr = new StanicaRepo();
            NaplatnaStanica stanica = sr.GetBySefActive(SefStanice.UserName)[0];
            NaplatnoMesto mesto = stanica.NaplatnaMesta[rednibr];
            switch (tip) 
            {
                case TipUredjaja.CitacTablice:
                    if (mesto.CitacTablice.Pokvaren)
                    {
                        return "kvar";
                    }
                    else 
                    {
                        return "radi";
                    }
                    break;
                case TipUredjaja.CitacTagova:
                    if (mesto.CitacTagova == null) 
                    {
                        return "----";
                    }
                    if (mesto.CitacTagova.Pokvaren)
                    {
                        return "kvar";
                    }
                    else
                    {
                        return "radi";
                    }
                    break;
                case TipUredjaja.Displej:
                    if (mesto.Displej.Pokvaren)
                    {
                        return "kvar";
                    }
                    else
                    {
                        return "radi";
                    }
                    break;
                case TipUredjaja.Rampa:
                    if (mesto.Rampa.Pokvaren)
                    {
                        return "kvar";
                    }
                    else
                    {
                        return "radi";
                    }
                    break;
                case TipUredjaja.Semafor:
                    if (mesto.Semafor.Pokvaren)
                    {
                        return "kvar";
                    }
                    else
                    {
                        return "radi";
                    }
                    break;
            }
            return "greska";
        }

        public void OznaciKaoPopravljeno(TipUredjaja tip, int rednibr)
        {
            StanicaRepo sr = new StanicaRepo();
            NaplatnaStanica stanica = sr.GetBySefActive(SefStanice.UserName)[0];
            NaplatnoMesto mesto = stanica.NaplatnaMesta[rednibr];
            switch (tip)
            {
                case TipUredjaja.CitacTablice:
                    mesto.CitacTablice.Pokvaren = false;
                    break;
                case TipUredjaja.CitacTagova:
                    if ((mesto.Elektronsko)) 
                    {
                        mesto.CitacTagova.Pokvaren = false;
                    }
                    break;
                case TipUredjaja.Displej:
                    mesto.Displej.Pokvaren = false;
                    break;
                case TipUredjaja.Rampa:
                    mesto.Rampa.Pokvaren = false;
                    //mozda proizvede bug !
                    mesto.Rampa.PromeniStanje(new StateSpusteno(null));
                    break;
                case TipUredjaja.Semafor:
                    mesto.Semafor.Pokvaren = false;
                    break;
            }

            ZabeleziIzmene(stanica);
        }

        public void ZabeleziIzmene(NaplatnaStanica ns) 
        {
            StanicaRepo sr = new StanicaRepo();
            sr.Update(ns);
        }
        public List<NaplatnaStanica> DobaviSveStanice()
        {
            StanicaRepo sr = new StanicaRepo();
            return sr.GetAll();  
        }
    }
}
