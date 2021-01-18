using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SaasKit.Multitenancy;
using Microsoft.AspNetCore.Http;

namespace MyWallet.Administration.API.Multitenancy
{
    public class MultitenancyHttpInterceptor : ITenantResolver<TenancyContext>
    {
        private static readonly TenancyContext[] tenancyConfig;
        static MultitenancyHttpInterceptor() => tenancyConfig =
              JsonSerializer.Deserialize<TenancyContext[]>(
                  File.ReadAllText("apptenancy.json"));

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        private TenancyContext Condition(Func<TenancyContext, bool> func)
        {
            return tenancyConfig.SingleOrDefault(func);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<TenantContext<TenancyContext>> ResolveAsync(HttpContext context)
        {
            /*
            var host = request.Host.Value.ToLower();
            var client = Condition(tenancy => tenancy.Host.Equals(host));
            */

            var request = context.Request;
            string prefix = request.Path.Value.ToLower().Trim('/').Split('/').FirstOrDefault();
            TenancyContext tenancy = Condition(tenancy => tenancy.Prefix.Equals(prefix));

            TenantContext<TenancyContext> tenant = !(tenancy is null) ?
                new TenantContext<TenancyContext>(tenancy)
                    : null;

            return Task.FromResult(tenant);
        }
    }
}
