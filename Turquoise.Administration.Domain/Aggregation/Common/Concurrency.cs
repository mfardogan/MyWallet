using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public abstract class ConcurrencyPoco<TPk> : Poco<TPk>
    {
        /// <summary>
        /// Concurrency token
        /// </summary>
        [
            ConcurrencyCheck,
            Column(name: "xmin", TypeName = "xid", Order = 2),
            DatabaseGenerated(DatabaseGeneratedOption.Computed)
        ]
        public uint ConcurrencyToken { get; set; }
    }
}
