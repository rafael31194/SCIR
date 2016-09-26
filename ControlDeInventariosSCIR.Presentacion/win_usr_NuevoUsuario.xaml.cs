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
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.BussinesLogic;
using System.Data;
using System.Data.SqlClient;


namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Interaction logic for win_usr_NuevoUsuario.xaml
    /// </summary>
    public partial class win_usr_NuevoUsuario : Window
    {
        private win_usr_Usuarios win_usr_Usuarios;
        private usr_usuarios user;


        
        public win_usr_NuevoUsuario()
        {
            InitializeComponent();
        }

        public win_usr_NuevoUsuario(win_usr_Usuarios win_usr_Usuarios)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.win_usr_Usuarios = win_usr_Usuarios;
            btnEliminar.Visibility = Visibility.Hidden;
        }

        public win_usr_NuevoUsuario(Presentacion.win_usr_Usuarios win_usr_Usuarios, usr_usuarios user)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.win_usr_Usuarios = win_usr_Usuarios;
            this.user = user;
            cbRoles.SelectedValue = user.usr_id_rol;
            txtUsuario.Text = user.usr_nombre;
            txtUsuario.IsEnabled = false;
            btnEliminar.Visibility = Visibility.Visible;
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ControlDeInventariosSCIR.Presentacion.DataSetConsultas dataSetConsultas = ((ControlDeInventariosSCIR.Presentacion.DataSetConsultas)(this.FindResource("dataSetConsultas")));
                // Load data into the table rol_roles. You can modify this code as needed.
                ControlDeInventariosSCIR.Presentacion.DataSetConsultasTableAdapters.rol_rolesTableAdapter dataSetConsultasrol_rolesTableAdapter = new ControlDeInventariosSCIR.Presentacion.DataSetConsultasTableAdapters.rol_rolesTableAdapter();
                dataSetConsultasrol_rolesTableAdapter.Fill(dataSetConsultas.rol_roles);
                System.Windows.Data.CollectionViewSource rol_rolesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("rol_rolesViewSource")));
                rol_rolesViewSource.View.MoveCurrentToFirst();
                cbRoles.SelectedValue = user.usr_id_rol;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.win_usr_Usuarios.cargarGrid();
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (user == null)
            {

                if (!(string.IsNullOrWhiteSpace(txtPassword.Password) | string.IsNullOrWhiteSpace(txtPasswordConfirm.Password)))
                {
                    if (txtPassword.Password == txtPasswordConfirm.Password)
                    {
                    

                            usr_usuarios usuario = new usr_usuarios();
                            usuario.usr_id_rol = (int)cbRoles.SelectedValue;
                            usuario.usr_nombre = (txtUsuario.Text).Replace("\r\n","");
                            usuario.usr_password = txtPassword.Password;
                            if (usr_UsuariosBLL.agregarUsuario(usuario))
                            {
                                MessageBox.Show("Nuevo usuario guardado con Exito", "NUEVO USUARIO", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("Error al guardar Usuario");
                            }

                            limpiarCampos();
                            this.Close();


                        }
                        else
                        {

                            MessageBox.Show("Las contraseñas no coinciden\n Verifique su contraseña", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    else
                    {


                        MessageBox.Show("Las contraseñas no debe estar vacías\n Verifique su contraseña", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

            }
            else
            {
                modificarUsuario();
            }
            
        }

        private void modificarUsuario()
        {
            if (!(string.IsNullOrWhiteSpace(txtPassword.Password) | string.IsNullOrWhiteSpace(txtPasswordConfirm.Password)))
            {
                if (txtPassword.Password == txtPasswordConfirm.Password)
                {
                    user.usr_password = txtPassword.Password;
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden\n Verifique su contraseña", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            
            user.usr_id_rol = (int)cbRoles.SelectedValue;
            if (usr_UsuariosBLL.modificarUsuario(user))
            {
                MessageBox.Show("El usuario ha sido actualizado con Exito", "USUARIO MODIFICADO", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.win_usr_Usuarios.cargarGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar Usuario");
                this.Close();
            }
        }

        public  void limpiarCampos()
        {
            txtPassword.Password = string.Empty;
            txtPasswordConfirm.Password = string.Empty;
            txtUsuario.Text = string.Empty;
            this.win_usr_Usuarios.cargarGrid();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                try
                {
                    if (usr_UsuariosBLL.eliminarUsuario(user))
                    {
                        MessageBox.Show("El usuario ha sido eliminado con Exito", "USUARIO ELIMINADO", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        this.win_usr_Usuarios.cargarGrid();
                        this.Close();
                        
                    }
               
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    MessageBox.Show("El usuario no pudo ser eliminado", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
