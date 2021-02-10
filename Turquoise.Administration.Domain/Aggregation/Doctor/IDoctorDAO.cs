using System;

namespace Turquoise.Administration.Domain.Aggregation.Doctor
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    public interface IDoctorDAO : IDataAccessObject,
        ICommand<Doctor, Guid>, 
        IQuery<Doctor, Guid>
    {
    }
}
