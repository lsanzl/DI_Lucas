using HP_Lucas_Sanz.Persistence;
using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Model
{
    /// <summary>
    /// Clase objeto Buy
    /// </summary>
    public class Buy
    {
        public int idC { get; set; }
        public int idA { get; set; }
        public ManageBuy manage_buy { get; set; }
        public Player p_aux;
        public Ability a_aux;
        /// <summary>
        /// Constructor objetos Buy
        /// </summary>
        /// <param name="idC">Identificador jugador</param>
        /// <param name="idA">Identificador habilidad</param>
        public Buy(int idC, int idA)
        {
            this.idC = idC;
            this.idA = idA;
            this.manage_buy = new ManageBuy();
        }
        /// <summary>
        /// Constructor vacío objeto Buy
        /// </summary>
        public Buy()
        {
            manage_buy = new ManageBuy();
        }
        /// <summary>
        /// Método que llama al manager para recuperar lista compras
        /// </summary>
        /// <returns>List: lista compras</returns>
        public List<Buy> getBuys()
        {
            List<Buy> buy_list = manage_buy.readBuy();
            return buy_list;
        }
        /// <summary>
        /// Método que llama al manager para recuperar lista compras de un jugador
        /// en concreto
        /// </summary>
        /// <param name="player">Jugador a comprobar</param>
        /// <returns>List: lista compras del jugador</returns>
        public List<Buy> getBuys(Player player)
        {
            List<Buy> buy_list = manage_buy.getBuys(player);
            return buy_list;
        }
    }
}
