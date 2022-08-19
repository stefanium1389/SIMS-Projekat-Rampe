using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class NaplatnaStanica
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Naziv { get; set; }
        public Korisnik? SefStanice { get; set; }
        public List<Korisnik> Radnici { get; set; }

        public void DodeliRadnika(Korisnik radnik)
        {
            Radnici.Add(radnik);
        }
    }
}
