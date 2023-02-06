using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Persistence
{
    public class DBBroker
    {
        private static DBBroker instance;
        private static MySql.Data.MySqlClient.MySqlConnection connection;//
        private const string driver = "server=localhost;database=hplucas;uid=root;pwd=lusalo96";

        private DBBroker()
        {
            connection = new MySql.Data.MySqlClient.MySqlConnection(driver);
        }

        // patron singleton
        public static DBBroker getAgent()
        {
            if (instance == null)
            {
                instance = new DBBroker();
            }
            return instance;
        }

        // operaciones SELECT
        public List<object> readSQL(string sql)
        {
            List<object> res = new List<object>();
            List<object> row;
            int i;
            MySql.Data.MySqlClient.MySqlDataReader reader;
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);

            connectionBD();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                row = new List<object>();
                for (i = 0; i <= reader.FieldCount - 1; i++)
                {
                    row.Add(reader[i].ToString());

                }
                res.Add(row);
            }
            desconnectionBD();
            return res;
        }

        // operaciones INSERT, UPDATE, DELETE
        public int executeSQL(string sql)
        {
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);
            int res;
            connectionBD();
            res = com.ExecuteNonQuery();
            desconnectionBD();
            return res;
        }

        private void connectionBD()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void desconnectionBD()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
