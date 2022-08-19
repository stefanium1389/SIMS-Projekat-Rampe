using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class Naplata
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime VremeNaplate { get; set; }
        public StavkaCenovnika Cena { get; set; }
    }
}
