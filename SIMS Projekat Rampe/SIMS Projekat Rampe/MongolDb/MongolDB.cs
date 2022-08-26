using System;
using System.Collections.Generic;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;
using System.Diagnostics;


namespace SIMS_Projekat_Rampe.MongolDb
{
    public class MongolDB
    {
        public const string connectionString = "mongodb://localhost:27017";
        public const string databaseName = "rampa_projekat_db";

        public static void generateTest()
        {
            var client = new MongoClient(connectionString);
            client.DropDatabase(databaseName);
            GenerisiStanice();
            
        }

        public static IMongoCollection<T> ConnectToMongol<T>(string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }


        public static void GenerisiStanice() 
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var coll_korisnici = db.GetCollection<Korisnik>("korisnici");
            var coll_stanice = db.GetCollection<NaplatnaStanica>("stanice");
            var coll_deonice = db.GetCollection<Deonica>("deonice");
            var coll_cenovnici = db.GetCollection<Cenovnik>("cenovnici");
            int sef_count = 1;
            int radnik_count = 1;
            int prodavac_count = 1;
            int mesto_count = 0;
            int stanica_count = 1;
            int deonica_count = 1;
            int men_count = 1;

            List<NaplatnaStanica> stanice = new List<NaplatnaStanica>();
            for (int i=0; i<4; i++) 
            {
                //kreiranje sefa
                Korisnik sef = new Korisnik { UserName = "sef"+sef_count, PassWord = "pass", DatumRodjenja = DateTime.Now, Ime = "sefthe"+sef_count+"th", Prezime = "sefkovic", PolKorisnika = Pol.Muski, Tip = TipKorisnika.SefStanice };
                coll_korisnici.InsertOne(sef);
                sef_count += 1;

                //kreiranje menadzera
                Korisnik menadzer = new Korisnik { UserName = "menadzer" + men_count, PassWord = "pass", DatumRodjenja = DateTime.Now, Ime = "menadzerko" + men_count + "-ti", Prezime = "menadzeric", PolKorisnika = Pol.Muski, Tip = TipKorisnika.Menadzer };
                coll_korisnici.InsertOne(menadzer);
                men_count += 1;

                //kreiranje radnika
                List<string> user_radnici = new List<string>();
                for (int j=0; j<3; j++) 
                {
                    Korisnik radnik = new Korisnik { UserName = "radnik" + radnik_count, PassWord = "pass", DatumRodjenja = DateTime.Now, Ime = "radnikthe" + radnik_count + "th", Prezime = "radnikovic", PolKorisnika = Pol.Muski, Tip = TipKorisnika.Radnik };
                    coll_korisnici.InsertOne(radnik);
                    user_radnici.Add(radnik.UserName);
                    radnik_count += 1;
                }

                //kreiranje prodavca
                Korisnik prodavac = new Korisnik { UserName = "prodavac" + prodavac_count, PassWord = "pass", DatumRodjenja = DateTime.Now, Ime = "prodavacthe" + prodavac_count + "th", Prezime = "xdbro", PolKorisnika = Pol.Muski, Tip = TipKorisnika.ProdavacENP };
                coll_korisnici.InsertOne(prodavac);
                prodavac_count += 1;
                List<string> user_prodavci = new List<string>();
                user_prodavci.Add(prodavac.UserName);

                //kreiranje naplatnih mesta
                List<NaplatnoMesto> naplatna_mesta = new List<NaplatnoMesto>();
                for (int j=0; j<3; j++) 
                {
                    NaplatnoMesto nm = new NaplatnoMesto(mesto_count,false, true);
                    naplatna_mesta.Add(nm);
                    mesto_count += 1;
                }
                if (i % 2 == 0)
                {
                    NaplatnoMesto nm = new NaplatnoMesto(mesto_count, true, true);
                    naplatna_mesta.Add(nm);
                    mesto_count += 1;
                }

                mesto_count = 1;

                NaplatnaStanica stanica = new NaplatnaStanica("st"+stanica_count,"grad"+i, sef.UserName, user_radnici, user_prodavci, naplatna_mesta);
                coll_stanice.InsertOne(stanica);
                stanica_count += 1;
                stanice.Add(stanica);
            }

            //generisanje deonica
            Random rd = new Random();
            List <Deonica> deonice = new List<Deonica>();
            for (int i=0; i<stanice.Count-1; i++) 
            {
                for (int j=i+1; j<stanice.Count; j++) 
                {
                    
                    float duzina = rd.Next(20, 200);
                    Deonica d = new Deonica("d"+deonica_count,duzina,stanice[i].Id, stanice[j].Id);
                    deonice.Add(d);
                    coll_deonice.InsertOne(d);
                    deonica_count += 1;
                }
            }

            //generisanje cenovnika
            List<DateTime> vremena = new List<DateTime>();
            vremena.Add(DateTime.Now.AddDays(-60));
            vremena.Add(DateTime.Now);
            vremena.Add(DateTime.Now.AddDays(60));
            int brTipova = Enum.GetNames(typeof(TipVozila)).Length;
            
            for (int i=0; i<3; i++) 
            {
                List<StavkaCenovnika> stavke = new List<StavkaCenovnika>();
                for (int j=0; j<deonice.Count; j++) 
                {
                    for (int k=0; k<brTipova; k++) 
                    {
                        StavkaCenovnika sc = new StavkaCenovnika(deonice[j].Id, (TipVozila)k, rd.Next(500, 1000));
                        stavke.Add(sc);
                    }
                }
                Cenovnik c = new Cenovnik(vremena[i], stavke);
                coll_cenovnici.InsertOne(c);
            }
            

        }
    }
}
