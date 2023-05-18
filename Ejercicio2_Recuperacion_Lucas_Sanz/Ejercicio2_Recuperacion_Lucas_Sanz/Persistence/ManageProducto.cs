using Ejercicio2_Recuperacion_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Recuperacion_Lucas_Sanz.Persistence
{
    class ManageProducto
    {
        public void insertarProducto(Producto producto)
        {
            DBBroker.getAgent().executeSQL("alter table ejerciciosrecuperacion.productos AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.productos (codigo, descripcion, coste, precio, observaciones) values ('{producto.codigo}','{producto.descripcion}','{producto.coste}','{producto.precio}','{producto.observaciones}');");
        }
        public void eliminarProducto(Producto producto)
        {

        }
        public void modificarProducto(Producto producto)
        {

        }
    }
}
