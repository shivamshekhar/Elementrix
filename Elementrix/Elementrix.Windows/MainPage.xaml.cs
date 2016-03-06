using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Elementrix
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool ismusicplaying = true;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void start_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Shuffle));
        }

        private void play_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(ismusicplaying==false)
            {
                intromusic.Play();
                ismusicplaying = true;
                play.Visibility = Visibility.Collapsed;
                pause.Visibility = Visibility.Visible;
            }
        }

        private void pause_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ismusicplaying == true)
            {
                intromusic.Pause();
                ismusicplaying = false;
                play.Visibility = Visibility.Visible;
                pause.Visibility = Visibility.Collapsed;
            }
        }

        private void help_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));
        }

        private void about_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void reference_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(reference));
        }
    }
}
