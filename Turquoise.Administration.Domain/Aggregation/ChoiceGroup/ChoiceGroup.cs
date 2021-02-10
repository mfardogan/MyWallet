using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.ChoiceGroup
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;

    [Table("choice_group", Schema = Schamas.SURVEY)]
    public class ChoiceGroup : Concurrency<Guid>, IAggregateRoot
    {
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column("code", TypeName = "varchar(3)")]
        public string Code { get; set; }

        /// <summary>
        /// Choices
        /// </summary>
        public ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
    }
}
