using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_Recuperacion_Lucas_Sanz.Persistence.Manage
{
    public class ManagerSesion
    {
        public Boolean checkFuncion(string fecha, int sesion)
        {
            List<Object> listaCheck = DBBroker.getAgent().readSQL($"select * from ejerciciosrecuperacion.estadisticascirco where fecha='{fecha}' and sesion='{sesion}';");

            if ( listaCheck.Count == 0)
            {
                return false;
            }
            return true;
        }
        public void crearSesion(string fecha, int sesion, Boolean existe)
        {
            string edadMedia = getEdadMedia(fecha, sesion);
            int totalRecaudado = getTotalRecaudado(fecha, sesion);
            List<int> edades = getEdadesFranja(fecha, sesion);
            int edad1 = edades[0];
            int edad2 = edades[1];
            int edad3 = edades[2];
            int edad4 = edades[3];

            if (!existe)
            {
                DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.estadisticascirco (fecha, sesion, edadMedia, totalRecaudado, asistentes0a4, asistentes4a8, asistentes8a65, asistentes65) values ('{fecha}', '{sesion}', '{edadMedia}', '{totalRecaudado}', '{edad1}', '{edad2}', '{edad3}', '{edad4}');");
            }
            else
            {
                DBBroker.getAgent().executeSQL($"update ejerciciosrecuperacion.estadisticascirco set fecha='{fecha}', sesion='{sesion}', edadMedia='{edadMedia}', totalRecaudado='{totalRecaudado}', asistentes0a4='{edad1}', asistentes4a8='{edad2}', asistentes8a65='{edad3}', asistentes65='{edad4}';");
            }
            
        }
        public string getEdadMedia(string fecha, int sesion)
        {
            List<Object> listaEdadMedia = DBBroker.getAgent().readSQL($"select edad from ejerciciosrecuperacion.circo where fecha='{fecha}' and sesion='{sesion}';");

            double edadMedia = 0;
            foreach(List<Object> obj in listaEdadMedia)
            {
                edadMedia += Convert.ToDouble(obj[0]);
            }
            edadMedia = edadMedia / listaEdadMedia.Count();

            return edadMedia.ToString();
        }
        public int getTotalRecaudado(string fecha, int sesion)
        {
            List<Object> listaTotalRecaudado = DBBroker.getAgent().readSQL($"select precio from ejerciciosrecuperacion.circo where fecha='{fecha}' and sesion='{sesion}';");

            int total = 0;
            foreach (List<Object> obj in listaTotalRecaudado)
            {
                total += Convert.ToInt32(obj[0]);
            }

            return total;
        }
        public List<int> getEdadesFranja(string fecha, int sesion)
        {
            List<int> edades = new List<int>() { 0, 0, 0, 0 };
            List<Object> listaObjetos = DBBroker.getAgent().readSQL($"select edad from ejerciciosrecuperacion.circo where fecha='{fecha}' and sesion='{sesion}';");

            foreach(List<Object> obj in listaObjetos)
            {
                int edad = Convert.ToInt32(obj[0]);

                if (edad >= 0 && edad < 4)
                {
                    edades[0]++;
                }
                else if (edad >= 4 && edad < 8)
                {
                    edades[1]++;
                }
                else if (edad >= 8 && edad < 65)
                {
                    edades[2]++;
                }
                else if (edad >= 65)
                {
                    edades[3]++;
                }
            }
            return edades;
        }
        public int getRecaudacion(string mes, string año)
        {
            List<Object> objetos = DBBroker.getAgent().readSQL($"select fecha, totalRecaudado from ejerciciosrecuperacion.estadisticascirco");

            string[] fechaSplit;
            string fechaString;
            DateTime fecha;
            int recaudacionTotal = 0;

            foreach(List<Object> obj in objetos)
            {
                fechaString = obj[0].ToString();
                fecha = DateTime.Parse(fechaString);
                fechaString = fecha.ToString("yyyy-MM-dd");
                fechaSplit = fechaString.Split('-');

                if (fechaSplit[0] == año && fechaSplit[1] == mes)
                {
                    recaudacionTotal += Convert.ToInt32(obj[1]);
                }
            }
            return recaudacionTotal;
        }
    }
}
