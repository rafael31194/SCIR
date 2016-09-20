using ControlDeInventariosSCIR.BussinesLogic;
using ControlDeInventariosSCIR.BussinessEntities;
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
    /// Interaction logic for win_t_EditarTransferencias.xaml
    /// </summary>
    public partial class win_t_EditarTransferencias : Window
    {
        int idx;
        public win_t_EditarTransferencias(int id)
        {
            InitializeComponent();
            idx = id;
        }
        private void CargarTrans(object sender, RoutedEventArgs e)
        {
            t_transferencia trans= new t_transferencia();
            trans.t_id = idx;
            t_transferencia_BLL tedit = new t_transferencia_BLL();
            var retorno = tedit.Editar(trans);

            if (retorno != null)
            {
                fechadate.SelectedDate = retorno.t_fecha;
                cbx_tipo.SelectedIndex = retorno.t_tipo-1;
                txt_descripcion.Text = retorno.t_descripcion;
                   }
            else
            {
                MessageBox.Show("No hay datos de ese registro");
            }

         
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private void btnCancelar_Transferencia_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
