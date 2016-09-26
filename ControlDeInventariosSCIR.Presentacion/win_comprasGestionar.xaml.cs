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

            win_comprasEditar editcompra = new win_comprasEditar(ids);
            editcompra.Show();
           
          
        }

     /*   private void Button_Click(object sender, RoutedEventArgs e)
        {
            c_compra compras = new c_compra();

            ComprasBLL com = new ComprasBLL();
            var retorno = com.Gestion(compras);

            gcompra.ItemsSource = (IEnumerable<c_compra>)retorno;
        }*/

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win_comprasInsertar detalle = new win_comprasInsertar();
            detalle.Show();

        }

        private void bteliminar(object sender, RoutedEventArgs e)
        {
            //accion de eliminar registro
            object item = gcompra.SelectedItem;
            string id = (gcompra.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int ids = Int32.Parse(id);
            c_compra compra = new c_compra();
            c_dtl_compra_detalle cdetalle = new c_dtl_compra_detalle();
            cdetalle.c_dtl_id_c= ids;
           
            compra.c_id = ids;
            int i = ComprasBLL.eliminar(compra);
            Boolean valor = CDetalleBLL.eliminar(cdetalle);
            
               c_compra compras = new c_compra();
                ComprasBLL com = new ComprasBLL();
                var retorno = com.Gestion(compras);
                gcompra.ItemsSource = (IEnumerable<c_compra>)retorno;
                gcompra.Items.Refresh();
           
        }

        private void btBuscar(object sender, RoutedEventArgs e)
        {
            string compra = txtCompra.Text;

            c_compra datos = new c_compra();
            datos.c_codigoFactura = compra;
            datos.c_fecha = (DateTime)fecha.SelectedDate;
            
            ComprasBLL compras = new ComprasBLL();
            var filas=  compras.Buscar(datos);
            gcompra.ItemsSource = (IEnumerable<c_compra>)filas;


        }

       
       

    }
}

