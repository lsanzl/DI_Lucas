using GuardaMuebles_Lucas_Sanz.Persistence.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardaMuebles_Lucas_Sanz.Model
{
    public class Guardamueble
    {
        public string codigo { get; set; }
        public int tamaño { get; set; }
        public double precio { get; set; }
        public ManagerGuardamueble manager;

        public Guardamueble(string codigo, int tamaño, double precio)
        {
            this.codigo = codigo;
            this.tamaño = tamaño;
            this.precio = precio;
            manager = new ManagerGuardamueble();
        }
        public void insertarGuardamueble()
        {
            manager.insertarGuardamueble(this);
        }
        public void eliminarGuardamueble()
        {
            manager.eliminarGuardamueble(this);
        }
        public void modificarGuardamueble()
        {
            manager.modificarGuardamueble(this);
        }
    }
}
