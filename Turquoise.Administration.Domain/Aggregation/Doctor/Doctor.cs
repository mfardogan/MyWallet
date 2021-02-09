using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Doctor
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.Branch;

    [Table("doctor", Schema = Schamas.USERS)]
    public class Doctor : ConcurrencyEntity<Guid>, IAggregateRoot, ICreationAt
    {
        [Required]
        [Column(name: "name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(name: "surname", TypeName = "varchar(20)")]
        public string Surname { get; set; }

        [Column(name: "full_name")]
        public string FullName { get; set; }

        [Column(name: "creationAt")]
        public DateTime? CreationAt { get; set; }

        [Column(name: "branch_id")]
        [ForeignKey(name: nameof(Branch))]
        public Guid? BranchId { get; set; }

        /// <summary>
        /// Branch
        /// </summary>
        public virtual Branch Branch { get; set; }
    }
}
