using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class Cenovnik
    {
        //[BsonId]
        //public string Id { get; set; }
        public DateTime VaziOd { get; set; }
        public List<StavkaCenovnika> Stavke { get; set; }

        public Cenovnik(DateTime vaziOd, List<StavkaCenovnika> stavke) 
        {
            VaziOd = vaziOd;
            Stavke = stavke;
        }

        /*public StavkaCenovnika? PronadjiStavku(Deonica deonica, TipVozila.Tip tipVozila)
        {
            foreach (StavkaCenovnika s in Stavke)
            {
                if(deonica.Ulazak == s.Deonica.Ulazak && deonica.Izlazak == s.Deonica.Izlazak && tipVozila == s.TipVozila)
                {
                    return s;
                }
            }
            return null;
        }*/
    }
}
