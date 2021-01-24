using System;

namespace Lesson_4.Autorization
{
    public class Auth
    {
        private DbDecorator _dbDecorator = new DbDecorator();
        
        public bool SignIn(string login, string pass)
        {
            try
            {
                var account = _dbDecorator.GetAccount(login);
                return IsCorrectlyPass(pass, account.Pass);
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
                var newAccount = new Account(login, pass.GetHashCode());
                _dbDecorator.SetAccount(newAccount);
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