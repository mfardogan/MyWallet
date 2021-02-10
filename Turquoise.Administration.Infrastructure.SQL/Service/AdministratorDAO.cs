﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    public class AdministratorDAO : CrudService<Administrator, Guid>, IAdministratorDAO
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Administrator Get(Guid id)
        {
            return RepositoryContext
                .Include(e => e.Password)
                .AsNoTracking()
                .SingleOrDefault(e => e.Id == id);
        }
    }
}
