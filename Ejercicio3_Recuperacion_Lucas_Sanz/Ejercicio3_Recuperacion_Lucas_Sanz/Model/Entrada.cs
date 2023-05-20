using Ejercicio3_Recuperacion_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_Recuperacion_Lucas_Sanz.Model
{
    public class Entrada
    {
        public string fecha { get; set; }
        public int sesion { get; set; }
        public int edad { get; set; }
        public int precio { get; set; }
        public ManagerEntrada manager = new ManagerEntrada();

        public Entrada (string fecha, int sesion, int edad, int precio)
        {
            this.fecha = fecha;
            this.sesion = sesion;
            this.edad = edad;
            this.precio = precio;
        }
        public void insertarEntrada()
        {
            manager.insertarEntrada(this);
        }
    }
}
