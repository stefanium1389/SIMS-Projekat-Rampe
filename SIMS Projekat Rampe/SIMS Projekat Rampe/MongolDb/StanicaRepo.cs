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
        public List<NaplatnaStanica> GetAllActive()
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.Obrisana == false);
            return results.ToList();
        }
        public List<NaplatnaStanica> GetByRadnik(string username)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.RadniciUsernames.Contains(username));
            return results.ToList();
        }
        public List<NaplatnaStanica> GetByRadnikActive(string username)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.RadniciUsernames.Contains(username) && xd.Obrisana == false);
            return results.ToList();
        }

        public List<NaplatnaStanica> GetBySef(string username)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.SefStaniceUsername == username);
            return results.ToList();
        }

        public List<NaplatnaStanica> GetBySefActive(string username)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.SefStaniceUsername == username && xd.Obrisana == false);
            return results.ToList();
        }

        public List<NaplatnaStanica> GetById(string id)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }

        public List<NaplatnaStanica> GetByIdActive(string id)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id && xd.Obrisana == false);
            return results.ToList();
        }

        public void Update(NaplatnaStanica ns) 
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var filter = Builders<NaplatnaStanica>.Filter.Eq("Id", ns.Id);
            collection.ReplaceOne(filter, ns);
        }

        public void Create(NaplatnaStanica ns)
        {
            var collection = MongolDB.ConnectToMongol<NaplatnaStanica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == ns.Id);
            if (results.ToList().Count > 0)
            {
                return;
            }
            collection.InsertOne(ns);
            return;
        }
        public void Delete(NaplatnaStanica ns)
        {
            //sigurno postoji bolji način za ovo
            NaplatnaStanica stanica = GetById(ns.Id)[0];
            stanica.Obrisana = true;
            Update(stanica);
        }
    }
}
