using GuardaMuebles_Lucas_Sanz.Model;
using GuardaMuebles_Lucas_Sanz.Persistence.Manager;
using GuardaMuebles_Lucas_Sanz.Report;
using GuardaMuebles_Lucas_Sanz.View;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace GuardaMuebles_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ManagerGuardamueble managerG;
        public ManagerCliente managerC;
        public ManagerContrataciones managerCont;
        public List<Guardamueble> listaGuardamuebles;
        public List<Cliente> listaClientes;
        public List<Contratacion> listaContrataciones;

        public MainWindow()
        {
            InitializeComponent();
            managerG = new ManagerGuardamueble();
            managerC = new ManagerCliente();
            managerCont = new ManagerContrataciones();

            actualizarDG();
        }

        // --------------- GENÉRICOS ------------------

        public void actualizarDG()
        {
            listaGuardamuebles = managerG.getGuardamueble();
            listaClientes = managerC.getClientes();
            listaContrataciones = managerCont.getContrataciones();

            dg_clientes.Items.Clear();
            dg_guardamuebles.Items.Clear();
            dg_contrataciones.Items.Clear();
            cb_clientes.Items.Clear();
            cb_guardamuebles.Items.Clear();

            foreach (Guardamueble g in listaGuardamuebles)
            {
                dg_guardamuebles.Items.Add(g);
                cb_guardamuebles.Items.Add(g.codigo);
            }
            foreach (Cliente c in listaClientes)
            {
                dg_clientes.Items.Add(c);
                cb_clientes.Items.Add(c.DNI);
            }
            foreach(Contratacion cont in listaContrataciones)
            {
                dg_contrataciones.Items.Add(cont);
            }
        }
        public Boolean checkCodigo(string codigo, Boolean opcion)
        {
            if (opcion)
            {
                return managerG.checkCodigo(codigo);
            }
            else
            {
                return managerC.checkCodigo(codigo);
            }
        }

        // --------------- GUARDAMUEBLES ------------------

        private void click_nuevo_guardamuebles(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_codigo.Text) || string.IsNullOrEmpty(txt_tamaño.Text) || string.IsNullOrEmpty(txt_precio.Text))
            {
                MessageBox.Show("Faltan datos");
                return;
            }
            if (checkCodigo(txt_codigo.Text, true))
            {
                MessageBox.Show("Ya existe dicho código");
                return;
            }

            string precio = txt_precio.Text;
            precio = precio.Replace(",", ".");

            Guardamueble g = new Guardamueble(txt_codigo.Text, Convert.ToInt32(txt_tamaño.Text), Convert.ToDouble(precio));
            g.insertarGuardamueble();
            listaGuardamuebles.Add(g);

            txt_codigo.Clear();
            txt_tamaño.Clear();
            txt_precio.Clear();

            actualizarDG();
        }  
        private void click_eliminar_guardamueble(object sender, RoutedEventArgs e)
        {
            Guardamueble g = (Guardamueble)dg_guardamuebles.SelectedValue;
            g.eliminarGuardamueble();
            listaGuardamuebles.Remove(g);
            actualizarDG();
        }
        private void selected_dg_guardamueble(object sender, SelectionChangedEventArgs e)
        {
            if (dg_guardamuebles.SelectedIndex != -1)
            {
                btn_eliminar_guardamuebles.IsEnabled = true;
                btn_modificar_guardamuebles.IsEnabled = true;
                Guardamueble g = (Guardamueble)dg_guardamuebles.SelectedValue;
                txt_codigo.Text = g.codigo.ToString();
                txt_tamaño.Text = g.tamaño.ToString();
                txt_precio.Text = g.precio.ToString();
            }
            else
            {
                btn_eliminar_guardamuebles.IsEnabled = false;
                btn_modificar_guardamuebles.IsEnabled = false;
                txt_codigo.Clear();
                txt_tamaño.Clear();
                txt_precio.Clear();
            }
        }
        private void click_modificar_guardamueble(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_codigo.Text) || string.IsNullOrEmpty(txt_tamaño.Text) || string.IsNullOrEmpty(txt_precio.Text))
            {
                MessageBox.Show("Faltan datos");
                return;
            }
            if (!checkCodigo(txt_codigo.Text, true))
            {
                MessageBox.Show("No existe dicho guardamueble");
                return;
            }

            Guardamueble gOld = (Guardamueble)dg_guardamuebles.SelectedValue;
            listaGuardamuebles.Remove(gOld);

            string precio = txt_precio.Text;
            precio = precio.Replace(",", ".");

            Guardamueble g = new Guardamueble(txt_codigo.Text, Convert.ToInt32(txt_tamaño.Text), Convert.ToDouble(precio));
            g.modificarGuardamueble();
            listaGuardamuebles.Add(g);

            txt_codigo.Clear();
            txt_tamaño.Clear();
            txt_precio.Clear();

            actualizarDG();
        }

        // --------------- CLIENTES ------------------

        private void click_nuevo_cliente(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_dni.Text) || string.IsNullOrEmpty(txt_nombre.Text))
            {
                MessageBox.Show("Faltan datos");
                return;
            }
            if (checkCodigo(txt_dni.Text, false))
            {
                MessageBox.Show("Ya existe dicho cliente");
                return;
            }

            Cliente c = new Cliente(txt_dni.Text, txt_nombre.Text);
            c.insertarCliente();
            listaClientes.Add(c);

            txt_dni.Clear();
            txt_nombre.Clear();

            actualizarDG();
        }
        private void click_eliminar_cliente(object sender, RoutedEventArgs e)
        {
            Cliente c = (Cliente)dg_clientes.SelectedValue;
            c.eliminarCliente();
            listaClientes.Remove(c);
            actualizarDG();
        }
        private void click_modificar_cliente(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_dni.Text) || string.IsNullOrEmpty(txt_nombre.Text))
            {
                MessageBox.Show("Faltan datos");
                return;
            }
            if (!checkCodigo(txt_dni.Text, false))
            {
                MessageBox.Show("No existe dicho cliente");
                return;
            }
            Cliente cOld = (Cliente)dg_clientes.SelectedValue;
            listaClientes.Remove(cOld);

            Cliente c = new Cliente(txt_dni.Text, txt_nombre.Text);
            c.modificarCliente();
            listaClientes.Add(c);

            txt_dni.Clear();
            txt_nombre.Clear();

            actualizarDG();
        }
        private void selected_dg_clientes(object sender, SelectionChangedEventArgs e)
        {
            if (dg_clientes.SelectedIndex != -1)
            {
                btn_eliminar_cliente.IsEnabled = true;
                btn_modificar_cliente.IsEnabled = true;
                Cliente c = (Cliente)dg_clientes.SelectedValue;
                txt_dni.Text = c.DNI.ToString();
                txt_nombre.Text = c.nombre.ToString();
            }
            else
            {
                btn_eliminar_cliente.IsEnabled = false;
                btn_modificar_cliente.IsEnabled = false;
                txt_dni.Clear();
                txt_nombre.Clear();
            }
        }

        // --------------- CONTRATACIONES ------------------

        private void click_añadir_contratacion(object sender, RoutedEventArgs e)
        {
            if (cb_clientes.SelectedIndex == -1 || cb_guardamuebles.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione cliente y guardamueble");
                return;
            }
            if (string.IsNullOrEmpty(txt_meses.Text))
            {
                MessageBox.Show("Introduzca número de meses");
                return;
            }
            Guardamueble g = listaGuardamuebles.Find(Guardamueble => Guardamueble.codigo == cb_guardamuebles.SelectedItem.ToString());
            Cliente c = listaClientes.Find(Cliente => Cliente.DNI == cb_clientes.SelectedItem.ToString());

            Contratacion cont = new Contratacion(c.DNI, g.codigo, Convert.ToInt32(txt_meses.Text), g.precio);
            cont.insertarContratacion();

            txt_meses.Clear();
            actualizarDG();
        }
        private void click_quitar_cont(object sender, RoutedEventArgs e)
        {
            Contratacion cont = (Contratacion)dg_contrataciones.SelectedValue;
            cont.eliminarContratacion();
            btn_quitar.IsEnabled = false;

            actualizarDG();
        }
        private void selected_dg_contrataciones(object sender, SelectionChangedEventArgs e)
        {
            if (dg_contrataciones.SelectedIndex != -1)
            {
                btn_quitar.IsEnabled = true;
                btn_factura.IsEnabled = true;
            }
            else
            {
                btn_quitar.IsEnabled = false;
                btn_factura.IsEnabled = false;
            }
        }

        private void click_factura(object sender, RoutedEventArgs e)
        {
            Contratacion cont = (Contratacion)dg_contrataciones.SelectedValue;

            DataTable dt = cont.getDataTable();

            Informe factura = new Informe();
            factura.Database.Tables["Contrato"].SetDataSource((DataTable)dt);
            ViewerReport vr = new ViewerReport();

            vr.facturaviewer.ViewerCore.ReportSource = factura;
            vr.Show();
        }
    }
}