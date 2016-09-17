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
    /// Lógica de interacción para EditarCompras.xaml
    /// </summary>
    public partial class EditarCompras : Window
    {
        int idx;
        public EditarCompras(int id)
        {
            InitializeComponent();
            idx = id;
        }

        private void Cargarcompra(object sender, RoutedEventArgs e)
        {
            c_compra compra = new c_compra();
            compra.c_id = idx;
            ComprasBLL cedit = new ComprasBLL();
            var retorno = cedit.Editar(compra);

            if (retorno != null)
            {
                txtcodigofactura.Text = retorno.c_codigoFactura;
                txtfecha.Text = String.Format("{0:d}", retorno.c_fecha);
                txtidinven.Text = retorno.c_id_i.ToString();
                txtdescripcion.Text = retorno.c_descripcion;
                txtidusuariocreacion.Text = retorno.c_id_usuarioCreacion.ToString();
                txtidoperacion.Text = retorno.c_id_ope.ToString();
            }
            else
            {
                MessageBox.Show("No hay datos de ese registro");
            }

            //gcompra.ItemsSource = (IEnumerable<c_compra>)retorno;
        }

        private void bteditar_Click(object sender, RoutedEventArgs e)
        {
            c_compra compra = new c_compra();
            c_compra comp = new c_compra();
            compra.c_id = idx;
            ComprasBLL cedit = new ComprasBLL();
         //   var retorno = cedit.Editar(compra);

            compra.c_id_i = Int32.Parse(txtidinven.Text);
            compra.c_codigoFactura = txtcodigofactura.Text;
            compra.c_descripcion = txtdescripcion.Text;
            compra.c_id_usuarioCreacion = Int32.Parse(txtidusuariocreacion.Text);
            compra.c_id_ope = Int32.Parse(txtidoperacion.Text);
            MessageBoxResult result = MessageBox.Show("Estas seguro de los cambios", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {
              //  scir.SaveChanges();
              var datos=  cedit.GuadarEdicion(compra);
                GestionCompras gestion = new GestionCompras();
                var data = cedit.Gestion(comp);

                gestion.gcompra.ItemsSource = null;
                gestion.gcompra.ItemsSource = data;
                MessageBox.Show("Edicion de materia prima correctamente");

            }
                     
        }
    }
}
