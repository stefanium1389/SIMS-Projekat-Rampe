using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class StavkaCenovnika
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int Iznos { get; set; }
        public TipVozila.Tip TipVozila { get; set; }
        public Deonica Deonica { get; set; }
    }
}
