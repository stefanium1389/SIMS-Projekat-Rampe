using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{
    public interface IObserver
    {
        void Perform(string s);
    }
}
