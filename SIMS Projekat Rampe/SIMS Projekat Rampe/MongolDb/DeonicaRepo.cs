using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;
using System.Collections.Generic;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class DeonicaRepo
    {
        public string imeKolekcije = "deonice";
        public List<Deonica> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<Deonica> GetAllActive()
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => xd.Obrisana == false);
            return results.ToList();
        }
        public List<Deonica> GetById(string id)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }
        public List<Deonica> GetByIdActive(string id)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id && xd.Obrisana == false);
            return results.ToList();
        }
        public List<Deonica> GetByStanica(string stanica)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => xd.UlazakId == stanica || xd.IzlazakId == stanica);
            return results.ToList();
        }
        public List<Deonica> GetByStanicaActive(string stanica)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => (xd.UlazakId == stanica || xd.IzlazakId == stanica) && xd.Obrisana == false);
            return results.ToList();
        }
        public List<Deonica> GetByStanice(string stanica1, string stanica2)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => xd.UlazakId == stanica1 && xd.IzlazakId == stanica2 || xd.UlazakId == stanica2 && xd.IzlazakId == stanica1);
            return results.ToList();
        }
        public List<Deonica> GetByStaniceActive(string stanica1, string stanica2)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => (((xd.UlazakId == stanica1 && xd.IzlazakId == stanica2) || (xd.UlazakId == stanica2 && xd.IzlazakId == stanica1)) && xd.Obrisana == false));
            return results.ToList();
        }

        public void Create(Deonica Deonica)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == Deonica.Id);
            if (results.ToList().Count > 0)
            {
                return;
            }
            collection.InsertOne(Deonica);
            return;
        }

        public void Update(Deonica deonica)
        {
            var collection = MongolDB.ConnectToMongol<Deonica>(imeKolekcije);
            var filter = Builders<Deonica>.Filter.Eq("Id", deonica.Id);
            var results = collection.ReplaceOne(filter, deonica);
            return;
        }

        public void Delete(Deonica d)
        {
            //sigurno postoji bolji način za ovo
            Deonica deonica = GetById(d.Id)[0];
            deonica.Obrisana = true;
            Update(deonica);
        }
    }
}
