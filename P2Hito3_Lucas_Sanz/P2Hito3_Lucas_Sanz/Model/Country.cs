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
            this.manage_country.insertCountry();
        }
        public void deleteCountries()
        {
            this.manage_country.deleteAll();
        }
        public List<Country> readCountries()
        {
            return this.manage_country.getCountrys();
        }
    }
}
