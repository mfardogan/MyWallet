using System;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    public class AdministratorDAO : CrudService<Administrator, Guid>, IAdministratorDAO
    {

    }
}
