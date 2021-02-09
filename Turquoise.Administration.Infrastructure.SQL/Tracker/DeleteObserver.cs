using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Turquoise.Administration.Infrastructure.SQL.Tracker
{
    using Turquoise.Administration.Domain.Abstraction;
    internal sealed class DeleteObserver : IObserver<IEnumerable<EntityEntry>>
    {
        public void Subscribe(IEnumerable<EntityEntry> parameter)
        {
            IEnumerable<EntityEntry> entries = parameter.Where(e => e.State == EntityState.Deleted);
        }
    }
}
