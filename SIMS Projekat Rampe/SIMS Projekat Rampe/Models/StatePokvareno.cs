using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePokvareno : State
    {
        public override void OznacenKaoPopravljen()
        {
            StateSpusteno s = new StateSpusteno(Kontroler);
            DobaviKontekst().PromeniStanje(s);
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
            throw new NotImplementedException("jauu");
        }
        public override void KlikNaDugme()
        {
            throw new NotImplementedException("jauu");
        }
        public StatePokvareno(NaplatnoMestoController nmk) : base(nmk)
        {
        }

    }
}
