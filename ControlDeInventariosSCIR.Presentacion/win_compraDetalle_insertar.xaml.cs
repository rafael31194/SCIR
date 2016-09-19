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
    /// Lógica de interacción para win_compraDetalle_insertar.xaml
    /// </summary>
    public partial class win_compraDetalle_insertar : Window
    {
        public win_compraDetalle_insertar()
        {
            InitializeComponent();
            bindi();
            bindmp();
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            //primero se creara un una instacia para agregar los datos en el grid 
            //se almacenara en el grid los datos de la compra para poder hacer
            //luego la incersion de detalle de la compra
            c_compra compra = new c_compra();
            compra.c_fecha = (DateTime)fecha.SelectedDate;
            compra.c_codigoFactura = txtcodfactura.Text;
         //   compra.c_id_i=Int32.Parse()
            compra.c_descripcion = tdescripcion.Text;



        }
        public void bindi()
        {

            //aqui se cargara los elemntos de los inventarios
            i_inventario inventario = new i_inventario();
            InventarioBLL inventariob = new InventarioBLL();
            var listinv = inventariob.Gestion(inventario);
            var inv = inventariob.inventarioI;
            inv = listinv;
            DataContext = inv;
        }

        public void bindmp()
        {
            mp_materiaPrima mp = new mp_materiaPrima();
            mp_materiaPrimaBLL mpb = new mp_materiaPrimaBLL();
            var item = mpb.Gestion(mp);
            //obtiene una lista de los datos de las materias prima
            var materiaprima = mpb.materiap;
            materiaprima = item;
            DataContext = materiaprima;

        }
       
       

        private void cargardatos(object sender, RoutedEventArgs e)
        {
           /* mp_materiaPrima mp= new mp_materiaPrima();
            mp_materiaPrimaBLL cmp =new mp_materiaPrimaBLL();
            var mpnombre = cmp.getnombre(mp);
          /*  foreach (var nmp in mpnombre){
                mplist.Items = nmp;
;           
            }*/
          
         //   var mpnombre= com.
        }

        

    }
}
