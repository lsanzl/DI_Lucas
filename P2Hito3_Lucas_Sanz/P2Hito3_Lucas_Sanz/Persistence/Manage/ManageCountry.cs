using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2Hito3_Lucas_Sanz.Model;

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
        public List<Country> getCountrys()
        {
            List<Country> country_list = new List<Country>();
            List<Object> country_object = new List<Object>();
            country_object = DBBroker.getAgent().readSQL("select * from leagueoflegends.country;");
            foreach(List<Object> objC in country_object)
            {
                Country c = new Country(objC[1].ToString());
                country_list.Add(c);
            }
            return country_list;
        }
    }
}
