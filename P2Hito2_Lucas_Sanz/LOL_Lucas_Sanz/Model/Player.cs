using LOL_Lucas_Sanz.Persistence.Manage;
using Org.BouncyCastle.Utilities.Zlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LOL_Lucas_Sanz.Model
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
        public string[] surname_list = { "Diaz", "García", "Moreno", "Aranda", "Marcos", "Ruedas", "Orovio", "Esquinas", "Ruiz", "Sanz", "Medina", "Morales", "Sancho", "Solera"};
        public string[] role_list = { "top", "support", "mid", "jungle", "adc" };
        public string[] country_list = { "Spain", "Italy", "France", "Portugal", "Denmark", "Deutschland", "UK", "Greece", "Netherlands", "Scotland" };
        /// <summary>
        /// Void constructor to Player object
        /// </summary>
        public Player()
        {
            this.manage_player = new ManagePlayer();
        }
        /// <summary>
        /// Constructor to build personalized Player objects, the rest of params are randomized from lists
        /// </summary>
        /// <param name="nickName"> Player's nickName </param>
        /// <param name="type"> Player's type: headline or reserve </param>
        /// <param name="idTeam"> Player's team assigned</param>
        public Player(string nickName, string type, int idTeam)
        {
            this.nickName = nickName;
            this.idTeam = idTeam;
            this.name = name_list[r.Next(name_list.Length)];
            this.surname = surname_list[r.Next(surname_list.Length)];
            this.role = role_list[r.Next(role_list.Length)];
            this.type = type;
            this.idCountry = r.Next(1,country_list.Length);
            this.manage_player = new ManagePlayer();
        }
        /// <summary>
        /// Calls to manage method to insert players
        /// </summary>
        public void insertPlayers()
        { 
            this.manage_player.insertPlayer();
        }
        /// <summary>
        /// Calls to manage method to delete each player
        /// </summary>
        public void deletePlayers()
        {
            this.manage_player.deleteAll();
        }
    }
}
