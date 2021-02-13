using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers.ChoiceGroups
{
    using Turquoise.Administration.API.Aspects;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    [RouteJoin("[controller]")]
    public sealed class ChoiceGroupsController : CQBaseController
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ChoiceGroupViewModel> GetById(Guid id)
        {
            return await ExecuteQueryAsync(new GetChoiceGroupByIdQuery(id));
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpPut("search")]
        public async Task<ChoiceGroupViewModel[]> Search([FromBody] SearchChoiceGroupsQuery searchQuery)
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
        public async Task Insert([FromBody] InsertChoiceGroupCommand insertCommand)
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
        public async Task Update([FromBody] UpdateChoiceGroupCommand updateCommand)
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
            await ExecuteCommandAsync(new DeleteChoiceGroupCommand(id));
        }
    }
}
