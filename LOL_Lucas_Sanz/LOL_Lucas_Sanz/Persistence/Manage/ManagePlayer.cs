using LOL_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL_Lucas_Sanz.Persistence.Manage
{
    public class ManagePlayer
    {
        public Random r = new Random();
        public void insertPlayer()
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.player AUTO_INCREMENT = 1;");
            for (int i=1; i<=50; i++)
            {
                string type = "holder";
                for (int j=1; j<=r.Next(12,16); j++)
                {
                    if (j > 5)
                    {
                        type = "substitute";
                    }
                    Player p = new Player("nick" + j, type, i);
                    
                    DBBroker.getAgent().executeSQL($"insert into leagueoflegends.player (nickName, name, surname, role, type, idTeam, idCountry) values ('{p.nickName}', '{p.name}', '{p.surname}', '{p.role}', '{p.type}', '{p.idTeam}', '{p.idCountry}');");
                }
            }
        }
        public void deleteAll()
        {
            DBBroker.getAgent().executeSQL("delete from leagueoflegends.player;");
        }
    }
}
