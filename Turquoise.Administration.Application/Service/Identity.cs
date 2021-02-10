using System;

namespace Turquoise.Administration.Application.Service
{
    using Turquoise.Administration.Domain.Abstraction;

    public sealed class Identity : IIdentity
    {
        Guid? IIdentity.DoctorId => Guid.NewGuid();
        Guid? IIdentity.AdministratorId => Guid.NewGuid();
    }
}
