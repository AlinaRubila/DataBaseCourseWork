using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class Comment
    {
        public string Date { get; set; } = "";
        public string Text { get; set; } = "";
        public string Username { get; set; } = "";
        public Comment(DateTime date, string text, string name)
        {
            Date = date.ToShortDateString(); Text = text; Username = name;
        }
    }
}
