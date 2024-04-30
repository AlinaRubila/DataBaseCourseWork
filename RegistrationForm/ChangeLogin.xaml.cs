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
    public partial class ChangeLogin : Page
    { 
        ChangeLoginDB loginDB = new ChangeLoginDB();
        string oldLogin = "";
        string newLogin = "";
        public ChangeLogin() { InitializeComponent(); }
        private void Back_Click(object sender, RoutedEventArgs e)
        {NavigationService.GoBack();}
        private void ChangeLog_Click(object sender, RoutedEventArgs e)
        {
            newLogin = NewLogin.Text.Trim();
            oldLogin = OldLogin.Text.Trim();
            if (newLogin.Length < 5) {Warning.Text = "Логин должен состоять из 5 символов и больше";}
            else if (oldLogin != CurrentUserInfo.Login) {Warning.Text = "Неверный логин!";}
            else
            {
                if (loginDB.ChangeL(newLogin) == false) {Warning.Text = "Пользователь с таким логином уже существует!";}
                else {Warning.Text = "Логин изменён успешно!";}
            }
        }
    }
}
