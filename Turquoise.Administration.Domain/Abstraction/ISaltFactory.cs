namespace Turquoise.Administration.Domain.Abstraction
{
    public interface ISaltFactory
    {
        byte[] Generate();
    }
}
