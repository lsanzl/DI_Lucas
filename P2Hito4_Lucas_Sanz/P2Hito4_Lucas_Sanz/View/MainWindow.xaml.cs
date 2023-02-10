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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P2Hito4_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable tabla1;
        Random r = new Random();
        DataRow dr;
        public MainWindow()
        {
            InitializeComponent();

            //Crear un DataTable con el mismo nombre de la tabla del informe
            tabla1 = new DataTable("DataTable1");
            

            //Crear las columnas con los mismos nombre de campos del datatable de crystal report
            tabla1.Columns.Add("Nombre");
            tabla1.Columns.Add("Edad");
            tabla1.Columns.Add("Dirección");
            tabla1.Columns.Add("Teléfono");

            //Añadir datos (100 filas)
            for (int i = 1; i<=100; i++)
            {
                dr = tabla1.NewRow();
                dr["Nombre"] = "Rosa";
                dr["Edad"] = r.Next(10,100);
                dr["Dirección"] = "dirección";
                dr["Teléfono"] = "664471288";
                tabla1.Rows.Add(dr);
            }

            //Crear una instancia de crystal report
            CrystalReport1 repor = new CrystalReport1();

            //Incluir el data source al crystal report
            repor.Database.Tables["Datatable1"].SetDataSource((DataTable)tabla1);

            //Asignar el informe para crystal report viewer
            //cr_viewer.
        }
    }
}
