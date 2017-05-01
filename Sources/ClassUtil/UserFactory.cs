using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassUtil
{
    public class UserFactory
    {
        private static UserFactory instance = new UserFactory();
        //private PostgreSQL db;
        private MySQL db;
        private string resultCreateUser;

        private UserFactory()
        {
        }

        public static UserFactory getInstance()
        {
            if(instance == null)
            {
                return instance = new UserFactory();
            }
            return instance;
        }

        public User createUser(string[] data)
        {
            try
            {
                db = MySQL.getInstance();
                //db.Open();

                int isBanned = 0;
                string resultat;

                /*string queryInsertUserData = "INSERT INTO public.\"User\"(pseudo,mail,password,isBanned) " +
                                               "values('" + data[0] + "','" + data[1] + "','" + data[2] + 
                                               "','" +  +isBanned + "');";*/

                string queryInsertUserData = "INSERT INTO User(pseudo,mail,password,isBanned) " +
                                             "values('" + data[0] + "','" + data[1] + "','" + data[2] + 
                                             "','" + isBanned + "');";

                resultat = db.doRequestIDU(queryInsertUserData);

                if (resultat == Opcodes.SC_QUERY_OK.ToString())
                {
                    setResultCreatOfUser(Opcodes.SC_QUERY_OK.ToString());
                    return new UserConcrete(data[0], data[1]);
                }
                else
                {
                    setResultCreatOfUser(Opcodes.SC_ERROR_SERVER.ToString());
                    return null;
                }
            }
            
            catch (Exception e)
            {
                db.Close();
                //Console.WriteLine(s.Red());
                Debug.WriteLine(e.ToString());
                return null;
            }
            
        }
        public void setResultCreatOfUser(string result)
        {
            resultCreateUser = result;
        }

        public string getResultCreatOfUser()
        {
            return resultCreateUser;
        }
    }
}