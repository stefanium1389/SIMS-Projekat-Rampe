using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StateSpusteno : State
    {
        public override void OznacenKaoPopravljen()
        {
            Debug.WriteLine("xd1");
        }
        public override void UsnesnaNaplataENP()
        {
            Debug.WriteLine("xd2");
        }
        public override void KolaOdu()
        {
            Debug.WriteLine("xd3");
        }
        public override void Entry()
        {
            DobaviKontekst().PromeniProlazSemafor(Kontroler, false);
        }
        public override void Do()
        {

            bool ispravan = DobaviKontekst() .SaljiSignal();
            if (!ispravan)
            {
                StatePokvareno p = new StatePokvareno(Kontroler );
                DobaviKontekst().PromeniStanje(p);
                p.Entry();
            }
        }
        public override void KlikNaDugme()
        {
            StatePodizeSe s = new StatePodizeSe(Kontroler);
            DobaviKontekst().PromeniStanje(new StatePodizeSe(Kontroler));
            s.Entry();
            s.Do();
        }

        public StateSpusteno(NaplatnoMestoController nmk) : base(nmk)
        {
        }
    }
}
