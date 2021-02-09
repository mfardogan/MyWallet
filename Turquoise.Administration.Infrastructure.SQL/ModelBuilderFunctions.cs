﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Domain.Aggregation.Common;

    internal static class ModelBuilderFunctions
    {
        public static void ConcurrencyTokens(this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.BaseType==typeof(ConcurrencyEntity<>))
                .Select(e => e.ClrType)
                .ToList()
                .ForEach(e => modelBuilder.Entity(e).Property(nameof(ConcurrencyEntity<object>.ConcurrencyToken))
                     .HasColumnName("xmin")
                         .HasColumnType("xid")
                              .ValueGeneratedOnAddOrUpdate()
                                     .IsConcurrencyToken());
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