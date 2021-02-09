using System;
using Microsoft.EntityFrameworkCore;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    using MyWallet.Administration.Domain.Aggregation.Common;

    public partial class MyDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.DefaultSqlValues(
                filter: e => e.ClrType.BaseType == typeof(Entity<Guid>),
                propertyName: nameof(Entity<Guid>.Id),
                defaultSqlValue: "uuid_generate_v4()"
                );

            modelBuilder.DefaultSqlValues(
                filter: e => e.ClrType.BaseType.IsGenericType && e.ClrType.BaseType.GetGenericTypeDefinition() == typeof(Entity<>),
                propertyName: nameof(Entity<object>.RowGuid),
                defaultSqlValue: "uuid_generate_v4()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
