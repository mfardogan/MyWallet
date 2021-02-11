using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregation.Survey;
    public class SurveyDAO : CrudService<Survey, Guid>, ISurveyDAO
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Survey Get(Guid id)
        {
            return RepositoryContext.Include(e => e.SurveyBranches)
                .Include(e => e.ChoiceGroup)
                .ThenInclude(e => e.Choices)
                .AsNoTracking()
                .SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Survey Update(Survey entity)
        {
            var comparer = new SurveyBranchEquality();
            SurveyBranch[] currents = DatabaseContext.SurveyBranches
                .Where(e => e.SurveyId == entity.Id)
                .ToArray();

            SurveyBranch[] addSurveyBranches = entity.SurveyBranches
                .Except(currents, comparer)
                .ToArray();

            SurveyBranch[] removeSurveyBranches = currents
                .Except(entity.SurveyBranches, comparer)
                .ToArray();

            DatabaseContext.SurveyBranches.AddRange(addSurveyBranches);
            DatabaseContext.SurveyBranches.RemoveRange(removeSurveyBranches);
            return base.Update(entity);
        }
    }
}
