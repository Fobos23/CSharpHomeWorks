using System;
using System.Collections.Generic;

namespace Lesson_5.Task4
{
    public class Disciple
    {
        public Disciple(string lastName, string firstName, string secondName, List<int> ratings)
        {
            LastName = lastName;
            FirstName = firstName;
            SecondName = secondName;
            this.ratings = ConvertListToRating(ratings);
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Length <= 20)
                    lastName = value;
                else
                    throw new ArgumentException("Фамилия не соответствует требованиям, как бы смешно это не звучало");    
            }
        }

        private string firstName;

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length <= 15)
                    firstName = value;
                else
                    throw new ArgumentException("Имя не соответствует требованиям, как бы смешно это не звучало");
            }
        }

        private string secondName;

        public string SecondName
        {
            get => secondName;
            private set => secondName = value;
        }

        private Rating ratings;
        public Rating Ratings => ratings;

        public override string ToString()
        {
            return string.Join(" ", 
                lastName, 
                firstName, 
                secondName, 
                ratings.ToString());
        }

        private Rating ConvertListToRating(List<int> inputRatings)
        {
            return new Rating(inputRatings);
        }
    }
}