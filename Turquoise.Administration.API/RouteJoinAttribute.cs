using System;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API
{
    /// <summary>
    /// Route 
    /// </summary>
    [
        AttributeUsage(
            AttributeTargets.Class,
            Inherited = true,
            AllowMultiple = false)
    ]
    public class RouteJoinAttribute : RouteAttribute
    {
        private const string leftPrefix = "/api/doctor/";
        public RouteJoinAttribute(string template) : base($"{leftPrefix}{template.Trim()}")
        {
        }
    }
}
