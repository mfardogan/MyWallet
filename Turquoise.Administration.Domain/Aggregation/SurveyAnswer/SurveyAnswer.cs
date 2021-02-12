using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.SurveyAnswer
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.Doctor;
    using Turquoise.Administration.Domain.Aggregation.Survey;


    [Table("survey_answer", Schema = Schamas.SURVEY)]
    public class SurveyAnswer : Concurrency<Guid>, IAggregateRoot, ICreationAt
    {
        [Column("creation_at")]
        public DateTime? CreationAt { get; set; }

        [Column("survey_id")]
        public Guid SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        /// <summary>
        /// Choices
        /// </summary>
        public ICollection<SurveyAnswerChoice> AnswerChoices { get; set; } = new HashSet<SurveyAnswerChoice>();
    }
}
