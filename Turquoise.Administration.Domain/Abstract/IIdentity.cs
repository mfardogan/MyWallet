using System;

namespace Turquoise.Administration.Domain.Abstract
{
    public interface IIdentity
    {
        Guid? AdministratorId { get; }
        Guid? DoctorId { get; }
    }
}
