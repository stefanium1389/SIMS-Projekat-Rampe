namespace SIMS_Projekat_Rampe.Models
{
    interface IPublisher
    {
        void Publish(string s);
        void AddObserver(IObserver o);
    }
}
