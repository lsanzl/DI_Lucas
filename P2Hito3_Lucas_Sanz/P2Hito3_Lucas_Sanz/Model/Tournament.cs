using P2Hito3_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
        public int year { get; set; }
        public ManageTournament manage_tournament { get; set; }
        public Tournament(string name, string year, int idCountry)
        {
            this.manage_tournament = new ManageTournament();
            this.idTournament = this.manage_tournament.countTournament();
            this.year = Convert.ToInt32(year);
            this.name = name;
            this.idCountry = idCountry;
        }
        public void insertTournament()
        {
            this.manage_tournament.insertTournament(this);
        }
        public void startTournament()
        {
            tournamentList();
            playRound(teams_octavos, teams_cuartos, 8);
            playRound(teams_cuartos, teams_semifinales, 4);
            playRound(teams_semifinales, teams_final, 2);
            playFinal(teams_final);
        }

        public void tournamentList()
        {
            List<int> num_used = new List<int>();
            teams_totals = team_aux.readTeams();
            int num_team = 0;
            Boolean repeat = false;
            string traza_inicial = "16 seleccionados para octavos:\n";

            for (int i = 0; i<16; i++)
            {
                while (!repeat)
                {
                    num_team = r.Next(0, teams_totals.Count);
                    repeat = checkRepeat(num_used, num_team);
                }
                num_used.Add(num_team);
                teams_octavos.Add(teams_totals[num_team]);
                repeat = false;
                traza_inicial += teams_totals[num_team].name + "\n";
            }
            MessageBox.Show(traza_inicial);
        }
        public void playRound(List<Team> ronda_actual, List<Team> ronda_next, int round)
        {
            int rand = 0;
            string traza_juegan = $"Juegan ronda {round}:\n";
            string traza_ganadores = $"Ganadores ronda {round}:\n";
            while(ronda_actual.Count > 0)
            {
                Team team1 = new Team();
                Team team2 = new Team();

                rand = r.Next(0, ronda_actual.Count);
                team1 = ronda_actual[rand];
                ronda_actual.RemoveAt(rand);

                rand = r.Next(0, ronda_actual.Count);
                team2 = ronda_actual[rand];
                ronda_actual.RemoveAt(rand);

                traza_juegan += team1.name + " vs " + team2.name + "\n";

                if (playMatch(team1, team2, round))
                {
                    ronda_next.Add(team1);
                    traza_ganadores += "Ganador: " + team1.name + " --> " + team1.name + " vs " + team2.name + "\n";
                }
                else
                {
                    ronda_next.Add(team2);
                    traza_ganadores += "Ganador: " + team2.name + " --> " + team1.name + " vs " + team2.name + "\n";
                }
            }
            MessageBox.Show(traza_juegan);
            MessageBox.Show(traza_ganadores);
        }
        public void playFinal(List<Team> ronda_final)
        {
            string traza_juegan = $"Juegan ronda final:\n";
            string traza_ganadores = $"GANADOR FINAL: ";

            Team team1 = ronda_final[0];
            Team team2 = ronda_final[1];

            traza_juegan += team1.name + " vs " + team2.name + "\n";

            if (playMatch(team1, team2, 1))
            {
                traza_ganadores += team1.name;
            }
            else
            {
                traza_ganadores += team2.name;
            }
            MessageBox.Show(traza_juegan);
            MessageBox.Show(traza_ganadores);
        }
        public Boolean playMatch(Team team1, Team team2, int round)
        {
            int kills1 = 0;
            int kills2 = 0;
            int assists1 = 0;
            int assists2 = 0;

            while (kills1 == kills2)
            {
                kills1 = r.Next(0, 100);
                kills2 = r.Next(0, 100);
            }
            assists1 = r.Next(0, kills1);
            assists2 = r.Next(0, kills2);

            return this.manage_tournament.insertMatch(team1, team2, kills1, assists1, kills2, assists2, round, this);
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
