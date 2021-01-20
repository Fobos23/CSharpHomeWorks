using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выполнил Андрей Лапшин

            Console.WriteLine("Для запуска конкретного задания, введи цифры от 1 до 3");
            var taskNumber = Console.ReadLine();

            switch (taskNumber)
            {
                case "1":
                    StartTask1();
                    break; 
                case "2":
                    StartTask2();
                    break;
                case "3":
                    StartTask3();
                    break;
            }
        }

        private static void StartTask1()
        {
            /*
             1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;
                б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;
             */

            Console.Clear();
            
            var complexStruct1 = new Complex(2,4);
            var complexStruct2 = new Complex(6,3);
            var sum = complexStruct1 + complexStruct2;
            Console.WriteLine($"Сложение комплексных числел: {complexStruct1} + {complexStruct2} = {sum}");
            
            var diff = complexStruct1 - complexStruct2;
            Console.WriteLine($"Разница комплексных числел: {complexStruct1} - {complexStruct2} = {diff}");
            
            var complexClass1 = new ComplexNumber(4, 10);
            var complexClass2 = new ComplexNumber(6, 1);
            var product = complexClass1 * complexClass2;
            Console.WriteLine($"Произведение комплексных числел: {complexClass1} * {complexClass2} = {product}");
            
            var quotient = complexClass1 / complexClass2;
            Console.WriteLine($"Частное комплексных числел: {complexClass1} / {complexClass2} = {quotient}");
        }
        
        private static void StartTask2()
        {
              /*а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
                Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести 
                на экран, используя tryParse;
                б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные 
                данные. При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;*/

              Console.Clear();
              
              Console.WriteLine("Вводи числа последовательно:");
              var sumOddPositiveNumber = Calculator.GetSumOddPositiveInputNumbers();
              Console.WriteLine($"Сумма введенных положительных нечетных чисел равна: {sumOddPositiveNumber}");
        }
        
        private static void StartTask3()
        { 
            /* Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
               Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, 
               демонстрирующую все разработанные элементы класса. 
               ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение -
               ArgumentException("Знаменатель не может быть равен 0");
               Добавить упрощение дробей.*/
            
            var fraction1 = new Fraction(3, 15);
            var fraction2 = new Fraction(1, 4);
            var sum = fraction1 + fraction2;
            Console.WriteLine($"Сложение дробей: {fraction1} + {fraction2} = {sum}");

            var diff = fraction1 - fraction2;
            Console.WriteLine($"Вычитание дробей: {fraction1} - {fraction2} = {diff}");
            
            fraction1 = new Fraction(1, 4);
            fraction2 = new Fraction(2, 4);
            var product = fraction1 * fraction2;
            Console.WriteLine($"Умножение дробей: {fraction1} * {fraction2} = {product}");

            var quotient = fraction1 / fraction2;
            Console.WriteLine($"Деление дробей: {fraction1} / {fraction2} = {quotient}");
        }
    }
}