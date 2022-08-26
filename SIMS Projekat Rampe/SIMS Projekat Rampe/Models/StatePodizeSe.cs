using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePodizeSe : State
    {
        public override void OznacenKaoPopravljen()
        {
            Debug.WriteLine("adohudodab");
        }
        public override void UsnesnaNaplataENP()
        {
            Debug.WriteLine("mjehao");
        }
        public override void KolaOdu()
        {
            Debug.WriteLine("ga");
        }
        public override void Entry()
        {
            DobaviKontekst().PodigniRampu();
        }
        public override void Do()
        {
            bool ispravan = DobaviKontekst() .SaljiSignal();
            if (ispravan)
            {
                StatePodignuto s = new StatePodignuto(Kontroler );
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
            Debug.WriteLine("propaganda regenjan");
        }

        public StatePodizeSe(NaplatnoMestoController nmk) : base(nmk)
        {
        }
    }
}
