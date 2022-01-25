using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileStopWatch
{
   
    public partial class MainPage : ContentPage
    {
        private readonly Stopwatch stopwatch;
        public MainPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
           
            lblStopWatchTime.Text = "00:00:00.00";
        }

        private void StartTimer()
        {

            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        lblStopWatchTime.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", stopwatch.Elapsed);
                    });

                    if (!stopwatch.IsRunning)
                        return false;
                    return true;
                }
                );
            }
        }
        private void Button_Start(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void Button_Stop(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        private void Button_Reset(object sender, EventArgs e)
        {
            stopwatch.Reset();
            lblStopWatchTime.Text = "00:00:00.00";
           
        }
    }
}
