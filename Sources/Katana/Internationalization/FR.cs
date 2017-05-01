using Katana.Internationalisation;

namespace Katana.Internationalisation
{
    public class FR : Internationalization
    {
        public FR()
        {
            // Menu MainWindow
            Title = "Connexion";
            Username = "Identifiant";
            Password = "Mot de passe";
            Connection = "Connexion";
            Remember = "Se souvenir";

            // Menu AppWindow
            MenuHome = "Accueil";
            MenuProfile = "Profil";
            CreateGame = "Créer Partie";
            JoinGame = "Rejoindre Partie";
            Option = "Options";
            Logout = "Quitter";
            Home = "Accueil";
            ServerList = "Liste des parties";

            //Menu RegisterWindow
            Register = "Inscription";
            Mail = "Mail";
            PasswordConfirm = "Confirmer mot de passe";
            Submit = "Soumettre";

            //Menu SwitchLanguageWindow
            /*FR = "Français";
            US = "Anglais";
            JP = "Japonais";
            ES = "Espagnol";*/
        }
    }
}
