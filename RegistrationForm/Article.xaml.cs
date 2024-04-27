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
    public partial class Article : Page
    {
        CommentingDB commentDB = new CommentingDB();
        public Article()
        {
            InitializeComponent();
            Header.Text = CurrentArticleInfo.Name;
            Description.Text = $"{ CurrentArticleInfo.Text}\n\nПоследняя правка: {CurrentArticleInfo.LastEdit}";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CurrentArticleInfo.Clear();
            NavigationService.GoBack();
        }

        private void AnyMistake_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Editing());
        }

        private void SendComment_Click(object sender, RoutedEventArgs e)
        {
            if (CommentBox.Text.Trim().Length > 0) 
            {
                commentDB.AddComment(CommentBox.Text);
            }
        }
    }
}
