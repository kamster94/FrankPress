using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace FrankPress.DataAccess.Extensions
{
    public static class DbSetExtensions
    {

        public static IQueryable<T>? Set<T>(this DbContext context)
        {
            MethodInfo? method = typeof(DbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                 .FirstOrDefault(x => x.Name == nameof(DbContext.Set));

            method = method?.MakeGenericMethod(typeof(T));

            return method?.Invoke(context, null) as IQueryable<T>;
        }
    }
}
