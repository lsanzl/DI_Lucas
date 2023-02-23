using HP_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Persistence.Manage
{
    public class ManagePlayer
    {
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
        public void insertPlayer(Player player)
        {
            DBBroker.getAgent().executeSQL("alter table hplucas.player AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into hplucas.player (name, nickname, avatar, money) values ('{player.name}','{player.nickname}','{player.avatar}','{player.money_player}');");
        }
        public void deletePlayer(Player player)
        {
            DBBroker.getAgent().executeSQL($"delete from hplucas.player where name='{player.name}';");
        }
    }
}
