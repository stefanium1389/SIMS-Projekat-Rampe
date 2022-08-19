using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class Prolazak
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public TipVozila.Tip TipVozila { get; set; }
        public DateTime VremeUlaska { get; set; }
        public Deonica Deonica { get; set; }
        public Naplata Naplata { get; set; }

    }
}
