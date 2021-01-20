using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MyWallet.Administration.API.Controllers
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Application.UseCase.Administrators.CQ;
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;

    [Route("/api/[controller]")]
    public class TotoController : CQRSBase
    {
        [HttpPut]
        public async Task<Administrator[]> Get([FromBody] GetAdministratorsQuery administratorsQuery)
        {
            return await ExecuteQueryAsync(administratorsQuery);
        }

        [HttpGet("{id}")]
        public async Task<AdministratorViewModel> Get(Guid id)
        {
            return await ExecuteQueryAsync(new GetAdministratorByIdQuery(id));
        }
    }
}
