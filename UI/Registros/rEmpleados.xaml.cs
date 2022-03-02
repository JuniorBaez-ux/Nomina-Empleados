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

namespace Nomina_Empleados_Leng.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEmpleados.xaml
    /// </summary>
    public partial class rEmpleados : Window
    {
        private Empleados empleados = new Empleados();
        public rEmpleados()
        {
            InitializeComponent();
            this.DataContext = empleados;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            Empleados encontrado = EmpleadosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (encontrado != null)
            {
                this.empleados = encontrado;
                Cargar();
            }
            else
            {
                this.empleados = new Empleados();
                this.DataContext = this.empleados;

                MessageBox.Show($"Este Contacto no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

                Limpiar();
                IdTextBox.SelectAll();
                IdTextBox.Focus();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                if (IdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Contacto Id) está vacío.\n\nPorfavor, Asigne un Id al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    IdTextBox.Text = "0";
                    IdTextBox.Focus();
                    IdTextBox.SelectAll();
                    return;
                }
                if (NombreTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Completo) está vacío.\n\nPorfavor, Asigne un Nombre al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreTextBox.Clear();
                    NombreTextBox.Focus();
                    return;
                }
                if (TelefonoTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Teléfono) está vacío.\n\nAsigne un Teléfono al Empleado.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TelefonoTextBox.Text = "0";
                    TelefonoTextBox.Focus();
                    TelefonoTextBox.SelectAll();
                    return;
                }
                if (TelefonoTextBox.Text.Length != 10)
                {
                    MessageBox.Show($"El Teféfono ({TelefonoTextBox.Text}) no es válido.\n\nEl Teléfono debe tener 10 dígitos (0-9).", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TelefonoTextBox.Focus();
                    return;
                }
                var paso = EmpleadosBLL.Guardar(empleados);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("El Registro se guardo satisfactoriamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("El Registro no se pudo guardar :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (EmpleadosBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = empleados;
        }
        private void Limpiar()
        {
            this.empleados = new Empleados();
            this.DataContext = empleados;
        }
        private bool Validar()
        {
            bool Validado = true;
            if (IdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida\n\nNo se pudo validar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
    }
}
