using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_5.Task4
{
    public class Rating
    {
        public Rating(List<int> ratings)
        {
            this.ratings = ratings;
        }
        
        private List<int> ratings;

        public List<int> Ratings => ratings;
        public double Average => GetAverage();

        public override string ToString()
        {
            return string.Join(" ", ratings);
        }

        private double GetAverage()
        {
            return Math.Round(ratings.Average(), 2);
        }
    }
}