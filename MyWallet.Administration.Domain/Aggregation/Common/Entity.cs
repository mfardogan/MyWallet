using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public abstract class Entity<TPk> : DbObject
    {
        /// <summary>
        /// Primary key column
        /// </summary>
        [Key]
        [Column("id", Order = 0)]
        public virtual TPk Id { get; set; }
    }
}
