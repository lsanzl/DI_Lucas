using Ejercicio2_Recuperacion_Lucas_Sanz.Model;
using Ejercicio2_Recuperacion_Lucas_Sanz.Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Ejercicio2_Recuperacion_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ManageProducto pman_aux;
        public MainWindow()
        {
            InitializeComponent();
            pman_aux = new ManageProducto();
            llenarGrid();
        }

        private void click_añadir(object sender, RoutedEventArgs e)
        {
            if (!checkCampos())
            {
                return;
            }
            string codigo = txt_codigo.Text;
            string descripcion = txt_descripcion.Text;
            float coste = float.Parse(txt_coste.Text);
            float precio = float.Parse(txt_precio.Text);
            string observaciones = txt_observaciones.Text;

            Producto p = new Producto(codigo, descripcion, coste, precio, observaciones);
            p.insertarProducto();
            llenarGrid();
        }
        private void click_modificar(object sender, RoutedEventArgs e)
        {
            if(!checkCampos())
            {
                return;
            }
            string codigo = txt_codigo.Text;
            string descripcion = txt_descripcion.Text;
            float coste = float.Parse(txt_coste.Text);
            float precio = float.Parse(txt_precio.Text);
            string observaciones = txt_observaciones.Text;

            Producto p = new Producto(codigo, descripcion, coste, precio, observaciones);
            p.modificarProducto();
            llenarGrid();
        }
        private void click_eliminar(object sender, RoutedEventArgs e)
        {
            if (dg_productos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione producto a eliminar", "Error al eliminar");
                return;
            }
            Producto p = (Producto)dg_productos.SelectedItem;
            p.eliminarProducto();
            llenarGrid();
        }

        public Boolean checkCampos()
        {
            if (string.IsNullOrEmpty(txt_codigo.Text) || string.IsNullOrEmpty(txt_descripcion.Text) || string.IsNullOrEmpty(txt_coste.Text) || string.IsNullOrEmpty(txt_precio.Text))
            {
                MessageBox.Show("Faltan datos", "Error");
                return false;
            }

            if (!double.TryParse(txt_coste.Text, out double costed) || !double.TryParse(txt_precio.Text, out double preciod))
            {
                MessageBox.Show("Valor no correcto, introduzca un número", "Error formato");
                return false;
            }
            return true;
        }
        public void llenarGrid()
        {
            dg_productos.Items.Clear();

            List<Producto> productosDG = pman_aux.getProductos();
            foreach (Producto p in productosDG)
            {
                dg_productos.Items.Add(p);
            }

            txt_codigo.Clear();
            txt_descripcion.Clear();
            txt_coste.Clear();
            txt_precio.Clear();
            txt_observaciones.Clear();
        }
    }
}
