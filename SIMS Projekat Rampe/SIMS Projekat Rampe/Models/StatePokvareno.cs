using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePokvareno : State
    {
        public override void OznacenKaoPopravljen()
        {
            Debug.WriteLine("xd");
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
            Debug.WriteLine("ajaja");
        }
        public override void Do()
        {
            Debug.WriteLine("pozz za");
        }
        public override void KlikNaDugme()
        {
            Debug.WriteLine("bracalu sa balkana");
        }

    }
}
