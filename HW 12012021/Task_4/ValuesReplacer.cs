using System;

namespace HW_12012021.Task_4
{
    public static class ValuesReplacer
    {
        public static void SwapValues<T>(T firstValue, T secondValue)
        {
            var t = firstValue;
            firstValue = secondValue;
            secondValue = t;
            Console.WriteLine($"Произошел обмен значениями переменных. Теперь firstValue = {firstValue}, а secondValue = {secondValue}");
        }
        
        public static void SwapIntValuesWithoutTempVariable(int firstValue, int secondValue)
        {
            firstValue += secondValue;
            secondValue = firstValue - secondValue;
            firstValue -= secondValue;
            Console.WriteLine($"Произошел обмен значениями переменных. Теперь firstValue = {firstValue}, а secondValue = {secondValue}");
        }
    }
}