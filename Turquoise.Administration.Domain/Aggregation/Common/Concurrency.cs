using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public abstract class Concurrency<TPk> : Entity<TPk>
    {
        /// <summary>
        /// Concurrency token
        /// </summary>
        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(name: "xmin", TypeName = "xid", Order = 2)]
        public uint ConcurrencyToken { get; set; }
    }
}
