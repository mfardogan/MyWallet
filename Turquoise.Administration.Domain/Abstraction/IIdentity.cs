using System;

namespace Turquoise.Administration.Domain.Abstraction
{
    public interface IIdentity
    {
        Guid? AdministratorId { get; }
    }
}
