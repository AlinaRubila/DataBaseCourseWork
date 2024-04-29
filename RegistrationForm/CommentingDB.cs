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
        public int GetLastID()
        {
            connection.con.Open();
            request = "SELECT ID FROM comments ORDER BY ID DESC LIMIT 1";
            command.Connection = connection.con;
            command.CommandText = request;
            int last = Convert.ToInt32(command.ExecuteScalar());
            connection.con.Close();
            return last;
        }
        public List<Comment> GetComments(int artID)
        {
            List<Comment> comments = new List<Comment>();
            connection.con.Open();
            request = $"SELECT Date, Text, Username FROM comments JOIN users ON users.ID=comments.users_ID WHERE comments.articles_ID={artID} ORDER BY comments.ID ASC";
            command.Connection = connection.con;
            command.CommandText = request;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Comment comment = new Comment(Convert.ToDateTime(reader[0]), reader[1].ToString() ?? "", reader[2].ToString() ?? "");
                comments.Add(comment);
            }
            connection.con.Close();
            return comments;
        }
        public void AddComment(string text)
        {
            int id = GetLastID() + 1;
            connection.con.Open();
            string date = DateTime.Now.ToString("u");
            request = $"INSERT INTO comments (ID, Date, Text, users_ID, articles_ID) VALUES ({id}, '{date.Trim('Z')}', '{text}', {CurrentUserInfo.ID}, {CurrentArticleInfo.ID})";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            connection.con.Close();
        }
    }
}
