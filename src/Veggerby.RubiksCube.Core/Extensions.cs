using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public static class Extensions
    {
        public static T SelectRandom<T>(this IEnumerable<T> list)
        {
            return list.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}