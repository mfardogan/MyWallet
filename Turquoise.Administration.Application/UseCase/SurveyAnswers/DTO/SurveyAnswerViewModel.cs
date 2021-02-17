using System;
using System.Collections.Generic;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO
{
    using Turquoise.Administration.Domain.Aggregate.SurveyAnswer;
    public class SurveyAnswerViewModel : EntityViewModelPersistent<Guid, SurveyAnswer>
    {
        public Guid SurveyId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime? CreationAt { get; set; }
        public uint ConcurrencyToken { get; set; }

        /// <summary>
        /// Choices
        /// </summary>
        public ICollection<SurveyAnswerChoiceViewModel> AnswerChoices { get; set; } = new HashSet<SurveyAnswerChoiceViewModel>();
    }
}
