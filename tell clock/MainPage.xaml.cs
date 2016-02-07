using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;
using Windows.UI.Notifications;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;


namespace tell_clock
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer _tick = new DispatcherTimer();
        private DispatcherTimer _sec = new DispatcherTimer();
        private DispatcherTimer telltimemedia = new DispatcherTimer();
        System.DateTime time = DateTime.Now;

        public MainPage()
        {
            this.InitializeComponent();
            _tick = new DispatcherTimer();
            _sec = new DispatcherTimer();
            telltimemedia = new DispatcherTimer();
            telltimemedia.Interval = new TimeSpan(0, 0, 0, 0, 1);
            telltimemedia.Tick += telltimemedia_Tick;

            _tick.Interval = new TimeSpan(0, 0, 0, 1, 0);
            _sec.Interval = new TimeSpan(0, 0, 0, 0, 100);
            _tick.Tick += _tick_Tick;
            _sec.Tick += _sec_Tick;
            _tick.Start();
            // string notify;

            //   public TileNotification tn=new TileNotification(
        }

        void telltimemedia_Tick(object sender, object e)
        {
            
                    tell7.Play();
           
        }

        void _sec_Tick(object sender, object e)
        {
            SolidColorBrush co = new SolidColorBrush();
            int hour = 0;
            int hh = time.Hour;
            hour = hh;
            string h = "";
            int mm = time.Minute;
            string m = "";
            int ss = time.Second;
            string s = "";
          
            
            if (sec.Visibility == Visibility.Visible)
            {
                sec.Visibility = Visibility.Collapsed;

            }
            else
            {
                sec.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }



        void _tick_Tick(object sender, object e)
        {
            _sec.Start();
            System.DateTime time = DateTime.Now;
            SolidColorBrush sb = new SolidColorBrush();
            sb.Color = new Windows.UI.Color();


            //      MODIFY HERE

            SolidColorBrush scb1 = new SolidColorBrush(Colors.Red);
            SolidColorBrush scb2 = new SolidColorBrush(Colors.Blue);
            SolidColorBrush img3 = new SolidColorBrush(Colors.White);
            int hour = 0;
            int hh = time.Hour;
            hour = hh;
            string h = "";
            int mm = time.Minute;
            string m = "";
            int ss = time.Second;
            string s = "";
            if (ss == 0 && mm == 0)
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => tell7.Play());
                
            }
            if (ss < 10)
            {
                s = "0" + ss.ToString();
            }
            else
            {
                s = ss.ToString();
            }
            displaysec.Text = s;

            if (toggle.IsOn)
            {
                ImageBrush img1 = new ImageBrush();
                img1.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/new.jpg"));
                ImageBrush img2 = new ImageBrush();
                img2.ImageSource = new BitmapImage(new Uri("ms-appx:/sunshine-223544 (1).jpg"));

                ampm.Text = "";
                if (hh < 10)
                {
                    h = "0" + hh.ToString();
                }
                else
                {
                    h = hh.ToString();
                }
                if (mm < 10)
                {
                    m = "0" + mm.ToString();
                }
                else
                {
                    m = mm.ToString();
                }
                displayhour.Text = h.ToString();
                displayminute.Text = m.ToString();
            }
            else
            {

                if (hh >= 12)
                {
                    ampm.Text = "PM";
                    hh = hh % 12;
                    if (hh < 10)
                    {
                        h = "0" + hh.ToString();
                    }
                    else
                    {
                        h = hh.ToString();
                    }
                }
                else if (hh < 12 && hh > 0)
                {
                    ampm.Text = "AM";
                    if (hh < 11)
                    {
                        h = "0" + hh.ToString();
                    }
                    else
                    {
                        h = hh.ToString();
                    }

                }
                else if (hh == 0)
                {
                    ampm.Text = "AM";
                    h = "00";

                }
                if (mm < 10)
                {

                    m = "0" + mm.ToString();

                }
                else
                {
                    m = mm.ToString();
                }
                if (ss < 10)
                {

                    s = "0" + ss.ToString();

                }
                else
                {
                    s = ss.ToString();
                }
                displayhour.Text = h;
                displayminute.Text = m;
            }
            if (hour >= 5 && hour < 12)
            {
                displayminute.Foreground = img3;
                displayhour.Foreground = img3;
                sec.Foreground = img3;
                ampm.Foreground = img3;
                wish.Text = "Good Morning";
                evening.Visibility = Visibility.Collapsed;
                night.Visibility = Visibility.Collapsed;
                afternoon.Visibility = Visibility.Collapsed;
                morning.Visibility = Visibility.Visible;


            }
            else if (hour >= 12 && hour < 16)
            {
                displayminute.Foreground = scb1;
                displayhour.Foreground = scb1;
                sec.Foreground = scb1;
                ampm.Foreground = scb1;
                wish.Text = "Good Afternoon";
                evening.Visibility = Visibility.Collapsed;
                night.Visibility = Visibility.Collapsed;
                morning.Visibility = Visibility.Collapsed;
                afternoon.Visibility = Visibility.Visible;
                // maingrid.Background =  scb2;
                // maingrid.tag = "1";
            }
            else if (hour >= 16 && hour < 19)
            {
                displayminute.Foreground = img3;
                displayhour.Foreground = img3;
                sec.Foreground = img3;
                ampm.Foreground = img3;
                wish.Text = "Good Evening";
                night.Visibility = Visibility.Collapsed;
                morning.Visibility = Visibility.Collapsed;
                afternoon.Visibility = Visibility.Collapsed;
                evening.Visibility = Visibility.Visible;
            }
            else if (hour < 5 || hour > 19)
            {
                displayminute.Foreground = img3;
                displayhour.Foreground = img3;
                sec.Foreground = img3;
                ampm.Foreground = img3;
                wish.Text = "Good Night";
                morning.Visibility = Visibility.Collapsed;
                afternoon.Visibility = Visibility.Collapsed;
                evening.Visibility = Visibility.Collapsed;
                night.Visibility = Visibility.Visible;
            }





        }

        private void notifytell(int hh)
        {
            string hourstr = "";
               
                //else if (hh <= 12 && hh > 0)
                //{
                //    hourstr = "ms-appx://sounds/" + hh.ToString() + ".mp3";
                //    telltime.Source = new Uri(hourstr, UriKind.RelativeOrAbsolute);
                //    telltime.Play();
                //}
                //else if (hh > 12 && hh <= 23 || hh == 0)
                //{
                //    if (hh == 0)
                //    {
                //        hourstr = "ms-appx://sounds/" + hh.ToString() + ".mp3";
                //        telltime.Source = new Uri(hourstr, UriKind.RelativeOrAbsolute);
                //        telltime.Play();
                //    }
                //    else
                //    {
                //        hh = hh % 12;
                //        hourstr = "ms-appx://sounds/" + hh.ToString() + ".mp3";
                //        telltime.Source = new Uri(hourstr, UriKind.RelativeOrAbsolute);
                //        telltime.Play();
                //    }
                }

       

        
    }
    
}





