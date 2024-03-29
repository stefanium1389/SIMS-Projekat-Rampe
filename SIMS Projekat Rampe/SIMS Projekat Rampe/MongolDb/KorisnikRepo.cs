﻿using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;
using System.Collections.Generic;

namespace SIMS_Projekat_Rampe.MongolDb
{
    class KorisnikRepo
    {
        public string imeKolekcije = "korisnici";
        public List<Korisnik> GetAll()
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>(imeKolekcije);
            var results = collection.Find(_ => true);
            return results.ToList();
        }
        public List<Korisnik> GetByUsername(string username)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>(imeKolekcije);
            var results = collection.Find(xd => xd.UserName == username);
            return results.ToList();
        }
        public List<Korisnik> GetByTip(TipKorisnika tip)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>(imeKolekcije);
            var results = collection.Find(xd => xd.Tip == tip);
            return results.ToList();
        }
        public void Delete(Korisnik user)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>(imeKolekcije);
            var results = collection.FindOneAndDelete(xd => xd.UserName == user.UserName);
            return;
        }
        public void Update(Korisnik user)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>(imeKolekcije);
            var filter = Builders<Korisnik>.Filter.Eq("UserName", user.UserName);
            var results = collection.ReplaceOne(filter, user);
            return;
        }

        public void Create(Korisnik user)
        {
            var collection = MongolDB.ConnectToMongol<Korisnik>(imeKolekcije);
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
