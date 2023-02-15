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
using JSON_Lucas_Sanz.Model;
using JSON_Lucas_Sanz.Persistence;

namespace JSON_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Costumer c1 = new Costumer(10, "Lucas", 26);
            Costumer c2 = new Costumer(8, "Lourdes", 25);

            JSONCostumer jc = new JSONCostumer();

            Costumer crr = jc.ReadCostumerJson();
            dg_costumers.Items.Add(crr);
        }
    }
}