using ControlDeInventariosSCIR.BussinesLogic;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.Presentacion;
using System;
using System.Diagnostics;
using System.Windows;

namespace SCIR
{
    /// <summary>
    /// Lógica de interacción para Insertar_mp.xaml
    /// </summary>
    public partial class Insertar_mp : Window
    {

  
        public struct MyData
        {
            public String cod_mp { set; get; }
            public String name_mp { set; get; }
            public String um_mp { set; get; }
            public float cantmin_mp { set; get; }
            public Boolean estado_mp { set; get; }
        }

        public Insertar_mp()
        {
            InitializeComponent();
        }

        private void btnGuardar_ins_mp_Click(object sender, RoutedEventArgs e)
        {
            mp_materiaPrima map = new mp_materiaPrima();
            map.mp_codigo = txtCod_ins_mp.Text;
            map.mp_nombre = txtNom_ins_mp.Text;
            map.mp_cantidadMinima =Convert.ToInt32( txtCanMin_ins_mp.Text);
            map.mp_unidadMedida = txtUniMed_ins_mp.Text;
            map.mp_estado = true; 

            if (!(map.Equals(null)))
            {
                MessageBoxResult result = MessageBox.Show("Estas seguro de Guardar el registro", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.ToString() == "Yes")
                {
                    int id = mp_materiaPrimaBLL.insertar(map);


                    MessageBox.Show("Registro Guardado");
                    win_materiaprima nueva = new win_materiaprima();
                    this.Show();

                }
            }
        }


        private void btnCancelar_ins_mp_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Boton cancelar presionado!");
            this.Hide();

        }

    }
}
