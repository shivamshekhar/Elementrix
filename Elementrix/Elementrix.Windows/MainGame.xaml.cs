/*Made by: Shivam Shekhar*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
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
    public sealed partial class MainGame : Page
    {
        int[] usercardorder = new int[36];
        int[] cpucardorder = new int[36];
        int numberofusercards = 18, numberofcpucards = 18, totalcards = 36, cpucall = 0;
        double[] usercurrentcardstats = new double[10];
        double[] cpucurrentcardstats = new double[10];
        bool isuserturn, iscpucardflipped = false, isuserturncomplete = false, ismusicplaying = true;
        public MainGame()
        {
            this.InitializeComponent();
            shuffle();
            nofcpuscards.Text = "Number of CPU's cards: " + numberofcpucards.ToString();
            nofuserscards.Text = "Number of Your cards: " + numberofusercards.ToString();
            isuserturn = false;
            if (isuserturn == false)
            {
                cputurn();
            }
            else
            {
                userturn();
            }
        }

        public void shuffle() //shuffles the deck
        {
            for (int i = 0; i < totalcards; i++)
            {
                usercardorder[i] = 0;
                cpucardorder[i] = 0;
            }
            Random rnd = new Random();
            for (int i = 0; i < totalcards; i++)
            {
                if (i % 2 == 0)
                {
                    while (true)
                    {
                        int ucardseq = rnd.Next(0, totalcards/2);
                        if (usercardorder[ucardseq] == 0)
                        {
                            usercardorder[ucardseq] = i + 1;
                            break;
                        }
                    }

                }
                else
                {
                    while (true)
                    {
                        int ccardseq = rnd.Next(0, totalcards/2);
                        if (cpucardorder[ccardseq] == 0)
                        {
                            cpucardorder[ccardseq] = i + 1;
                            break;
                        }
                    }
                }
            }
        }

       public void cputurn()
        {
            readdata(0);  //reads data
            readdata(1);
            if (isuserturn == false)
            {
                whosturn.Text = "CPU's Turn"; //HUD shows CPU's turn
                /*Random rnd = new Random(); //Randomizing CPU's moves
                cpucall = rnd.Next(0, 10);
                */
                cpucall = cpuAI();
                cpuspeak(cpucall);
             }
        }

        public int cpuAI()
        {
            Random rnd = new Random();
            int temp = rnd.Next(0, 10);
            switch(temp)
            {
                case 0:
                    if(cpucurrentcardstats[0]<19 && cpucurrentcardstats[0]>0)
                    {
                        if(rnd.Next(0,2)==0)
                        {
                            cpucall = 0;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 1:
                    if (cpucurrentcardstats[1] > 150)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 1;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 2:
                    if (cpucurrentcardstats[2] > 2)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 2;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 3:
                    if (cpucurrentcardstats[3] > 5)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 3;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 4:
                    if (cpucurrentcardstats[4] > 1000)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 4;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 5:
                    if (cpucurrentcardstats[5] > 2000)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 5;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 6:
                    if (cpucurrentcardstats[6] > 150)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 6;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 7:
                    if (cpucurrentcardstats[7] > 25)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 7;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 8:
                    if (cpucurrentcardstats[8] > 75)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 8;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
                case 9:
                    if (cpucurrentcardstats[9] < 1700)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            cpucall = 9;
                        }
                        else
                        {
                            cpucall = rnd.Next(0, 10);
                        }
                    }
                    else
                    {
                        cpucall = rnd.Next(0, 10);
                    }
                    break;
            }
            return cpucall;
        }

        public void userturn()
        {
            readdata(0); //reads data
            readdata(1);
            if (isuserturn == true)
            {
                whosturn.Text = "Your Turn";
            }
        }

        public async void comparestats(int stattocomapre, int typeofstat)
        {
            string cardstr = usercardorder[0].ToString();
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
            if (stats[3 + stattocomapre] != "NA")
            {
                usercurrentcardstats[stattocomapre] = Convert.ToDouble(stats[3 + stattocomapre]);
            }
            else
                usercurrentcardstats[stattocomapre] = -1;

            //cpu's 

            cardstr = cpucardorder[0].ToString();
            file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/" + cardstr + ".txt"));
            stream = await file.OpenStreamForReadAsync();
            stats = new string[13];
            using (StreamReader sr = new StreamReader(stream))
            {
                for (int i = 0; i < 13; i++)
                {
                    stats[i] = sr.ReadLine();
                }
            }
            if (stats[3 + stattocomapre] != "NA")
            {
                cpucurrentcardstats[stattocomapre] = Convert.ToDouble(stats[3 + stattocomapre]);
            }
            else
                cpucurrentcardstats[stattocomapre] = -1;

            switch (typeofstat)
            {
                case 1:
                    if (isuserturn == true) //user's moves
                    {
                        if (usercurrentcardstats[stattocomapre] > cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "You win!";
                            speaktext("Hey! You won!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = true;
                        }
                        else if (usercurrentcardstats[stattocomapre] < cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "Aw snap! You Lose!";
                            speaktext("Aw snap! You lose!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = false;
                        }
                        else
                        {
                            //flipcard();
                            alertmsg.Text = "It's a draw! Give it another try!";
                            speaktext("It's a draw! Give it another try!");
                            isuserturn = true;
                            isuserturncomplete = false;
                        }
                    }
                    else //cpu's moves
                    {
                        if (usercurrentcardstats[stattocomapre] > cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "You win!";
                            speaktext("Hey! You won!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = true;
                        }
                        else if (usercurrentcardstats[stattocomapre] < cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "Aw snap! You Lose!";
                            speaktext("Aw snap! You lose!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = false;
                        }
                        else
                        {
                            alertmsg.Text = "It's a draw!";
                            speaktext("It's a draw! I'll give another try.");
                            isuserturn = false;
                            isuserturncomplete = false;
                            cputurn();
                        }
                    }
                    break;
                case -1:
                    if (isuserturn == true)
                    {
                        if (usercurrentcardstats[stattocomapre] < cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "You win!";
                            speaktext("Hey! You won!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = true;
                        }
                        else if (usercurrentcardstats[stattocomapre] > cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "Aw snap! You Lose!";
                            speaktext("Aw snap! You lose!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = false;
                        }
                        else
                        {
                            alertmsg.Text = "It's a draw! Give it another try!";
                            speaktext("It's a draw! Give it another try!");
                            isuserturn = true;
                            isuserturncomplete = false;
                        }
                    }
                    else // cpu's turn
                    {
                        if (usercurrentcardstats[stattocomapre] < cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "You win!";
                            speaktext("Hey! You won!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = true;
                        }
                        else if (usercurrentcardstats[stattocomapre] > cpucurrentcardstats[stattocomapre])
                        {
                            flipcard();
                            alertmsg.Text = "Aw snap! You Lose!";
                            speaktext("Aw snap! You lose!");
                            okbutton.Visibility = Visibility.Visible;
                            isuserturn = false;
                        }
                        else
                        {
                            alertmsg.Text = "It's a draw!";
                            speaktext("It's a draw! I'll give another try.");
                            isuserturn = false;
                            isuserturncomplete = false;
                            cputurn();
                        }
                    }
                    break;
            }
        }

        private void okbutton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isuserturn == true)
            {
                usercardorder[numberofusercards] = cpucardorder[0];
                numberofusercards++;
                cpucardorder[0] = 0;
                changecards();
                numberofcpucards--;
                nofcpuscards.Text = "Number of CPU's cards: " + numberofcpucards.ToString();
                nofuserscards.Text = "Number of Your cards: " + numberofusercards.ToString();
                flipcard();
                userturn();
            }
            else
            {
                cpucardorder[numberofcpucards] = usercardorder[0];
                numberofcpucards++;
                usercardorder[0] = 0;
                changecards();
                numberofusercards--;
                nofcpuscards.Text = "Number of CPU's cards: " + numberofcpucards.ToString();
                nofuserscards.Text = "Number of Your cards: " + numberofusercards.ToString();
                flipcard();
                cputurn();
            }
            callbox.Text = "";
            alertmsg.Text = "";
            isuserturncomplete = false;
            okbutton.Visibility = Visibility.Collapsed;
        }

        public void flipcard()
        {
            if (iscpucardflipped == false)
            {
                VisualStateManager.GoToState(this, "FlipCardFront", true);
                iscpucardflipped = true;
            }
            else
            {
                Random rnd = new Random();
                int backgnum = rnd.Next(1, 7);
                BitmapImage bitmapImage = new BitmapImage();
                Uri uri = new Uri("ms-appx:///Assets/" + "Periodic table Background" + backgnum.ToString() + ".png");
                bitmapImage.UriSource = uri;
                backcpucard.Source = bitmapImage;
                VisualStateManager.GoToState(this, "FlipCardBack", true);
                iscpucardflipped = false;
            }
        }

        private void atomicn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete==false)
            {
                if (isuserturn == true)
                {
                    comparestats(0, -1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 0)
                    {
                        comparestats(0, -1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void atomicw_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(1, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 1)
                    {
                        comparestats(1, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void electronegativity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(2, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 2)
                    {
                        comparestats(2, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void density_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(3, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 3)
                    {
                        comparestats(3, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void meltingpoint_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(4, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 4)
                    {
                        comparestats(4, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void boilingpoint_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(5, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 5)
                    {
                        comparestats(5, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void atomicradius_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(6, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 6)
                    {
                        comparestats(6, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void nofisotopes_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(7, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 7)
                    {
                        comparestats(7, 1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        private void electronaffinity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(8, 1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 8)
                    {
                        comparestats(8, 1);
                        isuserturncomplete = true;
                    }
                }
            }
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

        private void reset_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
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

        private void yod_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(isuserturncomplete == false)
            {
                if (isuserturn == true)
                {
                    comparestats(9, -1);
                    isuserturncomplete = true;
                }
                else
                {
                    if (cpucall == 9)
                    {
                        comparestats(9, -1);
                        isuserturncomplete = true;
                    }
                }
            }
        }

        public void changecards()
        {
            int temp;
            temp = usercardorder[0]; 
            for (int i = 0 ; i < numberofusercards - 1; i++)
            {
                usercardorder[i] = usercardorder[i + 1];
            }
            usercardorder[numberofusercards - 1] = temp;
            temp = cpucardorder[0];
            for (int i = 0; i < numberofcpucards - 1; i++)
            {
                cpucardorder[i] = cpucardorder[i + 1];
            }
            cpucardorder[numberofcpucards - 1] = temp;
            readdata(1);
            readdata(2);
        }

        public async void readdata(int player)
        {
            if (player == 1) //read user's data
            {
                string cardstr = usercardorder[0].ToString(); //the current user card
                if(cardstr != "0")
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

                else
                {
                    if (numberofusercards == 1)
                        Frame.Navigate(typeof(finalpage), -1);
                    else if (numberofcpucards == 1)
                        Frame.Navigate(typeof(finalpage), 1);
                    isuserturn = true;
                }
                
            }
            else //read cpu's data
            {
                string cardstr = cpucardorder[0].ToString();
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
                    BitmapImage bitmapImage = new BitmapImage();
                    Uri uri = new Uri("ms-appx:///Assets/" + cardstr + ".jpg");
                    bitmapImage.UriSource = uri;
                    mcpuimage.Source = bitmapImage;
                    mcpuNameOfElement.Text = stats[0];
                    mcputrivia.Text = stats[1];
                    mcpuEConfig.Text = stats[2];
                    mcpuAN.Text = stats[3];
                    mcpuatomicn.Content = "Atomic number: " + stats[3];
                    mcpuatomicw.Content = "Atomic weight: " + stats[4];
                    mcpuelectronegativity.Content = "Electronegativity: " + stats[5];
                    mcpudensity.Content = "Density(g/cm3):" + stats[6];
                    mcpumeltingpoint.Content = "Melting point(C): " + stats[7];
                    mcpuboilingpoint.Content = "Boiling point(C): " + stats[8];
                    mcpuatomicradius.Content = "Atomic radius(pm): " + stats[9];
                    mcpunofisotopes.Content = "No of isotopes: " + stats[10];
                    mcpuelectronaffinity.Content = "Electron Affinity(kJ/mol): " + stats[11];
                    mcpuyod.Content = "Year of discovery: " + stats[12];
                }

                else
                {
                    if (numberofusercards == 1)
                        Frame.Navigate(typeof(finalpage), -1);
                    else if(numberofcpucards == 1)
                        Frame.Navigate(typeof(finalpage), 1);
                    isuserturn = true;
                }
                
            }
        }

        public async void cpuspeak(int par)
        {
            string cardstr = cpucardorder[0].ToString();
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
            if (stats[3 + par] != "NA")
            {
                cpucurrentcardstats[par] = Convert.ToDouble(stats[3 + par]);
            }
            else
                cpucurrentcardstats[par] = -1;
            switch (par)
            {
                case 0:
                    callbox.Text = "Atomic number: " + ((int)cpucurrentcardstats[0]).ToString();
                    speaktext("Atomic number " + ((int)cpucurrentcardstats[0]).ToString());
                    break;
                case 1:
                    callbox.Text = "Atomic weight: " + ((int)cpucurrentcardstats[1]).ToString();
                    speaktext("Atomic weight " + ((int)cpucurrentcardstats[1]).ToString());
                    break;
                case 2:
                    callbox.Text = "Electronegativity: " + cpucurrentcardstats[2].ToString();
                    speaktext("Electronegativity " + cpucurrentcardstats[2].ToString());
                    break;
                case 3:
                    callbox.Text = "Density: " + cpucurrentcardstats[3].ToString();
                    speaktext("Density " + cpucurrentcardstats[3].ToString());
                    break;
                case 4:
                    callbox.Text = "Melting Point: " + cpucurrentcardstats[4].ToString();
                    speaktext("Melting Point " + cpucurrentcardstats[4].ToString());
                    break;
                case 5:
                    callbox.Text = "Boiling Point: " + cpucurrentcardstats[5].ToString();
                    speaktext("Boiling Point " + cpucurrentcardstats[5].ToString());
                    break;
                case 6:
                    callbox.Text = "Atomic radius: " + ((int)cpucurrentcardstats[6]).ToString();
                    speaktext("Atomic radius " + ((int)cpucurrentcardstats[6]).ToString());
                    break;
                case 7:
                    callbox.Text = "Number of isotopes: " + ((int)cpucurrentcardstats[7]).ToString();
                    speaktext("Number of isotopes " + ((int)cpucurrentcardstats[7]).ToString());
                    break;
                case 8:
                    callbox.Text = "Electron Affinity: " + cpucurrentcardstats[8].ToString();
                    speaktext("Electron Affinity " + cpucurrentcardstats[8].ToString());
                    break;
                case 9:
                    callbox.Text = "Year of Discovery: " + ((int)cpucurrentcardstats[9]).ToString();
                    speaktext("Year of discovery " + ((int)cpucurrentcardstats[9]).ToString());
                    break;
                default:
                    break;
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
