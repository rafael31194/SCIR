using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.BussinesLogic;
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
using System.Data;

namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Interaction logic for win_t_InsertarTransferencias.xaml
    /// </summary>
    /// 
    public partial class win_t_InsertarTransferencias : Window
    {
        int i = 0;
    DataTable transferenciaDT= new DataTable();

        
    

        public win_t_InsertarTransferencias()
        {
            InitializeComponent();
      
       

            transferenciaDT.Columns.Add("Id_mp", typeof(Int32));
            transferenciaDT.Columns.Add("cantidad_mp", typeof(float));
            transferenciaDT.Columns.Add("nombre_mp", typeof(string));
            
       
        }

        //Funciones para aceptar solo numeros
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }
        //fin de funciones
       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /**
             * 1. crear la transferencia en la base, esto sale del encabezado que lleva fecha
             * 2. de la tabla recuperar objetos
             * 3. esos objetos son MP, entonces llenar la lista
             * 4. Insertar cada objeto de la lista a la base
             * **/
             
            //CREAR OBJETO DE TIPO ENTITIES LLENITO!!
            t_transferencia trans = new t_transferencia();
            trans.t_fecha = (DateTime)fechadate.SelectedDate;
            trans.t_descripcion = txt_descripcion.Text;
            trans.t_tipo = (int)cbx_tipo.SelectedIndex+1;

            //MANDAR EL OBJETO A LA CAPA BLL
            
            if (!(trans.Equals(null)) && !(trans.t_fecha.Equals(null))) {
                MessageBoxResult result = MessageBox.Show("Estas seguro de Guardar la transferencia", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.ToString() == "Yes")
                {
                    int id=t_transferencia_BLL.insertar_t_transferencia_BLL(trans);

                    try
                    {
                        if (cbx_tipo.SelectedIndex == 0)
                        {
                                foreach (DataRowView dr in transferencia2.Items)
                                {


                                    //agregar detalle de transeferencia
                                    //transferencia entrada
                           
                                          te_transferenciaEntrada te = new te_transferenciaEntrada();
                                          te.te_id_t = id;
                                          te.te_id_mp = (int)dr[0];
                                          te.te_cantidad = (float)dr[1];
                                          te_transferencia_BLL.insertar_te_transferencia_BLL(te);
                                     }
                             }else{
                                 if (cbx_tipo.SelectedIndex == 1)
                                 {
                                     foreach(DataRowView dr in transferencia2.Items)
                                     {
                                     ts_transferenciaSalida ts = new ts_transferenciaSalida();
                                     ts.ts_id_t = id;
                                     ts.ts_id_mp = (int)dr[0];
                                     ts.ts_cantidad = (float)dr[1];
                                     ts_transferencia_BLL.insertar_ts_transferencia_BLL(ts);


                                     }
                                 }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        MessageBox.Show("Ocurrio un error al recorrer la tabla", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                   }
                    MessageBox.Show("Registro Guardado");
                    win_t_GestionarTranferencias wg = new win_t_GestionarTranferencias();
                    wg.Show();
                    this.Close();

                }
            }
        }

        private void btnAgregar_mp_insertarTransferencia_Click_1(object sender, RoutedEventArgs e)
        {
           //Insertando al datagrid
           // transferencia2.Items.Add(new MyData { Id_mp = i++, cantidad_mp = Convert.ToInt32(txtCant.Text), nombre_mp = ( cb_mp.Text) });
           
            transferenciaDT.Rows.Add(cb_mp.SelectedValue,txtCant.Text,cb_mp.Text);
            transferencia2.ItemsSource = transferenciaDT.DefaultView;

        }

        private void btn_eliminar_trans_Click(object sender, RoutedEventArgs e)
        {
            //boton eliminar con mensaje
            MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {
                transferenciaDT.Rows.RemoveAt(transferencia2.SelectedIndex);
                // materiaprima.Items.Refresh();
                

            }
        }

        private void btnCancelar_Transferencia_Click(object sender, RoutedEventArgs e)
        {
            win_t_GestionarTranferencias win = new win_t_GestionarTranferencias();
            win.Show();
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ControlDeInventariosSCIR.Presentacion.DataSetConsultas dataSetConsultas = ((ControlDeInventariosSCIR.Presentacion.DataSetConsultas)(this.FindResource("dataSetConsultas")));
            // Load data into the table mp_materiaPrima. You can modify this code as needed.
            ControlDeInventariosSCIR.Presentacion.DataSetConsultasTableAdapters.mp_materiaPrimaTableAdapter dataSetConsultasmp_materiaPrimaTableAdapter = new ControlDeInventariosSCIR.Presentacion.DataSetConsultasTableAdapters.mp_materiaPrimaTableAdapter();
            dataSetConsultasmp_materiaPrimaTableAdapter.Fill(dataSetConsultas.mp_materiaPrima);
            System.Windows.Data.CollectionViewSource mp_materiaPrimaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mp_materiaPrimaViewSource")));
            mp_materiaPrimaViewSource.View.MoveCurrentToFirst();
        }

      
    }
}
