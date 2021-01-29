using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_5.Task4
{
    public class FilesWorker
    {
        public string PathToRead { get; set; }
        public string PathToWrite { get; set; }

        public List<string> Read()
        {
            try
            {
                var result = new List<string>();
                using (var sr = new StreamReader(PathToRead))
                {
                    var line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                        result.Add(line);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Файл не может быть считан. {e}");
                throw;
            }
        }

        public void Write(List<string> values)
        {
            using (var sw = new StreamWriter(PathToWrite))
            {
                foreach (var value in values)
                {
                    sw.WriteLine(value);
                }
            }
        }
    }
} 