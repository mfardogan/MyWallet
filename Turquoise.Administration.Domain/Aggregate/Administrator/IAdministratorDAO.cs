using System;

namespace Turquoise.Administration.Domain.Aggregate.Administrator
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;

    public interface IAdministratorDAO : IDataAccessObject, 
        ICommand<Administrator, Guid>, 
        IQuery<Administrator, Guid>
    {
    }
}
