using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Model;
using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Persistence.Manager;
using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.Report;
using Extraordinario2_Ejercicio1_DI_Lucas_Sanz.View;
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

namespace Extraordinario2_Ejercicio1_DI_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Clase1> listaClase;
        public ManagerClase1 managerAux;

        public MainWindow()
        {
            InitializeComponent();
            managerAux = new ManagerClase1();
        }
        private void actualizarDG()
        {
            listaClase = managerAux.getList();

            dg_principal.Items.Clear();
            txt_campo1.Clear();
            txt_campo2.Clear();
            txt_campo3.Clear();

            foreach (Clase1 c in listaClase)
            {
                dg_principal.Items.Add(c);
            }
        }

        private void selected_dg(object sender, SelectionChangedEventArgs e)
        {
            if (dg_principal.SelectedIndex != -1)
            {
                btn_modificar.IsEnabled = true;
                btn_eliminar.IsEnabled = true;
                btn_informe.IsEnabled = true;

                Clase1 c = (Clase1)dg_principal.SelectedItem;

                txt_campo1.Text = c.parametro1;
                txt_campo2.Text = c.parametro2.ToString();
                txt_campo3.Text = c.parametro3.ToString();
            }
            else
            {
                btn_modificar.IsEnabled = false;
                btn_eliminar.IsEnabled = false;
                btn_informe.IsEnabled = false;

                txt_campo1.Clear();
                txt_campo2.Clear();
                txt_campo3.Clear();
            }
        }

        private void click_nuevo(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_campo1.Text) || string.IsNullOrEmpty(txt_campo2.Text) || string.IsNullOrEmpty(txt_campo3.Text))
            {
                MessageBox.Show("Faltan datos por rellenar");
                return;
            }

            Clase1 c = new Clase1(txt_campo1.Text, Convert.ToInt32(txt_campo2.Text), Convert.ToDouble(txt_campo3.Text));

            c.insertarClase1();
            actualizarDG();
        }

        private void click_modificar(object sender, RoutedEventArgs e)
        {
            string parametro1 = txt_campo1.Text;
            int parametro2 = Convert.ToInt32(txt_campo2.Text);
            double parametro3 = Convert.ToDouble(txt_campo3.Text);

            Clase1 c = new Clase1(parametro1, parametro2, parametro3);

            if (!managerAux.checkRegistro(c))
            {
                MessageBox.Show("No existe el registro");
                return;
            }
            c.modificarClase1();
            actualizarDG();
        }

        private void click_eliminar(object sender, RoutedEventArgs e)
        {
            Clase1 c = (Clase1)dg_principal.SelectedItem;
            c.eliminarClase1();
            actualizarDG();
        }

        private void click_informe(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable("DataTable1");

            dt.Columns.Add("Columna1");
            dt.Columns.Add("Columna2");
            dt.Columns.Add("Columna3");

            DataRow dr = dt.NewRow();

            foreach(Clase1 c in listaClase)
            {
                dr[0] = c.parametro1;
                dr[1] = c.parametro2;
                dr[2] = c.parametro3;

                dt.Rows.Add(dr);
            }

            Informe informe = new Informe();
            informe.Database.Tables["dt"].SetDataSource((DataTable)dt);
            ReportViewer rv = new ReportViewer();

            rv.reportViewer.ViewerCore.ReportSource = informe;
            rv.Show();
        }

        private void selected_dg_secundario(object sender, SelectionChangedEventArgs e)
        {
            if (dg_secundario.SelectedIndex != -1)
            {
                btn_modificar_modal.IsEnabled = true;
                btn_eliminar_modal.IsEnabled = true;

                Clase1 c = (Clase1)dg_secundario.SelectedItem;
            }
            else
            {
                btn_modificar_modal.IsEnabled = false;
                btn_eliminar_modal.IsEnabled = false;
            }
        }

        private void click_nuevo_modal(object sender, RoutedEventArgs e)
        {
            Modal modal = new Modal();
            modal.ShowDialog();

            if (modal.IsAccepted())
            {
                Clase1 c = modal.getClase();
                c.insertarClase1();
                actualizarDG();
            }
        }
    }
}