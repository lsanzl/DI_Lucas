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
        /// <summary>
        /// Method to get objects from DB and convert to country object
        /// </summary>
        /// <returns> List of countries  </returns>
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
