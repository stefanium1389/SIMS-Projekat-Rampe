using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;
using System;

namespace SIMS_Projekat_Rampe.Controlers
{
    public class CenovnikException : Exception
    {
        public CenovnikException()
        {
        }
        public CenovnikException(string message)
            : base(message)
        {
        }
        public CenovnikException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class CenovnikControler
    {
        public Cenovnik DobaviCenovnik(DateTime datum)
        {
            var repo = new CenovnikRepo();
            var cenovnici = repo.GetAll();
            foreach (var cenovnik in cenovnici)
            {
                if (datum >= cenovnik.VaziOd)
                {
                    return cenovnik;
                }
                else throw new CenovnikException("Nema cenovnika za dati datum!");
            }
            throw new CenovnikException("Nema cenovnika uopste!");

        }
    }
}

