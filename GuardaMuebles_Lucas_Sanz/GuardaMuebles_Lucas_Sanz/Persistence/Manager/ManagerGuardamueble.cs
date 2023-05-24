using GuardaMuebles_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuardaMuebles_Lucas_Sanz.Persistence.Manager
{
    public class ManagerGuardamueble
    {
        public void insertarGuardamueble(Guardamueble guarda)
        {
            //string precio = guarda.precio.ToString();
            //precio = precio.Replace(".", ",");
            DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.guardamuebles (codigo, tamaño, precio) values ('{guarda.codigo}', '{guarda.tamaño}', '{guarda.precio}');");
        }
        public void eliminarGuardamueble(Guardamueble guarda)
        {
            DBBroker.getAgent().executeSQL($"delete from ejerciciosrecuperacion.guardamuebles where codigo='{guarda.codigo}';");
        }
        public void modificarGuardamueble(Guardamueble guarda)
        {
            DBBroker.getAgent().executeSQL($"update ejerciciosrecuperacion.guardamuebles set codigo='{guarda.codigo}', tamaño='{guarda.tamaño}', precio='{guarda.precio}';");
            MessageBox.Show("Guardamueble modificado correctamente");
        }
        public List<Guardamueble> getGuardamueble()
        {
            List<Object> objG = DBBroker.getAgent().readSQL("select * from ejerciciosrecuperacion.guardamuebles");
            List<Guardamueble> listaGuardamuebles = new List<Guardamueble>();

            string codigo;
            int tamaño;
            string precio;

            foreach(List<Object> o in objG)
            {
                codigo = o[0].ToString();
                tamaño = Convert.ToInt32(o[1]);
                precio = o[2].ToString();

                precio = precio.Replace(',', '.');

                Guardamueble g = new Guardamueble(codigo, tamaño, Convert.ToDouble(precio));
                listaGuardamuebles.Add(g);
            }
            return listaGuardamuebles;
        }
        public Boolean checkCodigo(string codigo)
        {
            List<Object> listaCheck = DBBroker.getAgent().readSQL($"select * from ejerciciosrecuperacion.guardamuebles where codigo='{codigo}';");

            if (listaCheck.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
