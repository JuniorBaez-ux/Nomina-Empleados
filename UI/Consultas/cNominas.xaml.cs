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
    /// Interaction logic for cNominas.xaml
    /// </summary>
    public partial class cNominas : Window
    {
        public cNominas()
        {
            InitializeComponent();
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Nominas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = NominasBLL.GetList(e => e.NominaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = NominasBLL.GetList(e => e.EmpleadoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = NominasBLL.GetList(e => e.SalarioMensual == int.Parse(CriterioTextBox.Text));
                        break;
                    case 3:
                        listado = NominasBLL.GetList(e => e.HorasExtra == int.Parse(CriterioTextBox.Text));
                        break;
                    case 4:
                        listado = NominasBLL.GetList(e => e.AFP == int.Parse(CriterioTextBox.Text));
                        break;
                    case 5:
                        listado = NominasBLL.GetList(e => e.SFS == int.Parse(CriterioTextBox.Text));
                        break;
                    case 6:
                        listado = NominasBLL.GetList(e => e.ISR == int.Parse(CriterioTextBox.Text));
                        break;

                }
            }
            else
            {
                listado = NominasBLL.GetList(c => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
