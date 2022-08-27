using System;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Controlers
{
    class DeonicaController
    {
        public List<string> MestaDeonice(string deonicaId)
        {
            var deonicaRrepo = new DeonicaRepo();
            var deonica = deonicaRrepo.GetById(deonicaId);
            var stanicaRepo = new StanicaRepo();
            var ulaz = stanicaRepo.GetById(deonica[0].UlazakId);
            var izlaz = stanicaRepo.GetById(deonica[0].IzlazakId);
            var lista = new List<string>();
            lista.Add(ulaz[0].Naziv);
            lista.Add(izlaz[0].Naziv);
            return lista;

        }
        public float DuzinaDeonice(string deonicaId)
        {
            var deonicaRepo = new DeonicaRepo();
            return deonicaRepo.GetById(deonicaId)[0].Duzina;
        }
    }
}
