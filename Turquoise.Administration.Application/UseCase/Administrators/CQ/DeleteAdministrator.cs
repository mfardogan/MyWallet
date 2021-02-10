using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    public class DeleteAdministrator : IRequest
    {
        public Guid AdministratorId { get; set; }
    }
}
