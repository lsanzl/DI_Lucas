using P2Hito3_Lucas_Sanz.Persistence;
using P2Hito3_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P2Hito3_Lucas_Sanz.Model
{
    public class Player
    {
        public Random r = new Random();
        public int id { get; set; }
        public string nickName { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string role { get; set; }
        public string type { get; set; }
        public int idTeam { get; set; }
        public int idCountry { get; set; }
        public ManagePlayer manage_player { get; set; }

        public string[] name_list = { "Alicia", "Ana", "Miguel", "Juan", "Manuel", "Olivia", "Pedro", "Carmen", "Julio", "Alba", "María", "Luis", "Raquel" };
        public string[] surname_list = { "Diaz", "García", "Moreno", "Aranda", "Marcos", "Ruedas", "Orovio", "Esquinas", "Ruiz", "Sanz", "Medina", "Morales", "Sancho", "Solera" };
        public string[] role_list = { "top", "support", "mid", "jungle", "adc" };
        public string[] country_list = { "Spain", "Italy", "France", "Portugal", "Denmark", "Deutschland", "UK", "Greece", "Netherlands", "Scotland" };

        public Player()
        {
            this.manage_player = new ManagePlayer();
        }
        public Player(string nickName, string type, int idTeam)
        {
            this.nickName = nickName;
            this.idTeam = idTeam;
            this.name = name_list[r.Next(name_list.Length)];
            this.surname = surname_list[r.Next(surname_list.Length)];
            this.role = role_list[r.Next(role_list.Length)];
            this.type = type;
            this.idCountry = r.Next(1, country_list.Length);
            this.manage_player = new ManagePlayer();
        }
        public Player(string nickName,string name, string surname,string role, string type, int idTeam, int idCountry)
        {
            this.nickName = nickName;
            this.idTeam = idTeam;
            this.name = name;
            this.surname = surname;
            this.role = role;
            this.type = type;
            this.idCountry = idCountry;
            this.idTeam = idTeam;
            this.manage_player = new ManagePlayer();
        }
        public void insertPlayer()
        {
            this.manage_player.insertPlayer(this);
        }
        public List<Player> readPlayers()
        {
            return this.manage_player.getPlayers();
        }
        public Boolean readPlayers(int team)
        {
            int contador_players = 0;
            List<Player> checkList = this.manage_player.getPlayers();
            foreach (Player p in checkList)
            {
                if (p.idTeam == team)
                {
                    contador_players++;
                }
            }
            if (contador_players < 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean readPlayers(String role, int idTeam)
        {
            int contador_roles = 0;
            List<Player> checkList = this.manage_player.getPlayers();

            foreach (Player p in checkList)
            {
                if (p.type.Equals("Headline") && p.idTeam == idTeam)
                {
                    contador_roles++;
                }
            }
            if (contador_roles < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void deletePlayer()
        {
            this.manage_player.deletePlayer(this);
        }
    }
}
