using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChangerKataVp
{
    public static class CoinChanger
    {
        public static int[] Compute(int changeAmount, int[] denominatorArray)
        {
            if (HasDuplicates(denominatorArray))
            {
                throw new InvalidDenominationException();
            }

            var orderedArray = denominatorArray.OrderByDescending(x => x).ToArray();
            var result = new int[denominatorArray.Length];

            for (int i = 0; i < orderedArray.Length; i++)
            {
                var denominatorArrayIndex = denominatorArray.ToList().IndexOf(denominatorArray.Single(x => x == orderedArray[i]));
                var coinValue = denominatorArray[denominatorArrayIndex];
                result[denominatorArrayIndex] = changeAmount / coinValue;
                changeAmount -= result[denominatorArrayIndex] * coinValue;
            }

            if (changeAmount != 0)
            {
                throw new UnchangeableAmountException();
            }

            return result;
        }

        private static bool HasDuplicates(int[] source)
        {
            var hs = new HashSet<int>(source);
            return hs.Count < source.Length;
        }
    }

    public class UnchangeableAmountException : Exception
    {
    }

    public class InvalidDenominationException : Exception
    {
    }
}
