using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.Request
{
    public class DeleteAdministratorCommand : IRequest
    {
        public Guid AdministratorId { get; set; }
    }
}
