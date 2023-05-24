using Ejercicio4_Recuperacion_Lucas_Sanz.Model;
using Ejercicio4_Recuperacion_Lucas_Sanz.Persistence.Manage;
using Ejercicio4_Recuperacion_Lucas_Sanz.Report;
using Ejercicio4_Recuperacion_Lucas_Sanz.View;
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

namespace Ejercicio4_Recuperacion_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Grid> listaGrid;
        public ManagerConsumicion managerAux;
        public Dictionary<string, double> listaPrecios;
        List<Consumicion> consumiciones;
        public MainWindow()
        {
            InitializeComponent();
            listaGrid = new List<Grid>() { grid_refrescos, grid_cervezas, grid_vinos, grid_combinados, grid_platos_combinados, grid_menus, grid_cafes};
            managerAux = new ManagerConsumicion();
            listaPrecios = managerAux.getPrecios();
            consumiciones = new List<Consumicion>();
        }

        private void click_refresco(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_refrescos);
        }
        private void click_cerveza(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_cervezas);
        }
        private void click_vino(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_vinos);
        }
        private void click_combinado(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_combinados);
        }
        private void click_plato_combinado(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_platos_combinados);
        }
        private void click_menu(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_menus);
        }
        private void click_cafe(object sender, RoutedEventArgs e)
        {
            mostrarSubPantalla(grid_cafes);
        }
        public void mostrarSubPantalla(Grid gridMostrar)
        {
            grid_inicial.Visibility = Visibility.Collapsed;
            gridMostrar.Visibility = Visibility.Visible;
            btn_volver.Visibility = Visibility.Visible;
        }
        private void click_volver(object sender, RoutedEventArgs e)
        {
            foreach (Grid grid in listaGrid)
            {
                grid.Visibility = Visibility.Collapsed;
            }
            grid_inicial.Visibility = Visibility.Visible;
            btn_volver.Visibility = Visibility.Collapsed;
        }

        private void selected_consumicion(object sender, SelectionChangedEventArgs e)
        {
            if(dg_consumiciones.SelectedIndex != -1)
            {
                btn_eliminar.IsEnabled = true;
            }
        }

        private void click_eliminar(object sender, RoutedEventArgs e)
        {
            Consumicion c = (Consumicion)dg_consumiciones.SelectedValue;
            dg_consumiciones.Items.Remove(c);
            consumiciones.Remove(c);
            btn_eliminar.IsEnabled = false;
            actualizarPedido();
        }

        private void click_consumicion(object sender, RoutedEventArgs e)
        {
            Button btnClick = (Button)sender;

            string consumicion = btnClick.Content.ToString();
            string consumicionCompleto = btnClick.Content.ToString();

            consumicion = consumicion.Replace(" ", "");
            consumicion = consumicion.ToLower();

            if (consumicion.Equals("cervezasin"))
            {
                MessageBox.Show("¿ESTÁS SEGURO?", "CUIDADO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            double precio = listaPrecios[consumicion];
            Consumicion c = new Consumicion(consumicionCompleto, precio);
            consumiciones.Add(c);

            actualizarPedido();
        }
        public void actualizarPedido()
        {
            dg_consumiciones.Items.Clear();
            foreach(Consumicion c in consumiciones)
            {
                dg_consumiciones.Items.Add(c);
            }
        }

        private void click_pagar(object sender, RoutedEventArgs e)
        {
            VisorFactura ventanaFactura = new VisorFactura();

            Factura nueva_factura = new Factura();
            DataTable factura = new DataTable("dt_consumiciones");

            factura.Columns.Add("Producto");
            factura.Columns.Add("Precio");

            foreach(Consumicion c in consumiciones)
            {
                DataRow row = factura.NewRow();
                row[0] = c.nombre;
                row[1] = c.precio;
                factura.Rows.Add(row);
            }

            nueva_factura.Database.Tables["dt_consumiciones"].SetDataSource((DataTable)factura);
            ventanaFactura.factura_viewer.ViewerCore.ReportSource = nueva_factura;

            ventanaFactura.Show();
        }
    }
}
