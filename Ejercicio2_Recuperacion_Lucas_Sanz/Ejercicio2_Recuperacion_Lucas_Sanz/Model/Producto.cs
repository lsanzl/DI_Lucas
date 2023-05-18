using Ejercicio2_Recuperacion_Lucas_Sanz.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Recuperacion_Lucas_Sanz.Model
{
    public class Producto
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double coste { get; set; }
        public double precio { get; set; }
        public string observaciones { get; set; }

        public Producto(string codigo, string descripcion, double coste, double precio, string observaciones)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.coste = coste;
            this.precio = precio;
            this.observaciones = observaciones;

            ManageProducto manager = new ManageProducto();
        }

        public void insertarProducto()
        {
            
        }
        public void eliminarProducto()
        {

        }
        public void modificarProducto()
        {

        }

    }

}
