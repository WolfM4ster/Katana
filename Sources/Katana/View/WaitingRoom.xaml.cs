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
    public sealed partial class WaitingRoom : Page
    {
        private string pseudoUser;
        public Internationalization CurrentLanguage { get; private set; }
        private static int uniqueIdentifiantMenu = 7;

        public WaitingRoom()
        {
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
            SwitchLanguage(Languages.French);
            InitializeComponent();
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

        private void buttonSubmitClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameWindow));
        }

        private void buttonReadyClick(object sender, RoutedEventArgs e)
        {

        }

        private void buttonHomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppWindow));
        }
    }
}
