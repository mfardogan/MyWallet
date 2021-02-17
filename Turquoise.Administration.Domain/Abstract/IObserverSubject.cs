namespace Turquoise.Administration.Domain.Abstract
{
    public interface IObserverSubject<TParameter>
    {
        void Publish(TParameter parameter);
        IObserverSubject<TParameter> AddObserver(IObserver<TParameter> observer);
    }
}
