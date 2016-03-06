using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Elementrix
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shuffle : Page
    {
        bool animationstart = false, ismusicplaying = true;
        //bool isuserturn;
        double centerx;
        public Shuffle()
        {
            this.InitializeComponent();
            speaktext("Tap on the deck to shuffle!");
        }
        private async void image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (animationstart == false)
            {
                centerx = ((TranslateTransform)image.RenderTransform).X;
                image2.Visibility = Visibility.Visible;
                image1.Visibility = Visibility.Visible;
                image3.Visibility = Visibility.Visible;
                textBlock.Visibility = Visibility.Collapsed;
                animationstart = true;
                int dirn = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (i % 2 == 0)
                        dirn = 1;
                    else
                        dirn = -1;
                    animateimage(image, dirn);
                    await System.Threading.Tasks.Task.Delay(500);
                    Random rnd = new Random();
                    int num = rnd.Next(1, 8);
                    BitmapImage bitmapImage = new BitmapImage();
                    Uri uri = new Uri("ms-appx:///Assets/" + "Periodic table Background" + num + ".png");
                    bitmapImage.UriSource = uri;
                    image.Source = bitmapImage;
                    if (dirn == 1)
                    {
                        fade(image1, bitmapImage);
                    }
                    else
                    {
                        fade(image2, bitmapImage);
                    }
                    fade(image3, bitmapImage);
                    ((TranslateTransform)image.RenderTransform).X = centerx;

                }
                start.Visibility = Visibility.Visible;
                image3.Visibility = Visibility.Collapsed;
                image.Visibility = Visibility.Collapsed;
            }
        }
        public async void fade(Image img, BitmapImage bitimg)
        {
            Storyboard fadestoryboard = new Storyboard();
            DoubleAnimation fadeanim = new DoubleAnimation();
            fadeanim.To = 0;
            fadeanim.Duration = new Duration(TimeSpan.FromMilliseconds(250));
            Storyboard.SetTarget(fadeanim, img);
            Storyboard.SetTargetProperty(fadeanim, "Opacity");
            fadestoryboard.Children.Add(fadeanim);
            fadestoryboard.Begin();
            //wintext.Text = "Level Completed";
            await Task.Delay(250);
            //Delay(1000);
            //fadestoryboard.Stop();
            /*Image Lv1_main = new Image();
            Lv1_main.Source = new BitmapImage(new Uri("ms-appx:///Assets/3_main.png"));
            Lv1_main.Margin = new Thickness(32, 130, 0, 0);
            Lv1_main.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            Lv1_main.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
            Lv1_main.Height = 334;
            Lv1_main.Width = 339;
            Lv1_main.Opacity = 0;
            */
            img.Source = bitimg;
            Storyboard appearstoryboard = new Storyboard();
            DoubleAnimation appearanim = new DoubleAnimation();
            appearanim.To = 1;
            appearanim.Duration = new Duration(TimeSpan.FromMilliseconds(250));
            Storyboard.SetTarget(appearanim, img);
            Storyboard.SetTargetProperty(appearanim, "Opacity");
            appearstoryboard.Children.Add(appearanim);
            appearstoryboard.Begin();
            //newTimer.Stop();
            //NextButton.Visibility = Visibility.Visible;
        }

        public void animateimage(Image img, int dirn)
        {
            Storyboard storyboard1 = new Storyboard();
            //((UIElement)img).RenderTransform = (Transform)new CompositeTransform();
            DoubleAnimation doubleAnimation1 = new DoubleAnimation();
            DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            DoubleAnimation doubleAnimation3 = new DoubleAnimation();
            /*doubleAnimation1.Duration = new Duration(new TimeSpan(0, 0, 1));
            
            doubleAnimation1.To = 0;
            doubleAnimation2.Duration = new Duration(new TimeSpan(0, 0, 1));
            doubleAnimation2.To = -200;*/
            doubleAnimation3.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            if (dirn == 1)
                doubleAnimation3.To = centerx + 500;
            else
                doubleAnimation3.To = centerx - 500;
            /*doubleAnimation1.AutoReverse = true;
            doubleAnimation2.AutoReverse = true;
            doubleAnimation3.AutoReverse = true;
            doubleAnimation1.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation2.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation3.RepeatBehavior = RepeatBehavior.Forever;*/

            /*Storyboard.SetTarget((Timeline)doubleAnimation1, (DependencyObject)img.RenderTransform);
            Storyboard.SetTarget((Timeline)doubleAnimation2, (DependencyObject)img.RenderTransform);
            */
            Storyboard.SetTarget(doubleAnimation3, img.RenderTransform);
            /*Storyboard.SetTargetProperty((Timeline)doubleAnimation1, "TranslateX");
            Storyboard.SetTargetProperty((Timeline)doubleAnimation2, "TranslateY");
            */
            Storyboard.SetTargetProperty(doubleAnimation3, "X");
            /*storyboard1.Children.Add(doubleAnimation1);
            storyboard1.Children.Add(doubleAnimation2);
            */
            storyboard1.Children.Add(doubleAnimation3);

            //if (((TranslateTransform)img.RenderTransform).X > || )
            storyboard1.Begin();

            /*((TranslateTransform)img.RenderTransform).X += 50;
            ((TranslateTransform)img.RenderTransform).Y -= 50;
            */
        }

        private void start_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainGame));
        }

        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            isuserturn = (bool)e.Parameter;
            /*counter = counter + (int)e.Parameter;
            CountdownTimer.Text = "Time Remaining: " + counter.ToString();
        }*/

        public async void speaktext(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            SpeechSynthesisStream synthesisStream;
            synthesisStream = await synthesizer.SynthesizeTextToStreamAsync(text);
            media.AutoPlay = true;
            media.SetSource(synthesisStream, synthesisStream.ContentType);
            media.Play();
        }

        private void play_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ismusicplaying == false)
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
    }
}
