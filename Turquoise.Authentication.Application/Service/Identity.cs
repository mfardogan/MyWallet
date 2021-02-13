using System;

namespace Turquoise.Authentication.Application.Service
{
    using Turquoise.Authentication.Domain.Abstraction;

    public sealed class Identity : IIdentity
    {
        Guid? IIdentity.DoctorId => Guid.NewGuid();
        Guid? IIdentity.AdministratorId => Guid.NewGuid();
    }
}
