using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TodoTestTask.BL.Model;

namespace TestTask.BL.Models
{
    public class User
    {
        private const string FilePath = "users.json";
        #region Свойства
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string UserPassword { get; set; }
        public List<TODO> Tasks { get; set; } = new List<TODO>();
        public string RolesUser { get; set; }


        #endregion

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="userPasswod"></param>
        /// <param name="roles"></param>
        /// <exception cref="ArgumentNullException"></exception>

        public User() { }
        public User(string login, string password, string roles)
        {
            LoginName = login;
            UserPassword = password;
            RolesUser = roles;

            string TasksList = JsonConvert.SerializeObject(Tasks);
            File.WriteAllText(FilePath, TasksList);
        }

    }
}
