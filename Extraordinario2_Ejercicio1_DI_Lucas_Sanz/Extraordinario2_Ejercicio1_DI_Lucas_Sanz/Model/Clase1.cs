using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Persistence.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Model
{
    public class Clase1
    {
        public string parametro1 { get; set; }
        public int parametro2 { get; set; }
        public double parametro3 { get; set; }
        public ManagerClase1 manager;

        public Clase1(string parametro1, int parametro2, double parametro3)
        {
            this.parametro1 = parametro1;
            this.parametro2 = parametro2;
            this.parametro3 = parametro3;
            manager = new ManagerClase1();
        }
        public void insertarClase1()
        {
            manager.insertarClase1(this);
        }
        public void eliminarClase1()
        {
            manager.eliminarClase1(this);
        }
        public void modificarClase1()
        {
            manager.modificarClase1(this);
        }
    }
}
