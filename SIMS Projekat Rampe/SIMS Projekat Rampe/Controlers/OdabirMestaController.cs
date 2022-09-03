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
            List<NaplatnaStanica> odabrana = stanicaRepo.GetByRadnikActive(Ulogovani.UserName);
            if (odabrana.Count > 0)
            {
                return stanicaRepo.GetByRadnikActive(Ulogovani.UserName)[0].Naziv;
            }
            else return "Niste pozicionirani ni na jednu stanicu";
            
        }

        public NaplatnaStanica DobaviStanicu()
        {
            StanicaRepo stanicaRepo = new StanicaRepo();
            return stanicaRepo.GetByRadnikActive(Ulogovani.UserName)[0];
        }

        //ignorise elektronska
        public List<string> DobaviImenaMesta() 
        {
            StanicaRepo stanicaRepo = new StanicaRepo();
            List<string> imena = new List<string>();
            
            List<NaplatnaStanica> stanice = stanicaRepo.GetByRadnikActive(Ulogovani.UserName);
            if (stanice.Count > 0) 
            {
                NaplatnaStanica st = stanice[0];
                foreach (NaplatnoMesto nm in st.NaplatnaMesta)
                {
                    if (nm.Elektronsko == false)
                    {
                        imena.Add("naplatno mesto " + nm.RedniBr);
                    }
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
