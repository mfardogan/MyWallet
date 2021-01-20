using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyWallet.Administration.Infrastructure.Persistence.Repository
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Domain.Aggregation.Common;

    public class AdministratorRepository : BaseService, IAdministratorService
    {
        public Administrator Delete(Administrator entity)
        {
            throw new NotImplementedException();
        }

        public Administrator Get(Guid id)
        {
            return DbContext.Administrators.SingleOrDefault(e => e.Id == id);
        }

        public Administrator[] Get(Expression<Func<Administrator, bool>> expression = null, Pagination pagination = null)
        {
            return DbContext.Administrators.ToArray();
        }

        public Administrator Insert(Administrator entity)
        {
            var e = DbContext.Administrators.Add(entity);
            return e.Entity;
        }

        public Administrator Update(Administrator entity)
        {
            throw new NotImplementedException();
        }
    }
}
