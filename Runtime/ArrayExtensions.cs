
using System;

namespace Artmine15.Extensions
{
    public static class ArrayExtensions
    {
        public static T GetLastElement<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
                throw new Exception("Array has no elements.");

            return array[array.Length - 1];
        }
    }
}

