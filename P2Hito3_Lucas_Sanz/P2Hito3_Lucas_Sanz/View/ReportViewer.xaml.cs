using P2Hito3_Lucas_Sanz.Report;
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
using System.Windows.Shapes;

namespace P2Hito3_Lucas_Sanz.View
{
    /// <summary>
    /// Lógica de interacción para ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        public void ShowReporter()
        {
            this.Show();
        }
        public void showReport(Informe_1 informe)
        {
            cr_viewer.ViewerCore.ReportSource = informe;
        }
        public void showReport(Informe_2 informe2)
        {
            cr_viewer.ViewerCore.ReportSource = informe2;
        }
    }
}
