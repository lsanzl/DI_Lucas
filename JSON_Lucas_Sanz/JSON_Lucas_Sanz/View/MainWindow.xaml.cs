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
        private Consumer c;
        private Product p;
        private JSONConsumer jc;
        private JSONProduct jp;
        private List<Consumer> list_consumer;
        private List<Product> list_product;
        public MainWindow()
        {
            c = new Consumer(10, "Lucas", 26);
            c.ConsumerToJson();
            c = new Consumer(8, "Lourdes", 25);
            c.ConsumerToJson();
            
            jc = new JSONConsumer();
            InitializeComponent();
            initializeDG();
        }
        public void initializeDG()
        {
            dg_consumers.Items.Clear();
            dg_products.Items.Clear();
            dg_products2.Items.Clear();
            
            list_consumer = jc.ReadConsumerJson();
            foreach (Consumer caux in list_consumer)
            {
                dg_consumers.Items.Add(caux);
            }
        }
    }
}