using Nomina_Empleados_Leng.BLL;
using Nomina_Empleados_Leng.Entidades;
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

namespace Nomina_Empleados_Leng.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cEmpleados.xaml
    /// </summary>
    public partial class cEmpleados : Window
    {
        public cEmpleados()
        {
            InitializeComponent();
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Empleados>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = EmpleadosBLL.GetList(e => e.EmpleadoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = EmpleadosBLL.GetList(e => e.NombreCompleto.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 2:
                        listado = EmpleadosBLL.GetList(e => e.Telefono == int.Parse(CriterioTextBox.Text));
                        break;
                    case 3:
                        listado = EmpleadosBLL.GetList(e => e.Departamento.Contains(CriterioTextBox.Text));
                        break;
                    case 4:
                        listado = EmpleadosBLL.GetList(e => e.Puesto.Contains(CriterioTextBox.Text));
                        break;

                }
            }
            else
            {
                listado = EmpleadosBLL.GetList(c => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
