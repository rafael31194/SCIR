using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;
using System.Data.SqlClient;

namespace ControlDeInventariosSCIR.DataAccess
{
    public static class MateriaPrimaDAL
    {
        //No funciona da error
        //no funciona luego la eliminare
        //funcion que solo obtiene los nombre de las materias primas registradas
        /*  public static List<mp_materiaPrima> mpnombre(mp_materiaPrima mp){
              SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
              List<mp_materiaPrima> mpname = new List<mp_materiaPrima>();
              //llamado al sp de compras
              var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_nombre").ToList<mp_materiaPrima>();
              //comprueba que sea diferente a null
              if (filas != null)
              {
                  return filas;
              }
              return null;
          }
         */
        //funcion q obtiene todos los datos de las materias primas

        public static int insertar(mp_materiaPrima tU)
        {
            SCIR_SistemaInventarioEntities DB = new SCIR_SistemaInventarioEntities();

            var ultimo = DB.mp_materiaPrima.OrderByDescending(u => u.mp_id).FirstOrDefault();
            tU.mp_id = ultimo.mp_id + 1;

            try
            {
                DB.sp_mp_insert_NuevaMateriaPrima(tU.mp_codigo, tU.mp_nombre, tU.mp_unidadMedida,tU.mp_cantidadMinima,tU.mp_estado);
                var idUltimo = DB.mp_materiaPrima.OrderByDescending(u => u.mp_id).FirstOrDefault();
                return idUltimo.mp_id;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return -1; //por si da error

            }
            //DB.sp_trans_insert_NuevaTransferencia(tU.t_id_i,tU.t_fecha,tU.t_descripcion,tU.t_tipo,tU.t_id_usuarioCreacion,tU.t_id_ope);

        }
   
        public static List<mp_materiaPrima> GetDatos(mp_materiaPrima mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<mp_materiaPrima> com = new List<mp_materiaPrima>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_all").ToList<mp_materiaPrima>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }

        //funcion q obtiene datos a partir de la busqueda
        public static mp_materiaPrima GetResultado(mp_materiaPrima mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            if (mp.mp_nombre == null)
            {
                return null;
            }
            else
            {
                var registro = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_where_MateriaPrimaPorNombre  @mp_nombre ", new SqlParameter("@mp_nombre", mp.mp_nombre)).ToList<mp_materiaPrima>().FirstOrDefault() ;
                if (registro != null)
                {
                    return registro;
                }

                return null;

            }
        }
    }
}


