using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Administration.Infrastructure.Persistence;

namespace MyWallet.Administration.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TotoController : ControllerBase
    {
        MyDbContext my;

        public TotoController(MyDbContext my)
        {
            this.my = my;
        }

        [HttpGet("get")]
        public string Get()
        {
            return my.Administrators.First().Name;
        }
    }
}
