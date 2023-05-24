using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_Recuperacion_Lucas_Sanz.Model
{
    public class Consumicion
    {
        public string nombre { get; set; }
        public double precio { get; set; }

        public Consumicion(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
    }
}
