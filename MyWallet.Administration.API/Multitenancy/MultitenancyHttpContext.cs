using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SaasKit.Multitenancy;
using Microsoft.AspNetCore.Http;
using MyWallet.Administration.API.Models;

namespace MyWallet.Administration.API.Multitenancy
{
    public class MultitenancyHttpContext : ITenantResolver<MultitenancyModel>
    {
        private static readonly MultitenancyModel[] tenancyConfig;
        static MultitenancyHttpContext() => tenancyConfig =
              JsonSerializer.Deserialize<MultitenancyModel[]>(
                  File.ReadAllText("apptenancy.json"));

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        private MultitenancyModel Condition(Func<MultitenancyModel, bool> func)
        {
            return tenancyConfig.SingleOrDefault(func);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<TenantContext<MultitenancyModel>> ResolveAsync(HttpContext context)
        {
            /*
            var host = request.Host.Value.ToLower();
            var client = Condition(tenancy => tenancy.Host.Equals(host));
            */

            var request = context.Request;
            string prefix = request.Path.Value.ToLower().Trim('/').Split('/').FirstOrDefault();
            MultitenancyModel tenancy = Condition(tenancy => tenancy.Prefix.Equals(prefix));

            TenantContext<MultitenancyModel> tenant =
                !(tenancy is null) ?
                new TenantContext<MultitenancyModel>(tenancy)
                    : null;

            return Task.FromResult(tenant);
        }
    }
}
