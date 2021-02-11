using System;

namespace Turquoise.Administration.Application.UseCase.Surveys.DTO
{
    using Turquoise.Administration.Domain.Aggregation.Survey;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    public class SurveyBranchViewModel : EntityViewModelPersistent<Guid, SurveyBranch>
    {
        public Guid SurveyId { get; set; }
        public virtual SurveyViewModel Survey { get; set; }
        public Guid BranchId { get; set; }
        public virtual BranchViewModel Branch { get; set; }
        public uint ConcurrencyToken { get; set; }
    }
}
