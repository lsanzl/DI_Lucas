using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Model
{
    public class Buy
    {
        public int idC { get; set; }
        public int idA { get; set; }
        public ManageBuy manage_buy { get; set; }
        public Buy(int idC, int idA)
        {
            this.idC = idC;
            this.idA = idA;
            this.manage_buy = new ManageBuy();
        }
    }
}
