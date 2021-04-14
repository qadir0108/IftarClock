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

namespace DigitalClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        SunSetCalculator sc = new SunSetCalculator();
        public MainWindow()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            this.Left = SystemParameters.WorkArea.Right - this.Width;
            this.Top = SystemParameters.WorkArea.Bottom - this.Height;

            sc.FetchAndSaveSunSet();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            label1.Content = sc.GetRemainingTime().PrintFormat();

            if(sc.GetRemainingTime().Seconds == 0)
                label1.Foreground = ColorChooser.GetRandomColor();

            // Refetch if !IsSunSetAlreadyGot and check at every Hour ( Minute = 0 ) 
            if (DateTime.Now.Minute == 0)
                sc.FetchAndSaveSunSet();
        }

    }
}
