using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace MyWallet.Administration.Infrastructure.Multitenancy
{
    public class MultitenancyHttpInterceptor : IMultitenancyAccessor
    {
        private readonly IHttpContextAccessor httpContext;
        public MultitenancyHttpInterceptor(IHttpContextAccessor httpContext)
            => this.httpContext = httpContext;

        static readonly TenancyContext[] _tenancies;
        static MultitenancyHttpInterceptor() => _tenancies =
            JsonSerializer.Deserialize<TenancyContext[]>(
                  File.ReadAllText("apptenancy.json"));

        /// <summary>
        /// Get tenancy context
        /// </summary>
        /// <returns></returns>
        public TenancyContext GetTenancy()
        {
            return _tenancies.SingleOrDefault(ten => ten.Host.Equals(httpContext.HttpContext.Request.Host.ToString().ToLower()));
        }
    }
}
