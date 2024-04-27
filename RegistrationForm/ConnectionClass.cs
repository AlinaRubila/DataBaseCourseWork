using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RegistrationForm
{
    public class ConnectionClass
    {
        static string conString = "server=localhost;user=root;database=mydb;password=niceMeow;";
        public MySqlConnection con = new MySqlConnection(conString);
    }
}
