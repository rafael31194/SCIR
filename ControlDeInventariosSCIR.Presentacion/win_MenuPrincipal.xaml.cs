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
    /// Interaction logic for win_MenuPrincipal.xaml
    /// </summary>
    public partial class win_MenuPrincipal : Window
    {
        private BussinessEntities.usr_usuarios user;

        public static win_MenuPrincipal menu;

        public win_MenuPrincipal()
        {
            InitializeComponent();
            menu = this;
        }

        public win_MenuPrincipal(BussinessEntities.usr_usuarios user)
        {
            // TODO: Complete member initialization
            this.user = user;
            InitializeComponent();
            //Codigo para ocultar los botones
            switch (this.user.usr_id_rol)
            {
                case 1:
                    break;
                case 2:
                    btnDesechos.Visibility = Visibility.Hidden;
                    btnMateriaPrima.Visibility = Visibility.Hidden;
                    btnUsuarios.Visibility = Visibility.Hidden;
                    
                    break;
                case 3:
                    btnCompras.Visibility = Visibility.Hidden;
                    btnTransferencias.Visibility = Visibility.Hidden;
                    btnUsuarios.Visibility = Visibility.Hidden;
                    break;

            }

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            win_usr_Usuarios users = new win_usr_Usuarios();
            users.Show();
            this.Close();
        }

        private void btnTransferencias_Click(object sender, RoutedEventArgs e)
        {
            win_t_GestionarTranferencias trans = new win_t_GestionarTranferencias();
            trans.Show();
            this.Close();

        }

        private void btnDesechos_Click(object sender, RoutedEventArgs e)
        {
            win_di_GestionarDesechoIncompleto dese = new win_di_GestionarDesechoIncompleto();
            dese.Show();
            this.Close();
        }

        private void btnMateriaPrima_Click(object sender, RoutedEventArgs e)

        {
            win_materiaprima mat = new win_materiaprima();
            mat.Show();
            this.Close();

        }
    }
}
