using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

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
            Debug.WriteLine("ga3");
        }
        public override void Entry()
        {
            Debug.WriteLine("dodae4");
        }
        public override void Do()
        {
            Debug.WriteLine("a obicna c#5");
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("propaganda regenjan6");
        }

    }
}
