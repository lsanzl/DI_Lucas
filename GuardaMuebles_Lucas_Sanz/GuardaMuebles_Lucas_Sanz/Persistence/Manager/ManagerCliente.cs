using GuardaMuebles_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuardaMuebles_Lucas_Sanz.Persistence.Manager
{
    public class ManagerCliente
    {
        public void insertarCliente(Cliente c)
        {
            DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.clientes (DNI, nombre) values ('{c.DNI}', '{c.nombre}');");
        }
        public void eliminarCliente(Cliente c)
        {
            DBBroker.getAgent().executeSQL($"delete from ejerciciosrecuperacion.clientes where DNI='{c.DNI}';");
        }
        public void modificarCliente(Cliente c)
        {
            DBBroker.getAgent().executeSQL($"update ejerciciosrecuperacion.clientes set DNI='{c.DNI}', nombre='{c.nombre}';");
            MessageBox.Show("Cliente modificado correctamente");
        }
        public List<Cliente> getClientes()
        {
            List<Object> objC = DBBroker.getAgent().readSQL("select * from ejerciciosrecuperacion.clientes");
            List<Cliente> listaClientes = new List<Cliente>();

            string DNI;
            string nombre;

            foreach (List<Object> o in objC)
            {
                DNI = o[0].ToString();
                nombre = o[1].ToString();

                Cliente c = new Cliente(DNI, nombre);
                listaClientes.Add(c);
            }
            return listaClientes;
        }
        public Boolean checkCodigo(string dni)
        {
            List<Object> listaCheck = DBBroker.getAgent().readSQL($"select * from ejerciciosrecuperacion.clientes where DNI='{dni}';");

            if (listaCheck.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
