using System;
using System.Collections.Generic;

namespace Common
{
    public static class CollectionUtilities
    {
        public static IEnumerable<TTo> ConvertAll<TFrom, TTo>(this IEnumerable<TFrom> from, Func<TFrom, TTo> converter)
        {
            if (from == null)
            {
                yield break;
            }

            foreach (var item in from)
            {
                yield return converter(item);
            }
        }
    }
}
