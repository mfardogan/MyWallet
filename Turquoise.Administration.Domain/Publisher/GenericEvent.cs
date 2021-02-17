using MediatR;

namespace Turquoise.Administration.Domain.Publisher
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
