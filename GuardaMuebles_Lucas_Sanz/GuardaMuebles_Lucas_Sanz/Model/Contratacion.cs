using GuardaMuebles_Lucas_Sanz.Persistence.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardaMuebles_Lucas_Sanz.Model
{
    public class Contratacion
    {
        public string DNI { get; set; }
        public string codigo { get; set; }
        public double precio { get; set; }
        public int meses { get; set; }
        public double precioTotal { get; set; }
        public ManagerContrataciones manager;

        public Contratacion(string DNI, string codigo, int meses, double precio)
        {
            this.DNI = DNI;
            this.codigo = codigo;
            this.meses = meses;
            this.precio = precio;
            precioTotal = Convert.ToDouble(precio) * meses;
            manager = new ManagerContrataciones();
        }
        public void insertarContratacion()
        {
            manager.insertarContratacion(this);
        }
        public void eliminarContratacion()
        {
            manager.eliminarContratacion(this);
        }
        public DataTable getDataTable()
        {
            DataTable dt = new DataTable("Contrato");

            dt.Columns.Add("DNI");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Meses");
            dt.Columns.Add("Precio");

            DataRow dr = dt.NewRow();
            dr[0] = this.DNI;
            dr[1] = this.codigo;
            dr[2] = this.meses;
            dr[3] = this.precio;

            dt.Rows.Add(dr);

            return dt;

        }
    }
}
