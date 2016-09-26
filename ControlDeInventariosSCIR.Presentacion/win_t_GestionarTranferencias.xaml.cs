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
    /// Interaction logic for win_t_GestionarTranferencias.xaml
    /// </summary>
    public partial class win_t_GestionarTranferencias : Window
    {
        public win_t_GestionarTranferencias()
        {
            InitializeComponent();
        }
          private void gestionTransferecia(object sender, RoutedEventArgs e)
        {
            t_transferencia trans = new t_transferencia();
            t_transferencia_BLL transfer = new t_transferencia_BLL();
            var returno = transfer.Gestion(trans);
            gtransfer.ItemsSource = (IEnumerable < t_transferencia >) returno;

        }

          private void Button_Click(object sender, RoutedEventArgs e)
          {
              win_t_InsertarTransferencias win = new win_t_InsertarTransferencias();
              win.Show();
          }

          private void gtransfer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
          {
              int ids = 0;
              object item = gtransfer.SelectedItem;
              string id = (gtransfer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

              ids = Int32.Parse(id);

              win_t_EditarTransferencias edittrans = new win_t_EditarTransferencias(ids);
              edittrans.Show();
          }

          private void salir_Click(object sender, RoutedEventArgs e)
          {
              this.Close();
          }

          private void bteliminar(object sender, RoutedEventArgs e)
          {
             /*  object item = materiaprima.SelectedItem;
              string id = (materiaprima.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
              int ids = Int32.Parse(id);
              //  var remover=scir.sp_mp_select_where_MateriaPrimaPorID(ids);
              var remover = scir.mp_materiaPrima.Where(w => w.mp_id == ids).FirstOrDefault();

              MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
              if (result.ToString() == "Yes")
              {
                  scir.mp_materiaPrima.Remove(remover);
                  scir.SaveChanges();

                  materiaprima.ItemsSource = scir.mp_materiaPrima.ToList();
                  // materiaprima.Items.Refresh();
                  MessageBox.Show("Registro eliminado");

              }*/

          }
    }
}
