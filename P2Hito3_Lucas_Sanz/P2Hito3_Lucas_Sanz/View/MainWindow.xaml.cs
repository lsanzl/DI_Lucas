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

            dg_players.Items.Clear();
            dg_teams.Items.Clear();
            cb_country.Items.Clear();
            cb_team.Items.Clear();
            cb_role.Items.Clear();
            cb_type.Items.Clear();

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

        private void click_btn_add(object sender, RoutedEventArgs e)
        {
            if (txt_name == null || txt_nickname == null || txt_surname == null || cb_role.SelectedIndex == -1 || cb_type.SelectedIndex == -1 || cb_country.SelectedIndex == -1 || cb_team.SelectedIndex == -1)
            {
                MessageBox.Show("Debe rellenar todos los campos");
                return;
            }
            if (!player.readPlayers(Convert.ToInt32(cb_team.SelectedValue)))
            {
                MessageBox.Show("Equipo llene, seleccione otro");
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
        }
    }
}
