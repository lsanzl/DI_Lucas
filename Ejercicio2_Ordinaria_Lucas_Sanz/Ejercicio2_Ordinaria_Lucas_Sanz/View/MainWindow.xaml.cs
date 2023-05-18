using Ejercicio2_Ordinaria_Lucas_Sanz.Model;
using Ejercicio2_Ordinaria_Lucas_Sanz.View;
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

namespace Ejercicio2_Ordinaria_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_new_activity_Click(object sender, RoutedEventArgs e)
        {
            NewActivityWindow activitywindow = new NewActivityWindow();
            activitywindow.Show();
            if (activitywindow.isAceptedCheck()) {
                Activity activity = activitywindow.getActivity();
                dg_activities.Items.Add(activity);
            }
        }

        private void btn_new_partner_Click(object sender, RoutedEventArgs e)
        {
            NewPartnerWindow partnerwindow = new NewPartnerWindow();
            partnerwindow.Show();
            if (partnerwindow.isAceptedCheck())
            {
                Partner partner = partnerwindow.getPartner();
                dg_partners.Items.Add(partner);
            }
        }
    }
}
