using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    public class ManageCountry
    {
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
        public void deleteAll()
        {
            DBBroker.getAgent().executeSQL("delete from leagueoflegends.country");
        }
        public List<String> getNameCountrys()
        {
            List<Country> country_names = new List<Country>();

        }
    }
}
