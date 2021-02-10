using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.SurveyAnswer
{
    using System.Collections.Generic;
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;

    [Table("survey_answer", Schema = Schamas.SURVEY)]
    public class SurveyAnswer : Concurrency<Guid>, IAggregateRoot, ICreationAt
    {
        [Column("creation_at")]
        public DateTime? CreationAt { get; set; }

        /// <summary>
        /// Choices
        /// </summary>
        public ICollection<SurveyAnswerChoice> AnswerChoices { get; set; } = new HashSet<SurveyAnswerChoice>();
    }
}
