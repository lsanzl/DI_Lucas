using Ejercicio1_Ordinario_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Ejercicio1_Ordinario_Lucas_Sanz.View
{
    /// <summary>
    /// Lógica de interacción para DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public Compra compra;
        public bool isAccepted = false;

        public DialogWindow()
        {
            InitializeComponent();
        }

        public Compra getCompra()
        {
            return this.compra;
        }
        public bool IsAccepted()
        {
            return isAccepted;
        }

        private void click_btn_ok(object sender, RoutedEventArgs e)
        {
            string cantidad = txt_cantidad.Text;
            string producto = txt_producto.Text;
            string precioUnitario = txt_precioUnitario.Text;

            if (String.IsNullOrEmpty(cantidad) || String.IsNullOrEmpty(producto) || String.IsNullOrEmpty(precioUnitario))
            {
                MessageBox.Show("Por favor rellene todos los campos", "Datos vacíos");
                return;
            }

            compra = new Compra(Convert.ToInt32(cantidad), producto, Convert.ToDouble(precioUnitario));
            isAccepted = true;
            Close();
        }

        private void click_btn_cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
