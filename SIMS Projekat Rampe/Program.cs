using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using SIMS_Projekat_Rampe.Models;

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

            MongolDb.MongolDB.generatexD();
            foreach(var k in korisnikRepo.GetAll())
            {
                Debug.WriteLine($"{k.Ime}, {k.Prezime}");
            }
            foreach (var k in korisnikRepo.GetByUsername("biban"))
            {
                Debug.WriteLine($"{k.Ime}, {k.Prezime}");
            }

            Application.Run(new Form1());

        }
    }
}
