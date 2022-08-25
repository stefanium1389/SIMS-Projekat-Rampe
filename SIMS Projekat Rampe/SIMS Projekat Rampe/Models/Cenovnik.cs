using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SIMS_Projekat_Rampe.Models
{
    public class Cenovnik
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime VaziOd { get; set; }
        public List<StavkaCenovnika> Stavke { get; set; }

        public Cenovnik(DateTime vaziOd, List<StavkaCenovnika> stavke) 
        {
            Id = ObjectId.GenerateNewId();
            VaziOd = vaziOd;
            Stavke = stavke;
        }

        public StavkaCenovnika? PronadjiStavku(string deonicaId, TipVozila tipVozila)
        {
            foreach (StavkaCenovnika s in Stavke)
            {
                if(deonicaId == s.DeonicaId && tipVozila == s.TipVozila)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
