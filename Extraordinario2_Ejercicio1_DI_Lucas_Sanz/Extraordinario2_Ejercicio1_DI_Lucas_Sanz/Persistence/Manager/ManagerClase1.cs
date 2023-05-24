using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Persistence.Manager
{
    public class ManagerClase1
    {
        public void insertarClase1(Clase1 clase)
        {
            DBBroker.getAgent().executeSQL($"insert into nombretabla (parametro1, parametro2, parametro3) values ('{clase.parametro1}','{clase.parametro2}','{clase.parametro3}');");
        }
        public void eliminarClase1(Clase1 clase)
        {
            DBBroker.getAgent().executeSQL($"delete from nombretabla where parametro1='{clase.parametro1}' and parametro2='{clase.parametro2}';");
        }
        public void modificarClase1(Clase1 clase)
        {
            DBBroker.getAgent().executeSQL($"update nombretabla set parametro1='{clase.parametro1}', set parametro2='{clase.parametro2}';");
        }
        public List<Clase1> getList()
        {
            List<Object> listaObj = DBBroker.getAgent().readSQL($"select * from nombretabla;");
            List<Clase1> listaClase = new List<Clase1>();

            string parametro1;
            int parametro2;
            double parametro3;

            foreach(List<Object> o in listaObj)
            {
                parametro1 = o[0].ToString();
                parametro2 = Convert.ToInt32(o[1].ToString());
                parametro3 = Convert.ToDouble(o[1].ToString());

                Clase1 c = new Clase1(parametro1, parametro2, parametro3);
                listaClase.Add(c);
            }
            return listaClase;
        }
    }
}
