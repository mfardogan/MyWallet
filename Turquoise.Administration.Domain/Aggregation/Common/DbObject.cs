using MyWallet.Administration.Domain.Abstraction;

namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public abstract class DbObject
    {
        /// <summary>
        /// Accept visitor
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IDbVisitor visitor) => visitor.Visit(this);
    }
}
