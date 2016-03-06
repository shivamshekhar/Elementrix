using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
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
    public sealed partial class finalpage : Page
    {
        int diduserwin;
        public finalpage()
        {
            this.InitializeComponent();
        }

        private void Playagain_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            diduserwin = (int)e.Parameter;
            if (diduserwin == 1)
            {
                textBlock.Text = "Congratulations! You won!";
                speaktext("Congratulations! You won!");
            }
            else if (diduserwin == -1)
            {
                textBlock.Text = "Nice try! Wanna play again?";
                speaktext("Nice try! Wanna play again?");
            }
        }

        public async void speaktext(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            SpeechSynthesisStream synthesisStream;
            synthesisStream = await synthesizer.SynthesizeTextToStreamAsync(text);
            media.AutoPlay = true;
            media.SetSource(synthesisStream, synthesisStream.ContentType);
            media.Play();
        }
    }
}
