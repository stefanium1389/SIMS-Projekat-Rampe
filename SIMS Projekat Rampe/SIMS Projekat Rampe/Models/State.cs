using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{
    public abstract class State
    {
        public abstract void OznacenKaoPopravljen();
        public abstract void UsnesnaNaplataENP();
        public abstract void KolaOdu();
        public abstract void Entry();
        public abstract void Do();
        public abstract void KlikNaDugme(); 

    }
}
