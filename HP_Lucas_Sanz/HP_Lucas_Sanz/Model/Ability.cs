using HP_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HP_Lucas_Sanz.Model
{
    public class Ability
    {
        public int idA { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float money { get; set; }
        public ManageAbility manage_ability { get; set; }

        public Ability(string name, string description, float money)
        {
            this.name = name;
            this.description = description;
            this.money = money;
            this.manage_ability = new ManageAbility();
        }
        public Ability()
        {
            this.manage_ability = new ManageAbility();
        }
        public void insertAbility()
        {
            this.manage_ability.insertAbility(this);
        }
        public void deleteAbility()
        {
            this.manage_ability.deleteAbility(this);
        }
        public List<Ability> getAbilities()
        {
            return this.manage_ability.getAbilities();
        }
    }
}
