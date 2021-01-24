using System;
using System.IO;

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

            switch (number)
            {
                case 1:
                    StartTask1();
                    break;
                case 2:
                    StartTask2();
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
            Console.WriteLine(
                $"\nКоличетсво биграмм, в которых хотя бы 1 число делиться на {denominator} без остатка, равно {bigramsCount}");
        }

        private static void StartTask2()
        {
            /*а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив заданной
             размерности и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, 
             которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, 
             метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее 
             количество максимальных элементов. В Main продемонстрировать работу класса.
            б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.*/

            var startNumber = 1;
            var step = 4;
            var length = 5;
            var myArray = new MyArray(length, startNumber, step);

            Console.WriteLine($"Исходный массив с длиной {length}. Начинается с {startNumber}. Имеет шаг {step}");
            for (var i = 0; i < myArray.ArrayLength; i++)
                Console.Write($"{myArray[i]} ");

            Console.WriteLine($"\nСумма элементов массива: {myArray.SumElements}");
            
            Console.WriteLine("Инверсия знаков");
            myArray.Inverse();
            for (var i = 0; i < myArray.ArrayLength; i++)
                Console.Write($"{myArray[i]} ");

            var number = 2;
            Console.WriteLine($"\nУмножение элементов массива на {number}");
            myArray.Multi(number);
            for (var i = 0; i < myArray.ArrayLength; i++)
                Console.Write($"{myArray[i]} ");
            
            Console.WriteLine("\nСоздаем новый массив");
            myArray = new MyArray(new []{10, 2, 10, 3, 4, 5, 10});
            for (var i = 0; i < myArray.ArrayLength; i++)
                Console.Write($"{myArray[i]} ");
            Console.WriteLine($"\nКоличество максимальных элементов: {myArray.MaxCount}");
            
            Console.WriteLine("Массив из файла DataArray");
            var pathToRead = $"{AppDomain.CurrentDomain.BaseDirectory}DataArray";
            myArray = new MyArray();
            myArray.GetDataFromFile(pathToRead);
            for (var i = 0; i < myArray.ArrayLength; i++)
                Console.Write($"{myArray[i]} ");
            
            var pathToWrite = $"{AppDomain.CurrentDomain.BaseDirectory}DataArray{DateTime.Now:yyyyMMddhhmmss}";
            Console.WriteLine($"\nЗапись массива в файл {pathToWrite}. После отоработки программы, файл удалится");
            myArray = new MyArray(5);
            myArray.SetRandomNumbers(-100, 100);
            myArray.SetDataToFile(pathToWrite);
            
            using (var sr = File.OpenText(pathToWrite))
            {
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                    Console.WriteLine(line);
            }
            File.Delete(pathToWrite);
        }
    }
}