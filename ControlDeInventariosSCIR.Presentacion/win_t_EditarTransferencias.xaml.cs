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
    /// Interaction logic for win_t_EditarTransferencias.xaml
    /// </summary>
    public partial class win_t_EditarTransferencias : Window
    {
        DataTable Transfergt = new DataTable();
       
        int idx;
        public win_t_EditarTransferencias(int id)
        {
            InitializeComponent();
            idx = id;
           // bindmp();
            Transfergt.Columns.Add("mp_nombre", typeof(string));
            Transfergt.Columns.Add("mp_cantidad", typeof(float));
            Transfergt.Columns.Add("t_tipo", typeof(Int32));
           
        }
        //public void bindmp()
        //{
        //    mp_materiaPrima mp = new mp_materiaPrima();
        //    mp_materiaPrimaBLL mpb = new mp_materiaPrimaBLL();
        //    var item = mpb.Gestion(mp);
        //    //obtiene una lista de los datos de las materias prima
        //    var materiaprima = mpb.materiap;
        //    materiaprima = item;
        //    cb_mp.DataContext= materiaprima;
           

        //}
        private void CargarTrans(object sender, RoutedEventArgs e)
        {
        //    mp_materiaPrima mp = new mp_materiaPrima();
        //    mp_materiaPrimaBLL mpget = new mp_materiaPrimaBLL();
        //    t_transferencia trans= new t_transferencia();
        //    trans.t_id = idx;
        //    t_transferencia_BLL cedit = new t_transferencia_BLL();
        //    var retorno = cedit.Editar(trans);
        //    te_transferenciaEntrada transfeint = new te_transferenciaEntrada();
        //    te_transferencia_BLL te = new te_transferencia_BLL();
        //    transfeint.te_id_t = idx;
        //    var edicion = te.editar(transfeint);
        //    if (retorno != null && edicion != null)
        //    {
        //        fechadate.SelectedDate = retorno.t_fecha;

        //        txt_descripcion.Text = retorno.t_descripcion;
        //        var listatrans = (IEnumerable<te_transferenciaEntrada>)edicion;
        //        List<te_transferenciaEntrada> tent = listatrans.ToList();

        //        foreach (te_transferenciaEntrada lista in tent)
        //        {
        //            int idmp = lista.te_id_mp;
        //            var mpnombres = mpget.NombreID(idmp);

        //            Transfergt.Rows.Add(mpnombres.mp_id, mpnombres.mp_nombre, lista.te_cantidad);
        //        }
        //        transferencia2.ItemsSource = Transfergt.DefaultView;

        //    }
        //    else
        //    {
        //        MessageBox.Show("No hay datos de ese registro");
        //    }

         
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
            win_t_GestionarTranferencias win = new win_t_GestionarTranferencias();
            win.Show();
            this.Close();
        }

    }
}
