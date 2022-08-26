using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using SIMS_Projekat_Rampe.Controlers;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public abstract class State
    {
        [BsonIgnore]
        public NaplatnoMestoController Kontroler { get; set; }
        public abstract void OznacenKaoPopravljen();
        public abstract void UsnesnaNaplataENP();
        public abstract void KolaOdu();
        public abstract void Entry();
        public abstract void Do();
        public abstract void KlikNaDugme();

        public State (NaplatnoMestoController nmk) 
        {
            Kontroler = nmk;
        }

        public Rampa DobaviKontekst() 
        {
            return Kontroler.VratiRampu();
        }

    }


}
