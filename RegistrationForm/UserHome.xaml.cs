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
    public partial class UserHome : Page
    {
        Homepage homepage = new Homepage();
        Page1 startpage = new Page1();
        public UserHome()
        {
            InitializeComponent();
            NameOfUser.Text = $"Профиль пользователя {CurrentUserInfo.Name}";
        }
        private void BackToHome_Click(object sender, RoutedEventArgs e)
        {NavigationService.Navigate(homepage);}
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserInfo.Name = "";
            CurrentUserInfo.Login = "";
            CurrentUserInfo.ID = 0;
            NavigationService.Navigate(startpage);
        }
        private void ChangeName_Click(object sender, RoutedEventArgs e) 
        {NavigationService.Navigate(new ChangeName());}
        private void ChangeLogin_Click(object sender, RoutedEventArgs e)
        {NavigationService.Navigate(new ChangeLogin());}
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {NavigationService.Navigate(new ChangePassword());}
    }
}
