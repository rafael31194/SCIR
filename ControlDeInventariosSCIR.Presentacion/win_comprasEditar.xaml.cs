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
    /// Lógica de interacción para win_comprasEditar.xaml
    /// </summary>
    public partial class win_comprasEditar : Window
    {

        DataTable comprasDT = new DataTable();
        int idx;
        public win_comprasEditar(int id)
        {
            InitializeComponent();
            idx = id;
            bindmp();
            comprasDT.Columns.Add("mp_id", typeof(Int32));
            comprasDT.Columns.Add("mp_nombre", typeof(string));
            comprasDT.Columns.Add("mp_cantidad", typeof(float));
        }


        //cargar datos al combobox de materiaprima
        public void bindmp()
        {
            mp_materiaPrima mp = new mp_materiaPrima();
            mp_materiaPrimaBLL mpb = new mp_materiaPrimaBLL();
            var item = mpb.Gestion(mp);
            //obtiene una lista de los datos de las materias prima
            var materiaprima = mpb.materiap;
            materiaprima = item;
            combomplist.DataContext = materiaprima;
           
        }
        private void CargaCompra(object sender, RoutedEventArgs e)
        {
            mp_materiaPrima mp=new mp_materiaPrima();
            mp_materiaPrimaBLL mpget=new mp_materiaPrimaBLL();
            c_compra compra = new c_compra();
            compra.c_id = idx;
            ComprasBLL cedit = new ComprasBLL();
            var retorno = cedit.Editar(compra);
            c_dtl_compra_detalle cmp= new  c_dtl_compra_detalle();
            CDetalleBLL cdedit = new CDetalleBLL();
            //aqui se asigna el id al detalle compra
            cmp.c_dtl_id_c= idx;
            //edicion variable q obtiene el registro de las 
            var edicion = cdedit.editar(cmp);

            if (retorno != null && edicion!=null)
            {
                fecha.SelectedDate = retorno.c_fecha;
                tdescripcion.Text = retorno.c_descripcion;
                txtcodfactura.Text = retorno.c_codigoFactura;
                //lista compra detalle de la compra
                //se ocupa esa variable para asignar el tipo de dato a un var
                var listacompra = (IEnumerable<c_dtl_compra_detalle>)edicion;
                //convierte el tipo IEnumerable a lista
                List<c_dtl_compra_detalle> dcompra = listacompra.ToList();
                foreach  (c_dtl_compra_detalle lista in dcompra){
                    //haremos una consulta a materia prima para obtener los nombres de materia pirma
                    int idmp=lista.c_dtl_id_mp;
                    var mpnombres=mpget.NombreID(idmp);

                    comprasDT.Rows.Add(mpnombres.mp_id,mpnombres.mp_nombre , lista.c_dtl_cantidad);
                }
                //comprasDT.Rows.Add(combomplist.SelectedValue, combomplist.Text, cantidad.Text);
               // comprasDT.Rows.Add(, combomplist.Text, cantidad.Text);
                compradatos.ItemsSource = comprasDT.DefaultView;
                
            }
            else
            {
                MessageBox.Show("No hay ningun registro");
            }
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void GestionarDetalleCompra(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarDetalle(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {
                comprasDT.Rows.RemoveAt(compradatos.SelectedIndex);
                

            }
        }

        //accion del boton guardar editar datos de compras y detalle de compras
        private void Editar(object sender, RoutedEventArgs e)
        {
            /**
             * 1 editar compra de la base
             * 2 de la tabla recupera objetos de tipo materia prima
             * 3 de esos llenara la lista
             * 4 modificar cada objeto en la lista de compra y detalle compra
             * */
            c_compra compra = new c_compra();
            //compra.c_fecha = (DateTime)fecha.SelectedDate;
            compra.c_id = idx;
            compra.c_descripcion = tdescripcion.Text;
            compra.c_codigoFactura = txtcodfactura.Text;
            if (!compra.Equals(null))
            {
                MessageBoxResult result = MessageBox.Show("Estas seguro de los cambios relizados", "confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.ToString() == "Yes")
                {
                    //se debe asignar el id de compra a detalle compra para obtener la posicion 
                    //de ese registro a editar
                    // materiaprima.Items.Refresh();
                   // int idDetalle = compra.c_id;
                    int id = ComprasBLL.GuadarEdicion(compra);
                     try
                    {
                        //agregar detalle de compras
                        foreach (DataRowView dr in compradatos.Items)
                        {
                            c_dtl_compra_detalle cdeta = new c_dtl_compra_detalle();
                            cdeta.c_dtl_id_c = id;
                            cdeta.c_dtl_id_mp= (int)dr[0];
                            cdeta.c_dtl_cantidad = (float)dr[2];
                            CDetalleBLL.actualizar(cdeta);

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
        

        private void btAgregar(object sender, RoutedEventArgs e)
        {
            comprasDT.Rows.Add(combomplist.SelectedValue, combomplist.Text, cantidad.Text);
            compradatos.ItemsSource = comprasDT.DefaultView;

        }
    }
}
