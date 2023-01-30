using Recuperacion_DI_Lucas_Sanz.Persistence;
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

namespace Recuperacion_DI_Lucas_Sanz
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

        private void click_btn_creartabla(object sender, RoutedEventArgs e)
        {
            string nombre_tabla = txt_nombretabla.Text;
            string consulta = $"CREATE TABLE IF NOT EXISTS {nombre_tabla}(\ncampo1 INT PRIMARY KEY,\ncampo2 VARCHAR(45)\n);";
            DBBroker.obtenerAgente().modificar(consulta);
        }
    }
}
