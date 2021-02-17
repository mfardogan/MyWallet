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
            var comparer = new ChoiceEquality();
            Choice[] currentChoices = DatabaseContext.Choices.Where(e => e.ChoiceGroupId == entity.Id).ToArray();
            Choice[] addChoices = entity.Choices.Except(currentChoices, comparer).ToArray();
            Choice[] removeChoices = currentChoices.Except(entity.Choices, comparer).ToArray();
            Choice[] updateChoices = currentChoices.Intersect(entity.Choices, comparer).ToArray();

            DatabaseContext.Choices.AddRange(addChoices);
            DatabaseContext.Choices.RemoveRange(removeChoices);

            foreach (Choice choice in updateChoices)
            {
                DatabaseContext.Choices.Update(choice);
            }

            return base.Update(entity);
        }
    }
}
