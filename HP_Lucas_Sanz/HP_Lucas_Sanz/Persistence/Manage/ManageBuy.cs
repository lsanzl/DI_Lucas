using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP_Lucas_Sanz.Model;

namespace HP_Lucas_Sanz.Persistence.Manage
{
    /// <summary>
    /// Clase manager de Buy para interactuar con la BD
    /// </summary>
    public class ManageBuy
    {
        public int idC { get; set;}
        public int idA { get; set;}
        public List<Buy> list_buys;
        public List<Object> list_buys_object;
        /// <summary>
        /// Método que recoge todas las buys de la BD
        /// y las mete en una lista
        /// </summary>
        /// <returns>List: lista con las buys de la BD</returns>
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
        /// <summary>
        /// Método que recoge todas las buys de la BD de un Player en concreto
        /// y las mete en una lista
        /// </summary>
        /// <returns>List: lista con las buys de Player de la BD</returns>
        public List<Buy> getBuys(Player player)
        {
            Ability a_aux = new Ability();
            List<Object> object_list = DBBroker.getAgent().readSQL($"select * from hplucas.buy where idC='{player.idC}';");
            List<Buy> buy_list = new List<Buy>();
            List<Ability> ability_list = a_aux.getAbilities();
            int idA;
            int idC;

            foreach (List<Object> o in object_list)
            {
                idC = Convert.ToInt32(o[0]);
                idA = Convert.ToInt32(o[1]);

                Buy b = new Buy(idC, idA);
                buy_list.Add(b);
            }
            foreach (Buy b in buy_list)
            {
                foreach (Ability a in ability_list)
                {
                    if (b.idA == a.idA)
                    {
                        player.player_ability.Add(a);
                    }
                }
            }
            return buy_list;
        }
    }
}
