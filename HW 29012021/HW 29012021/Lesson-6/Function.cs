using System;
using System.Text;

namespace Lesson_6
{
    public class Function
    {
        private StringBuilder _stringBuilder;
        
        public Function()
        {
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// Квадратичная функция y = a*x^2
        /// </summary>
        /// <returns></returns>
        public double QuadraticFunction(double a, double x)
        {
            var funcToString = $"{a} * {x}^2";
            _stringBuilder.Clear();
            _stringBuilder.Append(funcToString);
            return a * Math.Pow(x, 2);
        }
        
        /// <summary>
        /// Функция синусоида y = a*sin(x)
        /// </summary>
        /// <returns></returns>
        public double SinusoidFunction(double a, double x)
        {
            var funcToString = $"{a} * sin(x)";
            _stringBuilder.Clear();
            _stringBuilder.Append(funcToString);
            return a * Math.Sin(x);
        }

        public string PrepareFunctionToPrint(double a, double x, Func<double, double, double> func)
        {
            var resultToString = $" = {func(a, x):F}";
            return _stringBuilder.Append(resultToString).ToString();
        }
    }
}