using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Turquoise.Administration.API.Aspects
{
    /// <summary>
    /// Model validator
    /// </summary>
    [
        AttributeUsage(
            AttributeTargets.Class | AttributeTargets.Method,
            Inherited = true,
            AllowMultiple = false)
    ]
    internal class ValidationFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string[] errors = context.ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();
                context.Result = new BadRequestObjectResult(errors);
            }
            base.OnResultExecuting(context);
        }
    }
}
