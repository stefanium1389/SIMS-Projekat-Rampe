using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers

{
    public class KorisnikController
    {
        
        public static bool CheckLogin(string username, string password)
        {
            KorisnikRepo korisnikRepo = new KorisnikRepo();
            var korisnik = korisnikRepo.GetByUsername(username);
            if(korisnik.Count == 1)
            {
                if(korisnik[0].PassWord == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
