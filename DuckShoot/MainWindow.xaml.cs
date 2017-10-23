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

namespace DuckShoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(20, 0, 0);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Start();

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            int tick = -4;
            if(ImgDuck1.Margin.Left <= 0)
            {
                ImgDuck1.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1; // or 1
                                       //flipTrns.ScaleY = -1;
                ImgDuck1.RenderTransform = flipTrans;
                tick = 4;
            }

            ImgDuck1.Margin = new Thickness(ImgDuck1.Margin.Left + tick, ImgDuck1.Margin.Top, 0, 0);            //ImgDuck2.Margin = new Thickness(ImgDuck2.Margin.Left + 2, ImgDuck2.Margin.Top, 0, 0);
            //ImgDuck3.Margin = new Thickness(ImgDuck3.Margin.Left + 2, ImgDuck3.Margin.Top, 0, 0);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(WindowDuck);
            ImgTarget.Margin = new Thickness(point.X - ImgTarget.Width/2, point.Y - ImgTarget.Height / 2, 0, 0);
        }
    }
}
