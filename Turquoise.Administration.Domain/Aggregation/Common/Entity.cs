using MyWallet.Administration.Domain.Abstraction;

namespace Turquoise.Administration.Domain.Aggregation.Common
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
