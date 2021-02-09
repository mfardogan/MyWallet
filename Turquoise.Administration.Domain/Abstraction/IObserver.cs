namespace Turquoise.Administration.Domain.Abstraction
{
    public interface IObserver<TParameter>
    {
        void Subscribe(TParameter parameter);
    }
}
