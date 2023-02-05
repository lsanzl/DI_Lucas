using P2Hito3_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    public class ManageTournament
    {
        Random r = new Random();
        public void insertTournament(Tournament tournament)
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.tournament AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into leagueoflegends.tournament (name, idCountry) values ('{tournament.name}','{tournament.idCountry}');");
        }
        public Boolean insertMatch(Team team1, Team team2, int kills1, int assists1, int kills2, int assists2, int round, Tournament tournament)
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.match AUTO_INCREMENT = 1;");
            int idTournament_actual = countTournament();
            Boolean team1winner = false;

            if (kills1 > kills2)
            {
                DBBroker.getAgent().executeSQL($"insert into leagueoflegends.match (idTournament, year, round, winnerOfMatch) values ('{idTournament_actual}', '{tournament.year}', '{round}', '{team1.idTeam}');");
                team1winner = true;
            }
            else
            {
                DBBroker.getAgent().executeSQL($"insert into leagueoflegends.match (idTournament, year, round, winnerOfMatch) values ('{idTournament_actual}', '{tournament.year}', '{round}', '{team2.idTeam}');");
            }

            int idMatch = countMatch();
            insertPlay(team1, kills1, assists1, round, idMatch);
            insertPlay(team2, kills2, assists2, round, idMatch);
            return team1winner;
        }
        public void insertPlay(Team team, int kills, int assists, int round, int idMatch)
        {
            DBBroker.getAgent().executeSQL($"insert into leagueoflegends.play (idTeam, idMatch, kills, assists) values ('{team.idTeam}','{idMatch}', '{kills}', '{assists}');");
        }
        public int countTournament()
        {
            List<Object> list_tournaments = new List<Object>();
            list_tournaments = DBBroker.getAgent().readSQL("select * from leagueoflegends.tournament;");
            return list_tournaments.Count;
        }
        public int countMatch()
        {
            List<Object> list_matchs = new List<Object>();
            list_matchs = DBBroker.getAgent().readSQL("select * from leagueoflegends.match;");
            return list_matchs.Count;
        }
    }
}
