using MongoDB.Bson.Serialization.Attributes;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Models
{

    [System.Serializable]
    public class NotImplementedException : System.Exception
    {
        public NotImplementedException() { }
        public NotImplementedException(string message) : base(message) { }
        public NotImplementedException(string message, System.Exception inner) : base(message, inner) { }
        protected NotImplementedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [BsonKnownTypes(typeof(StateSpusteno), typeof(StateSpustaSe), typeof(StatePodignuto), typeof(StatePodizeSe), typeof(StatePokvareno))]
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

        public State(NaplatnoMestoController nmk)
        {
            Kontroler = nmk;
        }

        public Rampa DobaviKontekst()
        {
            return Kontroler.VratiRampu();
        }

    }


}
