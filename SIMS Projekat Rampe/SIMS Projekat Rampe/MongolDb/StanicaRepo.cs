using System.Collections.Generic;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class StanicaRepo
    {
        public string imeKolekcije = "stanice";
        public List<NaplatnaStanica> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<NaplatnaStanica> GetByRadnik(string username)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.RadniciUsernames.Contains(username));
            return results.ToList();
        }

        public List<NaplatnaStanica> GetById(string id)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }

    }
}
