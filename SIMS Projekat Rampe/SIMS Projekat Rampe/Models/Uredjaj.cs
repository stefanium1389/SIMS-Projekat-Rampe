namespace SIMS_Projekat_Rampe.Models
{
    public enum TipUredjaja
    {
        Rampa,
        Semafor,
        CitacTagova,
        CitacTablice,
        Displej
    }
    public class Uredjaj
    {
        public bool Pokvaren { get; set; }
        public TipUredjaja TipUredjaja { get; set; }

        public Uredjaj(TipUredjaja tip)
        {
            TipUredjaja = tip;
            Pokvaren = false;
        }

        public Uredjaj()
        {
        }
    }
}
