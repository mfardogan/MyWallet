using System;

namespace Turquoise.Administration.Domain.Aggregation.Administrator
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;

    public interface IAdministratorDAO : IDataAccessObject, 
        ICommand<Administrator, Guid>, 
        IQuery<Administrator, Guid>
    {
    }
}
