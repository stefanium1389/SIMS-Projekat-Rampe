using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class CenovnikRepo
    {
        public string imeKolekcije = "cenovnici";
        public List<Cenovnik> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<Cenovnik> GetById(ObjectId id)
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }
        public void Create(Cenovnik Cenovnik)
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == Cenovnik.Id);
            if (results.ToList().Count > 0)
            {
                return; 
            }
            collection.InsertOne(Cenovnik);
            
        }
    }
}
