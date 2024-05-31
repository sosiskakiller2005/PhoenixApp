using PhoenixApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixApp.AppData
{
    internal class AuthorisationHelper
    {
        private static PhoenixDbEntities _context = App.GetContext();
        public static User selectedUser;
        public static bool isLoggedIn = false;
        public static bool Authorise(string login, string password)
        {
            List<User> users = _context.User.ToList();

            if (login == "" && password == "")
            {
                MessageBoxHelper.Error("Введите логин и пароль");
                isLoggedIn = false;
                return false;
            }
            else if (login == "")
            {
                MessageBoxHelper.Error("Введите логин");
                isLoggedIn = false;
                return false;

            }
            else if (password == "")
            {
                MessageBoxHelper.Error("Введите пароль");
                isLoggedIn = false;
                return false;
            }
            else
            {
                foreach (User user in users)
                {
                    if (user.Login == login && user.Password == Convert.ToInt32(password))
                    {
                        selectedUser = user;
                        isLoggedIn = true;
                        return true;
                    }
                }
                if (selectedUser != null)
                {
                    return true;
                }
                else
                {
                    MessageBoxHelper.Error("Неправильно введен логин или пароль");
                    isLoggedIn = false;
                    return false;
                }
            }
        }
    }
}
