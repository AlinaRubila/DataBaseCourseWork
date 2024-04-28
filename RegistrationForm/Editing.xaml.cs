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
    public partial class Editing : Page
    {
        EditingDB editingDB = new EditingDB();
        public Editing()
        {
            InitializeComponent();
            ChangeableDescrip.Text = CurrentArticleInfo.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SendChanges_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeCommet.Text.Trim().Length > 1 && ChangeableDescrip.Text.Trim().Length > 5)
            {
                editingDB.SendEdit(ChangeCommet.Text, ChangeableDescrip.Text);
                Info.Text = "Сохранено";
            }
        }
    }
}
