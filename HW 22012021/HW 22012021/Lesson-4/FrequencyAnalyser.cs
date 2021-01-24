using System;
using System.Collections.Generic;

namespace Lesson_4
{
    public static class FrequencyAnalyser
    {
        /// <summary>
        /// Возвращает количество биграмм, в которых хотя бы один элемент делиться на number без остатка.
        /// </summary>
        /// <param name="number">Делитель для фильтрации биграмм</param>
        /// <returns></returns>
        public static int GetBigramsCount(int[] array, int number)
        {
            var count = 0;
            var bigrams = GetBigramsWithWeight(array);
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

        private static Dictionary<int, Dictionary<int, int>> GetBigramsWithWeight(int[] array)
        {
            var bigrams = new Dictionary<int, Dictionary<int, int>>();
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array.Length <= 1)
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