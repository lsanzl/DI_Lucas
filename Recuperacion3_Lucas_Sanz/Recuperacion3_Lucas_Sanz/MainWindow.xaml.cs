using Recuperacion3_Lucas_Sanz.Model;
using Recuperacion3_Lucas_Sanz.Persistence;
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

namespace Recuperacion3_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Empleado> listadeempleados;
        public MainWindow()
        {
            InitializeComponent();
            iniciarEmpleadosDG();
        }
        private void iniciarEmpleadosDG()
        {
            iniciarListaEmpleados();
            dg_datos.Items.Clear();
            foreach (Empleado emple in listadeempleados)
            {
                dg_datos.Items.Add(emple);
            }
        }
        private void iniciarListaEmpleados()
        {
            Empleado empleado = new Empleado();
            empleado.readAll();
            listadeempleados = empleado.getList();
        }

        private void click_btn_añadir(object sender, RoutedEventArgs e)
        {
            List<Object> emplenum = DBBroker.getAgent().readSQL("select max(id) from empleadosfaunia");
            int id = 1;
            try
            {
                foreach (List<Object> emple in emplenum)
                {
                    id = (Convert.ToInt32(emple[0]) + 1);
                }
            }
            catch (FormatException)
            {
                id = 1;
            }

            string nif = txt_nif.Text;
            string nombre = txt_nombre.Text;
            string apellidos = txt_apellidos.Text;
            int edad = Convert.ToInt32(txt_edad.Text);
            String sql = $"insert into recuperacion_db.empleadosfaunia values('{id}', '{nif}', '{nombre}', '{apellidos}', '{edad}');";
            DBBroker.getAgent().executeSQL(sql);
            iniciarEmpleadosDG();
            txt_nif.Clear();
            txt_nombre.Clear();
            txt_apellidos.Clear();
            txt_edad.Clear();
        }

        private void click_btn_eliminar(object sender, RoutedEventArgs e)
        {
            int index = dg_datos.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            Empleado empleelegido = listadeempleados[index];
            listadeempleados.RemoveAt(index);

            String sql = $"delete from recuperacion_db.empleadosfaunia where id='{empleelegido.id}'";
            DBBroker.getAgent().executeSQL(sql);
            iniciarEmpleadosDG();
        }

        private void click_btn_modificar(object sender, RoutedEventArgs e)
        {
            int index = dg_datos.SelectedIndex;
            if (index == -1)
            {
                return;
            }

            Empleado empleelegido = listadeempleados[index];

            string nif = txt_nif.Text.Trim();
            string nombre = txt_nombre.Text.Trim();
            string apellidos = txt_apellidos.Text.Trim();
            int edad = Convert.ToInt32(txt_edad.Text.Trim());
            String sql = $"update recuperacion_db.empleadosfaunia set nif='{nif}', nombre='{nombre}', apellidos='{apellidos}', edad='{edad}' where id='{empleelegido.id}';";
            DBBroker.getAgent().executeSQL(sql);

            iniciarEmpleadosDG();
            txt_nif.Clear();
            txt_nombre.Clear();
            txt_apellidos.Clear();
            txt_edad.Clear();
        }
    }
}
