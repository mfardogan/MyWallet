using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MyWallet.Administration.API.Controllers
{
    using MyWallet.Administration.Application.UseCase.Administrators.Request;
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;

    [Route("/api/[controller]")]
    public class TotoController : CQRSBase
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
