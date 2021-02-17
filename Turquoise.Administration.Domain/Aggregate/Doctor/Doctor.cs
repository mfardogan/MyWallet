using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregate.Doctor
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Domain.Aggregate.Branch;

    [Table("doctor", Schema = Schamas.USERS)]
    public class Doctor : ConcurrencyPoco<Guid>, IAggregateRoot, ICreationAt
    {
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column("surname", TypeName = "varchar(20)")]
        public string Surname { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("creation_at")]
        public DateTime? CreationAt { get; set; }

        [Column("branch_id")]
        [ForeignKey(nameof(Branch))]
        public Guid? BranchId { get; set; }

        /// <summary>
        /// Branch
        /// </summary>
        public virtual Branch Branch { get; set; }
    }
}
