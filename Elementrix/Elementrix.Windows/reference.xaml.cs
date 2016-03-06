using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Elementrix
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class reference : Page
    {
        public reference()
        {
            this.InitializeComponent();
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //textBlock.Text = ((int)comboBox.SelectedIndex).ToString();
            readdata(((int)comboBox.SelectedIndex) + 1);
        }

        public async void readdata(int index)
        {
            string cardstr = index.ToString(); //the current card
            if (cardstr != "0")
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/" + cardstr + ".txt"));
                Stream stream = await file.OpenStreamForReadAsync();
                string[] stats = new string[13];
                using (StreamReader sr = new StreamReader(stream))
                {
                    for (int i = 0; i < 13; i++)
                    {
                        stats[i] = sr.ReadLine();
                    }
                }
                /*putting the data in the card*/
                BitmapImage bitmapImage = new BitmapImage();
                Uri uri = new Uri("ms-appx:///Assets/" + cardstr + ".jpg");
                bitmapImage.UriSource = uri;
                image.Source = bitmapImage;
                NameOfElement.Text = stats[0];
                trivia.Text = stats[1];
                EConfig.Text = stats[2];
                AN.Text = stats[3];
                atomicn.Content = "Atomic number: " + stats[3];
                atomicw.Content = "Atomic weight: " + stats[4];
                electronegativity.Content = "Electronegativity: " + stats[5];
                density.Content = "Density(g/cm3):" + stats[6];
                meltingpoint.Content = "Melting point(C): " + stats[7];
                boilingpoint.Content = "Boiling point(C): " + stats[8];
                atomicradius.Content = "Atomic radius(pm): " + stats[9];
                nofisotopes.Content = "No of isotopes: " + stats[10];
                electronaffinity.Content = "Electron Affinity(kJ/mol): " + stats[11];
                yod.Content = "Year of discovery: " + stats[12];
            }
        }
    }
}
