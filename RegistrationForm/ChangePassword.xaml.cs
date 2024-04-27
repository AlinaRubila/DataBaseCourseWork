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
    public partial class ChangePassword : Page
    {
        ChangePassDB passwordDB = new ChangePassDB();
        string oldPassword = "";
        string newPassword = "";
        string repeatPassword = "";
        public ChangePassword() {InitializeComponent();}
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            oldPassword = OldPassword.Password.Trim();
            newPassword = NewPassword.Password.Trim();
            repeatPassword = RepeatPassword.Password.Trim();
            if (passwordDB.CheckOldPassword(oldPassword) == false) { Warning.Text = "Старый пароль неверен!";}
            else if (newPassword.Length < 5) { Warning.Text = "Пароль должен содержать не менее 5 символов"; }
            else if (newPassword != repeatPassword) { Warning.Text = "Повторенный пароль не совпадает!"; }
            else 
            {
                Warning.Text = "Пароль успешно изменён!";
                passwordDB.ChangeP(newPassword); 
            }
        }
    }
}
