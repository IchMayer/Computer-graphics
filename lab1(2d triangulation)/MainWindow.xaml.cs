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
            switch (MyApplication.r)
            {
                case -1:
                    this.Down.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 0, 0));
                    this.Mid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255));
                    this.Up.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255));
                    break;
                case 0:
                    this.Mid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 0, 0));
                    this.Down.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255));
                    this.Up.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255));
                    break;
                case 1:
                    this.Up.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 0, 0));
                    this.Mid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255));
                    this.Down.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255));
                    break;
            }
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

        private void ButtonR(object sender, RoutedEventArgs e)
        {
            MyApplication.Scale(1.111111111111111); // 1/0.9
        }

        private void ButtonF(object sender, RoutedEventArgs e)
        {
            MyApplication.Scale(0.9);
        }

        private void Button1(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Red;
        }
        private void Button2(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Orange;
        }
        private void Button3(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Yellow;
        }
        private void Button4(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Green;
        }
        private void Button5(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Cyan;
        }
        private void Button6(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Blue;
        }
        private void Button7(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.Purple;
        }

        private void ButtonESC(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonUp(object sender, RoutedEventArgs e)
        {
            if (MyApplication.r < 1)
                MyApplication.r++;
        }

        private void ButtonDown(object sender, RoutedEventArgs e)
        {
            if (MyApplication.r > -1)
                MyApplication.r--;
        }

        private void ButtonT(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.FromArgb(Math.Min(255, MyApplication.color.R + 20), MyApplication.color.G, MyApplication.color.B);
        }

        private void ButtonY(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.FromArgb(Math.Max(0, MyApplication.color.R - 20), MyApplication.color.G, MyApplication.color.B);
        }

        private void ButtonG(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.FromArgb(MyApplication.color.R, Math.Min(255, MyApplication.color.G + 20), MyApplication.color.B);
        }

        private void ButtonH(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.FromArgb(MyApplication.color.R, Math.Max(0, MyApplication.color.G - 20), MyApplication.color.B);
        }

        private void ButtonB(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.FromArgb(MyApplication.color.R, MyApplication.color.G, Math.Min(255, MyApplication.color.B + 20));
        }

        private void ButtonN(object sender, RoutedEventArgs e)
        {
            MyApplication.color = System.Drawing.Color.FromArgb(MyApplication.color.R, MyApplication.color.G, Math.Max(0, MyApplication.color.B - 20));
        }

        private void ButtonLeft(object sender, RoutedEventArgs e)
        {
            if (MyApplication.NumberActiv > 0)
                MyApplication.NumberActiv--;
        }

        private void ButtonRight(object sender, RoutedEventArgs e)
        {
            if (MyApplication.NumberActiv < MyApplication.n)
                MyApplication.NumberActiv++;
        }
    }
}
