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

        public win_MenuPrincipal()
        {
            InitializeComponent();
        }

        public win_MenuPrincipal(BussinessEntities.usr_usuarios user)
        {
            // TODO: Complete member initialization
            this.user = user;
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}
