using MyWallet.Administration.Domain.Abstract;

namespace Turquoise.Administration.Domain.Aggregate.Common
{
    public abstract class Entity
    {
        /// <summary>
        /// Accept visitor
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IDbVisitor visitor) => visitor.Visit(this);
    }
}
