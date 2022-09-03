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
        public List<Cenovnik> GetAllActive()
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var results = collection.Find(xd => xd.Obrisan == false);
            return results.ToList();
        }
        public List<Cenovnik> GetById(ObjectId id)
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id);
            return results.ToList();
        }
        public List<Cenovnik> GetByIdActive(ObjectId id)
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var results = collection.Find(xd => xd.Id == id && xd.Obrisan == false);
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

        public void Update(Cenovnik cenovnik)
        {
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            var filter = Builders<Cenovnik>.Filter.Eq("Id", cenovnik.Id);
            var results = collection.ReplaceOne(filter, cenovnik);
            return;
        }

        public void Sort() 
        {
            //ja ne znam pametniji nacin za ovo
            var cenovnici = GetAll();
            cenovnici.Sort((x, y) => x.VaziOd.CompareTo(y.VaziOd));
            var db = MongolDB.DobaviDB();
            db.DropCollection(imeKolekcije);
            var collection = MongolDB.ConnectToMongol<Cenovnik>(imeKolekcije);
            collection.InsertMany(cenovnici);

        }
        public void Delete(Cenovnik c)
        {
            //sigurno postoji bolji način za ovo
            Cenovnik cenovnik = GetById(c.Id)[0];
            cenovnik.Obrisan = true;
            foreach (StavkaCenovnika sc in cenovnik.Stavke) 
            {
                sc.Obrisana = true;
            }
            Update(cenovnik);
        }
    }
}
