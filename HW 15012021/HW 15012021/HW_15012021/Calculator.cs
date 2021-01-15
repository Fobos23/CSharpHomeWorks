using System;

namespace HW_15012021
{
    public static class Calculator
    {
        public static int GetSumOddPositiveInputNumbers()
        {
            var sumOddPositiveNumbers = 0;
            
            while (true)
            {
                var number = Console.ReadLine();
                
                if(number == "0")
                    break;
                
                if (!CheckOddAndPositiveInputNumber(number))
                    continue;
                
                sumOddPositiveNumbers += int.Parse(number);
            }

            return sumOddPositiveNumbers;
        }

        private static bool CheckOddAndPositiveInputNumber(string number)
        {
            return number.IsPositiveNumber() && int.Parse(number).IsOddNumber();
        }
    }
}