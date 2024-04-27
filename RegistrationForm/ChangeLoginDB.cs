using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace RegistrationForm
{
    public class ChangeLoginDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        public bool ChangeL(string login)
        {
            connection.con.Open();
            request = $"SELECT COUNT(*) FROM users WHERE Login = '{login}'";
            command.Connection = connection.con;
            command.CommandText = request;
            if (Convert.ToInt32(command.ExecuteScalar()) != 0)
            {
                connection.con.Close();
                return false;
            }
            else
            {
                request = $"UPDATE users SET Login = '{login}' WHERE ID = {CurrentUserInfo.ID}";
                command.Connection = connection.con;
                command.CommandText = request;
                command.ExecuteNonQuery();
                CurrentUserInfo.Login = login;
                connection.con.Close();
                return true;
            }
        }
           
    }
}
