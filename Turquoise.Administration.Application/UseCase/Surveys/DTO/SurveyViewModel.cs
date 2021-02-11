using System;
using System.Collections.Generic;

namespace Turquoise.Administration.Application.UseCase.Surveys.DTO
{
    using Turquoise.Administration.Domain.Aggregation.Survey;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    public class SurveyViewModel : EntityViewModelPersistent<Guid, Survey>
    {
        public SurveyStatus Status { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public byte[] Image { get; set; }
        public DateTime? CreationAt { get; set; }
        public Guid ChoiceGroupId { get; set; }
        public ChoiceGroupViewModel ChoiceGroup { get; set; }
        public Guid? BranchId { get; set; }
        public BranchViewModel Branch { get; set; }
        public uint ConcurrencyToken { get; set; }

        /// <summary>
        /// Survey branches
        /// </summary>
        public ICollection<SurveyBranchViewModel> SurveyBranches { get; set; } = new HashSet<SurveyBranchViewModel>();
    }
}
