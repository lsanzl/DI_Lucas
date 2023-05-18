using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_Ordinaria_Lucas_Sanz.Model
{
    public class Group
    {
        public int refGroup { get; set; }
        public int idActivity { get; set; }

        public Group(int refGroup, int idActivity)
        {
            this.refGroup = refGroup;
            this.idActivity = idActivity;
        }
    }
}
