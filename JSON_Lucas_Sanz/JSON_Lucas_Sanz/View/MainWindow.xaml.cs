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
        private List<Consumer> list_consumer;
        private List<Product> list_product;
        public MainWindow()
        {
            list_product = new List<Product>();
            jc = new JSONConsumer();

            InitializeComponent();
            initializeDG();
        }
        /// <summary>
        /// Method to update DataGrid View of consumers
        /// </summary>
        public void initializeDG()
        {
            dg_consumers.Items.Clear();
            dg_products.Items.Clear();
            dg_products2.Items.Clear();

            txt_id.Clear();
            txt_name.Clear();
            txt_age.Clear();
            
            list_consumer = jc.ReadConsumerJson();
            foreach (Consumer caux in list_consumer)
            {
                dg_consumers.Items.Add(caux);
            }
        }
        /// <summary>
        /// Method to update DataGrid View of products from a consumer list
        /// </summary>
        public void updateProducts()
        {
            txt_product_name.Clear();
            txt_price.Clear();
            dg_products.Items.Clear();

            foreach(Product paux in list_product)
            {
                dg_products.Items.Add(paux);
            }
        }
        /// <summary>
        /// Method to add created product to consumer list and show it into DataGrid
        /// It checks all fields are not empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_add_product(object sender, RoutedEventArgs e)
        {
            if (txt_product_name.Text.Length == 0 || txt_price.Text.Length == 0)
            {
                MessageBox.Show("Introduzca todos los datos del producto");
                return;
            }
            p = new Product(txt_product_name.Text, Convert.ToInt32(txt_price.Text));
            list_product.Add(p);
            updateProducts();
        }
        /// <summary>
        /// Method to show list of products from a selected consumer
        /// It checks consumer is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_show(object sender, RoutedEventArgs e)
        {
            dg_products2.Items.Clear();

            if (dg_consumers.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente para mostrar productos");
                return;
            }
            c = (Consumer)dg_consumers.SelectedValue;
            foreach (Product paux in c.productos_cliente)
            {
                dg_products2.Items.Add(paux);
            }
            dg_consumers.SelectedIndex = -1;
        }
        /// <summary>
        /// Method to add Json file the new consumer with the product list included (it can be empty)
        /// It checks all fields are wroten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_btn_save(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text.Length == 0 || txt_name.Text.Length == 0 || txt_age.Text.Length == 0)
            {
                MessageBox.Show("Rellene todos los datos para crear cliente");
                return;
            }
            c = new Consumer(Convert.ToInt32(txt_id.Text), txt_name.Text, Convert.ToInt32(txt_age.Text));
            if (list_product.Any())
            {
                foreach (Product p in list_product)
                {
                    c.productos_cliente.Add(p);
                }
            }
            c.ConsumerJson();
            list_product = new List<Product>();
            initializeDG();
        }
    }
}