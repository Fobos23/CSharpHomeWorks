using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_15012021
{
    public class Bmi
    {
        public void GetRecommendedWeight(double height, double weight)
        {
            var userBmi = GetUsersBmi(height, weight);
            var minNormalBmi = 18.5;
            var maxNormalBmi = 25d;
            
            if (userBmi < minNormalBmi)
            {
                Console.WriteLine($"Надо набрать {GetNormalWeight(minNormalBmi, height) - weight:F} кг");
                return;
            }

            if (userBmi > maxNormalBmi)
            {
                Console.WriteLine($"Надо скинуть {weight - GetNormalWeight(maxNormalBmi, height):F} кг");
                return;
            }
            
            Console.WriteLine($"ИТМ: {userBmi:F}. Ваш ИМТ итак в норме. Диета не нужна");
        }

        public void GetRecommendation(double height, double weight)
        {
            var userBmi = GetUsersBmi(height, weight);
            foreach (var bodyMasIndex in BodyMasIndexes.Where(
                bodyMasIndex => userBmi <= bodyMasIndex.Key))
            {
                Console.WriteLine($"Ваш ИМТ: {userBmi:F}. У вас {bodyMasIndex.Value}");
                break;
            }
        }

        public double GetUsersBmi(double height, double weight)
        {
            return weight / Math.Pow(GetHeightToMeters(height), 2);
        }

        private static double GetNormalWeight(double normalBmi, double height)
        {
            return normalBmi * Math.Pow(GetHeightToMeters(height), 2);
        }

        private static double GetHeightToMeters(double height)
        {
            return height / 100;
        }

        private Dictionary<double, string> BodyMasIndexes = new Dictionary<double, string>
        {
            { 16, "Выраженный дефицит массы тела" },
            { 18.5, "Недостаточная масса тела" },
            { 25, "Норма"},
            { 30, "Избыточная масса тела" },
            { 35, "Ожирение"},
            { 40, "Ожирение резкое" },
            { double.MaxValue, "Очень резкое ожирение" }
        };
    }
}