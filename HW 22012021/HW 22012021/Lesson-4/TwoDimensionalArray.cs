using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_4
{
    public class TwoDimensionalArray
    {
        private int[,] array;
        private int arrayLength;
        private int width;
        private int height;
        private int minValue;
        private int maxValue;

        public TwoDimensionalArray(string pathToFile)
        {
            GetDataFromFile(pathToFile);
        }
        
        public TwoDimensionalArray(int[,] array)
        {
            this.array = array;
            arrayLength = array.Length;
            width = array.GetLength(0);
            height = array.GetLength(1);
        }

        public TwoDimensionalArray(int width, int height)
        {
            this.width = width;
            this.height = height;
            array = new int[this.width,this.height];
            arrayLength = array.Length;
        }

        public int MinValue => GetMinValue();
        public int MaxValue => GetMaxValue();
        public int Width => width;
        public int Height => height;

        public int this[int indexX, int indexY]
        {
            get => array[indexX, indexY];
            set => array[indexX, indexY] = value;
        }

        public void SetRandomNumbers(int minValue, int maxValue)
        {
            var rnd = new Random();
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    array[i, j] = rnd.Next(minValue, maxValue);
        }

        public int GetSumElements()
        {
            var sum = 0;
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    sum += array[i, j];
            return sum;
        }

        /// <summary>
        /// Возвращает сумму всех элементов массива, которые больше number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GetSumElements(int number)
        {
            var sum = 0;
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                {
                    if (array[i,j] <= number) continue;
                    sum += array[i, j];
                }

            return sum;
        }

        public void GetMaxValueIndex(out string index)
        {
            var max = 0;
            var x = 0;
            var y = 0;
            
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                {
                    if (max >= array[i, j]) continue;
                    max = array[i, j];
                    x = i;
                    y = j;
                }
            index = $"[{x}, {y}]";
        }

        private int GetMinValue()
        {
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    minValue = minValue <= array[i, j] ? minValue : array[i, j];
            return minValue;
        }
        
        private int GetMaxValue()
        {
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    maxValue = maxValue >= array[i, j] ? maxValue : array[i, j];
            return maxValue;
        }
        
        public void GetDataFromFile(string pathToRead)
        {
            var _filesWorker = new FilesWorker {PathToRead = pathToRead};
            var tempArray = _filesWorker.Read();

            height = tempArray.Count;
            width = tempArray.FirstOrDefault().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length;
            array = new int[width,height];

            for (var i = 0; i < height; i++)
            {
                var values = tempArray[i].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < width; j++)
                {
                    if (int.TryParse(values[j], out var element))
                        array[j, i] = element;
                }
            }
        }

        public void SetDataToFile(string pathToWrite)
        {
            var _filesWorker = new FilesWorker {PathToWrite = pathToWrite};
            var values = new List<string>();
            
            for (var i = 0; i < height; i++)
            {
                var raw = string.Empty;
                for (var j = 0; j < width; j++)
                    raw += $"{array[j, i]} ";
                values.Add(raw);
            }
            
            _filesWorker.Write(values);
        }
    }
}