using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

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
            Debug.WriteLine("dodae");
        }
        public override void Do()
        {
            Debug.WriteLine("a obicna c#");
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("propaganda regenjan");
        }

    }
}
