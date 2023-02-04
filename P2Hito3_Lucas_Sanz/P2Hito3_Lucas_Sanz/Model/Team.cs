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

        public Team()
        {
            this.manage_team = new ManageTeam();
        }
        public Team(string name, string imageSrc)
        {
            this.name = name;
            this.imageSrc = imageSrc;
            this.manage_team = new ManageTeam();
        }
        public Team(int idTeam, string name, string imageSrc)
        {
            this.idTeam = idTeam;
            this.name = name;
            this.imageSrc = imageSrc;
            this.manage_team = new ManageTeam();
        }
        public List<Team> readTeams()
        {
            return this.manage_team.getTeams();
        }
        public void insertTeam()
        {
            this.manage_team.insertTeam(this);
        }
        public void deleteTeam()
        {
            this.manage_team.deleteTeam(this);
        }
        
    }
}
