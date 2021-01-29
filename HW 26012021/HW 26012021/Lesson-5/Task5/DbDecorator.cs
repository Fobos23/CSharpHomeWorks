using System;
using System.Collections.Generic;
using Lesson_5.Task4;

namespace Lesson_5.Task5
{
    public class DbDecorator
    {
        private readonly string dbName = "QuestionsDataBase";
        private string pathToDb;
        private FilesWorker _filesWorker;

        public DbDecorator()
        {
            pathToDb = $"{AppDomain.CurrentDomain.BaseDirectory}/Task5/{dbName}";
            _filesWorker = new FilesWorker
            {
                PathToRead = pathToDb
            };
            questions = UploadDb();
        }

        private List<Question> questions;
        public List<Question> Questions => questions;
        
        private List<Question> UploadDb()
        {
            var result = new List<Question>(); 
            
            foreach (var line in _filesWorker.Read())
            {
                var tmp = line.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                var question = tmp[0];
                var answer = tmp[1];

                result.Add(new Question(question, answer));
            }

            return result;
        }
    }
} 