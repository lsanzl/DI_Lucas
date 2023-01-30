using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperacion_DI_Lucas_Sanz.Persistence
{
    public class DBBroker
    {
        private static DBBroker _instancia;
        private static MySql.Data.MySqlClient.MySqlConnection conexion;//
        private const string cadenaConexion = "server=localhost;database=recuperacion_di;uid=root;pwd=lusalo96";

        private DBBroker()
        {
            conexion = new MySql.Data.MySqlClient.MySqlConnection(cadenaConexion);

        }

        public static DBBroker obtenerAgente()
        {
            if (_instancia == null)
            {
                _instancia = new DBBroker();
            }
            return _instancia;
        }

        public List<object> leer(string sql)
        {
            List<object> resultado = new List<object>();
            List<object> fila;
            int i;
            MySql.Data.MySqlClient.MySqlDataReader reader;
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, conexion);

            conectar();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                fila = new List<object>();
                for (i = 0; i <= reader.FieldCount - 1; i++)
                {
                    fila.Add(reader[i].ToString());

                }
                resultado.Add(fila);
            }
            desconectar();
            return resultado;
        }
        public int modificar(string sql)
        {
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, conexion);
            int resultado;
            conectar();
            resultado = com.ExecuteNonQuery();
            desconectar();
            return resultado;
        }
        private void conectar()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }
        private void desconectar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
