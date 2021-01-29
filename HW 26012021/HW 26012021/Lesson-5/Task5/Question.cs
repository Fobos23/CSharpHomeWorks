namespace Lesson_5.Task5
{
    public class Question
    {
        private string question;
        private string answer;
        
        public Question(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }

        public string _Question => question;
        public string _Answer => answer;
    }
}