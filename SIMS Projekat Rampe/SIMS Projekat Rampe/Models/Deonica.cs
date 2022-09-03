using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class Deonica
    {
        [BsonId]
        public string Id { get; set; }
        public float Duzina { get; set; }
        public string UlazakId { get; set; }
        public string IzlazakId { get; set; }
        public bool Obrisana { get; set; }

        public Deonica (string id,float duzina,string ulaz, string izlaz) 
        {
            Id = id;
            Duzina = duzina;
            UlazakId = ulaz;
            IzlazakId = izlaz;
            Obrisana = false;
        }
    }
}
