using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Ordinaria_Lucas_Sanz.Model
{
    public class Activity
    {        public string name { get; set; }
        public int price { get; set; }

        public Activity(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
