using System;
using System.Collections.Generic;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO
{
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    public class ChoiceGroupViewModel : EntityViewModelPersistent<Guid, ChoiceGroup>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public uint ConcurrencyToken { get; set; }

        /// <summary>
        /// Choices
        /// </summary>
        public ICollection<ChoiceViewModel> Choices { get; set; } = new HashSet<ChoiceViewModel>();
    }
}
