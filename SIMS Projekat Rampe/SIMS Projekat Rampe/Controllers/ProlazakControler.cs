using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;
using System;
using System.Collections.Generic;


namespace SIMS_Projekat_Rampe.Controlers
{
    class ProlazakControler
    {
        public List<Prolazak> DobaviProlaske(DateTime pocetno, DateTime krajnje, string stanica)
        {
            pocetno = pocetno.Date;
            krajnje = krajnje.Date;
            ProlazakRepo repo = new ProlazakRepo();
            DeonicaRepo dr = new DeonicaRepo();
            StanicaRepo sr = new StanicaRepo();
            List<Prolazak> lista = new List<Prolazak>();
            if (pocetno == krajnje)
            {
                krajnje = krajnje.AddDays(1);
            }
            foreach (var prolazak in repo.GetAll())
            {
                if (prolazak.Naplata.VremeNaplate < krajnje && prolazak.Naplata.VremeNaplate >= pocetno)
                {
                    lista.Add(prolazak);
                }
            }
            if (stanica != "Sve stanice")
            {
                List<Prolazak> listb = new List<Prolazak>();
                foreach (var prolazak in lista)
                {
                    if (stanica == sr.GetById(dr.GetById(prolazak.DeonicaId)[0].IzlazakId)[0].Naziv)
                    {
                        listb.Add(prolazak);
                    }
                }
                return listb;
            }
            return lista;
        }

        internal List<string> DobaviPodatkeOProlasku(Prolazak p)
        {
            DeonicaRepo dr = new DeonicaRepo();
            StanicaRepo sr = new StanicaRepo();
            CenovnikControler cc = new CenovnikControler();
            Cenovnik cenovnik = cc.DobaviCenovnik(p.Naplata.VremeNaplate);
            List<string> lista = new List<string>();
            lista.Add(p.TipVozila.ToString());
            lista.Add(p.VremeUlaska.ToString());
            lista.Add(sr.GetById(p.UlaznaStanica)[0].Naziv);
            lista.Add(p.Naplata.VremeNaplate.ToString());
            lista.Add(sr.GetById(dr.GetById(p.DeonicaId)[0].IzlazakId)[0].Naziv);
            lista.Add(cenovnik.PronadjiStavku(p.DeonicaId, (TipVozila)p.TipVozila).Iznos.ToString());

            return lista;
        }
    }
}
