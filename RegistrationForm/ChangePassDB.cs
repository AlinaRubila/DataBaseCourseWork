using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class ChangePassDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        string? truePass = "";
        public bool CheckOldPassword(string? password)
        {
            connection.con.Open();
            request = $"SELECT Password FROM users WHERE Login = '{CurrentUserInfo.Login}'";
            command.Connection = connection.con;
            command.CommandText = request;
            truePass = Convert.ToString(command.ExecuteScalar());
            connection.con.Close();
            if (password != truePass) {return false;}
            else {return true;}
        }
        public void ChangeP(string password)
        {
            connection.con.Open();
            request = $"UPDATE users SET Password = '{password}' WHERE ID = {CurrentUserInfo.ID}";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            connection.con.Close();
        }
    }
}
