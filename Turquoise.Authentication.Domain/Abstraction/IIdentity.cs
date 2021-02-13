using System;

namespace Turquoise.Authentication.Domain.Abstraction
{
    public interface IIdentity
    {
        Guid? AdministratorId { get; }
        Guid? DoctorId { get; }
    }
}
