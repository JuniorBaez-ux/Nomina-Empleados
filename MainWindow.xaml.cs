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
using Nomina_Empleados_Leng.UI.Registros;
using Nomina_Empleados_Leng.UI.Consultas;

namespace Nomina_Empleados_Leng
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

        private void Registro_Empleados_Click(object sender, RoutedEventArgs e)
        {
            rEmpleados rEmpleados = new rEmpleados();
            rEmpleados.Show();
        }

        private void Registro_Nominas_Click(object sender, RoutedEventArgs e)
        {
            rNominas rNominas = new rNominas();
            rNominas.Show();
        }

        private void Consulta_Empleados_Click(object sender, RoutedEventArgs e)
        {
            cEmpleados cEmpleados = new cEmpleados();
            cEmpleados.Show();
        }

        private void Consulta_Nominas_Click(object sender, RoutedEventArgs e)
        {
            cNominas cNominas = new cNominas();
            cNominas.Show();
        }
    }
}
