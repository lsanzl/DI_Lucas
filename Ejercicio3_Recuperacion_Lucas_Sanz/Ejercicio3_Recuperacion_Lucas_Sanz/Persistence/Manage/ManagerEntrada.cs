using Ejercicio3_Recuperacion_Lucas_Sanz.Model;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_Recuperacion_Lucas_Sanz.Persistence.Manage
{
    public class ManagerEntrada
    {
        public ManagerSesion managerS = new ManagerSesion();
        public void insertarEntrada(Entrada entrada)
        {
            DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.circo (fecha, sesion, edad, precio) values ('{entrada.fecha}','{entrada.sesion}','{entrada.edad}','{entrada.precio}');");
            if (!managerS.checkFuncion(entrada.fecha, entrada.sesion))
            {
                managerS.crearSesion(entrada.fecha, entrada.sesion, false);
            }
            else
            {
                managerS.crearSesion(entrada.fecha, entrada.sesion, true);
            }
        }
        public List<Entrada> getEntradas(string fecha, int sesion)
        {
            List<Object> listaObjetos = DBBroker.getAgent().readSQL($"select * from ejerciciosrecuperacion.circo where fecha='{fecha}' and sesion='{sesion}';");
            List<Entrada> listaEntradas = new List<Entrada>();

            string fechaobj;
            int sesionobj;
            int edad;
            int precio;

            foreach(List<Object> o in listaObjetos)
            {
                fechaobj = o[1].ToString();
                sesionobj = Convert.ToInt32(o[2]);
                edad = Convert.ToInt32(o[3]);
                precio = Convert.ToInt32(o[4]);

                Entrada entrada = new Entrada(fechaobj, sesionobj, edad, precio);
                listaEntradas.Add(entrada);
            }
            return listaEntradas;
        }
    }
}
