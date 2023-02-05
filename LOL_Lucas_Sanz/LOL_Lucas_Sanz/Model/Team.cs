using LOL_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL_Lucas_Sanz.Model
{
    public class Team
    {
        public int idTeam { get; set; }
        public string name { get; set; }
        public string imageSrc { get; set; }
        public ManageTeam manage_team { get; set; }
        /// <summary>
        /// Void constructor of Team objects
        /// </summary>
        public Team()
        {
            this.manage_team = new ManageTeam();
        }
        /// <summary>
        /// Constructor to Team object
        /// </summary>
        /// <param name="name"> Team's name </param>
        /// <param name="imageSrc"> Team's icon source </param>
        public Team(string name, string imageSrc)
        {
            this.name = name;
            this.imageSrc = imageSrc;
            this.manage_team = new ManageTeam();
        }
        /// <summary>
        /// Calls to manage method to insert teams
        /// </summary>
        public void insertTeams()
        { 
            this.manage_team.insertTeams();
        }
        /// <summary>
        /// Calls to manage method to delete each team
        /// </summary>
        public void deleteTeams()
        {
            this.manage_team.deleteAll();
        }

    }
}
