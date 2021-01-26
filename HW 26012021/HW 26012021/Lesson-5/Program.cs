using System;

namespace Lesson_5
{
    class Program
    {
        // Выполнил Андрей Лапшин

        static void Main(string[] args)
        {
            var number = 0;
            Console.Write("Введи номер задачи от 1 до 4: ");
            if (!int.TryParse(Console.ReadLine(), out number) || number > 5)
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
            /* 1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином
               будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при 
               этом цифра не может быть первой:
               а) без использования регулярных выражений;
               б) с использованием регулярных выражений.*/

            var auth = new Auth();
            while (true)
            {
                Console.WriteLine("Проверка логина регуляркой!");
                Console.Write("Логин: ");
                var login = Console.ReadLine();
                if (auth.SignUp(login, "1234"))
                {
                   Console.WriteLine("Пользователь создан!");
                   break;
                }
                Console.WriteLine("Логин некорректный, придумайте новый");
            }
            
            while (true)
            {
                Console.WriteLine("Проверка логина без регулярок!");
                Console.Write("Логин: ");
                var login = Console.ReadLine();
                if (auth.SignUp(login))
                {
                    Console.WriteLine("Пользователь создан!");
                    break;
                }
                Console.WriteLine("Логин некорректный, придумайте новый");
            }
            
        }
    }
}