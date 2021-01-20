using System;

namespace MyWallet.Administration.Application.Service
{
    using MyWallet.Administration.Domain.Abstraction;

    public sealed class Identity : IIdentity
    {
        public Guid? AdministratorId => Guid.NewGuid();
    }
}
