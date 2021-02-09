using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Turquoise.Administration.Infrastructure.SQL.Tracker
{
    using Turquoise.Administration.Domain.Abstraction;
    public class ModelWatcherSubject : IObserverSubject<IEnumerable<EntityEntry>>
    {
        private readonly HashSet<IObserver<IEnumerable<EntityEntry>>> observers =
            new HashSet<IObserver<IEnumerable<EntityEntry>>>();

        /// <summary>
        /// Add observer
        /// </summary>
        /// <param name="observer"></param>
        public IObserverSubject<IEnumerable<EntityEntry>> AddObserver(IObserver<IEnumerable<EntityEntry>> observer)
        {
            observers.Add(observer);
            return this;
        }

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="parameter"></param>
        public void Publish(IEnumerable<EntityEntry> parameter)
        {
            foreach (IObserver<IEnumerable<EntityEntry>> observer in observers)
                observer.Subscribe(parameter);
        }
    }
}
