using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.SurveyAnswer
{
    using System.ComponentModel.DataAnnotations;
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Domain.Aggregation.Common;

    [Table("survey_answer_choice", Schema = Schamas.SURVEY)]
    public class SurveyAnswerChoice : ConcurrencyPoco<Guid>, IAggregateRoot
    {
        [Column("survey_answer_id")]
        public Guid SurveyAnswerId { get; set; }
        public virtual SurveyAnswer SurveyAnswer { get; set; }

        [Column("choice_id")]
        public Guid ChoiceId { get; set; }
        public virtual Choice Choice { get; set; }

        [Required]
        [Column("coordinates", TypeName = "varchar")]
        public string Corrdinates { get; set; }

        [Column("drawing_type")]
        public DrawingType DrawingType { get; set; }
    }
}
