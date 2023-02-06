using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Model
{
    public class Player
    {
        public int idC { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string avatar { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public ManagePlayer manage_player { get; set; }

        public Player(string name, string nickname, string avatar)
        {
            this.name = name;
            this.nickname = nickname;
            this.avatar = avatar;
            this.manage_player = new ManagePlayer();
        }
        public Player()
        {
            this.manage_player = new ManagePlayer();
        }
        public void insertAbility()
        {
            this.manage_player.insertPlayer(this);
        }
        public void deleteAbility()
        {
            this.manage_player.deletePlayer(this);
        }
        public List<Player> getPlayers()
        {
            return this.manage_player.getPlayers();
        }
    }
}
