using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregate.Branch
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Domain.Aggregate.Doctor;

    [Table("branch", Schema = Schamas.USERS)]
    public class Branch : ConcurrencyPoco<Guid>, IAggregateRoot
    {
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column("code", TypeName = "varchar(3)")]
        public string Code { get; set; }

        /// <summary>
        /// Doctors
        /// </summary>
        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
