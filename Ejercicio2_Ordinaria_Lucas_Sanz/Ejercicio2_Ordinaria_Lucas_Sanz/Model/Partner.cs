using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Ordinaria_Lucas_Sanz.Model
{
    public class Partner
    {
        public String name { get; set; }
        public String date { get; set; }
        public int zipCode { get; set; }
        public String city { get; set; }
        public String province { get; set; }
        public int telephone { get; set; }
        public String bank { get; set; }

        public Partner(string name, String date, int zipCode, string city, string province, int telephone, string bank)
        {
            this.name = name;
            this.date = date;
            this.zipCode = zipCode;
            this.city = city;
            this.province = province;
            this.telephone = telephone;
            this.bank = bank;
        }
    }
}
