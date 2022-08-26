using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePodignuto : State
    {
        public override void OznacenKaoPopravljen()
        {
            Debug.WriteLine("adohudodab1");
        }
        public override void UsnesnaNaplataENP()
        {
            Debug.WriteLine("mjehao2");
        }
        public override void KolaOdu()
        {
            Thread.Sleep(2000);
            System.Diagnostics.Debug.WriteLine("adsadsad");
            StateSpustaSe s = new StateSpustaSe(Kontroler);
            DobaviKontekst() .PromeniStanje(s);
            s.Entry();
            s.Do();
        }
        public override void Entry()
        {
            DobaviKontekst().PromeniProlazSemafor(Kontroler,true);
        }
        public override void Do()
        {
            bool ispravan = DobaviKontekst().SaljiSignal();
            if (!ispravan)
            {
                StatePokvareno p = new StatePokvareno(Kontroler);
                DobaviKontekst() .PromeniStanje(p);
                p.Entry();
            }
            else 
            {
                KolaOdu();
            }
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("propaganda regenjan6");
        }

        public StatePodignuto(NaplatnoMestoController nmk) : base(nmk)
        {
        }
    }
}
