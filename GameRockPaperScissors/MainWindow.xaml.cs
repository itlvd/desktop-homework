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

namespace GameRockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int mode { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayBtn(object sender, RoutedEventArgs e)
        {
            var play = new PlayWindow(this);
            play.ShowDialog();
        }

        private void SettingBtn(object sender, RoutedEventArgs e)
        {
            var setting = new Setting(this);
            setting.ShowDialog();
        }
    }
}
