using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers.Branches
{
    using Turquoise.Administration.Application.UseCase.Branches.CQ;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;

    [RouteJoin("[controller]")]
    public class BranchesController : CQRSBase
    {
        [HttpPut("search")]
        public async Task<BranchViewModel[]> Search([FromBody] SearchBranches query)
        {
            return await ExecuteQueryAsync(query);
        }

        [HttpGet("{id}")]
        public async Task<BranchViewModel> GetById(Guid id)
        {
            return await ExecuteQueryAsync(new GetBranchById(id));
        }

        [HttpPost]
        public async Task Insert([FromBody] InsertBranch command)
        {
            await ExecuteCommandAsync(command);
        }

        [HttpPut]
        public async Task Update([FromBody] UpdateBranch command)
        {
            await ExecuteCommandAsync(command);
        }

        [HttpDelete("{id}")]
        public async Task Update(Guid id)
        {
            await ExecuteCommandAsync(new DeleteBranch(id));
        }
    }
}
