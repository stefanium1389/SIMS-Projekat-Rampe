using MongoDB.Bson;
using System;

namespace SIMS_Projekat_Rampe.Models
{
    public class Naplata
    {
        public DateTime VremeNaplate { get; set; }
        public ObjectId IdStavkeCene { get; set; }

        public Naplata(DateTime vreme, ObjectId stavka)
        {
            VremeNaplate = vreme;
            IdStavkeCene = stavka;
        }
    }
}
