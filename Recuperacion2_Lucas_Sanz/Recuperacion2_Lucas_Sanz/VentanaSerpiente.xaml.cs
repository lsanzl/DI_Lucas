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
using System.Windows.Shapes;

namespace Recuperacion2_Lucas_Sanz
{
    /// <summary>
    /// Lógica de interacción para VentanaSerpiente.xaml
    /// </summary>
    public partial class VentanaSerpiente : Window
    {
        public VentanaSerpiente(int[,] cuadrante)
        {
            InitializeComponent();
            grid_serpiente.RowDefinitions.Clear();
            grid_serpiente.ColumnDefinitions.Clear();

            for (int i=0; i<cuadrante.GetLength(0); i++)
            {
                grid_serpiente.RowDefinitions.Add(new RowDefinition());
                grid_serpiente.ColumnDefinitions.Add(new ColumnDefinition());
                /*for (int j=0; j<cuadrante.GetLength(1); j++)
                {
                    grid_serpiente.ColumnDefinitions.Add(new ColumnDefinition());
                }*/
            }
            for (int i = 0; i < cuadrante.GetLength(0); i++)
            {
                for (int j = 0; j < cuadrante.GetLength(1); j++)
                {
                    Label lbl = new Label();
                    lbl.Width = 30;
                    lbl.Height = 30;

                    if (cuadrante[i, j] == 0)
                    {
                        lbl.Content = " ";
                    }
                    else if (cuadrante[i, j] == 1)
                    {
                        lbl.Content = ">";
                    }
                    else if (cuadrante[i, j] == 2)
                    {
                        lbl.Content = "<";
                    }
                    else
                    {
                        lbl.Content = "*";
                    }

                    StackPanel sps = new StackPanel();
                    sps.Children.Add(lbl);
                    grid_serpiente.Children.Add(sps);
                    Grid.SetRow(sps, i);
                    Grid.SetColumn(sps, j);
                }
            }
        }
    }
}
