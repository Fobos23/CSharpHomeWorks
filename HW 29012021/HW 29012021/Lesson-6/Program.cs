using System;
using System.Collections.Generic;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 0;
            Console.Write("Введи номер задачи от 1 до 3: ");
            if (!int.TryParse(Console.ReadLine(), out number) || number > 3)
                throw new ArgumentException("Вы ввели некорректное число!");

            switch(number)
            {
                case 1:
                    StartTask1();
                    break;
                case 2:
                    StartTask2();
                    break;
                case 3:
                    StartTask3();
                    break;
            }
        }

        private static void StartTask1()
        {
            var func = new Function();
            Console.WriteLine(func.PrepareFunctionToPrint(1, 3, func.QuadraticFunction));
            Console.WriteLine(func.PrepareFunctionToPrint(2, 4, func.SinusoidFunction));
        }

        private static void StartTask2()
        {
            Console.WriteLine("Функционал не реализован =( ");
        }

        private static void StartTask3()
        {
            var students = new List<Student> { 
                new Student(
                    "Вася",
                    "Пупкин",
                    "Корабелка",
                    "Пищепромка",
                    "Технический",
                    1,
                    18,
                    666,
                    "Санкт-Петербург"), 
                new Student(
                    "Максим",
                    "Лапшин",
                    "ГУАП",
                    "Инженер",
                    "Програмист",
                    3,
                    21,
                    1732,
                    "Санкт-Петербург"), 
                new Student(
                    "Андрей",
                    "Лапшин",
                    "Финек",
                    "ФинМенж",
                    "Высоких",
                    4,
                    22,
                    5500,
                    "Санкт-Петербург")
            };

            foreach (var student in students)
                Console.WriteLine(student.ToString());
            
            Console.WriteLine("\nСортированный список студентов:\n");
            
            var studentInfo = new StudentsInfo(students);

            var sortedStudebts = studentInfo.GetSortedStudents(StudentsParams.FirstName); // выбор параметра для сортировки

            foreach (var student in sortedStudebts)
                Console.WriteLine(student.ToString());
            
            Console.WriteLine($"Количество студентов, возраст которых от 18 до 20, составляет " +
                              $"{studentInfo.GetCountStudents(StudentsParams.Age, 18, 20)}");
            
            Console.WriteLine($"Количество студентов, которые учатся в СПб, составляет " +
                              $"{studentInfo.GetCountStudents(StudentsParams.City, "Санкт-Петербург")}");
            
            Console.WriteLine($"Количество студентов, которые учатся на 3 и 4 курсах, составляет " +
                              $"{studentInfo.GetCountStudents(StudentsParams.Course, 3, 4)}");
        }
    }
}