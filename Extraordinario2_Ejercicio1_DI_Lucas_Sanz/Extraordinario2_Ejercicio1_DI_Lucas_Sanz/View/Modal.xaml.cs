using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Model;
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

namespace Extraordinario2_Ejercicio1_DI_Lucas_Sanz.View
{
    /// <summary>
    /// Lógica de interacción para Modal.xaml
    /// </summary>
    public partial class Modal : Window
    {
        public Clase1 c;
        public Boolean isAccepted = false;
        public Modal()
        {
            InitializeComponent();
        }
        public Boolean IsAccepted()
        {
            return this.isAccepted;
        }
        public Clase1 getClase()
        {
            return c;
        }

        private void click_ok(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_modal_1.Text) || string.IsNullOrEmpty(txt_modal_2.Text) || string.IsNullOrEmpty(txt_modal_3.Text))
            {
                MessageBox.Show("Faltan datos por rellenar");
                return;
            }
            string parametro1 = txt_modal_1.Text;
            int parametro2 = Convert.ToInt32(txt_modal_2.Text);
            double parametro3 = Convert.ToDouble(txt_modal_3.Text);

            c = new Clase1(parametro1, parametro2, parametro3);
            isAccepted = true;
        }

        private void click_cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
