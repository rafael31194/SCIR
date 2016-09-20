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

namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Lógica de interacción para win_materiaprima.xaml
    /// </summary>
    public partial class win_materiaprima : Window
    {
        public win_materiaprima()
        {
            InitializeComponent();
        }

        //funcion para llenar inicialmente el datagrid
        private void gestionMp(object sender, RoutedEventArgs e)
        {
            mp_materiaPrima compras = new mp_materiaPrima();

            mp_materiaPrimaBLL com = new mp_materiaPrimaBLL();
            var retorno = com.Gestion(compras);

            materiaprima.ItemsSource = (IEnumerable<mp_materiaPrima>)retorno;

         
        }

        private void EditarMp(object sender, MouseButtonEventArgs e)
        {
          /*  int ids = 0;
            //String fila= materiaprima.SelectedItems;
            object item = materiaprima.SelectedItem;
            string id = (materiaprima.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            if (id == null)
            {
                ids = 0;
                MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.OK, MessageBoxImage.Question);
                MessageBox.Show("No hay registro");
            }
            ids = Int32.Parse(id);

            MpEditar mpedit = new MpEditar(ids);

            mpedit.Show();


            // int ids = Int32.Parse(id);*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // String nombre = txtBuscarMp.Text;
            mp_materiaPrima mp = new mp_materiaPrima();
            mp_materiaPrimaBLL mat = new mp_materiaPrimaBLL();
            if (txtBuscarMp.Text == null)
            {
                MessageBox.Show("No hay registro con ese parametro");
            }
            else
            {
                mp.mp_nombre = txtBuscarMp.Text;
                if (mp.mp_nombre == null)
                {
                    MessageBox.Show("No hay registro con ese parametro");
                }
                else
                {
                    var registro = mat.Buscar(mp);
                    var data = mat.materiap;
                   // data =(IEnumerable<mp_materiaPrima>) registro;
                   //  data = (IEnumerable<mp_materiaPrima>)registro;
                   // materiaprima.ItemsSource=(List<mp_materiaPrima>) registro;
                }
            }
           

           
           // int ids = Int32.Parse(id);
           // materiaprima.ItemsSource = scir.sp_mp_select_where_MateriaPrimaPorID(ids);*/

        }

      /*  private void bteliminar(object sender, RoutedEventArgs e)
        {
            object item = materiaprima.SelectedItem;
            string id = (materiaprima.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int ids = Int32.Parse(id);
        */

            //  var remover=scir.sp_mp_select_where_MateriaPrimaPorID(ids);
           // var remover = scir.mp_materiaPrima.Where(w => w.mp_id == ids).FirstOrDefault();

       /*     MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {*/
               /* scir.mp_materiaPrima.Remove(remover);
                scir.SaveChanges();

                materiaprima.ItemsSource = scir.mp_materiaPrima.ToList();
                // materiaprima.Items.Refresh();
                MessageBox.Show("Registro eliminado");*/

//            }

  //      }
    }
}
