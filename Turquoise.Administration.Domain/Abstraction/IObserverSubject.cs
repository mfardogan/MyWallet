namespace Turquoise.Administration.Domain.Abstraction
{
    public interface IObserverSubject<TParameter>
    {
        void Publish(TParameter parameter);
        IObserverSubject<TParameter> AddObserver(IObserver<TParameter> observer);
    }
}
