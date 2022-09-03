using SIMS_Projekat_Rampe.MongolDb;
using System;
using System.Windows.Forms;

namespace SIMS_Projekat_Rampe
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            KorisnikRepo korisnikRepo = new KorisnikRepo();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ovo obara proslu bazu!!
            MongolDB.generateTest();

            Application.Run(new LoginView());

        }
    }
}
