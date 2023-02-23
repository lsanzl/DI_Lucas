using P2Hito3_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P2Hito3_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Country country;
        Team team;
        Player player;
        Tournament tournament;
        Tournament_DG tournament_dg;
        String[] roles = { "Top", "Support", "Mid", "Jungle", "ADC" };
        String[] types = { "Headline", "Reserve" };
        /// <summary>
        /// Main method
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            country = new Country();
            team = new Team();
            player = new Player();
            tournament_dg = new Tournament_DG();
            btn_start.IsEnabled = false;
            initializeCB();
        }
        /// <summary>
        /// Method to initialize combo boxes and data grids
        /// </summary>
        private void initializeCB()
        {
            List<Country> countries = country.readCountries();
            List<Player> players = player.readPlayers();
            List<Team> teams = team.readTeams();
            List<Tournament_DG> tournaments_dg = tournament_dg.readTournaments();

            foreach (Country c in countries)
            {
                cb_country.Items.Add(c.name);
                cb_tourcountry.Items.Add(c.name);
            }
            foreach (Player p in players)
            {
                dg_players.Items.Add(p);
            }
            foreach (Team t in teams)
            {
                dg_teams.Items.Add(t);
                cb_team.Items.Add(t.name);
            }
            foreach (Tournament_DG to in tournaments_dg)
            {
                dg_tournaments.Items.Add(to);
            }
            cb_role.ItemsSource = roles;
            cb_type.ItemsSource = types;
        }
        /// <summary>
        /// Method to clear and deselect each option related to players
        /// </summary>
        private void clearFieldsPlayer()
        {
            dg_players.Items.Clear();
            dg_players.SelectedIndex = -1;
            dg_teams.Items.Clear();
            cb_country.Items.Clear();
            cb_team.Items.Clear();
            cb_role.SelectedIndex = -1;
            cb_type.SelectedIndex = -1;
            txt_nickname.Clear();
            txt_name.Clear();
            txt_surname.Clear();
        }
        /// <summary>
        /// Method to clear and deselect each option related to teams
        /// </summary>
        private void clearFieldsTeam()
        {
            dg_teams.Items.Clear();
            txt_tname.Clear();
            txt_timage.Clear();
        }
        /// <summary>
        /// Method to clear and deselect each option related to tournaments
        /// </summary>
        /// <param name="txt_fields"> True to clear every fields, false to clear only data grid </param>
        private void clearFieldsTournament(Boolean txt_fields)
        {
            if (txt_fields)
            {
                txt_year.Clear();
                txt_name_tournament.Clear();
            }
            cb_tourcountry.Items.Clear();
            dg_tournaments.Items.Clear();
            dg_tournaments.SelectedIndex = -1;
        }
        /// <summary>
        /// Method to call insert method of players, first it checks all parameters are ready and that teams are not full
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_add(object sender, RoutedEventArgs e)
        {
            if (txt_name.Text.Equals("") || txt_nickname.Text.Equals("") || txt_surname.Text.Equals("") || cb_role.SelectedIndex == -1 || cb_type.SelectedIndex == -1 || cb_country.SelectedIndex == -1 || cb_team.SelectedIndex == -1)
            {
                MessageBox.Show("Debe rellenar todos los campos");
                return;
            }
            if (!player.readPlayers(cb_team.SelectedValue.ToString()))
            {
                MessageBox.Show("Equipo lleno, seleccione otro");
                return;
            }
            if (((cb_type.SelectedValue).ToString()).Equals("Headline"))
            {
                if (!player.readPlayers("Headline", cb_team.SelectedValue.ToString()))
                {
                    MessageBox.Show("Ya hay 5 titulares, debe ser suplente");
                    return;
                }
            }
            List<Team> teams = team.readTeams();
            int idTeam_s = 0;
            foreach (Team t in teams)
            {
                if (t.name.Equals(cb_team.SelectedValue.ToString()))
                {
                    idTeam_s = t.idTeam;
                }
            }
            string nickName_s = txt_nickname.Text;
            string name_s = txt_name.Text;
            string surname_s = txt_surname.Text;
            string role_s = cb_role.SelectedValue.ToString();
            string type_s = cb_type.SelectedValue.ToString();
            int idCountry_s = cb_country.SelectedIndex;

            Player player_insert = new Player(nickName_s, name_s, surname_s, role_s, type_s, idTeam_s, idCountry_s);
            player_insert.insertPlayer();
            MessageBox.Show("Jugador insertado");
            clearFieldsPlayer();
            initializeCB();
        }
        /// <summary>
        /// Method to call delete method of players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_delete(object sender, RoutedEventArgs e)
        {
            if (dg_players.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un jugador a eliminar");
                return;
            }
            Player player_delete = (Player)dg_players.SelectedValue;
            player_delete.deletePlayer();
            MessageBox.Show("Jugador eliminado");
            clearFieldsPlayer();
            initializeCB();
        }
        /// <summary>
        /// Method to call insert method of teams, first it checks fields are not null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_tadd(object sender, RoutedEventArgs e)
        {
            if (txt_tname.Text.Equals("") || txt_timage.Text.Equals(""))
            {
                MessageBox.Show("Debe introducir todos los datos");
                return;
            }
            Team team_insertar = new Team(txt_tname.Text, txt_timage.Text);
            team_insertar.insertTeam();
            MessageBox.Show("Equipo introducido");
            clearFieldsTeam();
            initializeCB();
        }
        /// <summary>
        /// Method to call delete method of teams
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_tdelete(object sender, RoutedEventArgs e)
        {
            if (dg_teams.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo a eliminar");
                return;
            }
            Team team_delete = (Team)dg_teams.SelectedValue;
            team_delete.deleteTeam();
            MessageBox.Show("Equipo eliminado");
            clearFieldsTeam();
            initializeCB();
        }
        /// <summary>
        /// Method to call creation method of tournaments, first it checks fields are not null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_create(object sender, RoutedEventArgs e)
        {
            if (txt_year.Text.Equals("") || txt_name_tournament.Text.Equals("") || cb_tourcountry.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca todos los datos del torneo");
                return;
            }
            tournament = new Tournament(txt_name_tournament.Text, txt_year.Text, cb_tourcountry.SelectedIndex);
            tournament.insertTournament();
            btn_start.IsEnabled = true;
            clearFieldsTournament(false);
            initializeCB();
        }
        /// <summary>
        /// Method to initialize tournament engine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_start(object sender, RoutedEventArgs e)
        {
            tournament.startTournament();
            clearFieldsTournament(true);
            initializeCB();
        }
        /// <summary>
        /// Method to call delete method of tournaments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_delete_tournament(object sender, RoutedEventArgs e)
        {
            if (dg_tournaments.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un torneo a eliminar");
                return;
            }
            Tournament_DG tournament_delete = (Tournament_DG)dg_tournaments.SelectedValue;
            tournament_delete.deleteTournamentDG();
            MessageBox.Show("Torneo eliminado");
            clearFieldsTournament(true);
            initializeCB();
        }
    }
}