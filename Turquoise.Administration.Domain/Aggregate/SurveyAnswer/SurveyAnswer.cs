using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregate.SurveyAnswer
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Domain.Aggregate.Doctor;
    using Turquoise.Administration.Domain.Aggregate.Survey;


    [Table("survey_answer", Schema = Schamas.SURVEY)]
    public class SurveyAnswer : ConcurrencyPoco<Guid>, IAggregateRoot, ICreationAt
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
