using MediatR;

namespace Turquoise.Administration.Domain.DomainEvent
{
    public sealed class GenericEvent<TArg> : INotification
    {
        public TArg Argument { get; set; }

        public GenericEvent(TArg argument)
        {
            Argument = argument;
        }
    }
}
