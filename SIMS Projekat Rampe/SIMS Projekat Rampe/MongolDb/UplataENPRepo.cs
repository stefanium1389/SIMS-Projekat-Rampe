using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class UplataENPRepo
    {
        public string imeKolekcije = "enp_uplate";
        public List<UplataENP> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<UplataENP>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<UplataENP> GetById(string id)
        {
            var collection = MongolDB.ConnectToMongol<UplataENP>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }

        public void Create(UplataENP kaznaZaPrekoracenjeBrzine)
        {
            var collection = MongolDB.ConnectToMongol<UplataENP>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == kaznaZaPrekoracenjeBrzine.Id);
            if (results.ToList().Count > 0)
            {
                return; 
            }
            collection.InsertOne(kaznaZaPrekoracenjeBrzine);
            
        }
    }
}
