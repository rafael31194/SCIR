using ControlDeInventariosSCIR.BussinesLogic;
using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Diagnostics;
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
    /// Lógica de interacción para win_di_NuevoDesechoIncompleto.xaml
    /// </summary>
    public partial class win_di_NuevoDesechoIncompleto : Window
    {
        d_desecho desecho;
        List<di_desechoIncompleto> registros;
        List<mp_materiaPrima> listaMP;
        struct Fila
        {
            public string mp_nombre { get; set; }
            public double mp_cantidad { get; set; }
        }
        public win_di_NuevoDesechoIncompleto()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void fillComboBox()
        {
            listaMP = new List<mp_materiaPrima>();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT mp_id, mp_nombre FROM mp_materiaPrima WHERE mp_estado = 1", Properties.Settings.Default.SCIR_SistemaInventarioConnectionString);
            DataSet mp_ds = new DataSet();
            adap.Fill(mp_ds);
            foreach(DataRow row in mp_ds.Tables[0].Rows)
            {
                mp_materiaPrima aux = new mp_materiaPrima();
                aux.mp_id = (int)row.ItemArray[0];
                aux.mp_nombre = (string)row.ItemArray[1];
                listaMP.Add(aux);
            }
            comboMP_di_NuevoDesechoIncompleto.ItemsSource = listaMP;
        }

        private void btnCrear_di_NuevoDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (btnCrear_di_NuevoDesechoIncompleto.Content.ToString() == "CREAR")
            {
                if (txtDescripcion_di_NuevoDesechoIncompleto != null && date_di_NuevoDesechoIncompleto.SelectedDate != null)
                {
                    if (desecho==null)
                    {
                        desecho = new d_desecho(); 
                    }
                    desecho.d_fecha = (DateTime)date_di_NuevoDesechoIncompleto.SelectedDate;
                    desecho.d_descripcion = txtDescripcion_di_NuevoDesechoIncompleto.Text;
                    stackMP_di_NuevoDesechoIncompleto.IsEnabled = true;
                    lblFecha_di_NuevoDesechoIncompleto.IsEnabled = false;
                    lblDescripcion_di_NuevoDesechoIncompleto.IsEnabled = false;
                    txtDescripcion_di_NuevoDesechoIncompleto.IsEnabled = false;
                    date_di_NuevoDesechoIncompleto.IsEnabled = false;
                    btnCrear_di_NuevoDesechoIncompleto.Content = "CAMBIAR";
                }
                else
                {
                    MessageBox.Show("Ingresa por favor una fecha y una descripción válidos.", "¡Atención!");
                } 
            }
            else
            {
                lblFecha_di_NuevoDesechoIncompleto.IsEnabled = true;
                lblDescripcion_di_NuevoDesechoIncompleto.IsEnabled = true;
                txtDescripcion_di_NuevoDesechoIncompleto.IsEnabled = true;
                date_di_NuevoDesechoIncompleto.IsEnabled = true;
                btnCrear_di_NuevoDesechoIncompleto.Content = "CREAR";   
            }
        }

        private void txtCantidad_di_NuevoDesechoIncompleto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private static bool IsTextNumeric(string txt)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(txt);
        }

        private void btnAgregar_di_NuevoDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (btnAgregar_di_NuevoDesechoIncompleto.Content.ToString() == "AGREGAR")
            {
                if (txtCantidad_di_NuevoDesechoIncompleto.Text.Length > 0 && comboMP_di_NuevoDesechoIncompleto.SelectedIndex != -1)
                {

                    di_desechoIncompleto registro = new di_desechoIncompleto();
                    registro.di_id_mp = (int)comboMP_di_NuevoDesechoIncompleto.SelectedValue;
                    registro.di_cantidad = Double.Parse(txtCantidad_di_NuevoDesechoIncompleto.Text);
                    mp_materiaPrima aux = (mp_materiaPrima)comboMP_di_NuevoDesechoIncompleto.SelectedItem;
                    if (registros == null)
                    {
                        registros = new List<di_desechoIncompleto>();
                    }
                    registros.Add(registro);
                    gridMateriasPrimas_di_NuevoDesechoIncompleto.Items.Add(new Fila { mp_nombre = aux.mp_nombre, mp_cantidad = registro.di_cantidad });
                    comboMP_di_NuevoDesechoIncompleto.SelectedItem = null;
                    txtCantidad_di_NuevoDesechoIncompleto.Text = null;
                    if (btnGuardar_di_NuevoDesechoIncompleto.IsEnabled == false)
                    {
                        btnGuardar_di_NuevoDesechoIncompleto.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa una materia prima y cantidad válidas.", "¡Atención!");
                }
            }
            else
            {
                if (txtCantidad_di_NuevoDesechoIncompleto.Text.Length > 0 && Double.Parse(txtCantidad_di_NuevoDesechoIncompleto.Text.ToString()) > 0)
                {
                    di_desechoIncompleto registro = new di_desechoIncompleto();
                    mp_materiaPrima materia = (mp_materiaPrima)comboMP_di_NuevoDesechoIncompleto.SelectedItem;
                    registro = registros.Find(x => x.di_id_mp == materia.mp_id);
                    registros.Remove(registro);
                    registro.di_cantidad = Double.Parse(txtCantidad_di_NuevoDesechoIncompleto.Text);
                    registros.Add(registro);
                    //Actualización del grid
                    Fila seleccion = (Fila)gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem;
                    seleccion.mp_nombre = materia.mp_nombre;
                    seleccion.mp_cantidad = registro.di_cantidad;
                    gridMateriasPrimas_di_NuevoDesechoIncompleto.Items.Remove(gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem);
                    gridMateriasPrimas_di_NuevoDesechoIncompleto.Items.Add(seleccion);
                    //Interacción con la vista
                    btnEliminar_di_NuevoDesechoIncompleto.Content = "ELIMINAR";
                    btnAgregar_di_NuevoDesechoIncompleto.Content = "AGREGAR";
                    btnGuardar_di_NuevoDesechoIncompleto.IsEnabled = true;
                    gridMateriasPrimas_di_NuevoDesechoIncompleto.IsEnabled = true;
                    comboMP_di_NuevoDesechoIncompleto.IsEnabled = true;
                    comboMP_di_NuevoDesechoIncompleto.SelectedItem = null;
                    txtCantidad_di_NuevoDesechoIncompleto.Text = null;
                }
                else
                {
                    MessageBox.Show("Ingresa una materia prima y cantidad válidas.", "¡Atención!");
                }
            }
        }

        private void btnCancelar_di_NuevoDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_di_NuevoDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (registros.Count>0)
            {
                //BURNED
                desecho.d_id_i = 1;
                desecho.d_id_ope = 4;
                desecho.id_tipoDesecho = 2;
                desecho.d_id_usuarioCreacion = 1;//SE RECUPERARÁ
                bool res = d_desechoBLL.insertDesechoBLL(desecho, registros);
                if (res)
                {
                    MessageBox.Show("Desecho Incompleto guardado con éxito","¡AVISO!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al ingresar registro a la base de datos","¡ALERTA!");
                } 
            }
            else
            {
                MessageBox.Show("Imposible guardar un desecho incompleto sin registros de materia prima","¡ATENCIÓN!");
            }
        }

        private void btnEliminar_di_NuevoDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (btnEliminar_di_NuevoDesechoIncompleto.Content.ToString() == "ELIMINAR")
            {
                if (gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem != null)
                {
                    Fila row = (Fila)gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem;
                    registros.RemoveAll(x => x.di_id_mp == listaMP.Find(y => y.mp_nombre == row.mp_nombre).mp_id);
                    gridMateriasPrimas_di_NuevoDesechoIncompleto.Items.Remove(gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem);
                    btnGuardar_di_NuevoDesechoIncompleto.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Selecciona un registro para borrarlo", "¡Atención!");
                }
            }
            else
            {
                //Interacción con la vista
                btnAgregar_di_NuevoDesechoIncompleto.Content = "AGREGAR";
                btnEliminar_di_NuevoDesechoIncompleto.Content = "ELIMINAR";
                btnGuardar_di_NuevoDesechoIncompleto.IsEnabled = true;
                gridMateriasPrimas_di_NuevoDesechoIncompleto.IsEnabled = true;
                comboMP_di_NuevoDesechoIncompleto.IsEnabled = true;
                //Limpiar el ingreso de materias primas
                comboMP_di_NuevoDesechoIncompleto.SelectedItem = null;
                txtCantidad_di_NuevoDesechoIncompleto.Text = null;
            }
        }

        private void gridMateriasPrimas_di_NuevoDesechoIncompleto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem != null)
            {
                Fila row = (Fila)gridMateriasPrimas_di_NuevoDesechoIncompleto.SelectedItem;
                comboMP_di_NuevoDesechoIncompleto.SelectedItem = listaMP.Find(x => x.mp_nombre == row.mp_nombre);
                txtCantidad_di_NuevoDesechoIncompleto.Text = row.mp_cantidad.ToString();
                //Interacción con la vista
                btnAgregar_di_NuevoDesechoIncompleto.Content = "CAMBIAR";
                btnEliminar_di_NuevoDesechoIncompleto.Content = "CANCELAR";
                comboMP_di_NuevoDesechoIncompleto.IsEnabled = false;
                btnGuardar_di_NuevoDesechoIncompleto.IsEnabled = false;
                gridMateriasPrimas_di_NuevoDesechoIncompleto.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Da doble clic a un registro para editarlo", "¡Atención!");
            }
        }
    }
}
