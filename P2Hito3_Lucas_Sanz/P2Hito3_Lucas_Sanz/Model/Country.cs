using P2Hito3_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Model
{
    public class Country
    {
        public ManageCountry manage_country { get; set; }
        public int idCountry { get; set; }
        public string name { get; set; }

        /// <summary>
        /// Constructor of Country
        /// </summary>
        public Country()
        {
            this.manage_country = new ManageCountry();
        }
        /// <summary>
        /// Constructor of Country introducing name
        /// </summary>
        /// <param name="name"> Name of the country </param>
        public Country(string name)
        {
            this.name = name;
            this.manage_country = new ManageCountry();
        }
        /// <summary>
        /// Method that read each of the countries from DB
        /// </summary>
        /// <returns> List of countries </returns>
        public List<Country> readCountries()
        {
            return this.manage_country.getCountrys();
        }
    }
}
