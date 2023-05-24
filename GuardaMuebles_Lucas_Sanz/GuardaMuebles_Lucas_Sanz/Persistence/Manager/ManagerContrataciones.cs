using GuardaMuebles_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardaMuebles_Lucas_Sanz.Persistence.Manager
{
    public class ManagerContrataciones
    {
        public void insertarContratacion(Contratacion cont)
        {
            DBBroker.getAgent().executeSQL($"insert into ejerciciosrecuperacion.contrataciones (DNI, codigo, meses, precioTotal) values ('{cont.DNI}', '{cont.codigo}','{cont.meses}', '{cont.precioTotal}');");
        }
        public void eliminarContratacion(Contratacion cont)
        {
            DBBroker.getAgent().executeSQL($"delete from ejerciciosrecuperacion.contrataciones where DNI='{cont.DNI}' and codigo='{cont.codigo}';");
        }
        public List<Contratacion> getContrataciones()
        {
            List<Object> obj = DBBroker.getAgent().readSQL("select * from ejerciciosrecuperacion.contrataciones;");
            List<Contratacion> listaContratos = new List<Contratacion>();

            string DNI;
            string codigo;
            int meses;
            double precio;

            foreach(List<Object> o in obj)
            {
                DNI = o[0].ToString();
                codigo = o[1].ToString();
                meses = Convert.ToInt32(o[2].ToString());
                precio = Convert.ToDouble(o[3].ToString());

                Contratacion cont = new Contratacion(DNI, codigo, meses, precio);
                listaContratos.Add(cont);
            }
            return listaContratos;
        }
    }
}
