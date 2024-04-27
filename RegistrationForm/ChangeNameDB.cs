using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class ChangeNameDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        public void ChangeN(string name)
        {
            connection.con.Open();
            request = $"UPDATE users SET Username = '{name}' WHERE ID = {CurrentUserInfo.ID}";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            CurrentUserInfo.Name = name;
            connection.con.Close();
        }
    }
}
