using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class AdministratorSpecify : Specification<Administrator, AdministratorViewModel>
    {
        public AdministratorSpecify(AdministratorViewModel filterClause) : base(filterClause)
        {
        }

        /// <summary>
        /// Create filter
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Administrator, bool>> GetExpressions()
        {
            return filter => IsThereNoFilter() || 
            filter.Name == FilterClause.Name || string.IsNullOrEmpty(FilterClause.Name);
        }
    }
}
