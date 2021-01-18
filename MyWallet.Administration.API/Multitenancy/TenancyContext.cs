using System.Text.Json.Serialization;

namespace MyWallet.Administration.API.Multitenancy
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
        /// Tenant persistence connection string
        /// </summary>
        [JsonPropertyName("persistenceConnection")] 
        public string PersistenceConnectionString { get; set; }
    }
}
