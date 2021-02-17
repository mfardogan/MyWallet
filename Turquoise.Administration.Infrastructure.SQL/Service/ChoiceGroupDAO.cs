using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregate.ChoiceGroup;

    public class ChoiceGroupDAO : CrudService<ChoiceGroup, Guid>, IChoiceGroupDAO
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override ChoiceGroup Get(Guid id) => RepositoryContext
            .Include(e => e.Choices)
            .AsNoTracking()
            .SingleOrDefault(e => e.Id == id);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override ChoiceGroup Update(ChoiceGroup entity)
        {
            Choice[] currents = DatabaseContext.Choices.Where(e => e.ChoiceGroupId == entity.Id).ToArray();

            ComparationBuilder<Choice> builder = new ComparationBuilder<Choice>()
                .AddCurrents(currents)
                .AddNews(entity.Choices)
                .AddEqualityComparer(new ChoiceEquality())
                .AddActionForNews(e => e.ChoiceGroupId = entity.Id);

            ComplexUpdate<Choice, Guid>(builder);
            return base.Update(entity);
        }
    }
}
