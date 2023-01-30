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

namespace Recuperacion2_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void click_btn_show(object sender, RoutedEventArgs e)
        {
            if (txt_a.Text.Trim().Length == 0 || txt_b.Text.Trim().Length == 0 || txt_fila_final.Text.Trim().Length == 0 || txt_columna_final.Text.Trim().Length == 0 || txt_tamaño.Text.Trim().Length == 0)
            {
                MessageBox.Show("Introduzca todos los datos");
                return;
            }

            int n_filas = Convert.ToInt32(txt_a.Text.Trim());
            int n_columnas = Convert.ToInt32(txt_b.Text.Trim());
            int tamaño_serpiente = Convert.ToInt32(txt_tamaño.Text.Trim());
            int fila_final = Convert.ToInt32(txt_fila_final.Text.Trim());
            int columna_final = Convert.ToInt32(txt_columna_final.Text.Trim());

            int[,] cuadrante = new int[n_filas, n_columnas];

            if (!checkTamaño(tamaño_serpiente, cuadrante, fila_final, columna_final)){
                MessageBox.Show("Tamaño incorrecto");
                txt_tamaño.Clear();
                return;
            }

            cuadrante = crearCuadrante(cuadrante, fila_final, columna_final, tamaño_serpiente);
            new VentanaSerpiente(cuadrante).Show();
        }
        public int calcularAsterisco(int[,] cuadrante_actual, int fila_final, int columna_final)
        {
            Boolean impar = false;
            int contador = 0;
            for (int i = 0; i < cuadrante_actual.GetLength(0) && i <= fila_final; i++)
            {
                if (!impar)
                {
                    for (int j = 0; j < cuadrante_actual.GetLength(1); j++)
                    {
                        contador++;
                        if (i == fila_final && j == columna_final)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = cuadrante_actual.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (i == fila_final && j == columna_final)
                        {
                            break;
                        }
                        contador++;
                    }
                }
                impar = !impar;
            }
            return contador;
        }
        public Boolean checkTamaño(int N, int[,] cuadrante_actual, int fila_final, int columna_final)
        {
            int tamaño = calcularAsterisco(cuadrante_actual, fila_final, columna_final);
            if (tamaño < N)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int[,] crearCuadrante(int[,] cuadrante_actual, int fila_final, int columna_final, int tamaño_serpiente)
        {
            int contador_estela = calcularAsterisco(cuadrante_actual, fila_final, columna_final) - tamaño_serpiente;
            int contador = 0;
            Boolean impar = false;
            for (int i = 0; i < cuadrante_actual.GetLength(0); i++)
            {
                for (int j = 0; j < cuadrante_actual.GetLength(1); j++)
                {
                    cuadrante_actual[i, j] = 0;
                }
            }

            for (int i = 0; i < cuadrante_actual.GetLength(0) && i <= fila_final; i++)
            {
                if (!impar)
                {
                    for (int j = 0; j < cuadrante_actual.GetLength(1); j++)
                    {
                        if (i == fila_final && j == columna_final)
                        {
                            cuadrante_actual[i, j] = 3;
                            break;
                        }
                        if (contador <= contador_estela)
                        {
                            cuadrante_actual[i, j] = 1;
                        }
                        else
                        {
                            cuadrante_actual[i, j] = 3;
                        }
                        contador++;
                    }
                }
                else
                {
                    for (int j = cuadrante_actual.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (i == fila_final && j == columna_final)
                        {
                            cuadrante_actual[i, j] = 3;
                            break;
                        }
                        if (contador < contador_estela)
                        {
                            cuadrante_actual[i, j] = 2;
                        }
                        else
                        {
                            cuadrante_actual[i, j] = 3;
                        }
                        contador++;
                    }
                }
                impar = !impar;
            }
            return cuadrante_actual;

        }

    }
}
