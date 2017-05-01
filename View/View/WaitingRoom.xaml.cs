using Katana.Internationalisation;
using Katana.internationalization;
using Katana.Network;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Katana.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class WaitingRoom : Page
    {
        private PacketManager Network;
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
            //Network = NetworkWaitingRoom;
            //pseudoUser = Network.getNickname();
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
            //Network.setMenu(secondWindow);
            //Network.setUniqueHashCodeMenu(8);
            Frame.Navigate(typeof(GameWindow));
        }

        private void buttonReadyClick(object sender, RoutedEventArgs e)
        {

        }

        private void buttonHomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppWindow));
            //Network.setMenu(secondWindow);
            //Network.setUniqueHashCodeMenu(3);
        }
    }
}
