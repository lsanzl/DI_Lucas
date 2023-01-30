using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recuperacion3_Lucas_Sanz.Model;

namespace Recuperacion3_Lucas_Sanz.Persistence
{
    internal class EmpleadoManage
    {
        public List<Empleado> listaEmpleados { get; set; }

        public EmpleadoManage()
        {
            this.listaEmpleados = new List<Empleado>();
        }

        public void leerEmpleados()
        {
            Empleado empleado = null;
            List<Object> lista_aux = DBBroker.getAgent().readSQL("Select * from recuperacion_db.empleadosfaunia");
            foreach (List<Object> emple in lista_aux)
            {
                empleado = new Empleado();
                empleado.id = Convert.ToInt32(emple[0]);
                empleado.nif = emple[1].ToString();
                empleado.nombre = emple[2].ToString();
                empleado.apellidos = emple[3].ToString();
                empleado.edad = Convert.ToInt32(emple[4]);
                this.listaEmpleados.Add(empleado);
            }
        }
    }
}
