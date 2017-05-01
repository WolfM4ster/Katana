using Katana.Internationalisation;
using Katana.internationalization;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Katana.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GameWindow : Page
    {
        public Internationalization CurrentLanguage { get; private set; }
        private string pseudoUser;
        private static int uniqueIdentifiantMenu = 8;

        public GameWindow()
        {
            InitializeComponent();
            SwitchLanguage(Languages.French);
            switch (Settings.Default.Langue)
            {
                case "FR":
                    SwitchLanguage(Languages.French);
                    break;
                case "US":
                    SwitchLanguage(Languages.English);
                    break;
                case "ES":
                    SwitchLanguage(Languages.Spanish);
                    break;
                case "JP":
                    SwitchLanguage(Languages.Japanese);
                    break;
            }
        }

        private void homeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppWindow));
        }

        /////////////////////////////
        //    CHANGEMENT LANGUE    //
        /////////////////////////////

        public void SwitchLanguage(Languages lang)
        {
            switch (lang)
            {
                case Languages.English:
                    CurrentLanguage = new US();
                    break;
                case Languages.French:
                    CurrentLanguage = new FR();
                    break;
                case Languages.Spanish:
                    CurrentLanguage = new ES();
                    break;
                case Languages.Japanese:
                    CurrentLanguage = new JP();
                    break;
            }
            this.DataContext = CurrentLanguage;
        }

        /*public void determinePlacementPlayer(int numberPlayer)
        {
            switch (numberPlayer)
            {
                case 3:
                    ImagePlayer7.Visibility = Visibility.Collapsed;
                    ImagePlayer2.Visibility = Visibility.Collapsed;
                    ImagePlayer6.Visibility = Visibility.Collapsed;
                    ImagePlayer3.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    ImagePlayer1.Visibility = Visibility.Collapsed;
                    ImagePlayer3.Visibility = Visibility.Collapsed;
                    ImagePlayer6.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    ImagePlayer6.Visibility = Visibility.Collapsed;
                    ImagePlayer3.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    ImagePlayer7.Visibility = Visibility.Collapsed;
                    break;
                case 7:
                    break;
            }
        }*/

        private async void btnScale_Click_Kiseru(Object sender, RoutedEventArgs e)
        {
            var animationKiseru = kiseru.Scale(duration: 100, delay: 0.5, centerX: 0.0f, centerY: 0.0f, scaleX: 2.0f, scaleY: 2.0f);
            await animationKiseru.StartAsync();
            await bokken.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.0f, scaleX: 1.0f, scaleY: 1.0f).StartAsync();
            await nodachi.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.0f, scaleX: 1.0f, scaleY: 1.0f).StartAsync();
            lancer.Visibility = Visibility.Visible;


        }

        private async void btnScale_Click_Bokken(Object sender, RoutedEventArgs e)
        {
            await bokken.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.5f, scaleX: 2.0f, scaleY: 2.0f).StartAsync();
            await kiseru.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.0f, scaleX: 1.0f, scaleY: 1.0f).StartAsync();
            await nodachi.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.0f, scaleX: 1.0f, scaleY: 1.0f).StartAsync();
            lancer.Visibility = Visibility.Visible;
        }

        private async void btnScale_Click_Nodachi(Object sender, RoutedEventArgs e)
        {
            await nodachi.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.5f, scaleX: 2.0f, scaleY: 2.0f).StartAsync();
            await kiseru.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.0f, scaleX: 1.0f, scaleY: 1.0f).StartAsync();
            await bokken.Scale(duration: 100, delay: 0, centerX: 0.0f, centerY: 0.0f, scaleX: 1.0f, scaleY: 1.0f).StartAsync();
            lancer.Visibility = Visibility.Visible;

        }


        private async void btnFade_Bokken(Object sender, RoutedEventArgs e)
        {
            lancer.Visibility = Visibility.Collapsed;
            await bokken.Fade(0, 1000, 5).StartAsync();
            bokken_Copy.Visibility = Visibility.Visible;
            attaquable.Visibility = Visibility.Visible;
            attaquable2.Visibility = Visibility.Visible;

        }

        public async void btn_go(Object sender, RoutedEventArgs e)
        {
            go.Visibility = Visibility.Collapsed;
            await rolecard6.Fade(10, 1000, 3).StartAsync();
            await rolecard1.Fade(10, 1000, 3).StartAsync();
            await rolecard2.Fade(10, 1000, 3).StartAsync();
            await rolecard3.Fade(10, 1000, 3).StartAsync();
            await rolecard4.Fade(10, 1000, 3).StartAsync();
            await rolecard5.Fade(10, 1000, 3).StartAsync();
            await rolecard0.Fade(10, 1000, 3).StartAsync();

            await persoCard1.Fade(10, 1000, 3).StartAsync();
            await persoCard2.Fade(10, 1000, 3).StartAsync();
            await persoCard3.Fade(10, 1000, 3).StartAsync();
            await persoCard4.Fade(10, 1000, 3).StartAsync();
            await persoCard5.Fade(10, 1000, 3).StartAsync();
            await persoCard6.Fade(10, 1000, 3).StartAsync();
            await persoCard7.Fade(10, 1000, 3).StartAsync();
            await persoCard8.Fade(10, 1000, 3).StartAsync();

            await kiseru.Fade(10, 1000, 1).StartAsync();
            await nodachi.Fade(10, 1000, 1).StartAsync();
            await bokken.Fade(10, 1000, 1).StartAsync();

        }
    }
}
