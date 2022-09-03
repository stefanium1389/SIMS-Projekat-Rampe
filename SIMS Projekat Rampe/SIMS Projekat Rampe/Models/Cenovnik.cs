using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SIMS_Projekat_Rampe.Models
{
    public class Cenovnik
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime VaziOd { get; set; }
        public List<StavkaCenovnika> Stavke { get; set; }
        public bool Obrisan { get; set; }

        public Cenovnik(DateTime vaziOd, List<StavkaCenovnika> stavke)
        {
            Id = ObjectId.GenerateNewId();
            VaziOd = vaziOd;
            Stavke = stavke;
            Obrisan = false;
        }

        public Cenovnik(Cenovnik c)
        {
            Id = ObjectId.GenerateNewId();
            VaziOd = DateTime.Now;
            Stavke = new List<StavkaCenovnika>();
            foreach (StavkaCenovnika sc in c.Stavke)
            {
                Stavke.Add(new StavkaCenovnika(sc.DeonicaId, sc.TipVozila, sc.Iznos));
            }

        }

        public StavkaCenovnika? PronadjiStavku(string deonicaId, TipVozila tipVozila)
        {
            foreach (StavkaCenovnika s in Stavke)
            {
                if (deonicaId == s.DeonicaId && tipVozila == s.TipVozila)
                {
                    return s;
                }
            }
            return null;
        }

        public List<StavkaCenovnika> DobaviStavkePoDeonici(string deonicaId)
        {
            List<StavkaCenovnika> odgovarajuce = new List<StavkaCenovnika>();
            foreach (StavkaCenovnika s in Stavke)
            {
                if (s.DeonicaId == deonicaId)
                {
                    odgovarajuce.Add(s);
                }
            }
            return odgovarajuce;
        }
    }
}
