using Recuperacion3_Lucas_Sanz.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperacion3_Lucas_Sanz.Model
{
    internal class Empleado
    {
        public int id { get; set; }
        public string nif { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public EmpleadoManage empleManage { get; set; }

        public Empleado(int id)
        {
            this.id = id;
            this.empleManage = new EmpleadoManage();
        }

        public Empleado()
        {
            this.empleManage = new EmpleadoManage();
        }

        public List<Empleado> getList()
        {
            return this.empleManage.listaEmpleados;
        }
        public void readAll()
        {
            this.empleManage.leerEmpleados();
        }
    }
}
