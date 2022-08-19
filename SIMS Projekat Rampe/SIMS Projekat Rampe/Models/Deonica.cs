using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class Deonica
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public NaplatnaStanica Ulazak { get; set; }
        public NaplatnaStanica Izlazak { get; set; }
    }
}
