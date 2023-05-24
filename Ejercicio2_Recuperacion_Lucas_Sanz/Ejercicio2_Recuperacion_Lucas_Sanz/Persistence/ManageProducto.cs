using Ejercicio2_Recuperacion_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ejercicio2_Recuperacion_Lucas_Sanz.Persistence
{
    public class ManageProducto
    {
        public List<Producto> listaCheck;
        public void insertarProducto(Producto producto)
        {
            DBBroker.getAgent().executeSQL("alter table ejerciciosrecuperacion.productos AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.productos (codigo, descripcion, coste, precio, observaciones) values ('{producto.codigo}','{producto.descripcion}','{producto.coste}','{producto.precio}','{producto.observaciones}');");
        }
        public void eliminarProducto(Producto producto)
        {
            DBBroker.getAgent().executeSQL($"delete from ejerciciosrecuperacion.productos where codigo='{producto.codigo}';");
        }
        public void modificarProducto(Producto producto)
        {
            listaCheck = getProductos();
            foreach(Producto p in listaCheck)
            {
                if (p.codigo == producto.codigo)
                {
                    DBBroker.getAgent().executeSQL($"update ejerciciosrecuperacion.productos set codigo='{producto.codigo}', descripcion='{producto.descripcion}', coste='{producto.coste}', precio='{producto.precio}', observaciones='{producto.observaciones}' where codigo='{producto.codigo}';");
                    MessageBox.Show("Producto modificado correctamente");
                    return;
                }
            }
            MessageBox.Show("No se ha encontrado dicho producto", "Error de código");
            return;
        }
        public List<Producto> getProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            List<Object> listaObjetos = new List<Object>();

            string codigo;
            string descripcion;
            string coste;
            string precio;
            string observaciones;

            listaObjetos = DBBroker.getAgent().readSQL("select * from ejerciciosrecuperacion.productos;");

            foreach (List<Object> item in listaObjetos)
            {
                codigo = item[1].ToString();
                descripcion = item[2].ToString();
                coste = item[3].ToString();
                precio = item[4].ToString();
                observaciones = item[5].ToString();

                Producto p = new Producto(codigo, descripcion, coste, precio, observaciones);
                listaProductos.Add(p);
            }

            return listaProductos;
        }
    }
}
