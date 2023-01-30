using LOL_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL_Lucas_Sanz.Persistence.Manage
{
    public class ManageTeam
    {
        public void insertTeams()
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.team AUTO_INCREMENT = 1;");
            for (int i=1; i<=50; i++) 
            {
                Team t = new Team("Team"+i, "/images/default.jpg");
                DBBroker.getAgent().executeSQL($"insert into leagueoflegends.team (name, imageSrc) values('{t.name}', '{t.imageSrc}');");
            }
        }
        public void deleteAll()
        {
            DBBroker.getAgent().executeSQL("delete from leagueoflegends.team");
        }
    }
}
