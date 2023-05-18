using Ejercicio2_Ordinaria_Lucas_Sanz.Model;
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

namespace Ejercicio2_Ordinaria_Lucas_Sanz.View
{
    /// <summary>
    /// Lógica de interacción para NewActivityWindow.xaml
    /// </summary>
    public partial class NewActivityWindow : Window
    {
        public Activity activity;
        public bool isAcepted;

        public NewActivityWindow()
        {
            InitializeComponent();
            isAcepted = false;
        }
        public Activity getActivity()
        {
            return activity;
        }

        private void click_btn_ok_activity(object sender, RoutedEventArgs e)
        {
            String name = txt_name.Text;
            String price = txt_price.Text;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(price))
            {
                MessageBox.Show("Please fill in all the fields", "Empty data");
                return;
            }

            activity = new Activity(name, Convert.ToInt32(price));
            isAcepted = true;
            Close();
        }
        public bool isAceptedCheck()
        {
            return isAcepted;
        }

        private void click_btn_cancel_activity(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
