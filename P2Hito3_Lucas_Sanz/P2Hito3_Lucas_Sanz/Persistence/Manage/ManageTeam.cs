using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using P2Hito3_Lucas_Sanz.Model;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    public class ManageTeam
    {
        public List<Team> getTeams()
        {
            List<Team> team_list = new List<Team>();
            List<Object> team_object = new List<Object>();

            int idTeam_p;
            string name_p;
            string img_p;

            team_object = DBBroker.getAgent().readSQL("select * from leagueoflegends.team;");
            foreach (List<Object> objP in team_object)
            {
                idTeam_p = Convert.ToInt32(objP[0]);
                name_p = objP[1].ToString();
                img_p = objP[2].ToString();

                Team t = new Team(idTeam_p, name_p, img_p);

                team_list.Add(t);
            }
            return team_list;
        }
        public void insertTeam(Team team_insert)
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.player AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into leagueoflegends.team (name, imageSrc) values ('{team_insert.name}', '{team_insert.imageSrc}');");
        }
        public void deleteTeam(Team team)
        {
            DBBroker.getAgent().executeSQL($"delete from leagueoflegends.team where name='{team.name}';");
        }
    }
}
