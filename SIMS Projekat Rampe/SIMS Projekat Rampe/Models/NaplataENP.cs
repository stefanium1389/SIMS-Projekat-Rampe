using MongoDB.Bson;
using System;

namespace SIMS_Projekat_Rampe.Models
{
    public class NaplataENP : Naplata
    {
        public ElektronskaNaplataPutarine Tag { get; set; }

        public NaplataENP(DateTime vreme, ObjectId stavka, ElektronskaNaplataPutarine tag) : base(vreme, stavka)
        {
            Tag = tag;
        }
    }
}
