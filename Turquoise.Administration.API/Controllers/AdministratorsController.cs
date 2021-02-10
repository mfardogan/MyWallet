using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers
{
    using Turquoise.Administration.Application.UseCase.Administrators.CQ;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    [RouteJoin("[controller]")]
    public class AdministratorsController : CQRSBase
    {
        [HttpPut("search")]
        public async Task<AdministratorViewModel[]> Get([FromBody] SearchAdministrators administratorsQuery)
        {
            return await ExecuteQueryAsync(administratorsQuery);
        }

        [HttpGet("{id}")]
        public async Task<AdministratorViewModel> Get(Guid id)
        {
            return await ExecuteQueryAsync(new GetAdministratorById(id));
        }

        [HttpPost]
        public async Task Get([FromBody]InsertAdministrator insertAdministratorCommand)
        {
             await ExecuteCommandAsync(insertAdministratorCommand);
        }

        [HttpPut]
        public async Task Get([FromBody] UpdateAdministrator updateAdministratorCommand)
        {
            await ExecuteCommandAsync(updateAdministratorCommand);
        }
    }
}
