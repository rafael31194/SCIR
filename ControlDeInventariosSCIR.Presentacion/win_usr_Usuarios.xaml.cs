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
using ControlDeInventariosSCIR.BussinessEntities;

namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Interaction logic for win_usr_Usuarios.xaml
    /// </summary>
    public  partial class win_usr_Usuarios : Window
    {
        public win_usr_Usuarios()
        {
            InitializeComponent();
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            win_usr_NuevoUsuario nuevoUser = new win_usr_NuevoUsuario(this);
            nuevoUser.Show();
            cargarGrid();

           
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            win_MenuPrincipal menu = new win_MenuPrincipal();
            menu.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid();
           
        }


        public void cargarGrid()
        {
            ControlDeInventariosSCIR.Presentacion.DataSetConsultas dataSetConsultas =  ((ControlDeInventariosSCIR.Presentacion.DataSetConsultas)(this.FindResource("dataSetConsultas")));
            // Load data into the table usr_UsuariosGestionar. You can modify this code as needed.
            ControlDeInventariosSCIR.Presentacion.DataSetConsultasTableAdapters.usr_UsuariosGestionarTableAdapter dataSetConsultasusr_UsuariosGestionarTableAdapter = new ControlDeInventariosSCIR.Presentacion.DataSetConsultasTableAdapters.usr_UsuariosGestionarTableAdapter();
            dataSetConsultasusr_UsuariosGestionarTableAdapter.Fill(dataSetConsultas.usr_UsuariosGestionar);
            System.Windows.Data.CollectionViewSource usr_UsuariosGestionarViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usr_UsuariosGestionarViewSource")));
            usr_UsuariosGestionarViewSource.View.MoveCurrentToFirst();
        }

        private void usr_UsuariosGestionarDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            win_usr_NuevoUsuario nuevo = null ;
            usr_usuarios user = new usr_usuarios();

            try
            {
                foreach (DataRowView dr in usr_UsuariosGestionarDataGrid.Items)
                {

                    //entro a la linea que le di doble click
                    if (dr == usr_UsuariosGestionarDataGrid.SelectedItem)
                    {

                        user.usr_id = Convert.ToInt32(dr[0].ToString());
                        user.usr_nombre = dr[1].ToString();
                        user.usr_id_rol = Convert.ToInt32(dr[3].ToString());

                        nuevo = new win_usr_NuevoUsuario(this, user);
                        break;
                    }

                }
                nuevo.Show();
            }catch(Exception)
            {
                MessageBox.Show("Seleccione un usuario valido", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
    }
}
