using System;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO
{
    using Turquoise.Administration.Domain.Aggregate.SurveyAnswer;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;
    public class SurveyAnswerChoiceViewModel : EntityViewModelPersistent<Guid, SurveyAnswerChoice>
    {
        public Guid ChoiceId { get; set; }
        public ChoiceViewModel Choice { get; set; }
        public string Corrdinates { get; set; }
        public DrawingType DrawingType { get; set; }
        public uint ConcurrencyToken { get; set; }
    }
}
