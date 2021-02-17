using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregate.ChoiceGroup
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;

    [Table("choice_group", Schema = Schamas.SURVEY)]
    public class ChoiceGroup : ConcurrencyPoco<Guid>, IAggregateRoot
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
