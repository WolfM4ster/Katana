using Katana.Internationalisation;

namespace Katana.Internationalisation
{
    public class US : Internationalization
    {
        public US()
        {
            // Menu MainWindow
            Title = "Connection";
            Username = "Username";
            Password = "Password";
            PasswordHelp = "Please, enter your password";
            Connection = "Connection";
            Remember = "Remember";

            // Menu AppWindow
            MenuHome = "Home";
            MenuProfile = "Profile";
            CreateGame = "Create Game";
            JoinGame = "Join Game";
            Option = "Setting";
            Logout = "Logout";
            Home = "Home";
            ServerList = "Server List";

            //Menu RegisterWindow
            Register = "Register";
            Mail = "Mail";
            PasswordConfirm = "Confirm password";
            Submit = "Submit";

            //Menu SwitchLanguage
            /*FR = "French";
            US = "English";
            JP = "Japanese";
            ES = "Spanish";*/
        }
    }
}
