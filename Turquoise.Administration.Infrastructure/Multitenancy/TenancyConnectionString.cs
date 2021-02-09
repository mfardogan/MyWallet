using System.Text.Json.Serialization;

namespace MyWallet.Administration.Infrastructure.Multitenancy
{
    public class TenancyConnectionString
    {
        /// <summary>
        /// Database
        /// </summary>
        [JsonPropertyName("persistence")]
        public string Persistence { get; set; }

        /// <summary>
        /// Logs
        /// </summary>
        [JsonPropertyName("auditLog")]
        public string AuditLog { get; set; }

        /// <summary>
        /// Blog storage
        /// </summary>
        [JsonPropertyName("blobStorage")]
        public string BlobStorage { get; set; }
    }
}
