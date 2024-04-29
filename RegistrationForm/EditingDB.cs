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
        public void SendArticleChanges(string date, string newText)
        {
            connection.con.Open();
            request = $"UPDATE articles SET Text = '{newText}', LastEditDate='{date.Trim('Z')}' WHERE ID = {CurrentArticleInfo.ID}";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            connection.con.Close();
        }
        public int LastID()
        {
            connection.con.Open();
            request = "SELECT ID FROM edits ORDER BY ID DESC LIMIT 1";
            command.Connection = connection.con;
            command.CommandText = request;
            int last = Convert.ToInt32(command.ExecuteScalar());
            connection.con.Close();
            return last;
        }
        public void SendEdit(string comment, string newText)
        {
            string date = DateTime.Now.ToString("u");
            SendArticleChanges(date, newText);
            int last = LastID() + 1;
            connection.con.Open();
            request = $"INSERT INTO edits (ID, Date, Comment, users_ID, articles_ID) VALUES ({last}, '{date.Trim('Z')}', '{comment}', {CurrentUserInfo.ID}, {CurrentArticleInfo.ID})";
            command.Connection = connection.con;
            command.CommandText = request;
            command.ExecuteNonQuery();
            connection.con.Close();
        }
    }
}
