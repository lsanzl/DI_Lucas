using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Model
{
    /// <summary>
    /// Clase objeto Habilidad
    /// </summary>
    public class Ability
    {
        public int idA { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int money { get; set; }
        public ManageAbility manage_ability { get; set; }

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Ability()
        {
            this.manage_ability = new ManageAbility();
        }
        /// <summary>
        /// Constructor casi completo de Habilidad
        /// </summary>
        /// <param name="name">Nombre habilidad</param>
        /// <param name="description">Descripción habilidad</param>
        /// <param name="money">Coste habilidad</param>
        public Ability(string name, string description, int money)
        {
            this.name = name;
            this.description = description;
            this.money = money;
            this.manage_ability = new ManageAbility();
        }
        /// <summary>
        /// Constructor completo habilidad
        /// </summary>
        /// <param name="idA">Identificador habilidad</param>
        /// <param name="name">Nombre habilidad</param>
        /// <param name="description">Descripción habilidad</param>
        /// <param name="money">Coste habilidad</param>
        public Ability(int idA, string name, string description, int money)
        {
            this.idA = idA;
            this.name = name;
            this.description = description;
            this.money = money;
            this.manage_ability = new ManageAbility();
        }
        /// <summary>
        /// Método que llama a la función para insertar habilidad en la BD
        /// </summary>
        public void insertAbility()
        {
            this.manage_ability.insertAbility(this);
        }
        /// <summary>
        /// Método que llama a la función para eliminar habilidad de la BD
        /// </summary>
        public void deleteAbility()
        {
            this.manage_ability.deleteAbility(this);
        }
        /// <summary>
        /// Método que recupera la lista de habilidades en la BD
        /// </summary>
        /// <returns>List: lista con todas las habilidades de la BD</returns>
        public List<Ability> getAbilities()
        {
            return this.manage_ability.getAbilities();
        }
    }
}
