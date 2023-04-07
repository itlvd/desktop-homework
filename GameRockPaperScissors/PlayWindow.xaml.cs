using RockPaperScissors;
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
    /// Interaction logic for PlayWindow.xaml
    /// </summary>
    public partial class PlayWindow : Window
    {
        private MainWindow mw;
        private Game service;
        private int machinewin = 0, playerwin = 0, draw = 0;
        public PlayWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            if(mw.mode == 0 )
            {
                this.service= new DummyMode();
                modeSelected.Content = "Bình thường";
            }
            else if(mw.mode == 1 )
            {
                this.service= new AlwaysWinMode();
                modeSelected.Content = "Khôn";
            }
            else
            {
                this.service = new SmartMode();
                modeSelected.Content = "Xác suất";
            }
        }

        private void rockChoosed(object sender, RoutedEventArgs e)
        {
            (int machineChoosed, int status) = service.Next((int)Game.Type.BUA);
            UpdateStatusAndStatistics((int)Game.Type.BUA, machineChoosed, status);
        }

        private void paperChoosed(object sender, RoutedEventArgs e)
        {
            (int machineChoosed, int status) = service.Next((int)Game.Type.BAO);
            UpdateStatusAndStatistics((int)Game.Type.BAO, machineChoosed, status);
        }

        private void scissorsChoosed(object sender, RoutedEventArgs e)
        {
            (int machineChoosed, int status) = service.Next((int)Game.Type.KEO);
            UpdateStatusAndStatistics((int)Game.Type.KEO, machineChoosed, status);
        }

        private void UpdateStatusAndStatistics(int playerChoosed, int machineChoosed, int status)
        {
            // Update Machine Choosed Image
            if (machineChoosed == (int)Game.Type.BUA)
            {
                machineResult.Source = new BitmapImage(new Uri("Img/bua.png", UriKind.Relative));
            }
            else if (machineChoosed == (int)Game.Type.KEO)
            {
                machineResult.Source = new BitmapImage(new Uri("Img/keo.png", UriKind.Relative));
            }
            else
            {
                machineResult.Source = new BitmapImage(new Uri("Img/bao.png", UriKind.Relative));
            }
            // Update Player Choosed Image
            if (playerChoosed == (int)Game.Type.BUA)
            {
                playerResult.Source = new BitmapImage(new Uri("Img/bua.png", UriKind.Relative));
            }
            else if (playerChoosed == (int)Game.Type.KEO)
            {
                playerResult.Source = new BitmapImage(new Uri("Img/keo.png", UriKind.Relative));
            }
            else
            {
                playerResult.Source = new BitmapImage(new Uri("Img/bao.png", UriKind.Relative));
            }

            // Update scores and status
            if (status == -1)
            {
                machineWin.Content = ++machinewin;
                statuslabel.Content = "Thua";
                statuslabel.Foreground = Brushes.Black;
                statuslabel.Visibility = Visibility.Visible;
            }
            else if (status == 0)
            {
                playerDraw.Content = ++draw;
                statuslabel.Content = "Hoà";
                statuslabel.Foreground = Brushes.Green;
                statuslabel.Visibility = Visibility.Visible;
            }
            else
            {
                playerWin.Content = ++playerwin;
                statuslabel.Content = "Thắng";
                statuslabel.Foreground = Brushes.Red;
                statuslabel.Visibility = Visibility.Visible;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
