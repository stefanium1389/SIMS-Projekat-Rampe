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
            List<int> xd = new List<int>(){ 10,25,30,20,50 };
            int index = xd.FindIndex(a => a==20);
            xd.Insert(index, 100);
            foreach(int f in xd) 
            
            {
                System.Diagnostics.Debug.WriteLine(f);
            }

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
