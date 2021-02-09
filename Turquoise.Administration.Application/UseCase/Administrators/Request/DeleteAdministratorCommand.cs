using MediatR;
using System;

namespace MyWallet.Administration.Application.UseCase.Administrators.Request
{
    public class DeleteAdministratorCommand : IRequest
    {
        public Guid AdministratorId { get; set; }
    }
}
