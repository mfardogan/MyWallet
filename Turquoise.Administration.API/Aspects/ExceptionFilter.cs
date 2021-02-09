using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Turquoise.Administration.API.Aspects
{
    /// <summary>
    /// Exception handler
    /// </summary>
    [
        AttributeUsage(
            AttributeTargets.Class | AttributeTargets.Method,
            Inherited = true,
            AllowMultiple = false)
    ]
    internal class ExceptionFilter : ExceptionFilterAttribute
    {
        public async override Task OnExceptionAsync(ExceptionContext context)
        {
            var trace = new List<string>();
            var inner = context.Exception;
            do
            {
                trace.Add(inner.Message);
                inner = inner.InnerException;
            }
            while (!(inner is null));

            context.Result = new BadRequestObjectResult(trace);
            await base.OnExceptionAsync(context);
        }
    }
}
