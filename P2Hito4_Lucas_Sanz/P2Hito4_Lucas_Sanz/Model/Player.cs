using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2Hito4_Lucas_Sanz.Persistence.Manage;

namespace P2Hito4_Lucas_Sanz.Model
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
        /// <summary>
        /// Constructor of Player
        /// </summary>
        public Player()
        {
            this.manage_player = new ManagePlayer();
        }
        /// <summary>
        /// Constructor with params, the rest of the params are random generated
        /// </summary>
        /// <param name="nickName"> To identify the player </param>
        /// <param name="type"> Headline or reserve </param>
        /// <param name="idTeam"> ID of the team to which it belongs </param>
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
        /// <summary>
        /// Constructor with full of params
        /// </summary>
        /// <param name="nickName"> To identify the player </param>
        /// <param name="name"> Player's name </param>
        /// <param name="surname"> Player's surname </param>
        /// <param name="role"> Player's role in the team </param>
        /// <param name="type"> Headline or reserve </param>
        /// <param name="idTeam"> ID of the team to which it belongs </param>
        /// <param name="idCountry"> ID of country of birth </param>
        public Player(string nickName, string name, string surname, string role, string type, int idTeam, int idCountry)
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
        /// <summary>
        /// Call manage class to insert a player
        /// </summary>
        public void insertPlayer()
        {
            this.manage_player.insertPlayer(this);
        }
        /// <summary>
        /// Call manage class to get list of players from DB
        /// </summary>
        /// <returns> List of players </returns>
        public List<Player> readPlayers()
        {
            return this.manage_player.getPlayers();
        }
        /// <summary>
        /// Method which check if there are 12 players (limit) in a team
        /// </summary>
        /// <param name="team"> Team to check </param>
        /// <returns> True if there are less than 12 </returns>
        public Boolean readPlayers(string team)
        {
            int contador_players = 0;
            List<Player> checkList = this.manage_player.getPlayers();
            foreach (Player p in checkList)
            {
                if (p.name == team)
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
        /// <summary>
        /// Method which check if there are 5 headlines in the team (limit of headlines)
        /// </summary>
        /// <param name="role"> Specify player's role </param>
        /// <param name="idTeam"> Team to check </param>
        /// <returns></returns>
        public Boolean readPlayers(String role, string name_team)
        {
            Team team_check = new Team();
            int contador_roles = 0;
            int id_team_check = 0;
            List<Team> team_list = team_check.manage_team.getTeams();
            foreach (Team t in team_list)
            {
                if (t.name.Equals(name_team))
                {
                    id_team_check = t.idTeam;
                }
            }
            List<Player> checkList = this.manage_player.getPlayers();

            foreach (Player p in checkList)
            {
                if (p.type.Equals("Headline") && p.idTeam == id_team_check)
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
        /// <summary>
        /// Call manage to delete a player
        /// </summary>
        public void deletePlayer()
        {
            this.manage_player.deletePlayer(this);
        }
    }
}
