using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_Recuperacion_Lucas_Sanz.Persistence.Manage
{
    public class ManagerConsumicion
    {
        public Dictionary<string, double> listaPrecios = new Dictionary<string, double>();

        public Dictionary<string, double> getPrecios()
        {
            listaPrecios.Clear();
            string nombre;

            List<Object> listaSQL = DBBroker.getAgent().readSQL("select nombre, precio from ejerciciosrecuperacion.productosbar;");

            foreach(List<Object> obj in listaSQL)
            {
                nombre = obj[0].ToString();
                nombre = nombre.Replace(" ", "");
                nombre = nombre.ToLower();
                listaPrecios.Add(nombre, Convert.ToDouble(obj[1]));
            }
            return listaPrecios;
        }
    }
}
