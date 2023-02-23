using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP_Lucas_Sanz.Model;

namespace HP_Lucas_Sanz.Persistence.Manage
{
    public class ManageBuy
    {
        public int idC { get; set;}
        public int idA { get; set;}
        public List<Buy> list_buys;
        public List<Object> list_buys_object;
        public List<Buy> readBuy()
        {
            list_buys_object = DBBroker.getAgent().readSQL("select * from hplucas.buy;");
            foreach (List<Object> o in list_buys_object)
            {
                idC = Convert.ToInt32(o[0].ToString());
                idA = Convert.ToInt32(o[1].ToString());
                Buy b = new Buy(idC, idA);
                list_buys.Add(b);
            }
            return list_buys;
        }
    }
}
