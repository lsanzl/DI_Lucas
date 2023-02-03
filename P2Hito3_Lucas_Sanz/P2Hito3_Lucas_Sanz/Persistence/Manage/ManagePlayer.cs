using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using P2Hito3_Lucas_Sanz.Model;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
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

            for (int i = 1; i <= 50; i++)
            {
                string type = "holder";
                for (int j = 1; j <= r.Next(12, 16); j++)
                {
                    if (j > 5)
                    {
                        type = "substitute";
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
        public List<Player> getPlayers()
        {
            List<Player> player_list = new List<Player>();
            List<Object> player_object = new List<Object>();

            string nick_p;
            string name_p;
            string surname_p;
            string role_p;
            string type_p;
            int idTeam_p;
            int idCountry_p;

            player_object = DBBroker.getAgent().readSQL("select * from leagueoflegends.player;");
            foreach (List<Object> objP in player_object)
            {
                nick_p = objP[1].ToString();
                name_p = objP[2].ToString();
                surname_p = objP[3].ToString();
                role_p = objP[4].ToString();
                type_p = objP[5].ToString();
                idTeam_p = Convert.ToInt32(objP[6]);
                idCountry_p = Convert.ToInt32(objP[7]);

                Player p = new Player(nick_p, name_p, surname_p, role_p, type_p, idTeam_p, idCountry_p);

                player_list.Add(p);
            }
            return player_list;
        }
    }
}
