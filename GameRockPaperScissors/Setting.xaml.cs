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

namespace GameRockPaperScissors
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {

        private MainWindow mw;
        public Setting(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void mode1(object sender, RoutedEventArgs e)
        {
            mw.mode = 0;
            this.Hide();
        }

        private void mode2(object sender, RoutedEventArgs e)
        {
            mw.mode = 1;
            this.Hide();
        }

        private void mode3(object sender, RoutedEventArgs e)
        {
            mw.mode = 2;
            this.Hide();
        }
    }
}
