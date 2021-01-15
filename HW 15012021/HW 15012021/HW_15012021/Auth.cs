using System;

namespace HW_15012021
{
    public class Auth
    {
        private DataBaseImitator _dataBaseImitator = new DataBaseImitator();
        
        public bool SignIn(string login, string pass)
        {
            try
            {
                var hashPass = _dataBaseImitator.GetPass(login);
                return IsCorrectlyPass(pass, hashPass);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SignUp(string login, string pass)
        {
            try
            {
                _dataBaseImitator.SetUser(login, pass.GetHashCode());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool IsCorrectlyPass(string inputPass, int hashPass)
        {
            return inputPass.GetHashCode().Equals(hashPass);
        }
    }
}