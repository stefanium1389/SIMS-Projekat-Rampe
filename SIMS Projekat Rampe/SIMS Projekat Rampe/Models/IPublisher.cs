using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{
    interface IPublisher
    {
        void Publish(string s);
        void AddObserver(IObserver o);
    }
}
