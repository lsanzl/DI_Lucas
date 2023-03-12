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
using HP_Lucas_Sanz.Persistence.Manage;
using Mysqlx.Resultset;
using System.Windows.Controls.Ribbon;
using System.Windows.Automation;

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
        ManagePlayer managePlayer = new ManagePlayer();
        Map m;
        List<Ability> ability_list;
        List<Player> player_list;
        List<Buy> buy_list;
        List<StackPanel> listSP = new List<StackPanel>();
        int nrows;
        int ncolumns;
        int rtarget;
        int ctarget;
        int posActual;
        int[,] map_grid;
        List<Player> listaJugadores;
        public MainWindow()
        {
            b_aux = new Buy();
            a_aux = new Ability();
            p_aux = new Player();
            initial_money = 100;
            selected = false;
            nrows = 15;
            ncolumns = 15;
            rtarget = 15;
            ctarget = 15;
            posActual = 0;
            
            InitializeComponent();
            initializeDataContainers();
        }
        /// <summary>
        /// Carga desde la BD los datos relacionados con las habilidades
        /// y los jugadores y los muestra en sus respectivos data grid
        /// </summary>
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
        /// <summary>
        /// Limpia los campos de texto y selectores
        /// </summary>
        private void clearFieldsAbility()
        {
            dg_abilities.Items.Clear();
            txt_name_ability.Clear();
            txt_description_ability.Clear();
            txt_price_ability.Clear();
            dg_abilities_player.Items.Clear();
        }
        /// <summary>
        /// Limpia los campos de texto y selectores
        /// </summary>
        private void clearFieldsPlayer()
        {
            dg_players.Items.Clear();
            txt_name_player.Clear();
            txt_nickname_player.Clear();
            txt_avatar_player.Clear();
            dg_abilities_player.Items.Clear();
            lbl_actual_money.Content = "Actual money: ";
        }
        /// <summary>
        /// Limpia los campos de texto y selectores
        /// </summary>
        private void clearFieldsSettings()
        {
            txt_rows.Clear();
            txt_columns.Clear();
            txt_money.Clear();
            txt_rowtarget.Clear();
            txt_columntarget.Clear();
        }
        /// <summary>
        /// Actualiza los valores por defecto según la configuración
        /// que introduzca el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_save_settings(object sender, RoutedEventArgs e)
        {
            if (txt_rows.Text.Equals("") || txt_columns.Text.Equals("") || txt_money.Text.Equals("") || txt_rowtarget.Text.Equals("") || txt_columntarget.Text.Equals(""))
            {
                MessageBox.Show("Introduzca todos los datos", "Faltan datos");
                return;
            }
            nrows = Convert.ToInt32(txt_rows.Text);
            ncolumns = Convert.ToInt32(txt_columns.Text);
            initial_money = Convert.ToInt32(txt_money.Text);
            rtarget = Convert.ToInt32(txt_rowtarget.Text);
            ctarget = Convert.ToInt32(txt_columntarget.Text);
            if (rtarget > nrows || ctarget > ncolumns)
            {
                MessageBox.Show("La celda final debe estar dentro de los límites", "Error");
                txt_rowtarget.Clear();
                txt_columntarget.Clear();
                return;
            }
            MessageBox.Show("Ajustes guardados");
            clearFieldsSettings();
        }
        /// <summary>
        /// Acción que llama al manager de habilidades e introduce la
        /// nueva habilidad tanto en la BD como en los data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Acción que elimina la habilidad seleccionada de la BD y de los
        /// data grid. Verifica que se haya seleccionado alguna primero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Acción que llama al manager de jugadores para introducirlo en la BD
        /// así como mostrarlo por los data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Acción que asigna una habilidad a un jugador, si no se ha seleccionado
        /// jugador dará error. Una vez hecho crea un nuevo objeto Buy y lo sube a
        /// la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Acción para seleccionar un jugador al que se va a comprar habilidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Acción que inicializa el juego, dará error si no se han creado al menos 2 jugadores
        /// Acaba cuando no quedan jugadores o uno de ellos ha ganado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_start_game(object sender, RoutedEventArgs e)
        {
            listaJugadores = managePlayer.getPlayers();
            createSPPlayer(listaJugadores);
            if (listSP.Count < 2)
            {
                MessageBox.Show("There must be at least 2 players ready to play\n(Players who have spent their points)");
                return;
            }
            Random r = new Random();
            map_grid = new int[nrows, ncolumns];
            for (int i = 0; i<nrows; i++)
            {
                for(int j = 0; j<ncolumns; j++)
                {
                    map_grid[i, j] = r.Next(0, 2);
                }
            }
            if (btn_start_game.Content.Equals("STOP"))
            {
                btn_start_game.Content = "START";
                g_game.Opacity = 0.5;
                btn_next.IsEnabled = false;
                return;
            }
            btn_start_game.Content = "STOP";
            g_game.Opacity = 1;
            btn_next.IsEnabled = true;
            foreach(Player p in listaJugadores)
            {
                p.checkAbilities();
            }
        }
        /// <summary>
        /// Acción que continúa el juego, comprobando primero el tipo de habilidad que posee
        /// para determinar el avance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_next(object sender, RoutedEventArgs e)
        {
            Player actualPlayer = listaJugadores[posActual];
            if (actualPlayer.vidas > 0)
            {
                move(actualPlayer);
            }
            if (actualPlayer.vidas == 0)
            {
                listSP[posActual].Children.OfType<Label>().First().Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show(actualPlayer.name + " ha muerto");
                actualPlayer.vidas -= 1;
            }
            if (ctarget % 2 != 0)
            {
                ctarget--;
                rtarget--;
            }
            if (Convert.ToInt32(listSP[posActual].GetValue(Grid.ColumnProperty)) == ctarget
            && Convert.ToInt32(listSP[posActual].GetValue(Grid.RowProperty)) == rtarget)
            {
                MessageBox.Show(actualPlayer.name + " has won the game!");
                btn_start_game.Content = "PLAY AGAIN";
                btn_next.IsEnabled = false;
                g_game.Opacity = 0.5;
                return;
            }
            if (posActual == listSP.Count - 1)
            {
                posActual = 0;
            }
            else
            {
                posActual++;
            }
        }
        /// <summary>
        /// Método que recibe por parámetro la posición de un jugador y determina
        /// si este ha llegado a la meta o no
        /// </summary>
        /// <param name="row">Fila del jugador</param>
        /// <param name="column">Columna del jugador</param>
        /// <param name="p">Jugador actual</param>
        private void checkGanador(int row, int column, Player p)
        {
            if (row == rtarget-1 && column == ctarget-1)
            {
                MessageBox.Show("El jugador " + p.name + " ha ganado!");
            }
        }
        /// <summary>
        /// Método que crea un Stackpanel por cada jugador que participe
        /// en la partida
        /// </summary>
        /// <param name="lista"></param>
        private void createSPPlayer(List<Player> lista)
        {
            foreach (Player p in lista)
            {
                listSP.Add(p.createSp(g_game));
            }

            foreach (StackPanel sp in listSP)
            {
                sp.SetValue(Grid.RowProperty, 0);
                sp.SetValue(Grid.ColumnProperty, 0);
            }
        }
        /// <summary>
        /// Función que checkea el tipo de movimiento que debe realizar
        /// el jugador en función de sus habilidades
        /// </summary>
        /// <param name="actualPlayer">Jugador actual</param>
        private void move(Player actualPlayer)
        {
            if (!actualPlayer.wand)
            {
                movRayBrain(actualPlayer);
            }
            else
            {
                movWand(actualPlayer);
            }
        }
        /// <summary>
        /// Si el jugador posee la varita se ejecutará este tipo
        /// de movimiento, donde no se checkean las vidas
        /// </summary>
        /// <param name="actualPlayer">Jugador actual</param>
        private void movWand(Player actualPlayer)
        {
            Random r = new Random();
            int n = r.Next(0, 9);
            int row = getRowPlayer(actualPlayer);
            int column = getColumnPlayer(actualPlayer);
            if (n == 4)
            {
                movWand(actualPlayer);
                return;
            }
            switch (n)
            {
                case 0: row -= 1; column -= 1; break;
                case 1: row -= 1; break;
                case 2: row -= 1; column += 1; break;
                case 3: column -= 1; break;
                case 4: break;
                case 5: column += 1; break;
                case 6: row += 1; column += 1; break;
                case 7: row += 1; break;
                case 8: row += 1; column += 1; break;
            }
            if (row == -1 || row == nrows || column == -1 || column == ncolumns)
            {
                movWand(actualPlayer);
                return;
            }
            for (int i = 0; i < listaJugadores.Count; i++)
            {
                if (actualPlayer == listaJugadores[i])
                {
                    listSP[i].SetValue(Grid.RowProperty, row);
                    listSP[i].SetValue(Grid.ColumnProperty, column);
                    break;
                }
            }
            checkGanador(row, column, actualPlayer);
        }
        /// <summary>
        /// Si el jugador posee la varita se ejecutará este tipo
        /// de movimiento, donde se moverá dos veces y en dirección
        /// al objetivo, pero podrá perder vidas
        /// </summary>
        /// <param name="actualPlayer">Jugador actual</param>
        private void movRayBrain(Player actualPlayer)
        {
            int row = getRowPlayer(actualPlayer);
            int column = getColumnPlayer(actualPlayer);
            for (int i = 0; i < listaJugadores.Count; i++)
            {
                if (actualPlayer == listaJugadores[i])
                {
                    row += 2;
                    column += 2;
                    listSP[i].SetValue(Grid.RowProperty, row);
                    listSP[i].SetValue(Grid.ColumnProperty, column);
                    if (map_grid[row, column] == 0) actualPlayer.vidas -= 1;
                    break;
                }
            }
            checkGanador(row, column, actualPlayer);
        }
        /// <summary>
        /// Función que obtiene la fila actual de un jugador pasado
        /// </summary>
        /// <param name="actualPlayer">Jugador actual</param>
        /// <returns>row: fila jugador</returns>
        private int getRowPlayer(Player actualPlayer)
        {
            int row = -1;
            int cont = 0;
            foreach (Player p in listaJugadores)
            {
                if (actualPlayer.idC == p.idC)
                {
                    row = Convert.ToInt32(listSP[cont].GetValue(Grid.RowProperty));
                    break;
                }
                cont++;
            }
            return row;
        }
        /// <summary>
        /// Función que devuelve la columna actual del jugador pasado
        /// </summary>
        /// <param name="actualPlayer">Jugador actual</param>
        /// <returns>column: columna jugador</returns>
        private int getColumnPlayer(Player actualPlayer)
        {
            int column = -1;
            int cont = 0;
            foreach (Player p in listaJugadores)
            {
                if (actualPlayer.idC == p.idC)
                {
                    column = Convert.ToInt32(listSP[cont].GetValue(Grid.ColumnProperty));
                    break;
                }
                cont++;
            }
            return column;
        }
        /// <summary>
        /// Acción que elimina el jugador seleccionado tanto de la BD como
        /// de los data grid. Comprueba que se haya seleccionado un jugador
        /// primero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_delete_player(object sender, RoutedEventArgs e)
        {
            if (dg_players.SelectedIndex == -1)
            {
                MessageBox.Show("Error", "Seleccione jugador");
                return;
            }
            Player playerDelete = (Player)dg_players.SelectedValue;
            playerDelete.deletePlayer();
            clearFieldsPlayer();
        }
    }
}