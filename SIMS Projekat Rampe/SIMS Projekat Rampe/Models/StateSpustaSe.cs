using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StateSpustaSe : State
    {
        public override void OznacenKaoPopravljen()
        {
            Debug.WriteLine("jauu1");
        }
        public override void UsnesnaNaplataENP()
        {
            Debug.WriteLine("jauu2");
        }
        public override void KolaOdu()
        {
            Debug.WriteLine("jauu3");
        }
        public override void Entry()
        {
            DobaviKontekst().SpustiRampu();
        }
        public override void Do()
        {
            bool ispravan = DobaviKontekst() .SaljiSignal();
            if (ispravan)
            {
                StateSpusteno s = new StateSpusteno(Kontroler );
                DobaviKontekst() .PromeniStanje(s);
                s.Entry();
                s.Do();

            }
            else
            {
                StatePokvareno p = new StatePokvareno(Kontroler );
                DobaviKontekst() .PromeniStanje(p);
                p.Entry();
            }
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("jauu6");
        }

        public StateSpustaSe(NaplatnoMestoController nmk) : base(nmk)
        {
        }

    }
}
