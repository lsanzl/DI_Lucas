using Ejercicio1_Ordinario_Lucas_Sanz.Model;
using Ejercicio1_Ordinario_Lucas_Sanz.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Ejercicio1_Ordinario_Lucas_Sanz.Persistence.DataSetCompras;

namespace Ejercicio1_Ordinario_Lucas_Sanz.View
{
    /// <summary>
    /// Lógica de interacción para Report_Viewer.xaml
    /// </summary>
    public partial class Report_Viewer : Window
    {
        public Compra compra_aux;
        public List<Compra> listaCompra;
        public Report_Viewer(List<Compra> listaCompra)
        {
            InitializeComponent();
            this.listaCompra = listaCompra;
            compra_aux = new Compra();
        }
        public DataTable compraDataTable()
        {
            DataTable tablecompras = new DataTable("Compras");
            DataRow dr;

            tablecompras.Columns.Add("Cantidad");
            tablecompras.Columns.Add("Producto");
            tablecompras.Columns.Add("Precio");
            tablecompras.Columns.Add("PrecioTotal");

            foreach(Compra c in listaCompra)
            {
                dr =  tablecompras.NewRow();
                dr["Cantidad"] = c.cantidad;
                dr["Producto"] = c.producto;
                dr["Precio"] = c.precioUnitario;
                tablecompras.Rows.Add(dr);
            }

            dr = tablecompras.NewRow();
            dr["PrecioTotal"] = compra_aux.getPrecioAbsoluto(listaCompra);
            tablecompras.Rows.Add(dr);

            return tablecompras;
        }
        public void showReport()
        {
            InformeCompra informe = new InformeCompra();
            compraDataTable(informe);
            cr_viewer.ViewerCore.ReportSource = informe;
        }
        private void compraDataTable(InformeCompra informe)
        {
            DataTable dt = new DataTable("Compras");
            DataColumn c1 = new DataColumn("Cantidad");
            DataColumn c2 = new DataColumn("Producto");
            DataColumn c3 = new DataColumn("Precio");
            DataColumn c4 = new DataColumn("PrecioTotal");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);

            DataRow row;
            foreach (Compra c in listaCompra)
            {
                row = dt.NewRow();
                row[0] = c.cantidad;
                row[1] = c.producto;
                row[2] = c.precioUnitario;
                dt.Rows.Add(row);
            }
            row = dt.NewRow();
            row[3] = compra_aux.getPrecioAbsoluto(listaCompra);


            informe.Database.Tables["Compras"].SetDataSource(dt);
        }
    }
}
