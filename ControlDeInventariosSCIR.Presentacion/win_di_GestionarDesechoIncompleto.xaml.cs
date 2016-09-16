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

namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Lógica de interacción para win_di_VerDesechoIncompleto.xaml
    /// </summary>
    public partial class win_di_GestionarDesechoIncompleto : Window
    {
        public win_di_GestionarDesechoIncompleto()
        {
            InitializeComponent();
        }

        private void btnNuevo_di_GestionarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            win_di_NuevoDesechoIncompleto win_di_N = new win_di_NuevoDesechoIncompleto();
            win_di_N.Show();
        }

        private void btnBuscar_di_DesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            //Actualmente permitirá ver la ventana de edición de datos
            win_di_EditarDesechoIncompleto win_di_E = new win_di_EditarDesechoIncompleto();
            win_di_E.Show();
        }
    }
}
