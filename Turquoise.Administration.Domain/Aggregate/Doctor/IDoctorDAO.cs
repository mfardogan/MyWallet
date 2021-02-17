using System;

namespace Turquoise.Administration.Domain.Aggregate.Doctor
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;
    public interface IDoctorDAO : IDataAccessObject,
        ICommand<Doctor, Guid>, 
        IQuery<Doctor, Guid>
    {
    }
}
