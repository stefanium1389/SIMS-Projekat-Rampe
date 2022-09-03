using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        private Dictionary<string, List<DateTime>> pokusaji = new Dictionary<string, List<DateTime>>();
        public Korisnik CheckLogin(string username, string password)
        {
            KorisnikRepo korisnikRepo = new KorisnikRepo();
            var korisnik = korisnikRepo.GetByUsername(username);
            if (korisnik.Count == 1)
            {
                ZabeleziLogin(username);
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
                ZabeleziLogin(username);
                throw new LoginException("Korisničko ime ili lozinka nisu ispravni, pokušajte ponovo");
            }
            else
            {
                throw new LoginException("Greška u prijavi");
            }

        }

        public void ProveriSpam(string user)
        {
            if (pokusaji.ContainsKey(user))
            {

                List<DateTime> vremena = pokusaji[user];
                int brPokusaja = 0;
                for (int i = 0; i < vremena.Count; i++)
                {
                    if (vremena[i] > DateTime.Now.AddMinutes(-15))
                    {
                        brPokusaja += 1;
                    }
                }

                if (brPokusaja > 5)
                {
                    throw new LoginException("Prekoračen broj pokušaja u 15 minuta, molimo sačekajte.");
                }

            }
        }

        public void ZabeleziLogin(string user)
        {
            if (pokusaji.ContainsKey(user))
            {
                List<DateTime> vremena = pokusaji[user];
                vremena.Add(DateTime.Now);
                pokusaji[user] = vremena;
            }
            else
            {
                List<DateTime> lista = new List<DateTime>();
                lista.Add(DateTime.Now);
                pokusaji[user] = lista;
            }
        }
    }
}
