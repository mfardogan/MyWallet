using MyWallet.Administration.Application.UseCase.Administrators.DTO;
using MyWallet.Administration.Domain.Aggregation.Administrator;
using System;
using System.Linq.Expressions;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    public class AdministratorSpecification : Specification<Administrator, AdministratorViewModel>
    {
        public AdministratorSpecification(AdministratorViewModel filterCaluses) : base(filterCaluses)
        {
        }

        public override Expression<Func<Administrator, bool>> Build()
        {
            if (IsEmptyFilter())
            {
                return _ => true;
            }

            return x => x.Name == FilterCaluses.Name || string.IsNullOrEmpty(FilterCaluses.Name);
        }
    }
}
