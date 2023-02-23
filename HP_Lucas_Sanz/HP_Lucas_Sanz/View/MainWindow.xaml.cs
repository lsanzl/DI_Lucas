using HP_Lucas_Sanz.Model;
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

namespace HP_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Buy b_aux;
        Ability a_aux;
        Player p_aux;
        int initial_money;
        Boolean selected;
        Player player_selected;
        Map m;
        List<Ability> ability_list;
        List<Player> player_list;
        List<Buy> buy_list;
        public MainWindow()
        {
            b_aux = new Buy();
            a_aux = new Ability();
            p_aux = new Player();
            initial_money = 100;
            selected = false;
            m = new Map(15, 15, 15, 15);
            
            InitializeComponent();
            initializeDataContainers();
        }
        private void initializeDataContainers()
        {
            ability_list = a_aux.getAbilities();
            player_list = p_aux.getPlayers();

            foreach (Ability a in ability_list)
            {
                dg_abilities.Items.Add(a);
                dg_abilities_player.Items.Add(a);
            }
            foreach (Player p in player_list)
            {
                dg_players.Items.Add(p);
                b_aux.getBuys(p);
            }
        }
        private void clearFieldsAbility()
        {
            dg_abilities.Items.Clear();
            txt_name_ability.Clear();
            txt_description_ability.Clear();
            txt_price_ability.Clear();
            dg_abilities_player.Items.Clear();
        }
        private void clearFieldsPlayer()
        {
            dg_players.Items.Clear();
            txt_name_player.Clear();
            txt_nickname_player.Clear();
            txt_avatar_player.Clear();
            dg_abilities_player.Items.Clear();
            lbl_actual_money.Content = "Actual money: ";
        }
        private void clearFieldsSettings()
        {
            txt_rows.Clear();
            txt_columns.Clear();
            txt_money.Clear();
            txt_rowtarget.Clear();
            txt_columntarget.Clear();
        }
        private void click_btn_save_settings(object sender, RoutedEventArgs e)
        {
            if (txt_rows.Text.Equals("") || txt_columns.Text.Equals("") || txt_money.Text.Equals("") || txt_rowtarget.Text.Equals("") || txt_columntarget.Text.Equals(""))
            {
                MessageBox.Show("Introduzca todos los datos", "Faltan datos");
                return;
            }
            int nrows = Convert.ToInt32(txt_rows.Text);
            int ncolumns = Convert.ToInt32(txt_columns.Text);
            initial_money = Convert.ToInt32(txt_money.Text);
            int rtarget = Convert.ToInt32(txt_rowtarget.Text);
            int ctarget = Convert.ToInt32(txt_columntarget.Text);
            if (rtarget > nrows || ctarget > ncolumns)
            {
                MessageBox.Show("La celda final debe estar dentro de los límites", "Error");
                txt_rowtarget.Clear();
                txt_columntarget.Clear();
                return;
            }
            m = new Map(nrows, ncolumns, rtarget, ctarget);
            MessageBox.Show("Ajustes guardados");
            clearFieldsSettings();
        }
        private void click_btn_create_ability(object sender, RoutedEventArgs e)
        {
            if (txt_name_ability.Text.Equals("") || txt_description_ability.Text.Equals("") || txt_price_ability.Text.Equals(""))
            {
                MessageBox.Show("Introduzca todos los campos", "Faltan datos");
                return;
            }
            if (txt_name_ability.Text.Length > 45 || txt_description_ability.Text.Length > 45)
            {
                MessageBox.Show("Ha sobrepasado el límite de longitud, introduzca menos de 45 caracteres", "Error");
                return;
            }
            string name_a = txt_name_ability.Text;
            string description_a = txt_description_ability.Text;
            int price_a = Convert.ToInt32(txt_price_ability.Text);

            Ability a = new Ability(name_a, description_a, price_a);
            a.insertAbility();
            clearFieldsAbility();
            initializeDataContainers();
        }
        private void click_btn_delete_ability(object sender, RoutedEventArgs e)
        {
            if (dg_abilities.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione habilidad a eliminar", "Ninguna habilidad seleccionada");
                return;
            }
            Ability a_delete = (Ability)dg_abilities.SelectedItem;
            a_delete.deleteAbility();
            clearFieldsAbility();
            initializeDataContainers();
        }
        private void click_btn_create_player(object sender, RoutedEventArgs e)
        {
            if (txt_name_player.Text.Equals("") || txt_nickname_player.Text.Equals("") || txt_avatar_player.Text.Equals(""))
            {
                MessageBox.Show("Introduzca todos los campos", "Faltan datos");
                return;
            }
            Player p = new Player(txt_name_player.Text, txt_nickname_player.Text, txt_avatar_player.Text, initial_money);
            p.insertPlayer();
            clearFieldsPlayer();
            initializeDataContainers();
        }
        private void click_btn_buy(object sender, RoutedEventArgs e)
        {
            if (dg_abilities_player.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione habilidad a comprar", "Ninguna habilidad seleccionada");
                return;
            }

            if (!selected)
            {
                MessageBox.Show("Seleccione jugador", "Ningún jugador asignado");
                return;
            }
            Ability a = (Ability)dg_abilities_player.SelectedItem;
            if (a.money > player_selected.money_player)
            {
                MessageBox.Show("Dinero insuficiente", "No puede comprar esta habilidad");
                return;
            }
            player_selected.money_player -= a.money;
            player_selected.player_ability.Add(a);
            b_aux = new Buy(player_selected.idC, a.idA);
            MessageBox.Show("Habilidad adquirida");
            dg_abilities_player.Items.RemoveAt(dg_abilities_player.SelectedIndex);
            selected = false;
        }
        private void click_btn_select(object sender, RoutedEventArgs e)
        {
            if (dg_players.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione jugador primero", "Ningún jugador seleccionado");
                return;
            }
            player_selected = (Player)dg_players.SelectedItem;
            lbl_actual_money.Content = "Actual money: "+player_selected.money_player.ToString();
            selected = true;
        }
        private void click_btn_start_game(object sender, RoutedEventArgs e)
        {
            if (p_aux.getPlayers().Count <= 1)
            {
                MessageBox.Show("Cree al menos dos jugadores para empezar el juego", "Jugadores insuficientes");
                return;
            }

        }
    }
}