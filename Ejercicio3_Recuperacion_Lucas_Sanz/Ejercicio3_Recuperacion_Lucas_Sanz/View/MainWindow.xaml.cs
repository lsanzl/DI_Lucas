using Ejercicio3_Recuperacion_Lucas_Sanz.Model;
using Ejercicio3_Recuperacion_Lucas_Sanz.Persistence.Manage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio3_Recuperacion_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime fechaActual;
        public DateTime fechaActualEst;
        public int sesionActual;
        public ManagerEntrada managerAux;
        public List<Entrada> listaEntradasAux;
        public Boolean edadValida;
        public int precioActual;
        public ManagerSesion managerSAux;

        public MainWindow()
        {
            InitializeComponent();
            managerAux = new ManagerEntrada();
            managerSAux = new ManagerSesion();
            listaEntradasAux = new List<Entrada>();
            btn_comprar.IsEnabled = false;
            sesionActual = -1;
            edadValida = false;
            precioActual = 0;

            List<string> meses = new List<string>(){"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio","Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
            cb_mes.ItemsSource = meses;
            for (int i = 2000; i < 2031; i++)
            {
                cb_año.Items.Add(i);
            }
        }

        private void selected_date(object sender, SelectionChangedEventArgs e)
        {
            if (dp_fecha.SelectedDate == null)
            {
                return;
            }

            cb_sesiones.Items.Clear();
            listaEntradasAux.Clear();
            fechaActual = dp_fecha.SelectedDate.Value;

            cb_sesiones.Items.Add(1);

            if (fechaActual.DayOfWeek == DayOfWeek.Saturday || fechaActual.DayOfWeek == DayOfWeek.Sunday)
            {
                cb_sesiones.Items.Add(2);
            }

            if (fechaActual != null && sesionActual != -1)
            {
                listaEntradasAux = managerAux.getEntradas(fechaActual.ToString("yyyy-MM-dd"), sesionActual);
                if (listaEntradasAux.Count == 30)
                {
                    lbl_disponibilidad.Content = "NO DISPONIBLE";
                    btn_comprar.IsEnabled = false;
                }
                else
                {
                    lbl_disponibilidad.Content = "DISPONIBLE";
                    btn_comprar.IsEnabled = true;
                }
            }
        }

        private void selected_sesion(object sender, SelectionChangedEventArgs e)
        {
            listaEntradasAux.Clear();
            sesionActual = Convert.ToInt32(cb_sesiones.SelectedValue);
            if (fechaActual != null && sesionActual != -1)
            {
                listaEntradasAux = managerAux.getEntradas(fechaActual.ToString("yyyy-MM-dd"), sesionActual);
                if (listaEntradasAux.Count == 30)
                {
                    lbl_disponibilidad.Content = "NO DISPONIBLE";
                    btn_comprar.IsEnabled = false;
                }
                else
                {
                    lbl_disponibilidad.Content = "DISPONIBLE";
                    btn_comprar.IsEnabled = true;
                }
            }
        }

        private void changed_text_edad(object sender, TextChangedEventArgs e)
        {
            edadValida = true;
            precioActual = 0;

            if (string.IsNullOrEmpty(txt_edad.Text) || !(int.TryParse(txt_edad.Text, out int valor)))
            {
                lbl_precio.Content = "";
                edadValida = false;
                return;
            }

            int edad = Convert.ToInt32(txt_edad.Text);

            if (edad < 0)
            {
                lbl_precio.Content = "Edad incorrecta";
                edadValida = false;
                return;
            }
            else if (edad >= 0 && edad < 4)
            {
                lbl_precio.Content = "Precio: 0€";
                return;
            }
            else if (edad >= 4 && edad < 8)
            {
                lbl_precio.Content = "Precio: 4€";
                precioActual = 4;
                return;
            }
            else if (edad >= 8 && edad < 65)
            {
                lbl_precio.Content = "Precio: 10€";
                precioActual = 10;
                return;
            }
            else if (edad >= 65)
            {
                lbl_precio.Content = "Precio: 3€";
                precioActual = 3;
                return;
            }
        }

        private void click_comprar(object sender, RoutedEventArgs e)
        {
            if (!edadValida)
            {
                MessageBox.Show("Edad incorrecta", "Error");
                return;
            }
            int edadActual = Convert.ToInt32(txt_edad.Text);

            Entrada entrada = new Entrada(fechaActual.ToString("yyyy-MM-dd"), sesionActual, edadActual, precioActual);
            entrada.insertarEntrada();

            dp_fecha.SelectedDate = null;
            cb_sesiones.Items.Clear();
            txt_edad.Clear();
            lbl_disponibilidad.Content = "";
            lbl_precio.Content = "";
            btn_comprar.IsEnabled = false;
        }

        private void click_mostrar(object sender, RoutedEventArgs e)
        {
            if (dp_fecha_estadistica.SelectedDate == null || cb_sesion_estadistica.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione fecha y sesión", "Error de datos");
                return;
            }

            txt_datos.Clear();
            string fechaDatos = dp_fecha_estadistica.SelectedDate.Value.ToString("yyyy-MM-dd");
            int sesionDatos = Convert.ToInt32(cb_sesion_estadistica.SelectedValue);

            if (!managerSAux.checkFuncion(fechaDatos, sesionDatos))
            {
                txt_datos.Text = "Sin datos de la función";
                return;
            }

            string edadMedia = managerSAux.getEdadMedia(fechaDatos, sesionDatos);
            int totalRecaudado = managerSAux.getTotalRecaudado(fechaDatos, sesionDatos);
            List<int> edades = managerSAux.getEdadesFranja(fechaDatos, sesionDatos);

            string datosCompletos = $"Edad media asistentes: {edadMedia}\r\nTotal recaudado: {totalRecaudado}\r\nAsistentes de 0 a 4 años: {edades[0]}\r\nAsistentes de 4 a 8 años: {edades[1]}\r\nAsistentes de 8 a 65 años: {edades[2]}\r\nAsistentes mayores de 65 años: {edades[3]}";
            txt_datos.Text = datosCompletos;
        }

        private void change_fecha_estadistica(object sender, SelectionChangedEventArgs e)
        {
            if (dp_fecha_estadistica.SelectedDate == null)
            {
                return;
            }

            cb_sesion_estadistica.Items.Clear();
            fechaActualEst = dp_fecha_estadistica.SelectedDate.Value;

            cb_sesion_estadistica.Items.Add(1);

            if (fechaActualEst.DayOfWeek == DayOfWeek.Saturday || fechaActualEst.DayOfWeek == DayOfWeek.Sunday)
            {
                cb_sesion_estadistica.Items.Add(2);
            }
        }

        private void click_recaudacion(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
