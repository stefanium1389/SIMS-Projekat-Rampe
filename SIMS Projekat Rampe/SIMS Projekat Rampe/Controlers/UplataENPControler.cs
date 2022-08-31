using System;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    class UplataENPControler
    {
        public List<UplataENP> DobaviUplate(DateTime pocetno, DateTime krajnje)
        {
            pocetno = pocetno.Date;
            krajnje = krajnje.Date;
            UplataENPRepo repo = new UplataENPRepo();
            List<UplataENP> lista = new List<UplataENP>();
            if (pocetno == krajnje)
            {
                krajnje = krajnje.AddDays(1);
            }
            foreach (var uplata in repo.GetAll())
            {
                if (uplata.Vreme < krajnje && uplata.Vreme >= pocetno)
                {
                    lista.Add(uplata);
                }
            }
            return lista;
        }
    }
}
