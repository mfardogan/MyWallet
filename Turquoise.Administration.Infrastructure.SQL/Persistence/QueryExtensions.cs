using System.Linq;

namespace Turquoise.Administration.Infrastructure.SQL.Persistence
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    internal static class QueryExtensions
    {
        /// <summary>
        /// Pagination
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public static IQueryable<T> Page<T>(this IQueryable<T> items, Pagination pagination)
        {
            if (pagination is null)
            {
                return items;
            }

            var (page, rows) = (pagination.Page, pagination.Rows);
            return items.Skip((page - 1) * rows).Take(rows);
        }
    }
}
