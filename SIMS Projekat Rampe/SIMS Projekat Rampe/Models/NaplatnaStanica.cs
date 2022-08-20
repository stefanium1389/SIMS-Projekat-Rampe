using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SIMS_Projekat_Rampe.Models
{
    public class WrongWorkerTypeException : Exception
    {
        public WrongWorkerTypeException()
        {
        }

        public WrongWorkerTypeException(string message)
            : base(message)
        {
        }

        public WrongWorkerTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class UserAlreadyPresentException : Exception
    {
        public UserAlreadyPresentException()
        {
        }

        public UserAlreadyPresentException(string message)
            : base(message)
        {
        }

        public UserAlreadyPresentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NaplatnaStanica
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Naziv { get; set; }
        public Korisnik? SefStanice { get; set; }
        public List<Korisnik> Radnici { get; set; }
        public List<Korisnik> ProdavciENP { get; set; }
        public List<NaplatnoMesto> NaplatnaMesta { get; set; }

        public void DodeliRadnika(Korisnik radnik)
        {
            if (radnik.Tip == TipKorisnika.Radnik)
            {
                Radnici.Add(radnik);
            }
            else throw new WrongWorkerTypeException("Uneti korisnik nije radnik!");
        }

        public void DodeliProdavcaENP(Korisnik prodavac)
        {
            if (prodavac.Tip == TipKorisnika.ProdavacENP)
            {
                ProdavciENP.Add(prodavac);
            }
            else throw new WrongWorkerTypeException("Uneti korisnik nije prodavacENP!");
        }

        public void DodeliSefaStanice(Korisnik sef)
        {
            if (sef.Tip == TipKorisnika.SefStanice)
            {
                if (SefStanice is null)
                {
                    this.SefStanice = sef;
                }
                else throw new UserAlreadyPresentException("Sef stanice već postoji! Za promenu sefa, prvo uklonite starog.");
            }
            else throw new WrongWorkerTypeException("Uneti korisnik nije sef!");
        }
    }
}
