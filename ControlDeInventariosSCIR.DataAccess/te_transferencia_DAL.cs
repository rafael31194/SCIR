using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.DataAccess
{
    public static class te_transferencia_DAL
    {
        public static void insertar(te_transferenciaEntrada tU)
        {
            SCIR_SistemaInventarioEntities DB = new SCIR_SistemaInventarioEntities();

            var ultimo = DB.te_transferenciaEntrada.OrderByDescending(u => u.te_id).FirstOrDefault();
            tU.te_id = ultimo.te_id + 1;

            try
            {
                DB.sp_trans_insert_TransferenciaEntradas1(tU.te_id,tU.te_id_t, tU.te_id_mp, tU.te_cantidad);
                var idUltimo = DB.te_transferenciaEntrada.OrderByDescending(u => u.te_id).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                 //por si da error

            }
            //DB.sp_trans_insert_NuevaTransferencia(tU.t_id_i,tU.t_fecha,tU.t_descripcion,tU.t_tipo,tU.t_id_usuarioCreacion,tU.t_id_ope);

        }
        public static void eliminar(int ids)
        {
            SCIR_SistemaInventarioEntities DB = new SCIR_SistemaInventarioEntities();
            var remover = DB.t_transferencia.Where(w => w.t_id == ids).FirstOrDefault();
            DB.t_transferencia.Remove(remover);
            DB.SaveChanges();


        }
        //public static List<te_transferenciaEntrada> GetFila(te_transferenciaEntrada tra)
        //{
            //SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();

          
            //var fila = scir.Database.SqlQuery<c_dtl_compra_detalle>("sp_c_dtl_select_where_CompraID @c_dtl_id_c", new SqlParameter("@c_dtl_id_c", tra.c_dtl_id_c)).ToList<c_dtl_compra_detalle>();
            //if (fila != null)
            //{
            //    return fila;
            //}
            //return null;
        //}
    }
}
