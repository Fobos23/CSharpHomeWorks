using System;
using HW_12012021.Task_1;
using HW_12012021.Task_2;
using HW_12012021.Task_3;
using HW_12012021.Task_4;
using HW_12012021.Task_5;
using HW_12012021.Task_6;

namespace HW_12012021
{
    class Program
    {
        static void Main()
        {
            // Выполнил Андрей Лапшин
            
            #region Программа "Анкета"
            /*
                Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
                    а) используя  склеивание;
	                б) используя форматированный вывод;
	                в) используя вывод со знаком $.
             */
            
            var usersData = Questionnaire.GetUsersData();
            Questionnaire.ShowUsersData(usersData);
            #endregion

            #region Рассчет индекс массы тела
            /*
                Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
                где m — масса тела в килограммах, h — рост в метрах.
             */
            Console.Clear();
            
            var usersBmi = Bmi.GetUsersBmi(usersData);
            Bmi.ShowUsersBmi(usersBmi);
            #endregion

            #region Рассчет растояния между точками
            /*
                а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2, y2 
                по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор 
                формата .2f (с двумя знаками после запятой);
                б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
             */
            Console.Clear();
            
            var firstPoint = new Point(2, 4);
            var secondPoint = new Point(4, 2);
            var pointsRangeFinder = new PointsRangeFinder(firstPoint, secondPoint);
            pointsRangeFinder.ShowPointsRange();
            #endregion

            #region Обмен значений двух переменных
            /*
                Написать программу обмена значениями двух переменных:
                    а) с использованием третьей переменной;
	                б) *без использования третьей переменной.
             */
            Console.Clear();
            
            ValuesReplacer.SwapValues("a", "b");
            ValuesReplacer.SwapValues(2d, 4d);
            ValuesReplacer.SwapIntValuesWithoutTempVariable(1, 2);
            #endregion
            
            #region Вывод ФИО на экран
            /*
                а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                б) *Сделать задание, только вывод организовать в центре экрана.
                в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
             */
            
            Console.Clear();
            
            MyVisitingCard.Print();
            
            var position = new Point(Console.WindowWidth/2, Console.WindowHeight/2); 
            MyVisitingCard.Print(position); 
            
            position = new Point(0,5);
            MyVisitingCard.Print(position, ConsoleColor.Yellow); 
            #endregion
            
            #region Создать вспомогательные методы для учебы
            /*
                *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause)
            */
            Console.Clear();

            var exampleText = "Текст, который мне нужно вывести на экран с помощью своего метода Print";
            
            Pause.SecondsTimeout(3); // условное ожидание
            Print.GetPrint(exampleText);

            #endregion
        }
    }
}