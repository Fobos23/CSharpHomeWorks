using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_15012021
{
    public class DataBaseImitator
    {
        public int GetPass(string login)
        {
            if (FindUser(login))
                return Users[login];
            
            throw new Exception("Пользователя не существует");
        }

        public void SetUser(string login, int pass)
        {
            if (!FindUser(login))
                Users.Add(login, pass);
            throw new Exception("Пользователь уже существует");
        }
        
        private bool FindUser(string user)
        {
            return Users.Keys.Contains(user);
        }
        
        private Dictionary<string, int> Users = new Dictionary<string, int>
        {
            {"user", -1231865543}
        };
    }
}