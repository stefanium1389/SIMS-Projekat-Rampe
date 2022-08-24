using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    
    public class NaplatnoMestoController
    {
        public Prolazak trenutniProlazak { get; set; }
        public NaplatnaStanica Stanica { get; set; }
        public int RedniBrojMesta { get; set; }
        
        public NaplatnoMestoController (NaplatnaStanica stanica, int redniBroj) 
        {
            Stanica = stanica;
            RedniBrojMesta = redniBroj;
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
