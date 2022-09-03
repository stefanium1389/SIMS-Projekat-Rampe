using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{
    public class StateSpustaSe : State
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
            DobaviKontekst().SpustiRampu();
        }
        public override void Do()
        {
            bool ispravan = DobaviKontekst().SaljiSignal();
            if (ispravan)
            {
                StateSpusteno s = new StateSpusteno(Kontroler);
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

        public StateSpustaSe(NaplatnoMestoController nmk) : base(nmk)
        {
        }

    }
}
