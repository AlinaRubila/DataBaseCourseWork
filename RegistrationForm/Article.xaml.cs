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
        List<Comment> comments;
        public Article()
        {
            InitializeComponent();
            Picture.Source = new BitmapImage(new Uri($"pictures/{CurrentArticleInfo.PicturePath}.png", UriKind.Relative));
            comments = commentDB.GetComments(CurrentArticleInfo.ID);
            if (comments.Count > 0)
            {
                Comments.ItemsSource = comments;
            }
            Header.Text = CurrentArticleInfo.Name;
            if (CurrentArticleInfo.LastEdit != null) { Description.Text = $"{CurrentArticleInfo.Text}\n\nПоследняя правка: {CurrentArticleInfo.LastEdit}"; }
            else  if (CurrentArticleInfo.LastEdit == null) {Description.Text = $"{CurrentArticleInfo.Text}";}
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
                comments = commentDB.GetComments(CurrentArticleInfo.ID);
                Comments.ItemsSource = comments;
            }
        }
    }
}
