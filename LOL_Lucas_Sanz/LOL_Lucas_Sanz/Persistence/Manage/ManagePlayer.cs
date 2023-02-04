using LOL_Lucas_Sanz.Model;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace LOL_Lucas_Sanz.Persistence.Manage
{
    public class ManagePlayer
    {
        public Random r = new Random();
        public void insertPlayer()
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.player AUTO_INCREMENT = 1;");
            string[] name_list = { "Alicia", "Ana", "Miguel", "Juan", "Manuel", "Olivia", "Pedro", "Carmen", "Julio", "Alba", "María", "Luis", "Raquel" };
            string[] surname_list = { "Diaz", "García", "Moreno", "Aranda", "Marcos", "Ruedas", "Orovio", "Esquinas", "Ruiz", "Sanz", "Medina", "Morales", "Sancho", "Solera" };
            string[] role_list = { "top", "support", "mid", "jungle", "adc" };
            string[] country_list = { "Spain", "Italy", "France", "Portugal", "Denmark", "Deutschland", "UK", "Greece", "Netherlands", "Scotland" };

            int idPlayer = 1;

            for (int i=1; i<= 50; i++)
            {
                string type = "Headline";
                for (int j=1; j<=r.Next(12,16); j++)
                {
                    if (j > 5)
                    {
                        type = "Reserve";
                    }
                    Player p = new Player("nick" + idPlayer, type, i);
                
                    DBBroker.getAgent().executeSQL($"insert into leagueoflegends.player (nickName, name, surname, role, type, idTeam, idCountry) values ('{p.nickName}', '{p.name}', '{p.surname}', '{p.role}', '{p.type}', '{p.idTeam}', '{p.idCountry}');");
                    idPlayer++;
                }
            }
        }
        public void deleteAll()
        {
            DBBroker.getAgent().executeSQL("delete from leagueoflegends.player;");
        }
    }
}
