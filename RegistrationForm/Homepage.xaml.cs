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
using System.Xml.Linq;

namespace RegistrationForm
{
    public partial class Homepage : Page
    {
        HomeDB homedb = new HomeDB();
        string searchRequest = "";
        string[] tagsList = new string[21];
        string[] articlesList = new string[48];
        public Homepage()
        {
            InitializeComponent();
            tagsList = homedb.ListOfTags();
            articlesList = homedb.ListOfArticles();
            for (int i = 0; i < tagsList.Length; i++) {Tags.Items.Add(tagsList[i]);}
            for (int i = 0; i < articlesList.Length; i++) { Articles.Items.Add(articlesList[i]); }
        }
        private void ToProfile_Click(object sender, RoutedEventArgs e)
        {NavigationService.Navigate(new UserHome());}
        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchRequest = SearchField.Text.Trim().ToLower();
            List<string> fromRequest = new List<string>();
            foreach (var s in articlesList)
            {
                if (s != null)
                {
                    if (s.ToLower().Contains(searchRequest)) { fromRequest.Add(s); }
                }
            }
            Articles.Items.Clear();
            if (searchRequest.Length < 1)
            {
                for (int i = 0; i < fromRequest.Count; i++) { Articles.Items.Add(articlesList[i]); }
            }
            for (int i = 0; i < fromRequest.Count;i++) { Articles.Items.Add(fromRequest[i]); }
        }
        private void Tags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Tags.SelectedIndex + 1;
            if (index > 0) 
            { 
                string[] s = homedb.TagChoice(index);
                Articles.Items.Clear();
                for (int i = 0; i < s.Length; i++) { Articles.Items.Add(s[i]); }
            }
        }
        private void Articles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Articles.SelectedItem  != null) 
            {
                string selectedArticle = Articles.SelectedItem.ToString() ?? "";
                homedb.GetArticleData(selectedArticle);
                NavigationService.Navigate(new Article());
            }
        }
    }
}
