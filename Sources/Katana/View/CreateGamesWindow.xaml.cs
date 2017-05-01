using Katana.Internationalisation;
using Katana.internationalization;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Katana.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class CreateGamesWindow : Page
    {
        public Internationalization CurrentLanguage { get; private set; }
        private static int uniqueIdentifiantMenu = 4;
        private string pseudoUser;

        public CreateGamesWindow()
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

        private int verifyNumberPlayer()
        {
            foreach (ComboBoxItem item in numberPlayer.Items)
            {
                if (item.IsSelected)
                {
                    int numVal = Int32.Parse(item.Content.ToString());
                    Settings.Default.numberPlayer = numVal;
                    return numVal;
                }
            }
            return -1;
        }

        private int verifyFormularCreateGame()
        {
            if (nameGame.Text == "")
            {
                return -1;
            }
            if(verifyNumberPlayer() == -1)
            {
                return -1;
            }
            return 0;
        }

        private void homeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppWindow));
        }

        private void CreateGameClick(object sender, RoutedEventArgs e)
        {
            if (verifyFormularCreateGame() == 0)
            {
                createGame();
            }
        }

        private void createGame()
        {

            Frame.Navigate(typeof(WaitingRoom));
        }

        private void numberPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
