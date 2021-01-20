using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    internal static class BuilderExtensions
    {
        public static void ConcurrencyTokens(this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.GetInterfaces().Contains(typeof(IHasConcurrency)))
                .Select(e => e.ClrType)
                .ToList()
                .ForEach(e =>
                {
                    modelBuilder.Entity(e)
                    .Property(nameof(IHasConcurrency.RowVersion))
                    .IsRowVersion();
                });
        }

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
