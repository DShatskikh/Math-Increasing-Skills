using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Core
{
    public static class ArrayExtension
    {
        public static T GetRandomItem<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
    }
}