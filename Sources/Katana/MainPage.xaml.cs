using Katana.Internationalisation;
using Katana.internationalization;
using Katana.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Katana
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<string> UserData;
        public Internationalization CurrentLanguage { get; private set; }
        public static char SEPERATOR_CHAR = '_';
        public string strName;
        private static Socket clientSocket;
        private static int numberCallOfInstance = 0;
        private static int uniqueIdentifiantMenu = 1;
        private static MainPage instance;

        public MainPage()
        {
            instance = this;
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

        public static MainPage getInstance()
        {
            if (instance == null)
            {
                instance = new MainPage();
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

        private void MetroWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.SouvenirState == 1)
            {
                username.Text = Settings.Default.Identifiant;
                password.Password = Settings.Default.MDP;
                remember.IsChecked = true;
            }
            if (numberCallOfInstance == 0)
            {
                numberCallOfInstance += 1;
            }
            else
            {
                numberCallOfInstance += 1;
            }
        }

        private void fillUserData()
        {
            try
            {
                UserData.Clear();
                UserData.Add(username.Text);
                UserData.Add(password.Password);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            };
        }

        private int verifyUsername()
        {
            Regex usernameRegex = new Regex("^([a-zA-Z0-9-_]{2,36})$");
            if (username.Text.Length == 0)
            {
                errorMessage.Text = "Enter an pseudo.";
                username.Focus(FocusState.Programmatic);
                return -1;
            }
            if (!usernameRegex.IsMatch(username.Text))
            {
                errorMessage.Text = "Enter valid Pseudo.";
                username.Focus(FocusState.Programmatic);
                return -1;
            }
            return 0;
        }

        private int verifyPassword()
        {
            Regex passwordRegex = new Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$");
            if (password.Password.Length == 0)
            {
                errorMessage.Text = "Enter password.";
                password.Focus(FocusState.Programmatic);
                return -1;
            }

            if (!passwordRegex.IsMatch(password.Password))
            {
                errorMessage.Text = "password is not valid";
                password.Focus(FocusState.Programmatic);
                return -1;
            }
            return 0;
        }

        private int verify()
        {
            if (verifyUsername() == -1) return -1;
            if (verifyPassword() == -1) return -1;

            return 0;
        }

        private void buttonSubmitClick(object sender, RoutedEventArgs e)
        {
            if (!(verify() == -1))
            {
                connexion();
            }
        }

        private async void connexion()
        {
            string pass = password.Password;
            String userCrypted = null;
            userCrypted = sha256_hash(pass);

            strName = username.Text;
            Frame.Navigate(typeof(AppWindow));
        }

        private void ButtonClickRegister(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterWindow));
        }

        public static string sha256_hash(string value)
        {
            // Create a string that contains the name of the
            // hashing algorithm to use.
            string strAlgName = HashAlgorithmNames.Sha512;

            // Create a HashAlgorithmProvider object.
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);

            // Create a CryptographicHash object. This object can be reused to continually
            // hash new messages.
            CryptographicHash objHash = objAlgProv.CreateHash();

            // Hash message 1.
            string strMsg1 = value;
            IBuffer buffMsg1 = CryptographicBuffer.ConvertStringToBinary(strMsg1, BinaryStringEncoding.Utf16BE);
            objHash.Append(buffMsg1);
            IBuffer buffHash1 = objHash.GetValueAndReset();

            // Convert the hashes to string values (for display);
            string strHash1 = CryptographicBuffer.EncodeToBase64String(buffHash1);
            Debug.WriteLine(strHash1);
            return strHash1;
        }
    }
}
