using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers
{
    using Turquoise.Administration.API.Aspects;

    /// <summary>
    /// Base controller
    /// </summary>
    [
        ApiController,
        TypeFilter(typeof(ExceptionFilter))
    ]
    public class Base : ControllerBase
    {
    }
}
