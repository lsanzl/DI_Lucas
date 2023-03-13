using Ejercicio1_Ordinario_Lucas_Sanz.Model;
using Ejercicio1_Ordinario_Lucas_Sanz.Persistence;
using Ejercicio1_Ordinario_Lucas_Sanz.View;
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

namespace Ejercicio1_Ordinario_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Compra> listaCompra;
        int precioAbsoluto;
        Report_Viewer reporter;
        InformeCompra informe;

        public MainWindow()
        {
            InitializeComponent();

            listaCompra = new List<Compra>();
            informe = new InformeCompra();
        }

        private void click_btn_nuevo(object sender, RoutedEventArgs e)
        {
            DialogWindow window = new DialogWindow();
            window.ShowDialog();
            if (window.IsAccepted())
            {
                Compra compra = window.getCompra();
                listaCompra.Add(compra);
                dg_compras.Items.Add(compra);
            }
        }


        private void click_btn_imprimir(object sender, RoutedEventArgs e)
        {
            if (listaCompra.Count == 0)
            {
                MessageBox.Show("Inserte algún producto antes", "Lista vacía");
                return;
            }
            reporter = new Report_Viewer(listaCompra);

            reporter.showReport();
            reporter.Show();
        }

        private void click_btn_eliminar(object sender, RoutedEventArgs e)
        {
            if(dg_compras.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione alguna compra primero", "Ninguna compra seleccionada");
                return;
            }
            EliminarConfirmacion windowEliminar = new EliminarConfirmacion();
            windowEliminar.ShowDialog();

            if (windowEliminar.isConfirmado)
            {
                dg_compras.Items.Remove(dg_compras.SelectedValue);
            }
            dg_compras.SelectedIndex = -1;
        }
    }
}
