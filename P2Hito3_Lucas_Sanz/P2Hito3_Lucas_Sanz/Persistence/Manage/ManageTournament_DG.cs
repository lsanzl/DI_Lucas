using P2Hito3_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    public class ManageTournament_DG
    {
        Country country_aux = new Country();
        public List<Tournament_DG> getTournaments()
        {
            List<Tournament_DG> tournament_list = new List<Tournament_DG>();
            List<Country> country_list = country_aux.readCountries();
            List<Object> team_object = DBBroker.getAgent().readSQL("select * from leagueoflegends.tournament;");

            string name_p;
            string location_p;
            int posicion;

            foreach (List<Object> objP in team_object)
            {
                name_p = objP[1].ToString();
                posicion = (Convert.ToInt32(objP[2]))-1;
                location_p = country_list[posicion].name;

                Tournament_DG to = new Tournament_DG(name_p, location_p);

                tournament_list.Add(to);
            }
            return tournament_list;
        }
        public void deleteTournament(Tournament_DG tournament)
        {
            DBBroker.getAgent().executeSQL($"delete from leagueoflegends.play where idMatch=(select idMatch from leagueoflegends.match where idTournament=(select idTournament from leagueoflegends.tournament where name='{tournament.name}'));");
            DBBroker.getAgent().executeSQL($"delete from leagueoflegends.match where idTournament=(select idTournament from leagueoflegends.tournament where name='{tournament.name}'");
            DBBroker.getAgent().executeSQL($"delete from leagueoflegends.tournament where name='{tournament.name}';");
        }
    }
}
