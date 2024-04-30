using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class RegisterDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        int sameLogin;
        public bool RegisterCheck(string name, string login, string password)
        {
            connection.con.Open();
            string request = $"SELECT COUNT(*) FROM users WHERE Login = '{login}'";
            command.Connection = connection.con;
            command.CommandText = request;
            sameLogin = Convert.ToInt32(command.ExecuteScalar());
            if (sameLogin != 0)
            {
                connection.con.Close();
                return false;
            }
            else
            {
                request = "SELECT COUNT(*) FROM users";
                command.CommandText = request;
                int count = Convert.ToInt32(command.ExecuteScalar()) + 1;
                request = $"INSERT INTO users (ID, Login, Password, Username) VALUES ({count}, '{login}', '{password}', '{name}')";
                command.CommandText = request;
                command.ExecuteNonQuery();
                CurrentUserInfo.ID = count;
                CurrentUserInfo.Name = name;
                CurrentUserInfo.Login = login;
                connection.con.Close();
                return true;
            }
        }
    }
}
