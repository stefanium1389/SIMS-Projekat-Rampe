using System.Collections.Generic;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class ProlazakRepo
    {
        public string imeKolekcije = "prolasci";
        public List<Prolazak> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<Prolazak>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<Prolazak> GetByKod(string kod)
        {
            var collection = MongolDB.ConnectToMongol<Prolazak>(imeKolekcije);
            var results = collection.Find(xd => xd.Kod == kod);
            return results.ToList();
        }

        public void Create(Prolazak prolazak)
        {
            var collection = MongolDB.ConnectToMongol<Prolazak>(imeKolekcije);
            var results = collection.Find(xd => xd.Kod == prolazak.Kod);
            if (results.ToList().Count > 0)
            {
                return; 
            }
            collection.InsertOne(prolazak);
            return;
        }
    }
}
