namespace Lesson_4.Autorization
{
    public struct Account
    {
        private string login;
        private int pass;

        public Account(string login, int pass)
        {
            this.login = login;
            this.pass = pass;
        }

        public string Login
        {
            get => login;
        }

        public int Pass
        {
            get => pass;
        }
    }
}