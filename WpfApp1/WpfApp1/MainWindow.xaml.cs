using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Example;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread t;

        public MainWindow()
        {
            t = new Thread(() => MyApplication.Start(this));
            t.Start();
            this.Topmost = true;

            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();

            this.Closed += (sender, e) =>
            {
                MyApplication.Close();
            };

            

            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!t.IsAlive)
                this.Close();
            this.Color.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, MyApplication.color.R, MyApplication.color.G, MyApplication.color.B));
        }

        private void ButtonW(object sender, RoutedEventArgs e)
        {
            MyApplication.Move(0, 0.05f);
        }

        private void ButtonA(object sender, RoutedEventArgs e)
        {
            MyApplication.Move(-0.05f, 0);
        }

        private void ButtonS(object sender, RoutedEventArgs e)
        {
            MyApplication.Move(0, -0.05f);
        }

        private void ButtonD(object sender, RoutedEventArgs e)
        {
            MyApplication.Move(0.05f, 0);
        }

        private void ButtonQ(object sender, RoutedEventArgs e)
        {
            MyApplication.Turn(Math.PI / 18f);
        }

        private void ButtonE(object sender, RoutedEventArgs e)
        {
            MyApplication.Turn(Math.PI / -18f);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
