using P2Hito3_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Model
{
    public class Team
    {
        public int idTeam { get; set; }
        public string name { get; set; }
        public string imageSrc { get; set; }
        public ManageTeam manage_team { get; set; }
        /// <summary>
        /// Constructor of Teams
        /// </summary>
        public Team()
        {
            this.manage_team = new ManageTeam();
        }
        /// <summary>
        /// Constructor that needs name and image source
        /// </summary>
        /// <param name="name"> Team's name </param>
        /// <param name="imageSrc"> Team's icon </param>
        public Team(string name, string imageSrc)
        {
            this.name = name;
            this.imageSrc = imageSrc;
            this.manage_team = new ManageTeam();
        }
        /// <summary>
        /// Constructor that introduce full user params
        /// </summary>
        /// <param name="idTeam"> Team's ID </param>
        /// <param name="name"> Team's name </param>
        /// <param name="imageSrc"> Team's icon </param>
        public Team(int idTeam, string name, string imageSrc)
        {
            this.idTeam = idTeam;
            this.name = name;
            this.imageSrc = imageSrc;
            this.manage_team = new ManageTeam();
        }
        /// <summary>
        /// Method which get list of teams from DB
        /// </summary>
        /// <returns> List of teams </returns>
        public List<Team> readTeams()
        {
            return this.manage_team.getTeams();
        }
        /// <summary>
        /// Call manage to insert teams
        /// </summary>
        public void insertTeam()
        {
            this.manage_team.insertTeam(this);
        }
        /// <summary>
        /// Call manage to delete teams
        /// </summary>
        public void deleteTeam()
        {
            this.manage_team.deleteTeam(this);
        }
    }
}
