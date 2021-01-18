using System.Text.Json.Serialization;

namespace MyWallet.Administration.API.Models
{
    public sealed class MultitenancyModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("persistenceConnectionString")]
        public string PersistenceConnectionString { get; set; }

        [JsonPropertyName("auditLogConnectionString")]
        public string AuditLogConnectionString { get; set; }

        [JsonPropertyName("disabled")]
        public int Disabled { get; set; }
    }
}
