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
        public string Id { get; set; }
        public string Naziv { get; set; }
        public string? SefStaniceUsername { get; set; }
        public List<string> RadniciUsernames { get; set; }
        public List<string> ProdavciENPUsernames { get; set; }
        public List<NaplatnoMesto> NaplatnaMesta { get; set; }

        public NaplatnaStanica( string id, string naziv, string? sef, List<string> radnici, List<string> prodavciENP, List<NaplatnoMesto> naplatnaMesta) 
        {
            Id = id;
            Naziv = naziv;
            SefStaniceUsername = sef;
            RadniciUsernames = radnici;
            ProdavciENPUsernames = prodavciENP;
            NaplatnaMesta = naplatnaMesta;
        }

        public override string ToString() 
        {
            return Naziv;
        }

        public void DodeliRadnika(Korisnik radnik)
        {
            if (radnik.Tip == TipKorisnika.Radnik)
            {
                RadniciUsernames.Add(radnik.UserName);
            }
            else throw new WrongWorkerTypeException("Uneti korisnik nije radnik!");
        }

        public void DodeliProdavcaENP(Korisnik prodavac)
        {
            if (prodavac.Tip == TipKorisnika.ProdavacENP)
            {
                ProdavciENPUsernames.Add(prodavac.UserName);
            }
            else throw new WrongWorkerTypeException("Uneti korisnik nije prodavacENP!");
        }

        public void DodeliSefaStanice(Korisnik sef)
        {
            if (sef.Tip == TipKorisnika.SefStanice)
            {
                if (SefStaniceUsername is null)
                {
                    this.SefStaniceUsername = sef.UserName;
                }
                else throw new UserAlreadyPresentException("Sef stanice već postoji! Za promenu sefa, prvo uklonite starog.");
            }
            else throw new WrongWorkerTypeException("Uneti korisnik nije sef!");
        }
    }
}
