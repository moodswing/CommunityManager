using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityManager.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static bool NotIn<T>(this T extended, IEnumerable<T> filter)
        {
            return !extended.In(filter);
        }

        public static bool In<T>(this T extended, IEnumerable<T> filter)
        {
            return filter.Contains(extended);
        }
    }
}