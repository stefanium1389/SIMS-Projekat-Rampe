using System.Collections.Generic;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class KorisnikRepo
    {
        public List<Korisnik> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>("users");
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<Korisnik> GetByUsername(string username)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>("users");
            var results = collection.Find(xd => xd.UserName == username);
            return results.ToList();
        }
        public void Delete(Korisnik user)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>("users");
            var results = collection.FindOneAndDelete(xd => xd.UserName == user.UserName);
            return;
        }
        public void Update(Korisnik user)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>("users");
            var filter = Builders<Korisnik>.Filter.Eq("UserName", user.UserName);
            var results = collection.ReplaceOne(filter, user);
            return;
        }

        public void Create(Korisnik user)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>("users");
            var results = collection.Find(xd => xd.UserName == user.UserName);
            if (results.ToList().Count > 0)
            {
                return; 
            }
            collection.InsertOne(user);
            return;
        }
    }
}
