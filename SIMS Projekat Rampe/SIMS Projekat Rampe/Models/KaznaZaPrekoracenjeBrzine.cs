using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class KaznaZaPrekoracenjeBrzine
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Tablice { get; set; }
        public Prolazak Prolazak { get; set; }
    }
}
