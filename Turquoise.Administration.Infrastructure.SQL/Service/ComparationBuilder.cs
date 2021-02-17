using System.Linq;
using System.Collections.Generic;
using System;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    internal sealed class ComparationBuilder<T>
    {
        private Action<T> action;
        private IEqualityComparer<T> equalityComparer;
        private IEnumerable<T> currentElements, newElements;

        /// <summary>
        /// Set equality
        /// </summary>
        /// <param name="equalityComparer"></param>
        /// <returns></returns>
        public ComparationBuilder<T> AddEqualityComparer(IEqualityComparer<T> equalityComparer)
        {
            this.equalityComparer = equalityComparer;
            return this;
        }

        /// <summary>
        /// Add current items
        /// </summary>
        /// <param name="currentElements"></param>
        /// <returns></returns>
        public ComparationBuilder<T> AddCurrents(IEnumerable<T> currentElements)
        {
            this.currentElements = currentElements;
            return this;
        }

        /// <summary>
        /// Add new items
        /// </summary>
        /// <param name="newElements"></param>
        /// <returns></returns>
        public ComparationBuilder<T> AddNews(IEnumerable<T> newElements)
        {
            this.newElements = newElements;
            return this;
        }

        /// <summary>
        /// Add new items
        /// </summary>
        /// <param name="newElements"></param>
        /// <returns></returns>
        public ComparationBuilder<T> AddActionForNews(Action<T> action)
        {
            this.action = action;
            return this;
        }

        /// <summary>
        /// Generate
        /// </summary>
        /// <returns></returns>
        public (T[] insert, T[] upadate, T[] remove) BuildTuple()
        {
            T[] add = newElements.Except(currentElements, equalityComparer).ToArray();
            T[] remove = currentElements.Except(newElements, equalityComparer).ToArray();
            T[] update = currentElements.Intersect(newElements, equalityComparer).ToArray();

            if (!(action is null))
            {
                foreach (T obj in add)
                    action(obj);
            }

            return (add, update, remove);
        }
    }
}
