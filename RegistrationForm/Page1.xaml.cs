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
    public partial class Page1 : Page
    {
        Authorization authorization = new Authorization();
        Registration registration = new Registration();
        public Page1() { InitializeComponent(); }
        private void Autho_Click(object sender, RoutedEventArgs e)
        {NavigationService.Navigate(authorization);}
        private void Register_Click(object sender, RoutedEventArgs e)
        {NavigationService.Navigate(registration);}
    }
}
