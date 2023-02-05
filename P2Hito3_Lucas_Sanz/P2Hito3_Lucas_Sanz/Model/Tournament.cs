using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Model
{
    public class Tournament
    {
        List<Team> teams_totals = new List<Team>();
        List<Team> teams_octavos = new List<Team>();
        List<Team> teams_cuartos = new List<Team>();
        List<Team> teams_semifinales = new List<Team>();
        List<Team> teams_final = new List<Team>();
        Team team_aux = new Team();

        Random r = new Random();

        public int idTournament { get; set; }
        public string name { get; set; }
        public int idCountry { get; set; }

        public void tournamentList()
        {
            List<int> num_used = new List<int>();
            teams_totals = team_aux.readTeams();
            int num_team = 0;

            for (int i = 0; i<16; i++)
            {
                Boolean repeat = false;
                while (!repeat)
                {
                    num_team = r.Next(0, teams_totals.Count);
                    repeat = checkRepeat(num_used, i);
                }
                num_used.Add(num_team);
                teams_octavos.Add(teams_totals[num_team]);
            }
        }
        public Boolean checkRepeat(List<int> int_check, int num_check)
        {
            foreach (int i in int_check)
            {
                if (i == num_check)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
