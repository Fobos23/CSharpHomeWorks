using System;
using System.Text;

namespace Lesson_5
{
    class Program
    {
        // Выполнил Андрей Лапшин

        static void Main(string[] args)
        {
            var number = 0;
            Console.Write("Введи номер задачи от 1 до 5: ");
            if (!int.TryParse(Console.ReadLine(), out number) || number > 5)
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

        private static void StartTask2()
        {
            /*  Разработать класс Message, содержащий следующие статические методы для обработки
                текста:
                    а) Вывести только те слова сообщения, которые содержат не более n букв.
                    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
                    в) Найти самое длинное слово сообщения.
                    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
                Продемонстрируйте работу программы на текстовом файле с вашей программой.*/


            Console.WriteLine("Для демонстрации подзадания А, выбери режим: 1 - дефолтное сообщение, 2 - ручной ввод сообещния");
            var type = Console.ReadLine();
            var inputMessage = string.Empty;
            switch (type)
            {
                case "2":
                    inputMessage = Console.ReadLine();
                    Console.WriteLine($"Кастомное сообщение: {inputMessage}");
                    break;
                default:
                    inputMessage = "Это дефолтное сообщение, для просмотра второго задания к пятому уроку.";
                    Console.WriteLine($"Дефолтное сообщение: {inputMessage}");
                    break;
            }
            
            var msg = new Message(inputMessage);

            var wordsLength = 6;
            var selectedWords = Message.GetWordsWithMaxLength(msg, wordsLength);
            Console.WriteLine($"Показываю все слова, с максимальной длиной {wordsLength}:");
            foreach (var word in selectedWords)
                Console.Write($"{word} ");
            
            
            Console.WriteLine("\n\nДемонстрация подзадания Б");
            var lastSign = "е";
            var parsedWords = Message.GetWordsWithoutWordsEndingSign(msg, lastSign);
            Console.WriteLine($"Показываю все слова, кроме слов с окончанием на {lastSign}");
            foreach (var word in parsedWords)
                Console.Write($"{word} ");
            
            Console.WriteLine("\n\nДемонстрация подзадачи В");
            var maxWord = Message.GetMaxWord(msg);
            Console.WriteLine($"Показываю слово максимальной длины: {maxWord}");
            
            Console.WriteLine("\nДемонстрация подзадачи Г");
            var maxWords = Message.GetAllMaxWords(msg);
            
            var sb = new StringBuilder();
            foreach (var word in maxWords)
                sb.Append($"{word} ");
            Console.WriteLine($"Показываю слова максимальной длины: {sb}");
        }

        private static void StartTask3()
        {
              /*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
               Регистр можно не учитывать:
                а) с использованием методов C#;
                б) *разработав собственный алгоритм.
                Например:
                badc являются перестановкой abcd.*/
            
            var s1 = "Привет";
            var s2 = "Тевирп";
            var ta = new TextAnalyzer(s1, s2);

            Console.WriteLine("Проверка втроенымми методами C#");
            Console.WriteLine(ta.CompareStrings() == 0
                ? $"Строка: {s2} является перестановкой строки: {s1}"
                : $"Строка: {s2} не является перестановкой строки: {s1}");
            
            Console.WriteLine("\nПроверка собственным алгоритмом");
            Console.WriteLine(ta.CompareStringsByAndrey() == 0
                ? $"Строка: {s2} является перестановкой строки: {s1}"
                : $"Строка: {s2} не является перестановкой строки: {s1}");
        }
    }
}