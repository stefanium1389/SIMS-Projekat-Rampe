using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Models
{
    class KorisnikRepo
    {
        const string connectionString = "mongodb://localhost:27017";
        const string databaseName = "rampa_projekat_db";
        public IMongoCollection<T> ConnectToMongol<T>(string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }

        public List<Korisnik> GetAll()
        {
            var collection = ConnectToMongol<Korisnik>("users");
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<Korisnik> GetByUsername(string username)
        {
            var collection = ConnectToMongol<Korisnik>("users");
            var results = collection.Find(xd => xd.UserName == username);
            return results.ToList();
        }
    }
}
