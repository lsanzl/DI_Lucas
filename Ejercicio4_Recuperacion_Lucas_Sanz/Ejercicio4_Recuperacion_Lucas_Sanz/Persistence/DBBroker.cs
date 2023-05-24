using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_Recuperacion_Lucas_Sanz.Persistence
{
    public class DBBroker
    {
        private static DBBroker instance;
        private static MySql.Data.MySqlClient.MySqlConnection connection;//
        private const String driver = "server=localhost;database=ejerciciosrecuperacion;uid=root;pwd=lusalo96";

        private DBBroker()
        {
            DBBroker.connection = new MySql.Data.MySqlClient.MySqlConnection(DBBroker.driver);
        }

        // patron singleton
        public static DBBroker getAgent()
        {
            if (DBBroker.instance == null)
            {
                DBBroker.instance = new DBBroker();
            }
            return DBBroker.instance;
        }

        // operaciones SELECT
        public List<Object> readSQL(String sql)
        {
            List<Object> res = new List<object>();
            List<Object> row;
            int i;
            MySql.Data.MySqlClient.MySqlDataReader reader;
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, DBBroker.connection);

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
        public int executeSQL(String sql)
        {
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, DBBroker.connection);
            int res;
            connectionBD();
            res = com.ExecuteNonQuery();
            desconnectionBD();
            return res;
        }

        private void connectionBD()
        {
            if (DBBroker.connection.State == System.Data.ConnectionState.Closed)
            {
                DBBroker.connection.Open();
            }
        }

        private void desconnectionBD()
        {
            if (DBBroker.connection.State == System.Data.ConnectionState.Open)
            {
                DBBroker.connection.Close();
            }
        }
    }
}
