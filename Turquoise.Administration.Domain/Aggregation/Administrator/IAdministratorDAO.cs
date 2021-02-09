using System;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Domain.Aggregation.Common;

    public interface IAdministratorDAO : IDAO, 
        ICommand<Administrator, Guid>, 
        IQuery<Administrator, Guid>
    {
    }
}
