namespace Turquoise.Administration.Domain.Abstract
{
    public interface ISaltFactory
    {
        byte[] Generate();
    }
}
