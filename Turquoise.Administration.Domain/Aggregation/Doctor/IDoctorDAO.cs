using System;

namespace Turquoise.Administration.Domain.Aggregation.Doctor
{
    using Turquoise.Administration.Domain.Aggregation.Common;

    public interface IDoctorDAO : 
        ICommand<Doctor, Guid>, 
        IQuery<Doctor, Guid>
    {
    }
}
