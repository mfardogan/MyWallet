using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    internal static class BuilderExtensions
    {
        public static void DefaultSqlValues(this ModelBuilder modelBuilder, Func<IMutableEntityType, bool> filter, string propertyName, string defaultSqlValue)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(filter)
                .Select(e => e.ClrType)
                .ToList()
                .ForEach(e =>
                {
                    modelBuilder.Entity(e)
                    .Property(propertyName)
                    .HasDefaultValueSql(defaultSqlValue);
                });
        }
    }
}
