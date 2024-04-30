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
using MySql.Data.MySqlClient;

namespace RegistrationForm
{
    public partial class Registration : Page
    {
        Homepage homepage = new Homepage();
        RegisterDB register = new RegisterDB();
        public Registration() { InitializeComponent(); }
        private void EnterHomepage_Click(object sender, RoutedEventArgs e)
        {
            WarningText.Text = "";
            string name = UserName.Text.Trim();
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();
            if (name.Length < 2 || login.Length < 5 || password.Length < 5) { WarningText.Text = "Заполните все поля!";}
            else 
            {
                if (register.RegisterCheck(name, login, password) == false)
                {
                    WarningText.Text = "Пользователь с таким логином уже существует";
                }
                else
                {
                    WarningText.Text = "";
                    NavigationService.Navigate(homepage);
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {NavigationService.GoBack();}
    }
}
