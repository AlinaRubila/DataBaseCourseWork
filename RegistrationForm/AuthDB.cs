using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class AuthDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        string? password2;
        public bool AuthCheck(string? login, string? password)
        {
            connection.con.Open();
            request = $"SELECT Password FROM users WHERE Login = '{login}'";
            command.Connection = connection.con;
            command.CommandText = request;
            password2 = Convert.ToString(command.ExecuteScalar());
            if (password2 != password) 
            {
                connection.con.Close();
                return false; 
            }
            else
            {
                request = $"SELECT ID, Username, Login FROM users WHERE Login = '{login}'";
                command.CommandText = request;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CurrentUserInfo.ID = Convert.ToInt32(reader[0]);
                    CurrentUserInfo.Name = reader[1].ToString() ?? "";
                    CurrentUserInfo.Login = reader[2].ToString() ?? "";
                }
                connection.con.Close();
                return true;
            }
        }
    }
}
