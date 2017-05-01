using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtil
{
    public class PostgreSQL
    {
        /*private static string conx = "Server=localhost;Port=5432;Database=katana;User Id=postgres;Password=root;";
        private NpgsqlCommand cmd = null;
        private static NpgsqlConnection connectionDatabase = new NpgsqlConnection(conx);
        private static NpgsqlDataReader reader = null;
        private static PostgreSQL instance = new PostgreSQL();

        private PostgreSQL()
        {

        }

        public static PostgreSQL getInstance()
        {
            if (instance == null)
            {
                return new PostgreSQL();
            }

            return instance;
        }

        public void Open()
        {
            try
            {
                connectionDatabase.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Close()
        {
            try
            {
                connectionDatabase.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<string> doRequest(string query)
        {
            List<string> result = new List<string>();
            try
            {
                // Define a query
                cmd = new NpgsqlCommand(query, connectionDatabase);

                // Execute a query
                reader = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader.GetValue(0)));
                }

                if (!reader.HasRows)
                {
                    result.Add("ERROR_1");
                }
                if (reader.HasRows && Convert.ToString(reader.GetValue(0)) == "1")
                {
                    result.Add("ERROR_3");
                }
                else
                {
                    result.Add("OK");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result.Add("SRV_ERROR");
            }

            reader.Close();
            return result;
        }

        public int doRequestIDU(string query)
        {
            int result;

            try
            {
                cmd = new NpgsqlCommand(query, connectionDatabase);
                cmd.ExecuteNonQuery();
                result = 0;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                result = -1;
            }
            return result;
        }*/
    }
}

