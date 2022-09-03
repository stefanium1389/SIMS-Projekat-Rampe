using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StateSpusteno : State
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
            DobaviKontekst().PromeniProlazSemafor(Kontroler, false);
        }
        public override void Do()
        {

            bool ispravan = DobaviKontekst().SaljiSignal();
            if (!ispravan)
            {
                StatePokvareno p = new StatePokvareno(Kontroler);
                DobaviKontekst().PromeniStanje(p);
                p.Entry();
            }
        }
        public override void KlikNaDugme()
        {
            StatePodizeSe s = new StatePodizeSe(Kontroler);
            DobaviKontekst().PromeniStanje(new StatePodizeSe(Kontroler));
            s.Entry();
            s.Do();
        }

        public StateSpusteno(NaplatnoMestoController nmk) : base(nmk)
        {
        }
    }
}
