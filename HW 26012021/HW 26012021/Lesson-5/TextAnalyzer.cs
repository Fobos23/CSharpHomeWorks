using System;
using System.Linq;

namespace Lesson_5
{
    public class TextAnalyzer
    {
        private string firstString;
        private string secondString;
        
        public TextAnalyzer(string firstString, string secondString)
        {
            this.firstString = firstString;
            this.secondString = secondString;
        }

        public int CompareStrings()
        {
            if (firstString.Length != secondString.Length) return 2;
            var temp1 = firstString.ToLower().ToCharArray();
            var temp2 = secondString.ToLower().ToCharArray();
            Array.Sort(temp1);
            Array.Sort(temp2);
            
            return string.CompareOrdinal(temp1.ToString(), 0, temp2.ToString(), 0, temp1.Length);
        }
        
        public int CompareStringsByAndrey()
        {
            var temp1 = GetSumSign(firstString);
            var temp2 = GetSumSign(secondString);

            if (temp1 < temp2) return -1;
            return temp1 == temp2 ? 0 : 1;
        }

        private int GetSumSign(string inputString)
        {
            var sum = 0;
            foreach (var t in inputString)
                sum += t;
            return sum;
        }
        
    }
}