using HP_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Persistence.Manage
{
    /// <summary>
    /// Clase manager de Habilidad para interactuar con la BD
    /// </summary>
    public class ManageAbility
    {
        /// <summary>
        /// Método que recoge todas las habilidades de la BD
        /// y las mete en una lista
        /// </summary>
        /// <returns>List: lista con las habilidades de la BD</returns>
        public List<Ability> getAbilities()
        {
            List<Object> abilities_objects = DBBroker.getAgent().readSQL("select * from hplucas.ability;");
            List<Ability> abilities_list = new List<Ability>();
            string name;
            string description;
            int money;
            int idA;
            
            foreach (List<Object> o in abilities_objects)
            {
                idA = Convert.ToInt32(o[0].ToString());
                name = o[1].ToString();
                description = o[2].ToString();
                money = Convert.ToInt32(o[3].ToString());
                Ability a = new Ability(idA, name, description, money);
                abilities_list.Add(a);
            }
            return abilities_list;
        }
        /// <summary>
        /// Método que inserta un objeto Habilidad en la BD
        /// </summary>
        /// <param name="ability">Habilidad a insertar</param>
        public void insertAbility(Ability ability)
        {
            DBBroker.getAgent().executeSQL("alter table hplucas.ability AUTO_INCREMENT = 1;");
            DBBroker.getAgent().executeSQL($"insert into hplucas.ability (name, description, money) values ('{ability.name}','{ability.description}','{ability.money}');");
        }
        /// <summary>
        /// Método que elimina un objeto Habilidad de la BD
        /// </summary>
        /// <param name="ability">Habilidad a eliminar</param>
        public void deleteAbility(Ability ability)
        {
            DBBroker.getAgent().executeSQL($"delete from hplucas.ability where name='{ability.name}';");
        }
    }
}
