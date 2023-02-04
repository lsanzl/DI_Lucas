using P2Hito3_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        String[] roles = {"Top", "Support", "Mid", "Jungle", "ADC"};
        String[] types = { "Headline", "Reserve" };
        public MainWindow()
        {
            InitializeComponent();
            country = new Country();
            team = new Team();
            player = new Player();
            initializeCB();
        }
        private void initializeCB()
        {
            List<Country> countries = country.readCountries();
            List<Player> players = player.readPlayers();
            List<Team> teams = team.readTeams();

            foreach (Country c in countries)
            {
                cb_country.Items.Add(c.name);
            }
            foreach (Player p in players)
            {
                dg_players.Items.Add(p);
            }
            foreach (Team t in teams)
            {
                dg_teams.Items.Add(t);
                cb_team.Items.Add(t.idTeam);
            }
            cb_role.ItemsSource = roles;
            cb_type.ItemsSource = types;
        }
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
        private void clearFieldsTeam()
        {
            dg_teams.Items.Clear();
            txt_tname.Clear();
            txt_timage.Clear();
        }

        private void click_btn_add(object sender, RoutedEventArgs e)
        {
            if (txt_name.Text.Equals("") || txt_nickname.Text.Equals("") || txt_surname.Text.Equals("") || cb_role.SelectedIndex == -1 || cb_type.SelectedIndex == -1 || cb_country.SelectedIndex == -1 || cb_team.SelectedIndex == -1)
            {
                MessageBox.Show("Debe rellenar todos los campos");
                return;
            }
            if (!player.readPlayers(Convert.ToInt32(cb_team.SelectedValue)))
            {
                MessageBox.Show("Equipo lleno, seleccione otro");
                return;
            }
            if (((cb_type.SelectedValue).ToString()).Equals("Headline"))
            {
                if (!player.readPlayers("Headline", Convert.ToInt32(cb_team.SelectedValue)))
                {
                    MessageBox.Show("Ya hay 5 titulares, debe ser suplente");
                    return;
                } 
            }
            string nickName_s = txt_nickname.Text;
            string name_s = txt_name.Text;
            string surname_s = txt_surname.Text;
            string role_s = cb_role.SelectedValue.ToString();
            string type_s = cb_type.SelectedValue.ToString();
            int idTeam_s = Convert.ToInt32(cb_team.SelectedValue);
            int idCountry_s = cb_country.SelectedIndex;

            Player player_insert = new Player(nickName_s, name_s, surname_s, role_s, type_s, idTeam_s, idCountry_s);
            player_insert.insertPlayer();
            MessageBox.Show("Jugador insertado");
            clearFieldsPlayer();
            initializeCB();
        }

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
    }
}
