using P2Hito3_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Model
{
    public class Tournament_DG
    {
        Country country_aux = new Country();
        public string location { get; set; }
        public string name { get; set; }
        public ManageTournament_DG manage_tournament_dg { get; set; }
        public Tournament_DG(string name, string location)
        {
            this.name = name;
            this.location = location;
            this.manage_tournament_dg = new ManageTournament_DG();
        }
        public Tournament_DG()
        {
            this.location = "";
            this.name = "";
            this.manage_tournament_dg = new ManageTournament_DG();
        }
        public List<Tournament_DG> readTournaments()
        {
            return this.manage_tournament_dg.getTournaments();
        }
        public void deleteTournament()
        {
            manage_tournament_dg.deleteTournament(this);
        }
    }
}
