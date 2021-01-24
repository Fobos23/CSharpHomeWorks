using System;

namespace Lesson_4
{
    class Program
    {
        // Выполнил Андрей Лапшин
        
        static void Main(string[] args)
        {
            var number = 0;
            Console.Write("Введи номер задачи от 1 до 4: ");
            if (!int.TryParse(Console.ReadLine(), out number) || number > 4)
                throw new ArgumentException("Вы ввели некорректное число!");

            switch(number)
            {
                case 1:
                    StartTask1();
                    break;
            }
        }

        private static void StartTask1()
        {
            /* Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения
               от –10 000 до 10 000 включительно. Написать программу, позволяющую найти и вывести количество
               пар элементов массива, в которых хотя бы одно число делится на 3. В данной задаче под парой
               подразумевается два подряд идущих элемента массива. Например, для массива из
               пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.*/
            
            var myArray = new MyArray(20);
            
            myArray.SetRandomNumbers(-10000, 10000);
            for (var i = 0; i < myArray.ArrayLength; i++)
                Console.WriteLine($"{myArray[i]} ");

            var denominator = 3;
            var bigramsCount = myArray.GetBigramsCount(denominator);
            Console.WriteLine($"\nКоличетсво биграмм, в которых хотя бы 1 число делиться на {denominator} без остатка, равно {bigramsCount}");
        }
    }
}