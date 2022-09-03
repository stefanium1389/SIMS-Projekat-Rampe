using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SIMS_Projekat_Rampe.Models
{

    public enum TipVozila
    {
        Auto,
        Motor,
        Kamion,
        Autobus,
        Kombi
    }

    public class Prolazak
    {
        [BsonId]
        public string Kod { get; set; }
        public TipVozila? TipVozila { get; set; }
        public DateTime VremeUlaska { get; set; }
        public string? UlaznaStanica { get; set; }
        public string? DeonicaId { get; set; }
        public Naplata? Naplata { get; set; }

        public Prolazak()
        {

        }
        public Prolazak(string kod, TipVozila tip, DateTime vreme, string ulaznaStanica, string deonica)
        {
            Kod = kod;
            TipVozila = tip;
            VremeUlaska = vreme;
            UlaznaStanica = ulaznaStanica;
            DeonicaId = deonica;
        }


    }


}
