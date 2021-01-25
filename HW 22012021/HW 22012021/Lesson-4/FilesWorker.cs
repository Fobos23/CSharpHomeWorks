using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;

namespace Lesson_4
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
            catch (FileLoadException e)
            {
                Console.WriteLine("Файл не может быть считан!");
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