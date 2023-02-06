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
        /// <summary>
        /// Method to insert a tournament in DB
        /// </summary>
        /// <param name="tournament"> Tournament to insert </param>
        public void insertTournament(Tournament tournament)
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.tournament AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into leagueoflegends.tournament (name, idCountry) values ('{tournament.name}','{tournament.idCountry}');");
        }
        /// <summary>
        /// Method to insert a match in DB, first it determinates which is the winner team
        /// </summary>
        /// <param name="team1"> Team 1 of match </param>
        /// <param name="team2"> Team 2 of match </param>
        /// <param name="kills1"> Kills of team 1 </param>
        /// <param name="assists1"> Assists of team 1 </param>
        /// <param name="kills2"> Kills of team 2 </param>
        /// <param name="assists2"> Assists of team 2 </param>
        /// <param name="round"> Number of round which is playing </param>
        /// <param name="tournament"> Tournament's name is playing </param>
        /// <returns> True if team 1 wins </returns>
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
        /// <summary>
        /// Method to insert results from match in DB
        /// </summary>
        /// <param name="team"> Team to insert stats </param>
        /// <param name="kills"> Number of kills in match </param>
        /// <param name="assists"> Number of assists in match </param>
        /// <param name="round"> Number of round is playing </param>
        /// <param name="idMatch"> ID of match is playing </param>
        public void insertPlay(Team team, int kills, int assists, int round, int idMatch)
        {
            DBBroker.getAgent().executeSQL($"insert into leagueoflegends.play (idTeam, idMatch, kills, assists) values ('{team.idTeam}','{idMatch}', '{kills}', '{assists}');");
        }
        /// <summary>
        /// Method to get number of tournaments created
        /// </summary>
        /// <returns> Count of tournament items in DB </returns>
        public int countTournament()
        {
            List<Object> list_tournaments = new List<Object>();
            list_tournaments = DBBroker.getAgent().readSQL("select * from leagueoflegends.tournament;");
            return list_tournaments.Count;
        }
        /// <summary>
        /// Method to get number of matches created
        /// </summary>
        /// <returns> Count of match items in DB </returns>
        public int countMatch()
        {
            List<Object> list_matchs = new List<Object>();
            list_matchs = DBBroker.getAgent().readSQL("select * from leagueoflegends.match;");
            return list_matchs.Count;
        }
    }
}
