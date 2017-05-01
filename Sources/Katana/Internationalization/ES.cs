using Katana.Internationalisation;

namespace Katana.internationalization
{
    public class ES : Internationalization
    {
        public ES()
        {
            // Menu MainWindow
            Title = "conexión";
            Username = "login";
            Password = "Contraseña";
            Connection = "conexión";
            Remember = "Acordarse";

            // Menu AppWindow
            MenuHome = "Recepción";
            CreateGame = "Crear Partido";
            JoinGame = "Unirse Partido";
            Option = "Opciones";
            Logout = "Dejar";
            Home = "Recepción";
            ServerList = "Lista de las Partes";

            //Menu RegisterWindow
            Register = "Registro";
            Mail = "correo";
            PasswordConfirm = "Confirmar la contraseña";
            Submit = "Enviar";

            //Menu SwitchLanguageWindow
            FR = "francés";
            US = "Inglés";
            JP = "japonés";
            ES = "español";
        }
    }
}
