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

        public Country()
        {
            this.manage_country = new ManageCountry();
        }

        public Country(string name)
        {
            this.name = name;
            this.manage_country = new ManageCountry();
        }
        public void insertCountries()
        {
            this.manage_country.deleteAll();
            this.manage_country.insertCountry();
        }
    }
    
}