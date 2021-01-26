using System.Globalization;
using System.Text.RegularExpressions;

namespace Lesson_5
{
    public class Auth
    {
        public bool SignUp(string login, string pass)
        {
            return IsCorrectLogin(login);
        }
        
        /// <summary>
        /// Тестовая перегрузка, для вызова метода проверки логина без регулярок
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool SignUp(string login)
        {
            return IsCorrectlyLogin(login);
        }

        private bool IsCorrectLogin(string login)
        {
            var pattern = @"^[^0-9][A-Za-z0-9]{1,9}$";
            var rgx = new Regex(pattern);
            return rgx.IsMatch(login);
        }

        private bool IsCorrectlyLogin(string login)
        {
            if (char.IsDigit(login[0]) 
                || login.Length < 2 || login.Length > 10)
                return false;

            foreach (var sign in login)
            {
                if (!(char.IsDigit(sign) 
                    || sign >= 'a' && sign <= 'z' 
                    || sign >= 'A' && sign <= 'Z'))
                    return false;
            }

            return true;
        }
    }
}