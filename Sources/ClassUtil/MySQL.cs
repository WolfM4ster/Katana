using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassUtil
{
    public class MySQL
    {
        private MySqlDataReader rdr = null;
        private MySqlCommand cmd;
        private static String constring = @"server=127.0.0.1;port=3306;database=katana;userid=root;password=root;";
        private static MySqlConnection conDataBase = new MySqlConnection(constring);
        private static MySQL instance = new MySQL();

        private MySQL()
        {
        }

        public static MySQL getInstance()
        {
            if (instance == null)
            {
                instance = new MySQL();
            }
            return instance;
        }

        public void Open()
        {
            try
            {
                conDataBase.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void Close()
        {
            try
            {
                conDataBase.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void setConstrig(string c)
        {
            constring = @c;
            conDataBase = new MySqlConnection(constring);
        }

        public List<string> doRequest(string request)
        {
            List<string> result = new List<string>();
            try
            {
                rdr = null;
                cmd = new MySqlCommand(request, conDataBase);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result.Add(Convert.ToString(rdr.GetValue(0)));
                }
                if (!rdr.HasRows)
                {
                    result.Add(Opcodes.SC_ERROR_EMPTY.ToString());
                }
                if (rdr.HasRows && Convert.ToString(rdr.GetValue(0)) == "1")
                {
                    result.Add("ERROR_3");
                }
                else
                {
                    result.Add(Opcodes.SC_QUERY_OK.ToString());
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
                result.Add(Opcodes.SC_ERROR_SERVER.ToString());
            }
            
            rdr.Close();
            return result;
        }

        public string doRequestIDU(string request)
        {
            string result;

            try
            {
                cmd = conDataBase.CreateCommand();
                cmd.Connection = conDataBase;

                cmd.CommandText = request;
                cmd.ExecuteNonQuery();
                result = Opcodes.SC_QUERY_OK.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                result = Opcodes.SC_ERROR_SERVER.ToString();
            }
            return result;
        }
    }
}