namespace Turquoise.Administration.Domain.Abstract
{
    public interface IObserver<TParameter>
    {
        void Subscribe(TParameter parameter);
    }
}
