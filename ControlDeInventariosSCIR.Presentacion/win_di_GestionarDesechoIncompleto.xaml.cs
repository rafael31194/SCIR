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

namespace ControlDeInventariosSCIR.Presentacion
{
    /// <summary>
    /// Lógica de interacción para win_di_VerDesechoIncompleto.xaml
    /// </summary>
    public partial class win_di_GestionarDesechoIncompleto : Window
    {
        List<d_desecho> registros;
        public win_di_GestionarDesechoIncompleto()
        {
            InitializeComponent();
        }

        private void btnNuevo_di_GestionarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            win_di_NuevoDesechoIncompleto win_di_N = new win_di_NuevoDesechoIncompleto();
            win_di_N.Show();
        }

        private void btnBuscar_di_DesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar_di_GestionarDesechoIncompleto.Text.Length>1)
            {
                string busqueda = txtBuscar_di_GestionarDesechoIncompleto.Text+" ";
                List<d_desecho> resultados = new List<d_desecho>();
                string aux = "";
                foreach (d_desecho d in registros)
                {
                    aux = d.d_descripcion+" ";
                    if (aux.ToLowerInvariant().Contains(busqueda.ToLowerInvariant()))
                    {
                        resultados.Add(d);
                    }
                }
                if (resultados != null)
                {
                    dataGrid_di_GestionarDesechoIncompleto.ItemsSource = resultados;
                    MessageBox.Show("Resultados de la búsqueda cargados en pantalla."
                                        + "\nPara modificar de doble clic sobre el registro.", "¡AVISO!");
                    //Interaccion con la vista
                    lblTitulo_di_GestionarDesechoIncompleto.Content = "RESULTADOS DE LA BÚSQUEDA";
                    lblTitulo_di_GestionarDesechoIncompleto.Foreground = new SolidColorBrush(Colors.Red);
                    btnNuevo_di_GestionarDesechoIncompleto.Visibility = Visibility.Hidden;
                    btnRegresar_di_GestionarDesechoIncompleto.Content = "REGRESAR";
                }
                else
                {
                    MessageBox.Show("Ningún resultado coincide con los criterios ingresados. \n" +
                                    "Intente con más palabras clave.","¡AVISO!");
                } 
            }
            else
            {
                MessageBox.Show("Ingrese un criterio de búsqueda más grande","¡ATENCIÓN!");
            }
        }

        private void dataGrid_di_GestionarDesechoIncompleto_Loaded(object sender, RoutedEventArgs e)
        {
            List<d_desecho> resultadosSelect = new List<d_desecho>();
            resultadosSelect = d_desechoBLL.selectDesechoBLL(2);
            registros = new List<d_desecho>();
            foreach(d_desecho d in resultadosSelect)
            {
                registros.Add(d);
            }
            if (registros!=null)
            {
                dataGrid_di_GestionarDesechoIncompleto.ItemsSource = registros; 
            }
        }

        private void dataGrid_di_GestionarDesechoIncompleto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int ids = 0;
            object item = dataGrid_di_GestionarDesechoIncompleto.SelectedItem;
            string id = (dataGrid_di_GestionarDesechoIncompleto.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            ids = Int32.Parse(id);
            win_di_EditarDesechoIncompleto win_di_E = new win_di_EditarDesechoIncompleto(ids);
            win_di_E.Show();
        }

        private void btnRegresar_di_GestionarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if(btnRegresar_di_GestionarDesechoIncompleto.Content.ToString()=="REGRESAR A MENU")
                this.Close();
            else
            {
                btnRegresar_di_GestionarDesechoIncompleto.Content = "REGRESAR A MENU";
                btnNuevo_di_GestionarDesechoIncompleto.Visibility = Visibility.Visible;
                txtBuscar_di_GestionarDesechoIncompleto.Text = null;
                lblTitulo_di_GestionarDesechoIncompleto.Content = "Gestionar Desecho Incompleto";
                lblTitulo_di_GestionarDesechoIncompleto.Foreground = new SolidColorBrush(Colors.Black);
                refreshDataGrid();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid_di_GestionarDesechoIncompleto.SelectedItem==null)
            {
                MessageBox.Show("No has seleccionado ningún registro!");
            }
            else
            {
                int ids = 0;
                object item = dataGrid_di_GestionarDesechoIncompleto.SelectedItem;
                string id = (dataGrid_di_GestionarDesechoIncompleto.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                ids = Int32.Parse(id);
                d_desechoBLL.deleteDesechoBLL(ids);
                eliminarRegistro(ids);
                refreshDataGrid();
            }
        }

        private void eliminarRegistro(int ids)
        {
            int index = 0;
            foreach (d_desecho r in registros)
            {
                if (r.d_id == ids)
                    index = registros.IndexOf(r);
            }
            registros.RemoveAt(index);
        }

        private void refreshDataGrid()
        {
            dataGrid_di_GestionarDesechoIncompleto.ItemsSource = null;
            dataGrid_di_GestionarDesechoIncompleto_Loaded(this, null);
            dataGrid_di_GestionarDesechoIncompleto.ItemsSource = registros;
        }
    }
}
