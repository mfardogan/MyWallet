using AutoMapper;
using System;
using System.Collections.Generic;

namespace Turquoise.Administration.Application.UseCase
{
    using Turquoise.Administration.Domain;

    public static class Mapper
    {
        private static readonly IMapper mapper;
        static Mapper() => mapper = Dependency.Get<IMapper>();

        /// <summary>
        /// Map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public T Map<T>(this object obj) where T : class
        {
            return (obj is null) ? null : 
                (T)mapper.Map(obj, obj.GetType(), 
                    typeof(T));
        }

        /// <summary>
        /// Map with action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        static public T Map<T>(this object obj, Action<T> action) where T : class
        {
            if (obj is null)
            {
                return null;
            }

            var ent = Map<T>(obj);
            action(ent);
            return ent;
        }

        /// <summary>
        /// Map collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vs"></param>
        /// <returns></returns>
        static public IEnumerable<T> Map<T>(this IEnumerable<object> vs) where T : class
        {
            return (vs is null) ? null : 
                (IEnumerable<T>)mapper.Map(vs, vs.GetType(), 
                    typeof(IEnumerable<T>));
        }

        /// <summary>
        /// Map collection with action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vs"></param>
        /// <returns></returns>
        static public IEnumerable<T> Map<T>(this IEnumerable<object> vs, Action<T> action) where T : class
        {
            if (vs is null)
            {
                return null;
            }

            IEnumerable<T> collection = 
                (IEnumerable<T>)mapper.Map(vs, vs.GetType(),
                    typeof(IEnumerable<T>));

            foreach (var item in collection)
            {
                action(item);
            }
            return collection;
        }
    }
}
