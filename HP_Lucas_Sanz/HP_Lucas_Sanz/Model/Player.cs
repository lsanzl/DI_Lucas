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
        public int money_player { get; set; }
        public List<Ability> player_abilty { get; set; }
        public ManagePlayer manage_player { get; set; }

        public Player(string name, string nickname, string avatar, int money_player)
        {
            this.name = name;
            this.nickname = nickname;
            this.avatar = avatar;
            this.money_player = money_player;
            this.player_abilty = new List<Ability>();
            this.manage_player = new ManagePlayer();
        }
        public Player()
        {
            this.manage_player = new ManagePlayer();
        }
        public void insertPlayer()
        {
            this.manage_player.insertPlayer(this);
        }
        public void deletePlayer()
        {
            this.manage_player.deletePlayer(this);
        }
        public List<Player> getPlayers()
        {
            return this.manage_player.getPlayers();
        }
    }
}
