using System.Text.Json.Serialization;

namespace MyWallet.Administration.Infrastructure.Multitenancy
{
    public sealed class TenancyContext
    {
        /// <summary>
        /// Tenant host name
        /// </summary>
        [JsonPropertyName("host")] 
        public string Host { get; set; }

        /// <summary>
        /// Tenant route prefix
        /// </summary>
        [JsonPropertyName("prefix")] 
        public string Prefix { get; set; }

        /// <summary>
        /// Tenant persistence connection strings
        /// </summary>
        [JsonPropertyName("connectionStrings")] 
        public TenancyConnectionString ConnectionStrings { get; set; }
    }
}
