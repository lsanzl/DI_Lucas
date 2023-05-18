using System;
using System.Collections.Generic;
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

namespace Ejercicio1_Recuperacion_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void click_cotizar(object sender, RoutedEventArgs e)
        {
            txt_salida.Clear();
            txt_costo.Clear();

            if (!checkErrores())
            {
                return;
            }

            int costeTotal = 0;
            string textoFinal = "Cotización de automóvil para "+txt_nombre.Text+":";

            if (rdb_basico.IsChecked == true)
            {
                costeTotal += 500;
                textoFinal += "\r\nLleva seguro básico por importe de 500€";
            }
            if (rdb_terceros.IsChecked == true)
            {
                costeTotal += 700;
                textoFinal += "\r\nLleva seguro a terceros por importe de 700€";
            }
            if (rdb_total.IsChecked == true)
            {
                costeTotal += 1000;
                textoFinal += "\r\nLleva seguro total por importe de 1000€";
            }

            if (chk_aire.IsChecked == true)
            {
                costeTotal += 500;
                textoFinal += "\r\nCon sistema de aire acondicionado por importe de 500€";
            }
            if (chk_audio.IsChecked == true)
            {
                costeTotal += 700;
                textoFinal += "\r\nCon sistema de audio por importe de 700€";
            }
            textoFinal += "\r\nEl coste total es de " + costeTotal + "€";

            txt_costo.Text = costeTotal.ToString();
            txt_salida.Text = textoFinal;

            rdb_basico.IsChecked = false;
            rdb_terceros.IsChecked = false;
            rdb_total.IsChecked = false;
            chk_aire.IsChecked = false;
            chk_audio.IsChecked = false;
            txt_nombre.Clear();
        }

        public Boolean checkErrores()
        {
            if (string.IsNullOrEmpty(txt_nombre.Text)) 
            {
                MessageBox.Show("Falta el nombre", "Error");
                return false;
            }
            if (rdb_basico.IsChecked == false && rdb_terceros.IsChecked == false && rdb_total.IsChecked == false)
            {
                MessageBox.Show("Seleccione seguro", "Error");
                return false;
            }
            return true;
        }
    }
}
