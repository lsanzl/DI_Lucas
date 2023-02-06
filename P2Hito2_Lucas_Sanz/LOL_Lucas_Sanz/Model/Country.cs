using LOL_Lucas_Sanz.Persistence.Manage;
using LOL_Lucas_Sanz.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL_Lucas_Sanz.Model
{
    public class Country
    {
        public ManageCountry manage_country { get; set; }
        public int idCountry { get; set; }
        public string name { get; set; }
        /// <summary>
        /// Void constructor of Country object
        /// </summary>
        public Country()
        {
            this.manage_country = new ManageCountry();
        }
        /// <summary>
        /// Constructor which allows to choose country name
        /// </summary>
        /// <param name="name"> Name to assign </param>
        public Country(string name)
        {
            this.name = name;
            this.manage_country = new ManageCountry();
        }
        /// <summary>
        /// Calls manage method to insert countries
        /// </summary>
        public void insertCountries()
        {
            this.manage_country.insertCountry();
        }
        /// <summary>
        /// Calls to manage method to delete each country
        /// </summary>
        public void deleteCountries()
        {
            this.manage_country.deleteAll();
        }
    }
    
}