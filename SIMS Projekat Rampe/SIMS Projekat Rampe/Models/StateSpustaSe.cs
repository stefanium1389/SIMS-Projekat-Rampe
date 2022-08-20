using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

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
            Debug.WriteLine("jauu4");
        }
        public override void Do()
        {
            Debug.WriteLine("jauu5");
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("jauu6");
        }

    }
}
