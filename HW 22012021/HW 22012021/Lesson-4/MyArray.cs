using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_4
{
    public class MyArray
    {
        private int[] array;
        private int sumElements;
        private int arrayLength;
        private int maxCount;

        public MyArray() { }

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

        public MyArray(int arrayLength, int startNumber, int step = 1)
        {
            this.arrayLength = arrayLength;
            array = new int[arrayLength];
            SetArray(startNumber, step);
        }

        public int SumElements
        {
            get => GetSumElements();
        }

        public int[] Array
        {
            get => array;
        }

        public int ArrayLength
        {
            get => arrayLength;
        }

        public int MaxCount
        {
            get => GetMaxCount();
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

        public void Inverse()
        {
            for (var i = 0; i < ArrayLength; i++)
            {
                var temp = array[i].ToString();
                if (temp[0] == '-')
                {
                    array[i] = Math.Abs(array[i]);
                    continue;
                }

                array[i] *= -1;
            }
        }

        public void Multi(int number)
        {
            for (var i = 0; i < ArrayLength; i++)
                array[i] *= number;
        }

        public void GetDataFromFile(string pathToRead)
        {
            var _filesWorker = new FilesWorker {PathToRead = pathToRead};
            var tempArray = _filesWorker.Read().FirstOrDefault().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            arrayLength = tempArray.Length;
            array = new int[ArrayLength];
            
            for (var i = 0; i < tempArray.Length; i++)
                if (int.TryParse(tempArray[i], out var element))
                    array[i] = element;
        }

        public void SetDataToFile(string pathToWrite)
        {
            var _filesWorker = new FilesWorker {PathToWrite = pathToWrite};
            var tempArray = string.Empty;
            for (var i = 0; i < arrayLength; i++)
                tempArray += $"{array[i]} ";

            var value = new List<string> {tempArray};
            _filesWorker.Write(value);
        }

        private int GetMaxCount()
        {
            var tempArray = array;
            System.Array.Sort(tempArray);
            var maxValue = tempArray.Last();

            for (var i = ArrayLength - 1; i >= 0; i--)
            {
                if (tempArray[i] != maxValue) break;
                maxCount++;
            }
            
            return maxCount;
        }

        private int GetSumElements()
        {
            for (var i = 0; i < ArrayLength; i++)
                sumElements += array[i];

            return sumElements;
        }

        private void SetArray(int startNumber, int step)
        {
            array[0] = startNumber;
            for (var i = 1; i < ArrayLength; i++)
                array[i] = array[i - 1] + step;
        }
    }
}