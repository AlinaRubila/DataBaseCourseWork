using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RegistrationForm
{
    public class EditingDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        public void SendEdit(string comment, string newText)
        {
            connection.con.Open();
            request = "SELECT ID FROM edits ORDER BY ID DESC LIMIT 1";
            command.Connection = connection.con;
            command.CommandText = request;
            int last = Convert.ToInt32(command.ExecuteScalar());
            string date = DateTime.Now.ToString("u");
            request = $"UPDATE articles SET Text = '{newText}', LastEditDate='{date.Trim('Z')}' WHERE ID = {CurrentArticleInfo.ID}";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            request = $"INSERT INTO edits (ID, Date, Comment, users_ID, articles_ID) VALUES ({last + 1}, '{date.Trim('Z')}', '{comment}', {CurrentUserInfo.ID}, {CurrentArticleInfo.ID})";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            connection.con.Close();
        }
    }
}
