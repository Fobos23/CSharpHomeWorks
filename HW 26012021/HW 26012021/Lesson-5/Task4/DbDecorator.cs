using System;
using System.Collections.Generic;

namespace Lesson_5.Task4
{
    public class DbDecorator
    {
        private readonly string dbName = "DataBaseImitator";
        private string pathToDb;
        private FilesWorker _filesWorker;

        public DbDecorator()
        {
            pathToDb = $"{AppDomain.CurrentDomain.BaseDirectory}/Task4/{dbName}";
            _filesWorker = new FilesWorker
            {
                PathToRead = pathToDb
            };
            disciples = UploadDb();
        }

        private List<Disciple> disciples;
        public List<Disciple> Disciples => disciples;
        
        private List<Disciple> UploadDb()
        {
            var result = new List<Disciple>(); 
            
            foreach (var line in _filesWorker.Read())
            {
                var tmp = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var lastName = tmp[0];
                var firstName = tmp[1];
                var secondName = tmp[2];
                var ratings = new List<int>();

                for (var i = 3; i < tmp.Length; i++)
                {
                    if (!int.TryParse(tmp[i], out var rating))
                        throw new ArgumentException("Некорректная запись оценки в базе");
                    ratings.Add(rating);
                }
                
                result.Add(new Disciple(lastName, firstName, secondName, ratings));
            }

            return result;
        }
    }
} 