using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers.Surveys
{
    using Turquoise.Administration.API.Aspects;
    using Turquoise.Administration.Application.UseCase.Surveys.CQ;
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;

    [RouteJoin("[controller]")]
    public class SurveysController : CQBaseController
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SurveyViewModel> GetById(Guid id)
        {
            return await ExecuteQueryAsync(new GetSurveyByIdQuery(id));
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpPut("search")]
        public async Task<SurveyViewModel[]> Search([FromBody] SearchSurveysQuery searchQuery)
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
        public async Task Insert([FromBody] InsertSurveyCommand insertCommand)
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
        public async Task Update([FromBody] UpdateSurveyCommand updateCommand)
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
            await ExecuteCommandAsync(new DeleteSurveyCommand(id));
        }
    }
}
