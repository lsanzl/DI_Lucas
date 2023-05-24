using GuardaMuebles_Lucas_Sanz.Persistence.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardaMuebles_Lucas_Sanz.Model
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string DNI { get; set; }
        public ManagerCliente manager;

        public Cliente(string DNI, string nombre)
        {
            this.nombre = nombre;
            this.DNI = DNI;
            this.manager = new ManagerCliente();
        }
        public void insertarCliente()
        {
            manager.insertarCliente(this);
        }
        public void eliminarCliente()
        {
            manager.eliminarCliente(this);
        }
        public void modificarCliente()
        {
            manager.modificarCliente(this);
        }
    }
}
