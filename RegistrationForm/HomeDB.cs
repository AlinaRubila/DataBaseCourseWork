using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class HomeDB
    {
        ConnectionClass connection = new ConnectionClass();
        MySqlCommand command = new MySqlCommand();
        string request = "";
        public string[] ListOfTags()
        {
            string[] tagsList = new string[21];
            int i = 0;
            connection.con.Open();
            request = $"SELECT Name FROM tags";
            command.Connection = connection.con;
            command.CommandText = request;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                tagsList[i] = reader[0].ToString() ?? "";
                i++;
            }
            connection.con.Close();
            return tagsList;
        }
        public string[] ListOfArticles()
        {
            string[] articlesList = new string[48];
            int i = 0;
            connection.con.Open();
            request = $"SELECT Name FROM articles";
            command.Connection = connection.con;
            command.CommandText = request;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                articlesList[i] = reader[0].ToString() ?? "";
                i++;
            }
            connection.con.Close();
            return articlesList;
        }
        public string[] TagChoice(int tag_id)
        {
            List<string> tagSearch = new List<string>();
            connection.con.Open();
            request = $"SELECT Name FROM articles JOIN tagarticlelist ON articles.ID = tagarticlelist.articles_ID WHERE tagarticlelist.tags_ID={tag_id}";
            command.Connection = connection.con;
            command.CommandText = request;
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) 
            {
                tagSearch.Add(reader[0].ToString() ?? "");
            }
            connection.con.Close();
            return tagSearch.ToArray();
        }
        public void GetArticleData(string title)
        {
            connection.con.Open();
            request = $"SELECT * FROM articles WHERE Name='{title}'";
            command.Connection = connection.con;
            command.CommandText = request;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CurrentArticleInfo.ID = Convert.ToInt32(reader[0]);
                if (!(reader[1] is DBNull)) {CurrentArticleInfo.LastEdit = Convert.ToDateTime(reader[1]);}
                else { CurrentArticleInfo.LastEdit = null; }
                CurrentArticleInfo.Text = reader[2].ToString() ?? "";
                CurrentArticleInfo.PicturePath = reader[3].ToString() ?? "";
                CurrentArticleInfo.Name = reader[4].ToString() ?? "";
            }
            connection.con.Close();
        }
    }
}
