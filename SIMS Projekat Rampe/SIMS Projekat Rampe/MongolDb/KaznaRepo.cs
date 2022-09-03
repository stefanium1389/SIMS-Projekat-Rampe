using MongoDB.Bson;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;
using System.Collections.Generic;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class KaznaRepo
    {
        public string imeKolekcije = "kazne";
        public List<KaznaZaPrekoracenjeBrzine> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<KaznaZaPrekoracenjeBrzine>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<KaznaZaPrekoracenjeBrzine> GetById(ObjectId id)
        {
            var collection = MongolDB.ConnectToMongol<KaznaZaPrekoracenjeBrzine>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }

        public void Create(KaznaZaPrekoracenjeBrzine kaznaZaPrekoracenjeBrzine)
        {
            var collection = MongolDB.ConnectToMongol<KaznaZaPrekoracenjeBrzine>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == kaznaZaPrekoracenjeBrzine.Id);
            if (results.ToList().Count > 0)
            {
                return;
            }
            collection.InsertOne(kaznaZaPrekoracenjeBrzine);

        }
    }
}
