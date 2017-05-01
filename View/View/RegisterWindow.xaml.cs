using ClassUtil;
using Katana.Internationalisation;
using Katana.internationalization;
using Katana.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
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
    public sealed partial class RegisterWindow : Page
    {
        private List<string> UserData = new List<string>();
        //public PacketManager Network = new PacketManager(100);
        public PacketManager Network;
        public Internationalization CurrentLanguage { get; private set; }
        private Socket clientSocket;
        private static int uniqueIdentifiantMenu = 2;
        public static char SEPERATOR = '_';
        private static RegisterWindow instance;

        public RegisterWindow()
        {
            //this.Network = NetworkRegisterWindow;
            //clientSocket = Network.getSocket();

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

        public static RegisterWindow getInstance(PacketManager Network)
        {
            if (instance == null)
            {
                instance = new RegisterWindow();
                return instance;
            }
            return instance;
        }

        private void RegisterWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void fillUserData()
        {
            UserData.Clear();
            UserData.Add(username.Text);
            UserData.Add(mail.Text);
            UserData.Add(sha256_hash(password.Password));
            UserData.Add(passwordConfirm.Password);
        }

        private int verifyMail()
        {
            Regex mailRegex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (mail.Text.Length == 0)
            {
                errorMessage.Text = "Enter an email.";
                mail.Focus(FocusState.Programmatic);
                return -1;
            }
            if (!mailRegex.IsMatch(mail.Text))
            {
                errorMessage.Text = "Enter a valid email.";
                mail.Select(0, mail.Text.Length);
                mail.Focus(FocusState.Programmatic);
                return -1;
            }
            return 0;
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

        private int verifyPasswordConfirm()
        {
            if (passwordConfirm.Password.Length == 0)
            {
                errorMessage.Text = "Enter confirmation password.";
                passwordConfirm.Focus(FocusState.Programmatic);
                return -1;
            }
            if (passwordConfirm.Password != password.Password)
            {
                errorMessage.Text = "Enter a valid confirmation password.";
                passwordConfirm.Focus(FocusState.Programmatic);
                return -1;
            }
            return 0;
        }

        private int verify()
        {
            if (verifyMail() == -1) return -1;
            if (verifyUsername() == -1) return -1;
            if (verifyPassword() == -1) return -1;
            if (verifyPasswordConfirm() == -1) return -1;

            return 0;
        }

        private void buttonSubmitClick(object sender, RoutedEventArgs e)
        {
            if (!(verify() == -1))
            {
                register();
            }
        }

        private void register()
        {
            List<string> dataUserStructured = new List<string>();

            fillUserData();

            int i = 0;

            foreach (string str in UserData)
            {
                dataUserStructured.Add(str);
                i++;
            }
            Frame.Navigate(typeof(MainPage));

            /*Packet msgToSend = new Packet();
            msgToSend.command = Opcodes.CS_REGISTRATION;
            msgToSend.name = null;
            msgToSend.message = dataUserStructured[0] + SEPERATOR + dataUserStructured[1] + SEPERATOR + dataUserStructured[2];

            byte[] b = msgToSend.ToByte();
            clientSocket.Send(b, 0, b.Length, SocketFlags.None);*/
        }

        private void homeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
            //Network.setMenu(secondWindow);
            //Network.setUniqueHashCodeMenu(1);
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

        // Function qui sera appelée pour le hash en SHA-256
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
