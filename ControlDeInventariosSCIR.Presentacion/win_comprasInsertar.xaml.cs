using System;
using System.Collections;
using System.Collections.Generic;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.BussinesLogic;
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
using System.Data;

namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Lógica de interacción para win_comprasInsertar.xaml
    /// </summary>
    public partial class win_comprasInsertar : Window
    {
        
        DataTable comprasDT = new DataTable();

        public win_comprasInsertar()
        {
            InitializeComponent();
              bindmp();
              comprasDT.Columns.Add("mp_id", typeof(Int32));
              comprasDT.Columns.Add("mp_nombre", typeof(string));
              comprasDT.Columns.Add("mp_cantidad", typeof(float));
            

        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {         
                    
           comprasDT.Rows.Add(combomplist.SelectedValue, combomplist.Text, cantidad.Text);
           compradatos.ItemsSource = comprasDT.DefaultView;
    
        }
       


        public void bindmp()
        {
            mp_materiaPrima mp = new mp_materiaPrima();
            mp_materiaPrimaBLL mpb = new mp_materiaPrimaBLL();
            var item = mpb.Gestion(mp);
            //obtiene una lista de los datos de las materias prima
            var materiaprima = mpb.materiap;
            materiaprima = item;
            combomplist.DataContext = materiaprima;
            // DataContext = materiaprima;

        }

        //funcion loaded que carga los elementos en el datagrid al iniciar la ventana
        private void GestionarDetalleCompra(object sender, RoutedEventArgs e)
        {
           /* c_dtl_compra_detalle cdetalle = new c_dtl_compra_detalle();
            CompraDetalleBLL com= new CompraDetalleBLL();
            var data = com.Gestion(cdetalle);
            compradatos.ItemsSource = (IEnumerable<c_dtl_compra_detalle>)data;*/

        }

     //  private void bteliminar(object sender, RoutedEventArgs e)
     //   {
         /*   object item = materiaprima.SelectedItem;
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

            }
            */
       // }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            /**
             * 1 crea compra de la base
             * 2 de la tabla recupera objetos de tipo materia prima
             * 3 de esos llenara la lista
             * 4 Insertar cada objeto en la lista de compra y detalle compra
             * */

            c_compra compra = new c_compra();
            compra.c_fecha = (DateTime)fecha.SelectedDate;
            compra.c_descripcion = tdescripcion.Text;
            compra.c_codigoFactura = txtcodfactura.Text;

            //mandar objeto a la capa bll
            if (!(compra.Equals(null)) && !(compra.c_fecha.Equals(null)))
            {
                MessageBoxResult result = MessageBox.Show("Estas seguro de Guardar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.ToString() == "Yes")
                {

                     int id=ComprasBLL.insertar_compra(compra);

                    try
                    {
                        //agregar detalle de compras
                        foreach (DataRowView dr in compradatos.Items)
                        {
                            c_dtl_compra_detalle cdeta = new c_dtl_compra_detalle();
                            cdeta.c_dtl_id_c = id;
                            cdeta.c_dtl_id_mp= (int)dr[0];
                            cdeta.c_dtl_cantidad = (float)dr[2];
                            CDetalleBLL.insertar(cdeta);

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        MessageBox.Show("Ocurrio un error al recorrer la tabla", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    MessageBox.Show("Registro Guardado");
                    win_comprasGestionar wg = new win_comprasGestionar();
                    wg.Show();
                    this.Close();
                }
            }

        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EliminarDetallle(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {
                comprasDT.Rows.RemoveAt(compradatos.SelectedIndex);
                // materiaprima.Items.Refresh();


            }
        }
    }
}

