using Turquoise.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.Abstraction
{
    public interface IDbVisitor
    {
        public void Visit(DbObject databaseObject);
    }
}
