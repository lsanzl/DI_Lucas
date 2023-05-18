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
using System.Windows.Shapes;

namespace Ejercicio1_Ordinario_Lucas_Sanz.View
{
    /// <summary>
    /// Lógica de interacción para EliminarConfirmacion.xaml
    /// </summary>
    public partial class EliminarConfirmacion : Window
    {
        public bool isConfirmado;
        public EliminarConfirmacion()
        {
            InitializeComponent();
            isConfirmado = false;
        }

        private void click_ok_eliminacion(object sender, RoutedEventArgs e)
        {
            isConfirmado=true;
            Close();
        }

        private void click_cancelar_eliminacion(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
