using ControlDeInventariosSCIR.BussinesLogic;
using ControlDeInventariosSCIR.BussinessEntities;
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
            //scir = new SCIR_SistemaInventarioEntities();
            //gtransfer = scir.t_transferencia.ToList();

        }

          private void Button_Click(object sender, RoutedEventArgs e)
          {
              win_t_InsertarTransferencias win = new win_t_InsertarTransferencias();
              win.Show();
              this.Close();
          }

          private void gtransfer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
          {
              int ids = 0;
              object item = gtransfer.SelectedItem;
              string id = (gtransfer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

              ids = Int32.Parse(id);

              win_t_EditarTransferencias edittrans = new win_t_EditarTransferencias(ids);
              edittrans.Show();
              this.Close();
          }

          private void salir_Click(object sender, RoutedEventArgs e)
          {
              win_MenuPrincipal win = new win_MenuPrincipal();
              win.Show();
              this.Close();
          }
         
        private void bteliminar(object sender, RoutedEventArgs e)
          {
              
              object item = gtransfer.SelectedItem;
              string id = (gtransfer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
             
            int ids = Int32.Parse(id);
              //  var remover=scir.sp_mp_select_where_MateriaPrimaPorID(ids);
             
           
              MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar la transferencia", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
              if (result.ToString() == "Yes")
              {
                   try
                    {
                        t_transferencia_BLL.eliminar_t_transferencia_BLL(ids);
                        }catch (Exception ex)
                   {
                       Console.Write(ex.Message);
                       MessageBox.Show("Ocurrio un error al eliminar valor", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                   }
                
              }

          }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    //t_transferencia trans = new t_transferencia();
        //    t_transferencia trans = new t_transferencia();
        //    t_transferencia_BLL transfer = new t_transferencia_BLL();
        //    DateTime fech1 = (DateTime)fecha1.SelectedDate;
        //    DateTime fech2 = (DateTime)fecha2.SelectedDate;
        //    var returno =transfer.Gestiona(fech1,fech2);
        //    gtransfer.ItemsSource = (IEnumerable<t_transferencia>)returno;
           
            
            //

          
        
        
        
        //}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int trans = cbx_tipo.SelectedIndex+1;
            try
            {
                t_transferencia transfer = new t_transferencia();
                transfer.t_tipo = trans;
                transfer.t_fecha = (DateTime)fecha1.SelectedDate;

                t_transferencia_BLL tra = new t_transferencia_BLL();
                var filas = tra.Buscar(transfer);
                gtransfer.ItemsSource = (IEnumerable<t_transferencia>)filas;

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show("Error en datos vacios", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Deshacer_Click(object sender, RoutedEventArgs e)
        {
            win_t_GestionarTranferencias ges = new win_t_GestionarTranferencias();
            ges.Show();
            this.Close();
        }
    }
}
