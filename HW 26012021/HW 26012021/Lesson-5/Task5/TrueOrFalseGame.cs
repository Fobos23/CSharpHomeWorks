using System;
using System.Collections.Generic;

namespace Lesson_5.Task5
{
    public class TrueOrFalseGame
    {
        private List<Question> questions;
        private List<int> rndNumbers;
        
        public TrueOrFalseGame()
        {
            var db = new DbDecorator();
            questions = db.Questions;
            rndNumbers = new List<int>();
        }

        public List<Question> GetRandomQuestion()
        {
            var rnd = new Random();
            var result = new List<Question>();

            while (rndNumbers.Count < 5)
            {
                var rndNumber = rnd.Next(0, questions.Count - 1);
                if(rndNumbers.Contains(rndNumber))
                    continue;
                rndNumbers.Add(rndNumber);
                result.Add(questions[rndNumber]);
            }

            return result;
        }

        public bool CheckResult(Question question, string inputAnswer)
        {
            return question._Answer.Equals(inputAnswer);
        }
    }
}