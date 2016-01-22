using System;
using System.Collections.Generic;

namespace BruPark.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Limit<T>(this List<T> list, int n)
        {
            return list.GetRange(0, Math.Min(list.Count, n));
        }
    }
}
