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
using System.Windows.Shapes;

namespace LearningEnglish
{
    /// <summary>
    /// Interaction logic for Learning.xaml
    /// </summary>
    public partial class Learning : Window
    {

        WordsManager wm = new WordsManager();
        int mode = 0; // 0 is word appear, 1 is word hidden
        public Learning()
        {
            InitializeComponent();

        }

        private void SwitchMode(object sender, RoutedEventArgs e)
        {
            if(mode == 0) {
                mode = 1;
                lbWord.Visibility = Visibility.Hidden;
                imgLearn.Visibility = Visibility.Visible;
            }
            else
            {
                mode = 0;
                lbWord.Visibility = Visibility.Visible;
                imgLearn.Visibility = Visibility.Hidden;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            string word = wm.Previous();
            ShowImage(word);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            string word = wm.Next();
            ShowImage(word);
        }

        private void ShowImage(string word)
        {
            imgLearn.Source = new BitmapImage(new Uri("img/" + word.ToLower() + ".jpg", UriKind.Relative));
            imgLearn.Visibility = Visibility.Visible;
            lbWord.Visibility = Visibility.Hidden;
            lbWord.Content= word;
            mode = 1;
        }
    }
}
