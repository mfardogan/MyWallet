using System;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.API.Aspects;

    /// <summary>
    /// Base controller
    /// </summary>
    [
        ApiController,
        TypeFilter(typeof(ExceptionFilter))
    ]
    public class BaseController : ControllerBase
    {
        private readonly Lazy<IDistributedMemory> distributedMemory =
            new Lazy<IDistributedMemory>(() => Dependency.Get<IDistributedMemory>(),
                isThreadSafe: false);

        /// <summary>
        /// Cache provider
        /// </summary>
        public IDistributedMemory DistributedMemory => distributedMemory.Value;
    }
}
