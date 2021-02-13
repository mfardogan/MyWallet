namespace Turquoise.Authentication.Domain.Abstraction
{
    public interface ISaltFactory
    {
        byte[] Generate();
    }
}
