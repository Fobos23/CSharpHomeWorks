using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_4.Autorization
{
    public class DbDecorator
    {
        private readonly string dbName = "DataBase.txt";
        private string pathToDb;
        private List<Account> accounts;
        private FilesWorker _filesWorker;

        public DbDecorator()
        {
            pathToDb = $"{AppDomain.CurrentDomain.BaseDirectory}/Autorization/{dbName}";
            _filesWorker = new FilesWorker
            {
                PathToRead = pathToDb,
                PathToWrite = pathToDb
            };
            accounts = UploadDb();
        }

        public Account GetAccount(string login)
        {
            foreach (var account in accounts.Where(account => account.Login == login))
                return account;

            throw new ArgumentException($"Пользователя с логином: {login} нет в базе данных!");
        }

        public void SetAccount(Account newAccount)
        {
            if (accounts.Any(account => account.Login == newAccount.Login))
                throw new ArgumentException($"Пользователь с логином: {newAccount.Login} уже существует!");

            accounts.Add(newAccount);
            UpdateDb();
        }

        private List<Account> UploadDb()
        {
            var result = new List<Account>(); 
            foreach (var line in _filesWorker.Read())
            {
                var tmp = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var login = tmp[0];
                
                if (!int.TryParse(tmp[1], out var pass))
                    throw new ArgumentException("Некорректная запись пароля в базе");
                
                result.Add(new Account(login, pass));
            }

            return result;
        }

        private void UpdateDb()
        {
            var value = accounts.Select(account => $"{account.Login} {account.Pass}").ToList();
            _filesWorker.Write(value);
        }
    }
}