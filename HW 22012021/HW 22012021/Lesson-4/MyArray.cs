using System;
using System.Collections.Generic;

namespace Lesson_4
{
    public class MyArray
    {
        private int[] array;
        private int sumElements;
        private int arrayLength;

        public MyArray(int[] array)
        {
            this.array = array;
            arrayLength = array.Length;
        }
        
        public MyArray(int arrayLength)
        {
            this.arrayLength = arrayLength;
            array = new int[arrayLength];
        }

        public int ArrayLength
        {
            get => arrayLength;
        }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public void SetRandomNumbers(int minValueRange, int maxValueRange)
        {
            var rand = new Random();
            for (var i = 0; i < arrayLength; i++)
                array[i] = rand.Next(minValueRange, maxValueRange);
        }

        public int GetBigramsCount(int denominator)
        {
            return FrequencyAnalyser.GetBigramsCount(array, denominator);
        }
    }
}