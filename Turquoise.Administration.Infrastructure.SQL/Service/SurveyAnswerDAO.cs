using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregate.SurveyAnswer;
    public class SurveyAnswerDAO : CrudService<SurveyAnswer, Guid>, ISurveyAnsewerDAO
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SurveyAnswer Get(Guid id) => RepositoryContext
            .Include(e => e.AnswerChoices)
            .ThenInclude(e => e.Choice)
            .AsNoTracking()
            .SingleOrDefault(e => e.Id == id);
    }
}
