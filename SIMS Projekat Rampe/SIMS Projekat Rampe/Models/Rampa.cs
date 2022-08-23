using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{

    public class Rampa : Uredjaj
    {
        public State Stanje { get; set; }
        public void PodigniRampu() { }
        public void SpustiRampu() { }
        public void SaljiSignal() { }
        public void KlikNaDugme() { }
        public void UsnesnaNaplataENP() { }
        public void KolaOdu() { }
        public void OznacenKaoPopravljen() { }
        public void PromeniStanje(State stanje)
        {
            Stanje = stanje;
        }

        public Rampa (TipUredjaja tip) : base(tip) 
        {
            PromeniStanje(new StateSpusteno());
        }


    }
    
}
