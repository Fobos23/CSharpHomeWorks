using System;

namespace HW_12012021.Task_1
{
    public static class Questionnaire
    {
        public static User GetUsersData()
        {
            var name = AskAndWriteAnswer("Как тебя зовут?");
            var surname = AskAndWriteAnswer("Какая у тебя фамилия?");
            var age = AskAndWriteAnswer("Сколько тебе лет?");
            var height = AskAndWriteAnswer("Какой у тебя рост?");
            var weight = AskAndWriteAnswer("Какой у тебя вес?");

            return new User(name, surname, int.Parse(age), double.Parse(height), double.Parse(weight));
        }

        public static void ShowUsersData(User usersData)
        {
            Console.WriteLine("Вывод данных через конкатенацию строк, V1 - " + 
                              "Имя: " + usersData.Name + " " +
                              "Фамилия: " + usersData.Surname + " " + 
                              "Возраст: " + usersData.Age + " " +
                              "Рост: " + usersData.Height + " " +
                              "Вес: " + usersData.Weight);
            
            Console.WriteLine(string.Concat("Вывод данных через конкатенацию строк, V2 - ", 
                "Имя: ", usersData.Name, " ",
                "Фамилия: ", usersData.Surname, " ",
                "Возраст: ", usersData.Age, " ",
                "Рост: " + usersData.Height, " ",
                "Вес: " + usersData.Weight));
            
            Console.WriteLine("Форматированный вывод данных - Имя: {0} Фамилия: {1} Возраст: {2:D} Рост: {3:F1} Вес: {4:F1}", 
                usersData.Name, usersData.Surname, usersData.Age, usersData.Height, usersData.Weight);
            
            Console.WriteLine("Вывод данных через интерполяцию строк - " +
                              $"Имя: {usersData.Name} " +
                              $"Фамилия: {usersData.Surname} " +
                              $"Возраст: {usersData.Age} " +
                              $"Рост: {usersData.Height} " +
                              $"Вес: {usersData.Weight}");
        }

        private static string AskAndWriteAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}