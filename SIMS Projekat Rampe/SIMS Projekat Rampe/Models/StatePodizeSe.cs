using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePodizeSe : State
    {
        public override void OznacenKaoPopravljen()
        {
            throw new NotImplementedException("jauu");
        }
        public override void UsnesnaNaplataENP()
        {
            throw new NotImplementedException("jauu");
        }
        public override void KolaOdu()
        {
            throw new NotImplementedException("jauu");
        }
        public override void Entry()
        {
            DobaviKontekst().PodigniRampu();
        }
        public override void Do()
        {
            bool ispravan = DobaviKontekst().SaljiSignal();
            if (ispravan)
            {
                StatePodignuto s = new StatePodignuto(Kontroler);
                DobaviKontekst().PromeniStanje(s);
                s.Entry();
                s.Do();

            }
            else
            {
                StatePokvareno p = new StatePokvareno(Kontroler);
                DobaviKontekst().PromeniStanje(p);
                p.Entry();
            }
        }
        public override void KlikNaDugme()
        {
            throw new NotImplementedException("jauu");
        }

        public StatePodizeSe(NaplatnoMestoController nmk) : base(nmk)
        {
        }
    }
}
