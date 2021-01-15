using System;

namespace HW_15012021
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выполнил Андрей Лапшин
            
            Console.WriteLine("Для запуска конкретного задания, введи цифры от 1 до 7");
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
                case "4":
                    StartTask4();
                    break;
                case "5":
                    StartTask5();
                    break;
                case "6":
                    StartTask6();
                    break;
                case "7":
                    StartTask7();
                    break;
            }
        }

        #region Task 1. Минимальное из трех
        private static void StartTask1()
        {
            // аписать метод, возвращающий минимальное из трёх чисел.

            Console.Clear();
                    
            var intNumbers = new[] { 11, 15, 2 };
            Console.WriteLine($"Минимальное число в массиве интов: {intNumbers.MinValue()}");

            var doubleNumbers = new[] { 10d, 5d, 43d };
            Console.WriteLine($"Минимальное число в массиве даблов: {doubleNumbers.MinValue()}");
        }
        #endregion

        #region Task 2. Подсчет количества цифр числа
        private static void StartTask2()
        {
            // Task2. Написать метод подсчета количества цифр числа.
            
            Console.Clear();

            var intNumber = 598347;
            var doubleNumber = 465d;
            var stringNumber = "1000";
            
            Console.WriteLine($"Количество цифр у числа {intNumber}: {intNumber.NumeralsCount()}\n" +
                              $"Количество цифр у числа {doubleNumber}: {doubleNumber.NumeralsCount()}\n" +
                              $"Количетсво цифр у числа {stringNumber}: {stringNumber.NumeralsCount()}");
        }
        #endregion

        #region Task 3. Сумма всех введенных положительных чисел

        private static void StartTask3()
        {
            // Task3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

            Console.Clear();
            
            Console.WriteLine("Вводи числа последовательно:");
            var sumOddPositiveNumber = Calculator.GetSumOddPositiveInputNumbers();
            Console.WriteLine($"Сумма введенных положительных нечетных чисел равна: {sumOddPositiveNumber}");
        }

        #endregion

        #region Task 4. Проверка логина и пароля

        private static void StartTask4()
        {
            /*Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина,
            если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод 
            проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает 
            его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.*/
            
            Console.Clear();
            var auth = new Auth();

            var tryCount = 0;
            do
            {
                Console.Write("Введите login: ");
                var login = Console.ReadLine();
                Console.Write("Введите pass: ");
                var pass = Console.ReadLine();

                if (auth.SignIn(login, pass))
                {
                    Console.WriteLine("Добро пожаловать!");
                    break;
                }
                
                ++tryCount;
                Console.WriteLine($"Логин или пароль был введен неверно, попробуйте еще раз.\nУ вас осталось {3 - tryCount} попыток");
            } while (tryCount < 3);
        }
        #endregion
        
        #region Task5. Программа: Диетолог
        private static void StartTask5()
        {
            /*а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и
             сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
             б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.*/

            Console.Clear();

            var bmi = new Bmi();
            
            Console.Write("Введите ваш рост: ");
            var height = Convert.ToDouble(Console.ReadLine() ?? "0");
            
            Console.Write("Введите ваш вес: ");
            var weight = Convert.ToDouble(Console.ReadLine() ?? "0");

            bmi.GetRecommendation(height, weight);
            bmi.GetRecommendedWeight(height, weight);
        }
        #endregion

        #region Task 6. Подсчет "хороших" чисел в диапозоне от 1 до 10 000 000
        private static void StartTask6()
        {
            /*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
             «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени 
             выполнения программы, используя структуру DateTime.
             */
            
            var start = DateTime.Now;
            var goodNumbersCount = 0;
            
            for (var i = 1; i <= 10000000; i++) // уменьшил диапозон до 10млн, чтобы можно было быстрее проверить логику работы
                if (i.IsGoodNumber())
                    goodNumbersCount++;

            Console.WriteLine($"Количество \"хороших\" чисел от 1 до 10 млн. составляет {goodNumbersCount}");
            
            var finish = DateTime.Now;
            Console.WriteLine($"Время выполнения программы составило {finish - start}");
        }
        #endregion

        #region Task 7. Сумма чисел через рекурсию
        /*a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.*/
        
        private static void StartTask7()
        {
            Console.Clear();
            Console.WriteLine("Вывод чисел на консоль от 1 до 10 через рекурсию:");
            MyMath.ShowAllNumbersBetweenTwoNumbers(1, 10);
            
            Console.WriteLine("Вывод суммы числел на консоль от 1 до 10 через рекурсию:");
            Console.WriteLine(MyMath.GetSumNumbersBetweenTwoNumbers(1, 10));
        }
        #endregion
    }
}