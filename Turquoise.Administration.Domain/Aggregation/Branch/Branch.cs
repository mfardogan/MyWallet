using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Branch
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.Doctor;

    public class Branch : ConcurrencyEntity<Guid>, IAggregateRoot
    {
        [Required]
        [Column(name: "name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(name: "code", TypeName = "varchar(3)")]
        public string Code { get; set; }

        /// <summary>
        /// Doctors
        /// </summary>
        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
