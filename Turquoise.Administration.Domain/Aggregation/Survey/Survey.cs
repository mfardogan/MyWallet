using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Survey
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using System.Collections.Generic;

    [Table("survey", Schema = Schamas.SURVEY)]
    public class Survey : ConcurrencyPoco<Guid>, IAggregateRoot, ICreationAt
    {
        [Column("status")]
        public SurveyStatus Status { get; set; }

        [Column("title", TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Column("body", TypeName = "varchar(1000)")]
        public string Body { get; set; }

        [Required]
        [Column("image")]
        public byte[] Image { get; set; }

        [Column("creation_at")]
        public DateTime? CreationAt { get; set; }

        [Column("choice_group_id")]
        [ForeignKey(nameof(ChoiceGroup))]
        public Guid ChoiceGroupId { get; set; }
        public virtual ChoiceGroup ChoiceGroup { get; set; }

        [Column("branch_id")]
        [ForeignKey(nameof(Branch))]
        public Guid? BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        /// <summary>
        /// Survey branches
        /// </summary>
        public ICollection<SurveyBranch> SurveyBranches { get; set; } = new HashSet<SurveyBranch>();
    }
}
