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
    /// Interaction logic for rNominas.xaml
    /// </summary>
    public partial class rNominas : Window
    {
        private Nominas nominas = new Nominas();
        public rNominas()
        {
            InitializeComponent();
            this.DataContext = nominas;
            //Llenando el combo box de empleados
            EmpleadoComboBox.ItemsSource = EmpleadosBLL.GetEmpleados();
            EmpleadoComboBox.SelectedValuePath = "EmpleadoId";
            EmpleadoComboBox.DisplayMemberPath = "NombreCompleto";
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            Nominas encontrado = NominasBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (encontrado != null)
            {
                this.DataContext = null;
                this.DataContext = encontrado;
            }
            else
            {
                this.nominas = new Nominas();
                this.DataContext = this.nominas;

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


                var paso = NominasBLL.Guardar(nominas);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("El Registro se pudo guardar satisfactoriamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("El Registro no se pudo guardar :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (NominasBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (IdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(IdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Contacto Id) debe ser un número.\n\nPor favor, digite un número valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                IdTextBox.Text = "0";
                IdTextBox.Focus();
                IdTextBox.SelectAll();
            }
        }

        private void SalarioMensualTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularSalario();
        }



        private void CalcularSalario()
        {
            if (SalarioMensualTextBox.Text == "0")
            {
                HorasExtraTextBox.IsEnabled = false;
            }
            else
            {
                HorasExtraTextBox.IsEnabled = true;
            }

            nominas.SalarioMensual = double.Parse(SalarioMensualTextBox.Text.ToString());
            nominas.SalarioMensual += nominas.HorasExtra * 200;




            //Formula del Seguro familiar de salud (SFS)
            double SFS = 0.0304;
            //Formulas de la Administradora de fondos de pensiones (AFP)
            double AFP = 0.0287;

            //Total SFS y AFP
            double T_SFS = (nominas.SalarioMensual * SFS);
            double T_AFP = (nominas.SalarioMensual * AFP);


            //Formulas del Impuesto sobre renta (ISR)
            //double DEDUC = T_SFS + T_AFP;
            // double RDEDUC = SM - DEDUC;
            // double IMPOx12 = RDEDUC * 12;
            //double EXCEDENT = IMPOx12 - 100 ;
            //double APLICA20 = EXCEDENT * 0.20;
            //double PASO_ADICC = APLICA20 + 31216;

            double T_ISR = nominas.SalarioMensual * 0.10;
            //624329.01

            //Total con Descuentos
            double T_Descuentos = (T_SFS + T_AFP + T_ISR);

            SFSTextBox.Text = Convert.ToString(Math.Round(T_SFS, 2));
            AFPTextBox.Text = Convert.ToString(Math.Round(T_AFP, 2));
            ISRTextBox.Text = Convert.ToString(Math.Round(T_ISR, 2));

            SueldoTotalTextBox.Text = Convert.ToString(Math.Round(nominas.SalarioMensual, 2));
            TotalDecuentosTextBox.Text = Convert.ToString(Math.Round(nominas.SalarioMensual - T_Descuentos, 2));
        }

        private void HorasExtraTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int HorasExtra = Convert.ToInt32(HorasExtraTextBox.Text);
            nominas.SalarioMensual += HorasExtra * 200;
            SalarioMensualTextBox.Text = nominas.SalarioMensual.ToString();
            CalcularSalario();

        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = nominas;
        }
        private void Limpiar()
        {
            this.nominas = new Nominas();
            this.DataContext = nominas;
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

        private void SalarioMensualTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
