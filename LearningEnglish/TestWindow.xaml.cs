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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        WordsManager wm;
        int positionTrueAnswer = -1;
        string[] words;
        int indexNow = 0;
        int numberOfCorrect = 0;
        public TestWindow()
        {
            InitializeComponent();
            wm = new WordsManager();
            words = new string[10];

            int n = 10;
            while (--n >= 0)
            {
                words[n] = wm.Next();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Next(object sender, RoutedEventArgs e)
        {

            if(indexNow == words.Length - 1)
            {
                btnPlay.Visibility = Visibility.Hidden;
                lbShowStatus.Visibility = Visibility.Visible;

                btnAnswer0.Visibility = Visibility.Hidden;
                btnAnswer1.Visibility = Visibility.Hidden;
                btnAnswer2.Visibility = Visibility.Hidden;

                imgLearn.Visibility = Visibility.Hidden;

                
                lbShowStatus.Content = "Bạn đúng " + numberOfCorrect + "/10 câu";
                lbShowStatus.Foreground = Brushes.Green;
               
            }
            else
            {
                string[] choosedWords = new string[3];
                string correctWord = words[indexNow];
                Random rng = new Random();

                HashSet<int> indexChoosed = randomSetInt(0, 10, 2, indexNow);

                int i = 0;
                foreach (int index in indexChoosed)
                {
                    choosedWords[i++] = words[index];
                }

                positionTrueAnswer = rng.Next(0, 3);

                choosedWords[2] = choosedWords[positionTrueAnswer];
                choosedWords[positionTrueAnswer] = correctWord;

                btnAnswer0.Content = choosedWords[0];
                btnAnswer0.Visibility = Visibility.Visible;
                btnAnswer1.Content = choosedWords[1];
                btnAnswer1.Visibility = Visibility.Visible;
                btnAnswer2.Content = choosedWords[2];
                btnAnswer2.Visibility = Visibility.Visible;

                imgLearn.Source = new BitmapImage(new Uri("img/" + choosedWords[positionTrueAnswer].ToLower() + ".jpg", UriKind.Relative));
                imgLearn.Visibility = Visibility.Visible;

                btnPlay.Visibility = Visibility.Hidden;
                lbShowStatus.Visibility = Visibility.Hidden;

                indexNow++;
            }
        }

        private void Answer0(object sender, RoutedEventArgs e)
        {
            showResult(0);
           
        }

        private void Answer1(object sender, RoutedEventArgs e)
        {
            showResult(1);
            
        }

        private void Answer2(object sender, RoutedEventArgs e)
        {
            showResult(2);
            
        }

        private void showResult(int answer)
        {
            btnPlay.Visibility = Visibility.Visible;
            btnPlay.Content = "Tiếp";
            lbShowStatus.Visibility = Visibility.Visible;

            btnAnswer0.Visibility = Visibility.Hidden;
            btnAnswer1.Visibility = Visibility.Hidden;
            btnAnswer2.Visibility = Visibility.Hidden;

            imgLearn.Visibility = Visibility.Hidden;

            if (positionTrueAnswer == answer)
            {
                lbShowStatus.Content = "Đúng";
                lbShowStatus.Foreground = Brushes.Green;
                numberOfCorrect++;
            }
            else
            {
                lbShowStatus.Content = "Sai";
                lbShowStatus.Foreground = Brushes.OrangeRed;
            }

        }

        private static HashSet<int> randomSetInt(int minValue, int maxValue, int amount, int dontRandomThisNumber)
        {
            HashSet<int> set = new HashSet<int>();
            Random rng = new Random();

            set.Add(dontRandomThisNumber);
            while (set.Count < amount + 1)
            {
                set.Add(rng.Next(minValue, maxValue));
            }
            set.Remove(dontRandomThisNumber);

            return set;
        }
    }
}
