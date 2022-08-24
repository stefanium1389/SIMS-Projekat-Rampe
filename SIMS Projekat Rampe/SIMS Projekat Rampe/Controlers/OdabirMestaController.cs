using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    
    public class OdabirMestaController
    {
        public Korisnik Ulogovani { get; set; }
        
        public OdabirMestaController (Korisnik ulogovani) 
        {
            Ulogovani = ulogovani;
        }

        public string DobaviImeStanice() 
        {
            StanicaRepo stanicaRepo = new StanicaRepo();
            return stanicaRepo.GetByRadnik(Ulogovani.UserName)[0].Naziv;
        }

        public NaplatnaStanica DobaviStanicu()
        {
            StanicaRepo stanicaRepo = new StanicaRepo();
            return stanicaRepo.GetByRadnik(Ulogovani.UserName)[0];
        }

        //ignorise elektronska
        public List<string> DobaviImenaMesta() 
        {
            StanicaRepo stanicaRepo = new StanicaRepo();
            List<string> imena = new List<string>();
            
            NaplatnaStanica st = stanicaRepo.GetByRadnik(Ulogovani.UserName)[0];

            foreach (NaplatnoMesto nm in st.NaplatnaMesta)
            {
                if (nm.Elektronsko == false) 
                {
                    imena.Add("naplatno mesto " + nm.RedniBr);
                }
            }

            return imena;
            
        }

        public string DobaviImeUlogovanog()
        {
            return Ulogovani.Ime +" "+ Ulogovani.Prezime;
        }
    }
}
