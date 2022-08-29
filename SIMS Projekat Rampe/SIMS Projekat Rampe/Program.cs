using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.MongolDb;

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
            //MongolDB.generateTest();

            Application.Run(new LoginView());

        }
    }
}
