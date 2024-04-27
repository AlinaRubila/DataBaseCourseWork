using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class CommentingDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        public void GetComments(int artID)
        {

        }
        public void AddComment(string text)
        {
            connection.con.Open();
            request = "SELECT ID FROM comments ORDER BY ID DESC LIMIT 1";
            command.Connection = connection.con;
            command.CommandText = request;
            int last = Convert.ToInt32(command.ExecuteScalar());
            string date = DateTime.Now.ToString("u");
            request = $"INSERT INTO comments (ID, Date, Text, users_ID, articles_ID) VALUES ({last + 1}, '{date.Trim('Z')}', '{text}', {CurrentUserInfo.ID}, {CurrentArticleInfo.ID})";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            connection.con.Close();
        }
    }
}
