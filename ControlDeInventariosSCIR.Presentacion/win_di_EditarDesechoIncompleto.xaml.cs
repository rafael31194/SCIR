using ControlDeInventariosSCIR.BussinesLogic;
using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Lógica de interacción para win_di_EditarDesechoIncompleto.xaml
    /// </summary>
    public partial class win_di_EditarDesechoIncompleto : Window
    {
        int idDesecho;
        d_desecho desecho, desechoOriginal;
        List<di_desechoIncompleto> registros, registrosOriginal;
        List<mp_materiaPrima> listaMP, listaMPOriginal;
        struct Fila
        {
            public string mp_nombre { get; set; }
            public double mp_cantidad { get; set; }
        }
        public win_di_EditarDesechoIncompleto()
        {
            InitializeComponent();
        }
        public win_di_EditarDesechoIncompleto(int idD)
        {
            InitializeComponent();
            idDesecho = idD;
            cargarDesecho();
            fillComboBox();
            cargarRegistros();
            respaldarDatos();
            btnGuardar_di_EditarDesechoIncompleto.IsEnabled = false;
        }

        private void respaldarDatos()
        {
            registrosOriginal = new List<di_desechoIncompleto>();
            foreach (di_desechoIncompleto viejo in registros)
            {
                registrosOriginal.Add(new di_desechoIncompleto()
                {
                    di_cantidad = viejo.di_cantidad,
                    di_id = viejo.di_id,
                    di_id_d = viejo.di_id_d,
                    di_id_mp = viejo.di_id_mp
                });
            }
            listaMPOriginal = new List<mp_materiaPrima>();
            foreach (mp_materiaPrima vieja in listaMP)
            {
                listaMPOriginal.Add(new mp_materiaPrima()
                {
                    mp_cantidadMinima = vieja.mp_cantidadMinima,
                    mp_codigo = vieja.mp_codigo,
                    mp_estado = vieja.mp_estado,
                    mp_id = vieja.mp_id,
                    mp_nombre = vieja.mp_nombre,
                    mp_unidadMedida = vieja.mp_unidadMedida
                });
            }
            desechoOriginal = new d_desecho();
            desechoOriginal.d_descripcion = desecho.d_descripcion;
            desechoOriginal.d_fecha = desecho.d_fecha;
            desechoOriginal.d_id = desecho.d_id;
            desechoOriginal.d_id_i = desecho.d_id_i;
            desechoOriginal.d_id_ope = desecho.d_id_ope;
            desechoOriginal.d_id_usuarioCreacion = desecho.d_id_usuarioCreacion;
            desechoOriginal.id_tipoDesecho = desecho.id_tipoDesecho;
        }

        private void cargarRegistros()
        {
            registros = new List<di_desechoIncompleto>();
            registros = di_desechoIncompletoBLL.selectAll(idDesecho);
            if (registros.Count > 0)
            {
                foreach (di_desechoIncompleto di in registros)
                {
                    var aux = from value in listaMP where value.mp_id== di.di_id_mp select value.mp_nombre;
                    string nombre = aux.FirstOrDefault();
                    gridMateriasPrimas_di_EditarDesechoIncompleto.Items.Add(new Fila { mp_nombre =nombre, mp_cantidad = di.di_cantidad });
                }
            }
            else
            {
                MessageBox.Show("No existen registros asociados");
            }
        }

        private void cargarDesecho()
        {
            if(desecho==null)
                desecho = new d_desecho();
            desecho = d_desechoBLL.selectDesechoBLLxID(idDesecho);
            txtDescripcion_di_EditarDesechoIncompleto.Text = desecho.d_descripcion;
            date_di_EditarDesechoIncompleto.SelectedDate = desecho.d_fecha;
        }

        private void fillComboBox()
        {
            listaMP = new List<mp_materiaPrima>();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT mp_id, mp_nombre FROM mp_materiaPrima WHERE mp_estado = 1", Properties.Settings.Default.SCIR_SistemaInventarioConnectionString);
            DataSet mp_ds = new DataSet();
            adap.Fill(mp_ds);
            foreach (DataRow row in mp_ds.Tables[0].Rows)
            {
                mp_materiaPrima aux = new mp_materiaPrima();
                aux.mp_id = (int)row.ItemArray[0];
                aux.mp_nombre = (string)row.ItemArray[1];
                listaMP.Add(aux);
            }
            comboMP_di_EditarDesechoIncompleto.ItemsSource = listaMP;
        }

        private void txtCantidad_di_EditarDesechoIncompleto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private static bool IsTextNumeric(string txt)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(txt);
        }

        private void btnGuardar_di_EditarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            int resultado1, resultado2, caso = -2 ;
            bool changes1 = compararDesechos(desecho, desechoOriginal), changes2 = compararRegistros(registros, registrosOriginal, ref caso);
            if (caso==-1)
            {
                MessageBox.Show("No se puede almacenar un desecho incompleto sin registros", "¡Atención!");
            }
            else
            {
                if (changes1 || changes2)
                {
                    if (changes1)
                    {
                        MessageBoxResult answ1 = MessageBox.Show("Se guardarán cambios en datos generales del registro \n¿Continuar?", "AVISO", MessageBoxButton.OKCancel);
                        if (answ1 == MessageBoxResult.OK)
                        {
                            resultado1 = d_desechoBLL.updateDesechoBLL(desecho);
                        }
                        else
                        {
                            return;
                        }
                    }
                    if (changes2)
                    {
                        if (MessageBox.Show("Se modificará el registro de algunas materias primas \n¿Continuar?", "AVISO", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                        {
                            List<di_desechoIncompleto> updates, news, deletes;
                            deletes = new List<di_desechoIncompleto>();
                            news = new List<di_desechoIncompleto>();
                            updates = new List<di_desechoIncompleto>();
                            foreach (di_desechoIncompleto registro in registros)
                            {
                                if (!this.registrosOriginal.Exists(x => x.di_id_mp == registro.di_id_mp))
                                {
                                    news.Add(registro);
                                }
                                else
                                {
                                    if (!this.registrosOriginal.Exists(x => x.di_id_mp == registro.di_id_mp && x.di_cantidad == registro.di_cantidad))
                                    {
                                        updates.Add(registro);
                                    }
                                }
                            }
                            foreach (di_desechoIncompleto registroO in registrosOriginal)
                            {
                                if ((!news.Exists(y => y.di_id_mp == registroO.di_id_mp)) &&
                                    (!updates.Exists(z => z.di_id_mp == registroO.di_id_mp)) &&
                                    (!registros.Exists(w => w.di_id_mp == registroO.di_id_mp)))
                                {
                                    deletes.Add(registroO);
                                }
                            }
                            //Preparadas las listas, mandar a la base
                            if (updates != null)
                                di_desechoIncompletoBLL.updateAll(updates);
                            if (deletes != null)
                                di_desechoIncompletoBLL.deleteAll(deletes);
                            if(news!=null)
                                di_desechoIncompletoBLL.insertAll(news,idDesecho);
                        }
                        else
                        {
                            return;
                        }
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No hay cambios para actualizar", "¡Atención!");
                }
            }
        }

        private bool compararRegistros(List<di_desechoIncompleto> registros, List<di_desechoIncompleto> registrosOriginal, ref int caso)
        {
            bool res = false;
            //caso = 0: no hay cambios y la cantidad es la misma
            //caso = 3: la cantidad de registros es la misma pero hay cambios en los registros
            if (registros.Count == registrosOriginal.Count)
            {
                caso = 0;
                res = false;
                
                foreach (di_desechoIncompleto nuevo in registros)
                {
                    if(!this.registrosOriginal.Exists(x => x.di_id_mp == nuevo.di_id_mp && x.di_cantidad == nuevo.di_cantidad))
                    {
                        res = true;
                    }
                }
                if (res)
                {
                    caso = 3;
                }
            }
            //caso = -1: no existen registros
            if (registros.Count == 0)
            {
                caso = -1;
                return res;
            }
            //caso = 1: se borraron registros
            if (registros.Count < registrosOriginal.Count)
            {
                caso = 1;
                res = true;
            }
            //caso = 2: se aumentaron los registros
            if (registros.Count > registrosOriginal.Count)
            {
                caso = 2;
                res = true;
            }
            return res;
        }

        private bool compararDesechos(d_desecho desecho, d_desecho desechoOriginal)
        {
            bool res = false;
            if (desecho.d_fecha != desechoOriginal.d_fecha || desecho.d_descripcion != desechoOriginal.d_descripcion)
                res = true;
            return res;
        }

        private void btnModificar_di_EditarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (btnModificar_di_EditarDesechoIncompleto.Content.ToString() == "GUARDAR")
            {
                if (txtDescripcion_di_EditarDesechoIncompleto != null && date_di_EditarDesechoIncompleto.SelectedDate != null)
                {
                    desecho.d_fecha = (DateTime)date_di_EditarDesechoIncompleto.SelectedDate;
                    desecho.d_descripcion = txtDescripcion_di_EditarDesechoIncompleto.Text;
                    btnModificar_di_EditarDesechoIncompleto.Content = "CAMBIAR";
                    lblFecha_di_EditarDesechoIncompleto.IsEnabled = false;
                    btnEliminarRegistro_di_EditarDesechoIncompleto.IsEnabled = false;
                    lblDescripcion_di_EditarDesechoIncompleto.IsEnabled = false;
                    txtDescripcion_di_EditarDesechoIncompleto.IsEnabled = false;
                    date_di_EditarDesechoIncompleto.IsEnabled = false;
                    btnGuardar_di_EditarDesechoIncompleto.IsEnabled = true;
                    stackMP_di_EditarDesechoIncompleto.IsEnabled = true;
                    gridMateriasPrimas_di_EditarDesechoIncompleto.IsEnabled = true;
                    btnEliminarMP_di_EditarDesechoIncompleto.IsEnabled = true;
                    btnModificar_di_EditarDesechoIncompleto.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Ingresa por favor una fecha y una descripción válidos.", "¡Atención!");
                }
            }
            else
            {
                lblFecha_di_EditarDesechoIncompleto.IsEnabled = true;
                lblDescripcion_di_EditarDesechoIncompleto.IsEnabled = true;
                txtDescripcion_di_EditarDesechoIncompleto.IsEnabled = true;
                date_di_EditarDesechoIncompleto.IsEnabled = true;
                btnGuardar_di_EditarDesechoIncompleto.IsEnabled = false;
                stackMP_di_EditarDesechoIncompleto.IsEnabled = false;
                gridMateriasPrimas_di_EditarDesechoIncompleto.IsEnabled = false;
                btnModificar_di_EditarDesechoIncompleto.Content = "GUARDAR";
                btnEliminarMP_di_EditarDesechoIncompleto.IsEnabled = false;
                btnModificar_di_EditarDesechoIncompleto.IsEnabled = true;
                btnEliminarRegistro_di_EditarDesechoIncompleto.IsEnabled = true;
            }
        }

        private void btnCancelar_di_EditarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCambiar_di_EditarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (btnCambiar_di_EditarDesechoIncompleto.Content.ToString() == "AGREGAR")
            {
                if (txtCantidad_di_EditarDesechoIncompleto.Text.Length > 0 && comboMP_di_EditarDesechoIncompleto.SelectedIndex != -1)
                {
                    if (Double.Parse(txtCantidad_di_EditarDesechoIncompleto.Text.ToString())>0)
                    {
                        di_desechoIncompleto registro = new di_desechoIncompleto();
                        registro.di_id_mp = (int)comboMP_di_EditarDesechoIncompleto.SelectedValue;
                        registro.di_cantidad = Double.Parse(txtCantidad_di_EditarDesechoIncompleto.Text);
                        registro.di_id = idDesecho;
                        mp_materiaPrima aux = (mp_materiaPrima)comboMP_di_EditarDesechoIncompleto.SelectedItem;
                        if (registros == null)
                        {
                            registros = new List<di_desechoIncompleto>();
                        }
                        registros.Add(registro);
                        gridMateriasPrimas_di_EditarDesechoIncompleto.Items.Add(new Fila { mp_nombre = aux.mp_nombre, mp_cantidad = registro.di_cantidad });
                        comboMP_di_EditarDesechoIncompleto.SelectedItem = null;
                        txtCantidad_di_EditarDesechoIncompleto.Text = null;
                        if (btnGuardar_di_EditarDesechoIncompleto.IsEnabled == false)
                        {
                            btnGuardar_di_EditarDesechoIncompleto.IsEnabled = true;
                        } 
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa una materia prima y cantidad válidas.", "¡Atención!");
                }
            }
            else
            {
                if (txtCantidad_di_EditarDesechoIncompleto.Text.Length > 0 && Double.Parse(txtCantidad_di_EditarDesechoIncompleto.Text.ToString()) > 0)
                {
                    di_desechoIncompleto registro = new di_desechoIncompleto();
                    mp_materiaPrima materia = (mp_materiaPrima)comboMP_di_EditarDesechoIncompleto.SelectedItem;
                    registro = registros.Find(x => x.di_id_mp == materia.mp_id);
                    registros.Remove(registro);
                    registro.di_cantidad = Double.Parse(txtCantidad_di_EditarDesechoIncompleto.Text);
                    registros.Add(registro);
                    //Actualización del grid
                    Fila seleccion = (Fila)gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem;
                    seleccion.mp_nombre = materia.mp_nombre;
                    seleccion.mp_cantidad = registro.di_cantidad;
                    gridMateriasPrimas_di_EditarDesechoIncompleto.Items.Remove(gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem);
                    gridMateriasPrimas_di_EditarDesechoIncompleto.Items.Add(seleccion);
                    //Interacción con la vista
                    btnEliminarMP_di_EditarDesechoIncompleto.Content = "ELIMINAR";
                    btnCambiar_di_EditarDesechoIncompleto.Content = "AGREGAR";
                    btnGuardar_di_EditarDesechoIncompleto.IsEnabled = true;
                    gridMateriasPrimas_di_EditarDesechoIncompleto.IsEnabled = true;
                    comboMP_di_EditarDesechoIncompleto.IsEnabled = true;
                    comboMP_di_EditarDesechoIncompleto.SelectedItem = null;
                    txtCantidad_di_EditarDesechoIncompleto.Text = null;
                }
                else
                {
                    MessageBox.Show("Ingresa una materia prima y cantidad válidas.", "¡Atención!");
                }
            }
        }

        private void btnEliminarMP_di_EditarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if (btnEliminarMP_di_EditarDesechoIncompleto.Content.ToString()=="ELIMINAR")
            {
                if (gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem != null)
                {
                    Fila row = (Fila)gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem;
                    registros.RemoveAll(x => x.di_id_mp == listaMP.Find(y => y.mp_nombre == row.mp_nombre).mp_id);
                    gridMateriasPrimas_di_EditarDesechoIncompleto.Items.Remove(gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem);
                    btnGuardar_di_EditarDesechoIncompleto.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Selecciona un registro para borrarlo", "¡Atención!");
                } 
            }
            else
            {
                //Interacción con la vista
                btnCambiar_di_EditarDesechoIncompleto.Content = "AGREGAR";
                btnEliminarMP_di_EditarDesechoIncompleto.Content = "ELIMINAR";
                btnGuardar_di_EditarDesechoIncompleto.IsEnabled = true;
                gridMateriasPrimas_di_EditarDesechoIncompleto.IsEnabled = true;
                comboMP_di_EditarDesechoIncompleto.IsEnabled = true;
                //Limpiar el ingreso de materias primas
                comboMP_di_EditarDesechoIncompleto.SelectedItem = null;
                txtCantidad_di_EditarDesechoIncompleto.Text = null;
            }
        }

        private void gridMateriasPrimas_di_EditarDesechoIncompleto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem != null)
            {
                Fila row = (Fila)gridMateriasPrimas_di_EditarDesechoIncompleto.SelectedItem;
                comboMP_di_EditarDesechoIncompleto.SelectedItem = listaMP.Find(x => x.mp_nombre == row.mp_nombre);
                txtCantidad_di_EditarDesechoIncompleto.Text = row.mp_cantidad.ToString();
                //Interacción con la vista
                btnCambiar_di_EditarDesechoIncompleto.Content = "CAMBIAR";
                btnEliminarMP_di_EditarDesechoIncompleto.Content = "CANCELAR";
                comboMP_di_EditarDesechoIncompleto.IsEnabled = false;
                btnGuardar_di_EditarDesechoIncompleto.IsEnabled = false;
                gridMateriasPrimas_di_EditarDesechoIncompleto.IsEnabled = false; 
            }
            else
            {
                MessageBox.Show("Da doble clic a un registro para editarlo", "¡Atención!");
            }
        }

        private void btnEliminarRegistro_di_EditarDesechoIncompleto_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("¿Está seguro de borrar el registro completo de este desecho incompleto?","¡ALERTA!",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                d_desechoBLL.deleteDesechoBLL(idDesecho);
                this.Close();
            }
        }
    }
}
