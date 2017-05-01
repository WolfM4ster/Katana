﻿using Katana.Internationalisation;
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
    public sealed partial class CreateGamesWindow : Page
    {
        public Internationalization CurrentLanguage { get; private set; }
        public PacketManager Network;
        private static int uniqueIdentifiantMenu = 4;
        private string pseudoUser;

        public CreateGamesWindow()
        {
            //Network = ;
            //pseudoUser = Network.getNickname();

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

        private int verifyFormularCreateGame()
        {
            if (nameGame.Text == "")
            {
                return -1;
            }
            /*if (numberPlayer.PlaceholderText == "")
            {
                return -1;
            }*/
            return 0;
        }

        private void homeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppWindow));
            //Network.setMenu(secondWindow);
            //Network.setUniqueHashCodeMenu(3);
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
            //Network.setMenu(secondWindow);
            //Network.setUniqueHashCodeMenu(7);
        }

        private void numberPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
