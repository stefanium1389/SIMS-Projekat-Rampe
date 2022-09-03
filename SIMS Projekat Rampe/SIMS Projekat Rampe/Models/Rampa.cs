using MongoDB.Bson.Serialization.Attributes;
using SIMS_Projekat_Rampe.Controlers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SIMS_Projekat_Rampe.Models
{
    public class Rampa : Uredjaj, IPublisher
    {

        public State Stanje { get; set; }
        [BsonIgnore]
        public List<IObserver> Observers { get; set; }
        public void PodigniRampu()
        {
            Thread.Sleep(300);
        }
        public void SpustiRampu()
        {
            Thread.Sleep(300);
        }

        public bool SaljiSignal()
        {
            Random random = new Random();
            int br = random.Next(1, 10);
            if (br == 5)
            {
                return false;
            }
            return true;
        }
        public void KlikNaDugme()
        {
            Stanje.KlikNaDugme();
        }
        public void UsnesnaNaplataENP() { }
        public void KolaOdu() { }
        public void OznacenKaoPopravljen() { }
        public void PromeniStanje(State stanje)
        {
            if (stanje.GetType().Equals(typeof(StatePokvareno)))
            {
                Pokvaren = true;
            }
            else
            {
                Pokvaren = false;
            }
            Stanje = stanje;
            Publish("osvezi");
        }

        public Rampa(TipUredjaja tip) : base(tip)
        {
            Observers = new List<IObserver>();
            PromeniStanje(new StateSpusteno(null));
        }

        public void PromeniProlazSemafor(NaplatnoMestoController nmk, bool dozvoljeno)
        {
            var mesto = nmk.Stanica.NaplatnaMesta[nmk.RedniBrojMesta];
            mesto.Semafor.DozvoljenProlazak = dozvoljeno;
            mesto.Semafor.Publish("osvezi");
        }

        public void Publish(string s)
        {
            if (!(Observers is null))
                foreach (IObserver o in Observers)
                {
                    o.Perform(s);
                }
        }

        public void AddObserver(IObserver o)
        {
            if (Observers is null)
            {
                Observers = new List<IObserver>();
            }
            Observers.Add(o);
        }

    }

}
