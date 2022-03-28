using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SMartShop.Infra.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> collection, string orderBy)
            => ParseOrderBy(orderBy).Aggregate(collection, ApplyOrderBy);

        private static IEnumerable<OrderByInfo> ParseOrderBy(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                yield break;
            }

            var initial = true;
            var items = orderBy.Split(',');
            foreach (var item in items)
            {
                var pair = item.Trim().Split(' ');
                if (pair.Length > 2)
                {
                    throw new ArgumentException($"Invalid OrderBy string '{item}'. Order By Format: Property1, Property2 ASC, Property3 DESC");
                }

                var propertyName = pair[0].Trim();
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentException("Invalid Property. Order By Format: Property1, Property2 ASC, Property3 DESC");
                }

                var descending = pair.Length == 2 && "desc".Equals(pair[1].Trim(), StringComparison.OrdinalIgnoreCase);

                yield return new OrderByInfo { PropertyName = propertyName, Descending = descending, Initial = initial };
                initial = false;
            }
        }

        private static IQueryable<T> ApplyOrderBy<T>(IQueryable<T> collection, OrderByInfo orderByInfo)
        {
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            var props = orderByInfo.PropertyName.Split('.');
            foreach (var prop in props)
            {
                var pi = type.GetProperty(prop, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);
            var methodName = (!orderByInfo.Initial && collection is IOrderedQueryable<T> ? "ThenBy" : "OrderBy") + (orderByInfo.Descending ? "Descending" : string.Empty);

            return (IOrderedQueryable<T>)typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                    && method.IsGenericMethodDefinition
                    && method.GetGenericArguments().Length == 2
                    && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { collection, lambda });
        }

        private class OrderByInfo
        {
            public string PropertyName { get; set; }
            public bool Descending { get; set; }
            public bool Initial { get; set; }
        }
    }
}
