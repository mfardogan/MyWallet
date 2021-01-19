using System;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Domain.Aggregation.Common;

    public interface IAdministratorRepository : IRepository, 
        ICommand<Administrator, Guid>, 
        IQuery<Administrator, Guid>
    {
    }
}
