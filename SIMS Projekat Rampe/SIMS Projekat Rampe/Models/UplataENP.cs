using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class UplataENP
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int Iznos { get; set; }
        public DateTime Vreme { get; set; }
    }
}
