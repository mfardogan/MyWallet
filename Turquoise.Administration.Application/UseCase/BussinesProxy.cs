﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;

    public class BussinesProxy<TDAO> : Bussines where TDAO : IDAO
    {
        private readonly Lazy<IUoW> lazyUoW;
        public BussinesProxy() => (DataAccessObject, lazyUoW) =
            (Dependency.Get<TDAO>(), new Lazy<IUoW>(
                () => Dependency.Get<IUoW>()));

        /// <summary>
        /// Aggregation service
        /// </summary>
        public TDAO DataAccessObject { get; }

        /// <summary>
        /// Save changes async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveAsync(CancellationToken cancellationToken = default) => lazyUoW.Value.SaveAsync(cancellationToken);

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <returns></returns>
        public ITransaction BeginTransaction() => lazyUoW.Value.BeginTransaction();

        /// <summary>
        /// Get service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ServiceAs<T>() where T : IDAO => lazyUoW.Value.ServiceAs<T>();
    }
}
