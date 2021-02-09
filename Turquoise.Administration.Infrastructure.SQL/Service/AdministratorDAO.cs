﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Domain.Aggregation.Common;

    public class AdministratorDAO : BaseService, IAdministratorDAO
    {
        public Administrator Delete(Guid id)
        {
            Administrator administrator = DbContext.Administrators.Single(e => e.Id == id);
            DbContext.Administrators.Remove(administrator);
            return administrator;
        }

        public Administrator Get(Guid id)
        {
            return DbContext.Administrators.SingleOrDefault(e => e.Id == id);
        }

        public Administrator[] Get(Expression<Func<Administrator, bool>> expression = null, Pagination pagination = null)
        {
            var (skip, rows) = ((pagination.Page - 1) * pagination.Rows, pagination.Rows);
            return DbContext.Administrators
                .Include(x => x.Password)
                .Where(expression)
                .Skip(skip)
                .Take(rows)
                .ToArray();
        }

        public Administrator Insert(Administrator entity)
        {
            var e = DbContext.Administrators.Add(entity);
            return e.Entity;
        }

        public Administrator Update(Administrator entity)
        {
            DbContext.Entry<Administrator>(entity).State = EntityState.Modified;
            return entity;
        }
    }
}