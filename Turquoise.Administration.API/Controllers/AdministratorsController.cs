using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers
{
    using Turquoise.Administration.Application.UseCase.Administrators.Request;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    [RouteJoin("[controller]")]
    public class AdministratorsController : CQRSBase
    {
        [HttpPut("search")]
        public async Task<AdministratorViewModel[]> Get([FromBody] GetAdministratorsQuery administratorsQuery)
        {
            return await ExecuteQueryAsync(administratorsQuery);
        }

        [HttpGet("{id}")]
        public async Task<AdministratorViewModel> Get(Guid id)
        {
            return await ExecuteQueryAsync(new GetAdministratorByIdQuery(id));
        }

        [HttpPost]
        public async Task Get([FromBody]InsertAdministratorCommand insertAdministratorCommand)
        {
             await ExecuteCommandAsync(insertAdministratorCommand);
        }

        [HttpPut]
        public async Task Get([FromBody] UpdateAdministratorCommand updateAdministratorCommand)
        {
            await ExecuteCommandAsync(updateAdministratorCommand);
        }
    }
}
