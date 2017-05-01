using Katana.Internationalisation;
using Katana.internationalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Katana.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AppWindow : Page
    {
        public Internationalization CurrentLanguage { get; private set; }
        private string pseudoUser;
        private static int uniqueIdentifiantMenu = 3;
        private static AppWindow instance;

        public AppWindow()
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
            //pseudoUser = Network.getNickname();
        }

        public static AppWindow getInstance()
        {
            if (instance == null)
            {
                instance = new AppWindow();
                return instance;
            }
            return instance;
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

        private void CreateGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateGamesWindow));
        }

        private void JoinGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(JoinGameWindow));
        }

        private void OptionClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SwitchLanguageWindow));
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
