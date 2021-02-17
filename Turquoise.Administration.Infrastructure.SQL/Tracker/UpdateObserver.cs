using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Turquoise.Administration.Infrastructure.SQL.Tracker
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;

    internal sealed class UpdateObserver : IObserver<IEnumerable<EntityEntry>>
    {
        public void Subscribe(IEnumerable<EntityEntry> parameter)
        {
            IEnumerable<EntityEntry> entries = parameter.Where(e => e.State == EntityState.Modified);
            foreach (var item in entries)
            {
                item.Property("Id").IsModified = false;
                item.Property("RowGuid").IsModified = false;

                if (item.Entity is ICreationAt)
                {
                    item.Property(nameof(ICreationAt.CreationAt)).IsModified = false;
                }
            }
        }
    }
}
