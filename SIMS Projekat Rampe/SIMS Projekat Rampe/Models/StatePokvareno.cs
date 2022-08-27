using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePokvareno : State
    {
        public override void OznacenKaoPopravljen()
        {
            StateSpusteno s = new StateSpusteno(Kontroler);
            DobaviKontekst().PromeniStanje(s);
        }
        public override void UsnesnaNaplataENP()
        {
            Debug.WriteLine("bro");
        }
        public override void KolaOdu()
        {
            Debug.WriteLine("ipsum");
        }
        public override void Entry()
        {
            DobaviKontekst().PromeniProlazSemafor(Kontroler, false);
        }
        public override void Do()
        {
            Debug.WriteLine("pozz za");
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("bracalu sa balkana");
        }
        public StatePokvareno(NaplatnoMestoController nmk) : base(nmk)
        {
        }

    }
}
