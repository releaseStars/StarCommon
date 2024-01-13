using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class EnumerableExtensions
    {

        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query.Skip(skipCount).Take(maxResultCount);
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool condition, Func<T, bool> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool condition, Func<T, int, bool> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

        /// <summary>
        /// 通过 condition 的结果行来决定是否执行 predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIfByCount<T>(this IEnumerable<T> query, Func<T, bool> predicate)
        {
            return query.Where(predicate).Any() ? query.Where(predicate) : query;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyName">属性名</param>
        /// <param name="asc">true：OrderBy False: OrderByDescending</param>
        /// <returns></returns>
        public static IQueryable<TSource> Sort<TSource>(this IQueryable<TSource> query, string propertyName, bool asc = true)
        {
            var parameter = Expression.Parameter(typeof(TSource), "e");
            var property = Expression.Property(parameter, propertyName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = asc ? "OrderBy" : "OrderByDescending";
            Expression queryExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(TSource), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );

            return query.Provider.CreateQuery<TSource>(queryExpression);
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyName"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public static IQueryable<TSource> ThenSort<TSource>(this IQueryable<TSource> query, string propertyName, bool asc = true)
        {
            var parameter = Expression.Parameter(typeof(TSource), "e");
            var property = Expression.Property(parameter, propertyName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = asc ? "ThenBy" : "ThenByDescending";
            Expression queryExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(TSource), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );

            return query.Provider.CreateQuery<TSource>(queryExpression);
        }

        public static IEnumerable<T> OrderByIf<T, TKey>(this IEnumerable<T> query, bool condition, Func<T, TKey> keySelector)
        {
            if (!condition)
            {
                return query;
            }

            return query.OrderBy(keySelector);
        }

        public static IEnumerable<T> OrderByDescendingIf<T, TKey>(this IEnumerable<T> query, bool condition, Func<T, TKey> keySelector)
        {
            if (!condition)
            {
                return query;
            }

            return query.OrderByDescending(keySelector);
        }

        /// <summary>
        /// 获取输入集合的交集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IReadOnlyList<T> Intersect<T>(this IEnumerable<IEnumerable<T>> items)
        {
            var result = new List<T>();
            var firstAdded = false;
            foreach (var item in items)
            {
                if (!firstAdded)
                {
                    firstAdded = true;
                    result.AddRange(item);
                }
                else
                {
                    result = result.Intersect(item).ToList();
                }
            }

            return result;
        }

        public static bool TryFirstOrDefault<T>(this IEnumerable<T> items, Func<T, bool> predicate, out T result)
        {
            foreach (var item in items)
            {
                if (predicate.Invoke(item))
                {
                    result = item;
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
