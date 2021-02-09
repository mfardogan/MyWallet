using System;

namespace Turquoise.Administration.Application.Service
{
    using Turquoise.Administration.Domain.Abstraction;

    public sealed class Identity : IIdentity
    {
        public Guid? AdministratorId => Guid.NewGuid();
    }
}
