using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Turquoise.Administration.Application.Subscriber
{
    using Turquoise.Administration.Domain.Publisher;
    using Turquoise.Administration.Domain.Aggregate.ChoiceGroup;

    public sealed class ChoiceListEventHandler : INotificationHandler<GenericEvent<IEnumerable<Choice>>>
    {
        public Task Handle(GenericEvent<IEnumerable<Choice>> notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
