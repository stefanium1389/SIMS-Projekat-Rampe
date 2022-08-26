using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{
    
    public class Semafor : Uredjaj, IPublisher
    {
        public bool DozvoljenProlazak { get; set; }

        public List<IObserver> Observers { get; set; }

        public Semafor (TipUredjaja tip) :base( tip)
        {
            Observers = new List<IObserver>();
            DozvoljenProlazak = false;
        }

        public void Publish(string s)
        {
            foreach (IObserver o in Observers)
            {
                o.Perform(s);
            }
        }

        public void AddObserver(IObserver o)
        {
            Observers.Add(o);
        }
    }
    
}
