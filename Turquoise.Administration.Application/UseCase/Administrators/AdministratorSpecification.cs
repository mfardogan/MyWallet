using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

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
