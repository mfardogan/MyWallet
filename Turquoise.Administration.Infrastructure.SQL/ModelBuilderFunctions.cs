using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    internal static class ModelBuilderFunctions
    {
        /// <summary>
        /// Add concurrency tokens for models
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void ConcurrencyTokens(this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.BaseType==typeof(Concurrency<>))
                .Select(e => e.ClrType)
                .ToList()
                .ForEach(e => modelBuilder.Entity(e).Property(nameof(Concurrency<object>.ConcurrencyToken))
                     .HasColumnName("xmin")
                         .HasColumnType("xid")
                              .ValueGeneratedOnAddOrUpdate()
                                     .IsConcurrencyToken());
        }

        /// <summary>
        /// Default value sql
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="filter"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultSqlValue"></param>
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
