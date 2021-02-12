using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers.SurveyAnswers
{
    using Turquoise.Administration.API.Aspects;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;

    [RouteJoin("[controller]")]
    public class SurveyAnswersController : CQBaseController
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SurveyAnswerViewModel> GetById(Guid id)
        {
            return await ExecuteQueryAsync(new GetSurveyAnswerById(id));
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpPut("search")]
        public async Task<SurveyAnswerViewModel[]> Search([FromBody] SearchSurveyAnswers searchQuery)
        {
            return await ExecuteQueryAsync(searchQuery);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="insertCommand"></param>
        /// <returns></returns>
        [
            HttpPost,
            ValidationFilter
        ]
        public async Task Insert([FromBody] InsertSurveyAnswer insertCommand)
        {
            await ExecuteCommandAsync(insertCommand);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="updateCommand"></param>
        /// <returns></returns>
        [
            HttpPut,
            ValidationFilter
        ]
        public async Task Update([FromBody] UpdateSurveyAnswer updateCommand)
        {
            await ExecuteCommandAsync(updateCommand);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Update(Guid id)
        {
            await ExecuteCommandAsync(new DeleteSurveyAnswer(id));
        }
    }
}
