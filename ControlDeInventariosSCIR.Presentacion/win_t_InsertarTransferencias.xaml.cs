﻿using ControlDeInventariosSCIR.BussinessEntities;
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
    /// Interaction logic for win_t_InsertarTransferencias.xaml
    /// </summary>
    /// 
    public partial class win_t_InsertarTransferencias : Window
    {
        int i = 0;
        public struct MyData
        {
            public int id { set; get; }
            public string cod_mp { set; get; }
            public int cantidad_mp { set; get; }
            public DateTime nombre_mp { set; get; }
            public DateTime nextrun { set; get; }
        }

        public win_t_InsertarTransferencias()
        {
            InitializeComponent();
            List<mp_materiaPrima> mpList = new List<mp_materiaPrima>();
            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();

            transferencia2.Columns.Add(col1);
            transferencia2.Columns.Add(col2);
            transferencia2.Columns.Add(col3);

            col1.Binding = new Binding("cod_mp");
            col2.Binding = new Binding("cantidad_mp");
            col3.Binding = new Binding("nombre_mp");

            col1.Header = "COD";
            col2.Header = "cantidad_mp";
            col3.Header = "nombre_mp";
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
            trans.t_tipo = cbx_tipo.SelectedIndex;

            //MANDAR EL OBJETO A LA CAPA BLL
            
            if (!(trans.Equals(null)) && !(trans.t_fecha.Equals(null))) {
                MessageBoxResult result = MessageBox.Show("Estas seguro de Guardar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.ToString() == "Yes")
                {
                    t_transferencia_BLL.insertar_t_transferencia_BLL(trans);
                    MessageBox.Show("Registro Guardado");
                    this.Close();

                }
            }
        }

        private void btnAgregar_mp_insertarTransferencia_Click_1(object sender, RoutedEventArgs e)
        {
           //Insertando al datagrid
            transferencia2.Items.Add(new MyData { id = i++, cod_mp = cbx_tipo.SelectedIndex.ToString(), cantidad_mp = Convert.ToInt32(txtCant.Text), nombre_mp = new DateTime() });
           
        }

        private void btn_eliminar_trans_Click(object sender, RoutedEventArgs e)
        {
            //boton eliminar con mensaje
            MessageBoxResult result = MessageBox.Show("Estas seguro de eliminar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {
                transferencia2.Items.RemoveAt(transferencia2.SelectedIndex);
                // materiaprima.Items.Refresh();
                

            }
        }

        private void btnCancelar_Transferencia_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
