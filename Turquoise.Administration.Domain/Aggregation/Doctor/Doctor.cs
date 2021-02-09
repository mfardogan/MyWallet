using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Doctor
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.Branch;

    [Table("doctor", Schema = Schamas.USERS)]
    public class Doctor : Concurrency<Guid>, IAggregateRoot, ICreationAt
    {
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column("surname", TypeName = "varchar(20)")]
        public string Surname { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("creationAt")]
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
