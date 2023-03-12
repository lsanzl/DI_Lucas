using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HP_Lucas_Sanz.Model
{
    /// <summary>
    /// Clase objeto Player
    /// </summary>
    public class Player
    {
        public int idC { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string avatar { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int money_player { get; set; }
        public List<Ability> player_ability { get; set; }
        public ManagePlayer manage_player { get; set; }
        public int vidas;
        public StackPanel stackpanelPlayer { get; set; }
        public Boolean wand;
        public Boolean ray;
        public Boolean brain;

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Player()
        {
            manage_player = new ManagePlayer();
        }
        /// <summary>
        /// Constructor casi completo objeto Player
        /// </summary>
        /// <param name="name">Nombre jugador</param>
        /// <param name="nickname">Nickname jugador</param>
        /// <param name="avatar">Avatar jugador</param>
        /// <param name="money_player">Dinero jugador</param>
        public Player(string name, string nickname, string avatar, int money_player)
        {
            this.name = name;
            this.nickname = nickname;
            this.avatar = avatar;
            this.money_player = money_player;
            player_ability = new List<Ability>();
            manage_player = new ManagePlayer();
            vidas = 3;
            stackpanelPlayer = new StackPanel();
            wand = false;
            ray = false;
            brain = false;
        }
        /// <summary>
        /// Constructor completo objeto Player
        /// </summary>
        /// <param name="idC">Identificador Player</param>
        /// <param name="name">Nombre jugador</param>
        /// <param name="nickname">Nickname jugador</param>
        /// <param name="avatar">Avatar jugador</param>
        /// <param name="money_player">Dinero jugador</param>
        public Player(int idC, string name, string nickname, string avatar, int money_player)
        {
            this.idC = idC;
            this.name = name;
            this.nickname = nickname;
            this.avatar = avatar;
            this.money_player = money_player;
            player_ability = new List<Ability>();
            manage_player = new ManagePlayer();
            vidas = 3;
            stackpanelPlayer = new StackPanel();
            wand = false;
            ray = false;
            brain = false;
        }
        /// <summary>
        /// Método que llama al maneger para introducir un jugador en la BD
        /// </summary>
        public void insertPlayer()
        {
            manage_player.insertPlayer(this);
        }
        /// <summary>
        /// Método que llama al maneger para eliminar un jugador de la BD
        /// </summary>
        public void deletePlayer()
        {
            manage_player.deletePlayer(this);
        }
        /// <summary>
        /// Método que llama al manager para conseguir la lista de Players de la BD
        /// </summary>
        /// <returns>List: lista con jugadores</returns>
        public List<Player> getPlayers()
        {
            return manage_player.getPlayers();
        }
        /// <summary>
        /// Método que comprueba que habilidades ha comprado el Player para
        /// empezar la partida
        /// </summary>
        public void checkAbilities()
        {
            foreach (Ability ab in player_ability)
            {
                if (ab.name.Equals("ray"))
                {
                    ray = true;
                }
                else if (ab.name.Equals("brain"))
                {
                    brain = true;
                }
                else
                {
                    wand = true;
                }
            }
        }
        /// <summary>
        /// Método que crea un StackPanel personalizado para cada Player
        /// </summary>
        /// <param name="grid">Grid de juego</param>
        /// <returns>StackPanel sp personalizado</returns>
        public StackPanel createSp(Grid grid)
        {
            Label lbl = new Label();
            lbl.Content = this.nickname;
            stackpanelPlayer.Children.Add(lbl);
            grid.Children.Add(stackpanelPlayer);
            Grid.SetRow(stackpanelPlayer, 0);
            Grid.SetColumn(stackpanelPlayer, 0);
            return this.stackpanelPlayer;
        }
    }
}
