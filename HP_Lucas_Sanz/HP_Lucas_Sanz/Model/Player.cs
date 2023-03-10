using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public List<Ability> player_ability { get; set; }
        public ManagePlayer manage_player { get; set; }
        public int vidas;
        public StackPanel stackpanelPlayer { get; set; }
        public static Boolean wand;
        public static Boolean ray;
        public static Boolean brain;

        public Player()
        {
            this.manage_player = new ManagePlayer();
        }
        public Player(string name, string nickname, string avatar, int money_player)
        {
            this.name = name;
            this.nickname = nickname;
            this.avatar = avatar;
            this.money_player = money_player;
            player_ability = new List<Ability>();
            manage_player = new ManagePlayer();
            vidas = 3;
            stackpanelPlayer = new StackPanel();
            wand = false;
            ray = false;
            brain = false;
        }
        public Player(int idC, string name, string nickname, string avatar, int money_player)
        {
            this.idC = idC;
            this.name = name;
            this.nickname = nickname;
            this.avatar = avatar;
            this.money_player = money_player;
            player_ability = new List<Ability>();
            manage_player = new ManagePlayer();
            vidas = 3;
            stackpanelPlayer = new StackPanel();
            wand = false;
            ray = false;
            brain = false;
        }
        
        public void insertPlayer()
        {
            manage_player.insertPlayer(this);
        }
        public void deletePlayer()
        {
            manage_player.deletePlayer(this);
        }
        public List<Player> getPlayers()
        {
            return manage_player.getPlayers();
        }

        public void checkAbilities()
        {
            foreach (Ability ab in player_ability)
            {
                if (ab.name.Equals("ray"))
                {
                    ray = true;
                }
                else if (ab.name.Equals("brain"))
                {
                    brain = true;
                }
                else
                {
                    wand = true;
                }
            }
        }

        public void addSPPlayer(Grid gridGame){}
        {
            Label lbl = new Label();
            lbl.Content = this.nickname;
            this.stackpanelPlayer.Children.Add(lbl);
            
        }
        public void getRowPlayer()
        {
            int row = Convert.ToInt32(stackpanelPlayer.GetValue(Grid.RowProperty));
        }
    }
}
