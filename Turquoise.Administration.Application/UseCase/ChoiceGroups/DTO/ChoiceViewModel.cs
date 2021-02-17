using System;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO
{
    using Turquoise.Administration.Domain.Aggregate.ChoiceGroup;

    public class ChoiceViewModel : EntityViewModelPersistent<Guid, Choice>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public uint Number { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public uint ConcurrencyToken { get; set; }
    }
}
