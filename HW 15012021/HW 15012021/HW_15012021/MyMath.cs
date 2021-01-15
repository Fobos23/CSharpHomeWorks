using System;
using System.Linq;

namespace HW_15012021
{
    public static class MyMath
    {
        public static T MinValue<T>(this T[] array) 
            where T : IComparable
        {
            for (var i = array.Length - 1; i > 0; i--)
            for (var j = 1; j <= i; j++)
            {
                var element1 = array[j - 1];
                var element2 = array[j];

                if (element1.CompareTo(element2) < 0) continue;
                array[j - 1] = element2;
                array[j] = element1;
            }

            return array[0];
        }

        public static int NumeralsCount<T>(this T number)
            where T : IComparable
        {
            return number.ToString().Length;
        }

        public static bool IsGoodNumber<T>(this T number)
            where T : IComparable
        {
            var castNumber = number.ToString();
            var sumNumerals = castNumber.Sum(numeral => int.Parse(numeral.ToString()));

            return int.Parse(castNumber) % sumNumerals == 0;
        }

        public static bool IsOddNumber(this int number)
        {
            return number % 2 > 0;
        }

        public static bool IsPositiveNumber(this string number)
        {
            return number[0] != '-';
        }

        public static void ShowAllNumbersBetweenTwoNumbers(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                return;
            Console.WriteLine(minValue);
            ShowAllNumbersBetweenTwoNumbers(minValue + 1, maxValue);
        }
        
        public static int GetSumNumbersBetweenTwoNumbers(int minValue, int maxValue)
        {
            if (minValue <= maxValue)
                return minValue + GetSumNumbersBetweenTwoNumbers(minValue + 1, maxValue);;
            return 0;
        }
    }
}