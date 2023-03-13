using Ejercicio2_Ordinaria_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Lógica de interacción para NewPartnerWindow.xaml
    /// </summary>
    public partial class NewPartnerWindow : Window
    {
        public Partner partner;
        public bool isAcepted;
        public NewPartnerWindow()
        {
            InitializeComponent();
            isAcepted = false;
        }
         private void click_btn_ok_partner(object sender, RoutedEventArgs e)
        {
            String name = txt_name.Text;
            String date = txt_date.Text;
            String zip = txt_zip.Text;
            String city = txt_city.Text;
            String province = txt_privince.Text;
            String telephone = txt_telephone.Text;
            String bank = txt_bank.Text;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(date) || String.IsNullOrEmpty(zip) || String.IsNullOrEmpty(province) || String.IsNullOrEmpty(telephone) || String.IsNullOrEmpty(city) || String.IsNullOrEmpty(bank))
            {
                MessageBox.Show("Please fill in all the fields", "Empty data");
                return;
            }
            partner = new Partner(name, date, Convert.ToInt32(zip), city, province, Convert.ToInt32(telephone), bank);
            isAcepted = true;
            Close();
        }
        public bool isAceptedCheck()
        {
            return isAcepted;
        }

        private void click_btn_cancelar_partner(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public Partner getPartner()
        {
            return partner;
        }
    }
}
