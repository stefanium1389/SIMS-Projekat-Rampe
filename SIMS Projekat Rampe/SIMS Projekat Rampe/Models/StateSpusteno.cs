using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

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
            Debug.WriteLine("xd4");
        }
        public override void Do()
        {
            Debug.WriteLine("xd5");
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("xd6");
        }

    }
}
