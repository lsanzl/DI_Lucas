using HP_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Persistence.Manage
{
    /// <summary>
    /// Clase manager de Player para interactuar con la BD
    /// </summary>
    public class ManagePlayer
    {
        /// <summary>
        /// Método que recoge todas los players de la BD
        /// y los mete en una lista
        /// </summary>
        /// <returns>List: lista con los players de la BD</returns>
        public List<Player> getPlayers()
        {
            List<Object> players_objects = DBBroker.getAgent().readSQL("select * from hplucas.player;");
            List<Player> players_list = new List<Player>();
            string name;
            string nickname;
            string avatar;
            int money;
            int idC;

            foreach (List<Object> o in players_objects)
            {
                idC = Convert.ToInt32(o[0].ToString());
                name = o[1].ToString();
                nickname = o[2].ToString();
                avatar = o[3].ToString();
                money = Convert.ToInt32(o[6].ToString());
                Player a = new Player(idC, name, nickname, avatar, money);
                players_list.Add(a);
            }
            return players_list;
        }
        /// <summary>
        /// Método que inserta un objeto Player en la BD
        /// </summary>
        /// <param name="ability">Player a insertar</param>
        public void insertPlayer(Player player)
        {
            DBBroker.getAgent().executeSQL("alter table hplucas.player AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into hplucas.player (name, nickname, avatar, money) values ('{player.name}','{player.nickname}','{player.avatar}','{player.money_player}');");
        }
        /// <summary>
        /// Método que elimina un objeto Player de la BD
        /// </summary>
        /// <param name="ability">Player a eliminar</param>
        public void deletePlayer(Player player)
        {
            DBBroker.getAgent().executeSQL($"delete from hplucas.player where name='{player.name}';");
        }
    }
}
