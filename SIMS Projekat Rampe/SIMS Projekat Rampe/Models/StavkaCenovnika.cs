﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class StavkaCenovnika
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public float Iznos { get; set; }
        public TipVozila TipVozila { get; set; }
        public string DeonicaId { get; set; }
        public bool Obrisana { get; set; }


        public StavkaCenovnika(string deonica, TipVozila tip, float iznos)
        {
            Id = ObjectId.GenerateNewId();
            Iznos = iznos;
            TipVozila = tip;
            DeonicaId = deonica;
            Obrisana = false;
        }
    }
}
