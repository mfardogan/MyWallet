using System;

namespace MyWallet.Administration.Domain.Abstraction
{
    public interface IIdentity
    {
        Guid? AdministratorId { get; }
    }
}
