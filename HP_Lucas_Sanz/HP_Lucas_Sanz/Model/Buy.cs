﻿using HP_Lucas_Sanz.Persistence;
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
        public Buy()
        {
            this.manage_buy = new ManageBuy();
        }
        public List<Buy> getBuys()
        {
            List<Object> object_list = DBBroker.getAgent().readSQL("select * from hplucas.buy;");
            List<Buy> buy_list = new List<Buy>();
            int idA;
            int idC;

            foreach(List<Object> o in object_list)
            {
                idC = Convert.ToInt32(o[0]);
                idA = Convert.ToInt32(o[1]);

                Buy b = new Buy(idC, idA);
                buy_list.Add(b);
            }
            return buy_list;
        }
        public List<Buy> getBuys(Player player)
        {
            List<Object> object_list = DBBroker.getAgent().readSQL($"select * from hplucas.buy where idC='{player.idC}';");
            List<Buy> buy_list = new List<Buy>();
            int idA;
            int idC;

            foreach (List<Object> o in object_list)
            {
                idC = Convert.ToInt32(o[0]);
                idA = Convert.ToInt32(o[1]);

                Buy b = new Buy(idC, idA);
                buy_list.Add(b);
            }
            return buy_list;
        }
    }
}
