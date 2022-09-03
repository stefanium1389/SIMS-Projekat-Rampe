using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace SIMS_Projekat_Rampe.Models
{
    public class KaznaZaPrekoracenjeBrzine
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Tablice { get; set; }
        public string ProlazakId { get; set; }

        public KaznaZaPrekoracenjeBrzine(string tablice, string prolazakKod)
        {
            Id = ObjectId.GenerateNewId();
            Tablice = tablice;
            ProlazakId = prolazakKod;
        }
    }
}
