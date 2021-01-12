using System;
using HW_12012021.Task_1;

namespace HW_12012021.Task_2
{
    public static class Bmi
    {
        public static void ShowUsersBmi(double usersBMI)
        {
            Console.WriteLine($"Индекс массы тела пользователя составляте: {usersBMI:F}");
        }

        public static double GetUsersBmi(User usersData)
        {
            var heightToMeters = usersData.Height / 100;
            return usersData.Weight / Math.Pow(heightToMeters, 2);
        }
    }
}