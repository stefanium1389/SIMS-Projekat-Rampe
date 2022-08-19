using System;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.MongolDb
{
    public class MongolDB
    {
        public const string connectionString = "mongodb://localhost:27017";
        public const string databaseName = "rampa_projekat_db";

        public static void generatexD()
        {

            var client = new MongoClient(connectionString);
            client.DropDatabase(databaseName);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Korisnik>("users");

            Korisnik korisnik = new Korisnik { UserName = "user", PassWord = "pass", DatumRodjenja = DateTime.Now, Ime = "djole", Prezime = "xd", PolKorisnika = Pol.Muski, Tip = TipKorisnika.Radnik };
            collection.InsertOne(korisnik);
            korisnik = new Korisnik { UserName = "user2", PassWord = "pass2", DatumRodjenja = DateTime.Now, Ime = "djole2", Prezime = "xd2", PolKorisnika = Pol.Muski, Tip = TipKorisnika.Radnik };
            collection.InsertOne(korisnik);
            korisnik = new Korisnik { UserName = "user3", PassWord = "pass3", DatumRodjenja = DateTime.Now, Ime = "djole3", Prezime = "xd3", PolKorisnika = Pol.Muski, Tip = TipKorisnika.Admin };
            collection.InsertOne(korisnik);
            
        }

        public static IMongoCollection<T> ConnectToMongol<T>(string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }

    }
}
