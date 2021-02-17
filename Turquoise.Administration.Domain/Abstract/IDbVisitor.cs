using Turquoise.Administration.Domain.Aggregate.Common;

namespace MyWallet.Administration.Domain.Abstract
{
    public interface IDbVisitor
    {
        public void Visit(Entity databaseObject);
    }
}
