using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregate.Survey
{
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Domain.Aggregate.Branch;

    [Table("survey_branch", Schema = Schamas.SURVEY)]
    public class SurveyBranch : ConcurrencyPoco<Guid>
    {
        [Column("survey_id")]
        [ForeignKey(nameof(Survey))]
        public Guid SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        [Column("branch_id")]
        [ForeignKey(nameof(Branch))]
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
