using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class CurrentArticleInfo
    {
        public static int ID = 0;
        public static DateTime? LastEdit;
        public static string Name = "";
        public static string Text = "";
        public static string PicturePath = "";
        public static void Clear()
        {
            ID = 0; LastEdit = null; Name = ""; Text = ""; PicturePath = "";
        }
    }
}
