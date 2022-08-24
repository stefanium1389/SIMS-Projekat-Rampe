using System;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    public class LoginException : Exception
    {
        public LoginException()
        {
        }
        public LoginException(string message)
            : base(message)
        {
        }
        public LoginException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    class LoginController
    {
        public Korisnik CheckLogin(string username, string password)
        {
            KorisnikRepo korisnikRepo = new KorisnikRepo();
            var korisnik = korisnikRepo.GetByUsername(username);
            if (korisnik.Count == 1)
            {
                if (korisnik[0].PassWord == password)
                {
                    return korisnik[0];
                }
                else 
                {
                    throw new LoginException("Korisničko ime ili lozinka nisu ispravni, pokušajte ponovo");
                }
               
            }
            else if (korisnik.Count == 0) 
            {
                throw new LoginException("Korisničko ime ili lozinka nisu ispravni, pokušajte ponovo");
            }
            else
            {
                throw new LoginException("Greška u prijavi");
            }
            
        }
    }
}
