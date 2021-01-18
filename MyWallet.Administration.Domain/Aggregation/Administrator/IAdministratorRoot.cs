using MyWallet.Administration.Domain.Aggregation.Common;
using System;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    public interface IAdministratorRoot : IRoot, 
        ICommand<Administrator, Guid>, 
        IQuery<Administrator, Guid>
    {
    }
}
