using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistrationForm
{
    public partial class ChangeName : Page
    {
        string name = "";
        ChangeNameDB nameDB = new ChangeNameDB();
        public ChangeName()
        {
            InitializeComponent();
            OldName.Text = $"Ваше старое имя: {CurrentUserInfo.Name}";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserHome());
        }

        private void ChangeNam_Click(object sender, RoutedEventArgs e)
        {
            name = NewName.Text.Trim();
            if (name.Length < 2)
            {
                Warning.Text = "Имя должно состоять из 2 символов и больше";
            }
            else 
            {
                Warning.Text = "Имя успешно изменено!";
                nameDB.ChangeN(name);
                OldName.Text = $"Ваше старое имя: {CurrentUserInfo.Name}";
            }
        }
    }
}
