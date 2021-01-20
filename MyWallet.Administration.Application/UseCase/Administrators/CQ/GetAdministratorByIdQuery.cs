using MediatR;
using System;

namespace MyWallet.Administration.Application.UseCase.Administrators.CQ
{
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;
    public class GetAdministratorByIdQuery : IRequest<AdministratorViewModel>
    {
        public GetAdministratorByIdQuery()
        {
        }
        public GetAdministratorByIdQuery(Guid ıd)
        {
            Id = ıd;
        }
        public Guid Id { get; set; }
    }
}
