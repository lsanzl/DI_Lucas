using LOL_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL_Lucas_Sanz.Persistence.Manage
{
    public class ManageCountry
    {
        /// <summary>
        /// Execute sql query to insert a determinated list of countries to DB
        /// </summary>
        public void insertCountry()
        {
            DBBroker.getAgent().executeSQL("alter table leagueoflegends.country AUTO_INCREMENT = 1;");
            string[] name_list = { "Spain", "Italy", "France", "Portugal", "Denmark", "Deutschland", "UK", "Greece", "Netherlands", "Scotland" };
            
            foreach (string name in name_list)
            {
                Country c = new Country(name);
                DBBroker.getAgent().executeSQL($"insert into leagueoflegends.country (name) values('{c.name}');");
            }            
        }
        /// <summary>
        /// Execute a sql query to delete each country from DB
        /// </summary>
        public void deleteAll()
        {
            DBBroker.getAgent().executeSQL("SET FOREIGN_KEY_CHECKS=0;");
            DBBroker.getAgent().executeSQL("delete from leagueoflegends.country");
            DBBroker.getAgent().executeSQL("SET FOREIGN_KEY_CHECKS=1;");
        }
    }
}