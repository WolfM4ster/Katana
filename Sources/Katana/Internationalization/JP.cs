using Katana.Internationalisation;

namespace Katana.internationalization
{
    public class JP : Internationalization
    {
        public JP()
        {
            // Menu MainWindow
            Title = "でログインします";
            Username = "ユーザー名";
            Password = "パスワード";
            Connection = "でログインします";
            Remember = "思い出します";

            // Menu AppWindow
            MenuHome = "歓迎";
            CreateGame = "パーティーを作成します";
            JoinGame = "パーティーに参加";
            Option = "オプション";
            Logout = "去ります";
            Home = "歓迎";
            ServerList = "締約国のリスト";

            //Menu RegisterWindow
            Register = "登録";
            Mail = "郵便";
            PasswordConfirm = "パスワードを確認";
            Submit = "提出します";

            //Menu SwitchLanguageWindow
            /*FR = "フランス語";
            US = "英語";
            JP = "フランス語";
            ES = "スペイン語";*/
        }
    }
}
