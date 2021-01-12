using System;
using HW_12012021.Task_3;

namespace HW_12012021.Task_5
{
    public static class MyVisitingCard
    {
        private const string Name = "Андрей";
        private const string Surname = "Лапшин";
        private const string City = "Санкт-Петербург";

        public static void Print(Point position = null, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.ForegroundColor = foregroundColor;

            var data = new[] { Name, Surname, City }; 
            position = position ?? new Point(0, 0);
            
            for (var i = 0; i < data. Length; i++) 
            {
                Console.SetCursorPosition(position.X, position.Y + i);
                Console.WriteLine($"{data[i]}");
            }
        }
    }
}