using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SIMS_Projekat_Rampe.Models
{ 
    public class NaplatnoMesto
    {
        public int RedniBr { get; set; }
        public bool Elektronsko { get; set; }
        public bool Aktivno { get; set; }
        public Uredjaj Displej { get; set; }
        public Uredjaj CitacTablice { get; set; }
        public Uredjaj CitacTagova { get; set; }
        public Semafor Semafor { get; set; }
        public Rampa Rampa { get; set; }

        public NaplatnoMesto(int redniBr, bool elektronsko, bool aktivno)  
        {
            RedniBr = redniBr;
            Elektronsko = elektronsko;
            Aktivno = aktivno;
            Displej = new Uredjaj(TipUredjaja.Displej);
            CitacTablice = new Uredjaj(TipUredjaja.CitacTablice);
            CitacTagova = new Uredjaj(TipUredjaja.CitacTagova);
            Semafor = new Semafor(TipUredjaja.Semafor);
            Rampa = new Rampa(TipUredjaja.Rampa);
        }

        
    }
}
