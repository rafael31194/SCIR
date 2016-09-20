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
    /// Lógica de interacción para win_comprasGestionar.xaml
    /// </summary>
    public partial class win_comprasGestionar : Window
    {
        public win_comprasGestionar()
        {
            InitializeComponent();
        }
    private void gestionCompra(object sender, RoutedEventArgs e)
        {
          
            c_compra compras = new c_compra();

            ComprasBLL com = new ComprasBLL();
            var retorno = com.Gestion(compras);
            
            gcompra.ItemsSource =(IEnumerable<c_compra>) retorno;
                


        }

        private void EditarCompra(object sender, MouseButtonEventArgs e)
        {
            int ids = 0;
            object item = gcompra.SelectedItem;
            string id = (gcompra.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            ids = Int32.Parse(id);
            
            /*EditarCompras editcompra = new EditarCompras(ids);
            editcompra.Show();*/
        //    gcompra.Items.Refresh();
           /* int ids = 0;
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
            c_compra compras = new c_compra();

            ComprasBLL com = new ComprasBLL();
            var retorno = com.Gestion(compras);

            gcompra.ItemsSource = (IEnumerable<c_compra>)retorno;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win_comprasInsertar detalle = new win_comprasInsertar();
            detalle.Show();

        }

        private void bteliminar(object sender, RoutedEventArgs e)
        {
            //accion de eliminar registro
        }

       
       

    }
}

