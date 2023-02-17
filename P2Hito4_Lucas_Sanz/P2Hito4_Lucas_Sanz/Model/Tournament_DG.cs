using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2Hito4_Lucas_Sanz.Persistence.Manage;

namespace P2Hito4_Lucas_Sanz.Model
{
    public class Tournament_DG
    {
        Country country_aux = new Country();
        public string location { get; set; }
        public string name { get; set; }
        public ManageTournament_DG manage_tournament_dg { get; set; }
        /// <summary>
        /// Constructor of tournament to data grid
        /// </summary>
        /// <param name="name"> Tournaments name </param>
        /// <param name="location"> Tournament's location </param>
        public Tournament_DG(string name, string location)
        {
            this.name = name;
            this.location = location;
            this.manage_tournament_dg = new ManageTournament_DG();
        }
        /// <summary>
        /// Void constructor of tournament to data grid
        /// </summary>
        public Tournament_DG()
        {
            this.location = "";
            this.name = "";
            this.manage_tournament_dg = new ManageTournament_DG();
        }
        /// <summary>
        /// Method to get list of tournaments from DB
        /// </summary>
        /// <returns> List of tournaments </returns>
        public List<Tournament_DG> readTournaments()
        {
            return this.manage_tournament_dg.getTournaments();
        }
        /// <summary>
        /// Method to call manage method to delete a tournament
        /// </summary>
        public void deleteTournamentDG()
        {
            this.manage_tournament_dg.deleteTournament_DG(this);
        }
    }
}
