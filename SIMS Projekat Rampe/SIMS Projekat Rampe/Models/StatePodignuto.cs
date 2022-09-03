using SIMS_Projekat_Rampe.Controlers;
using System.Threading;

namespace SIMS_Projekat_Rampe.Models
{
    public class StatePodignuto : State
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
            Thread.Sleep(2000);
            StateSpustaSe s = new StateSpustaSe(Kontroler);
            DobaviKontekst().PromeniStanje(s);
            s.Entry();
            s.Do();
        }
        public override void Entry()
        {
            DobaviKontekst().PromeniProlazSemafor(Kontroler, true);
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
            else
            {
                KolaOdu();
            }
        }
        public override void KlikNaDugme()
        {
            throw new NotImplementedException("jauu");
        }

        public StatePodignuto(NaplatnoMestoController nmk) : base(nmk)
        {
        }
    }
}
