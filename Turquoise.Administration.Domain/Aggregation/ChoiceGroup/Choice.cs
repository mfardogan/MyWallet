using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.ChoiceGroup
{
    using Turquoise.Administration.Domain.Aggregation.Common;

    [Table("choice", Schema = Schamas.SURVEY)]
    public class Choice : Concurrency<Guid>
    {
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column("code", TypeName = "varchar(3)")]
        public string Code { get; set; }

        [Column("number")]
        public uint Number { get; set; }

        [Required]
        [Column("color", TypeName = "varchar(6)")]
        public string Color { get; set; }

        [Column("description", TypeName = "varchar")]
        public string Description { get; set; }

        [Required]
        [Column("choice_group_id")]
        [ForeignKey(name: nameof(ChoiceGroup))]
        public Guid ChoiceGroupId { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual ChoiceGroup ChoiceGroup { get; set; }
    }
}
