using System;

namespace Lesson3
{
    public static class Calculator
    {
        public static int GetSumOddPositiveInputNumbers()
        {
            var sumOddPositiveNumbers = 0;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out var number))
                {
                    Console.WriteLine("Вы ввели некорректное число! Попробуйте еще раз. ");
                    continue;
                }

                if(number == 0)
                    break;

                if (!CheckOddAndPositiveInputNumber(number))
                    continue;

                sumOddPositiveNumbers += number;
            }

            return sumOddPositiveNumbers;
        }

        private static bool CheckOddAndPositiveInputNumber(int number)
        {
            return number.ToString().IsPositiveNumber() && number.IsOddNumber();
        }

        private static bool IsOddNumber(this int number)
        {
            return number % 2 > 0;
        }

        private static bool IsPositiveNumber(this string number)
        {
            return number[0] != '-';
        }
    }
}