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

        /// <summary>
        /// Возвращает количество биграмм, в которых хотя бы один элемент делиться на number без остатка.
        /// </summary>
        /// <param name="number">Делитель для фильтрации биграмм</param>
        /// <returns></returns>
        public int GetBigramsCount(int number)
        {
            var count = 0;
            var bigrams = GetBigramsWithWeight();
            foreach (var bigram in bigrams)
            {
                if (bigram.Key % number != 0)
                {
                    foreach (var bigramValues in bigram.Value)
                    {
                        if (bigramValues.Key % number != 0)
                            continue;
                        count += bigramValues.Value;
                    }
                    continue;
                }

                foreach (var bigramValues in bigram.Value)
                    count += bigramValues.Value;
            }

            return count;
        }

        private Dictionary<int, Dictionary<int, int>> GetBigramsWithWeight()
        {
            var bigrams = new Dictionary<int, Dictionary<int, int>>();
            for (var i = 0; i < arrayLength - 1; i++)
            {
                if (arrayLength <= 1)
                    throw new ArgumentException("Для работы с биграммами, массив должен иметь > 1 элемента");
                
                var firstPartBigram = array[i];
                var secondPartBigram = array[i + 1];

                if (!bigrams.ContainsKey(firstPartBigram))
                    bigrams[firstPartBigram] = new Dictionary<int, int>();

                if (!bigrams[firstPartBigram].ContainsKey(secondPartBigram))
                    bigrams[firstPartBigram].Add(secondPartBigram, 1);
                else
                    bigrams[firstPartBigram][secondPartBigram]++;
            }
            return bigrams;
        }
    }
}