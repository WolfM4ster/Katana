using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtil
{
    public abstract class User
    {
        private string pseudo;
        private string mail;
        private string password;

        public User(string pseudo, string mail)
        {
            this.pseudo = pseudo;
            this.mail = mail;
        }

        public void rejoinGame()
        {

        }

        public void createGame()
        {

        }

        public String getPseudo()
        {
            return this.pseudo;
        }
    }
}
