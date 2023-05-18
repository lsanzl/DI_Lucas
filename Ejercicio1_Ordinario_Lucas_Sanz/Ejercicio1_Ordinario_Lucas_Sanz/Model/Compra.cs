using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Ordinario_Lucas_Sanz.Model
{
    public class Compra
    {
        public int cantidad { get; set; }
        public string producto { get; set; }
        public double precioUnitario { get; set; }

        public Compra(int cantidad, string producto, double precioUnitario)
        {
            this.cantidad = cantidad;
            this.producto = producto;
            this.precioUnitario = precioUnitario;
        }
        public Compra()
        {

        }

        public double getPrecioTotal()
        {
            return precioUnitario * cantidad;
        }
        public double getPrecioAbsoluto(List<Compra> listaCompra)
        {
            double precioAbsolutoCalculado = 0;
            foreach(Compra c in listaCompra)
            {
                precioAbsolutoCalculado += c.getPrecioTotal();
            }
            return precioAbsolutoCalculado;
        }
    }
}
