using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SIMS_Projekat_Rampe.Models
{
    public class Korisnik 
    {
        public TipKorisnika Tip { get; set; }
        [BsonId]
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol PolKorisnika { get; set; }
    }
    public enum Pol
    {
        Muski,
        Zenski
    }
    public enum TipKorisnika
    {
        Admin,
        SefStanice,
        Radnik,
        Menadzer,
        ProdavacENP
    }
}
