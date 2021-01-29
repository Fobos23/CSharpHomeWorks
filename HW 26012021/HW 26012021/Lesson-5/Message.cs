using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lesson_5
{
    public class Message
    {
        private string[] parsedMessage;
        private string message;
        
        public Message(string message)
        {
            this.message = message;
            parsedMessage = ParseMessage();
        }
        
        public string Msg => message;

        public static List<string> GetWordsWithMaxLength(Message message, int maxWordsLength)
        {
            var result = new List<string>();
            var pattern = $@"^[A-Za-zА-Яа-я-]{{0,{maxWordsLength}}}$";
            var rgx = new Regex(pattern);
            
            foreach (var word in message.parsedMessage)
                if (rgx.IsMatch(word))
                    result.Add(word);
            
            return result;
        }

        public static List<string> GetWordsWithoutWordsEndingSign(Message message, string lastSign)
        {
            var result = new List<string>();
            var pattern = $@"[A-Za-zА-Яа-я-]{{0,}}[{lastSign.ToUpper()}-{lastSign.ToLower()}]$";
            var rgx = new Regex(pattern);

            foreach (var word in message.parsedMessage)
                if (!rgx.IsMatch(word))
                    result.Add(word);
            
            return result;
        }

        public static string GetMaxWord(Message message)
        {
            var maxWord = string.Empty;
            
            foreach (var word in message.parsedMessage)
                if (word.Length >= maxWord.Length)
                    maxWord = word;

            return maxWord;
        }

        public static List<string> GetAllMaxWords(Message message)
        {
            var result = new List<string>();
            var maxWord = GetMaxWord(message);
            foreach (var word in message.parsedMessage)
                if (word.Length == maxWord.Length)
                    result.Add(word);

            return result;
        }

        private string[] ParseMessage()
        {
            var separators = new[] { " ", ",", ".", "!", "?", ":", ";" };
            return message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}