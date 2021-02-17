using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers.Branches
{
    using Turquoise.Administration.API.Aspects;
    using Turquoise.Administration.Application.UseCase.Branches.CQ;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;

    [RouteJoin("[controller]")]
    public sealed class BranchesController : CQBaseController
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<BranchViewModel> GetById(Guid id)
        {
            return await ExecuteQueryAsync(new GetBranchByIdQuery(id));
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpPut("search")]
        public async Task<BranchViewModel[]> Search([FromBody] SearchBranchesQuery searchQuery)
        {
            if (DistributedMemory.TryGet("branches", out BranchViewModel[] viewModels))
            {
                return viewModels;
            }

            viewModels = await ExecuteQueryAsync(searchQuery);
            DistributedMemory.Set("branches", viewModels);
            return viewModels;
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
        public async Task Insert([FromBody] InsertBranchCommand insertCommand)
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
        public async Task Update([FromBody] UpdateBranchCommand updateCommand)
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
            await ExecuteCommandAsync(new DeleteBranchCommand(id));
        }
    }
}
