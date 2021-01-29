﻿using System;
using System.Text;
using Lesson_5.Task4;
using Lesson_5.Task5;

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
                case 4: 
                    StartTask4();
                    break;
                case 5:
                    StartTask5();
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

        private static void StartTask4()
        {
            /*  На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
                школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
                превосходит 100, каждая из следующих N строк имеет следующий формат:
                <Фамилия> <Имя> <оценки>,
                где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
                более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
                пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
                Пример входной строки:
                Иванов Петр 4 5 3
                Требуется написать как можно более эффективную программу, которая будет выводить на экран
                фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
                набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.*/
            
            var examResultPrinter = new ExamResultPrinter();
            Console.WriteLine(examResultPrinter.GetText());
        }

        private static void StartTask5()
        {
            /*Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. Например:
             «Шариковую ручку изобрели в древнем Египте», «Да». Компьютер загружает эти данные, случайным 
             образом выбирает 5 вопросов и задаёт их игроку. Игрок отвечает Да или Нет на каждый вопрос и 
             набирает баллы за каждый правильный ответ. Список вопросов ищите во вложении или воспользуйтесь 
             интернетом.*/
            
            Console.WriteLine("Игра \"Правки или Ложь\"" +
                              "\nОтвечай на вопросы только \"Да\" или \"Нет\"" +
                              "\nЗа каждый правильный ответ ты получаешь 5 баллов");
            
            var game = new TrueOrFalseGame();
            var questions = game.GetRandomQuestion();
            var score = 0;
            
            foreach (var question in questions)
            {
                Console.Write($"{question._Question}? Ваш ответ: ");
                var inputAnswer = Console.ReadLine();
                if (game.CheckResult(question, inputAnswer))
                {
                    Console.WriteLine("Правильно!");
                    score += 5;
                    continue;
                }
                Console.WriteLine("Неверно..");
            }
            
            Console.WriteLine($"Вы набрали {score} очков!");
        }
    }
}