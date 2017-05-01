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
    public sealed partial class SwitchLanguageWindow : Page
    {
        private Frame rootFrame = Window.Current.Content as Frame;
        public PacketManager Network;
        public Internationalization CurrentLanguage { get; private set; }
        private string pseudoUser;
        private static SwitchLanguageWindow instance;
        private static int uniqueIdentifiantMenu = 6;

        public SwitchLanguageWindow()
        {
            //Network = NetworkSwitchLanguageWindow;
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

        /*public static SwitchLanguageWindow getInstance(PacketManager Network)
        {
            if (instance == null)
            {
                instance = new SwitchLanguageWindow(Network);
                return instance;
            }
            return instance;
        }*/

        private void homeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppWindow));
        }

        /*private void ButtonUSClick(object sender, RoutedEventArgs e)
        {
            CurrentLanguage = new US();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "US";
            Settings.Default.Save();
        }

        private void ButtonFRClick(object sender, RoutedEventArgs e)
        {
            CurrentLanguage = new FR();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "FR";
            Settings.Default.Save();
        }

        private void ButtonESClick(object sender, RoutedEventArgs e)
        {
            CurrentLanguage = new ES();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "ES";
            Settings.Default.Save();
        }

        private void ButtonJPClick(object sender, RoutedEventArgs e)
        {
            CurrentLanguage = new JP();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "JP";
            Settings.Default.Save();
        }*/

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
        
        private void FR_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentLanguage = new FR();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "FR";
            Settings.Default.Save();
        }

        private void ES_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentLanguage = new ES();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "ES";
            Settings.Default.Save();
        }

        private void JP_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentLanguage = new JP();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "JP";
            Settings.Default.Save();
        }

        private void US_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentLanguage = new US();
            this.DataContext = CurrentLanguage;
            Settings.Default.Langue = "US";
            Settings.Default.Save();
        }
    }
}
