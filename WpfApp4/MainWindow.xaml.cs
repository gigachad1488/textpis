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
using System.Threading;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(1000000);
            timer.Tick += new EventHandler(timerTick);
            //timer.Start();
        }

        public void timerTick(object sender, EventArgs e)
        {
            Random r1 = new Random();
            Thread.Sleep(5);
            Random r2 = new Random();
            Thread.Sleep(5);
            Random r3 = new Random();
            //b65.BorderBrush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r1.Next(0, 255)), Convert.ToByte(r2.Next(0, 255)), Convert.ToByte(r3.Next(0, 255))));
            Thread.Sleep(5);
            //b66.BorderBrush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r1.Next(0, 255)), Convert.ToByte(r2.Next(0, 255)), Convert.ToByte(r3.Next(0, 255))));

        }
            
    }
}
