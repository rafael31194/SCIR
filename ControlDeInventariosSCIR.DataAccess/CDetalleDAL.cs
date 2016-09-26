using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.DataAccess
{
    public  class CDetalleDAL
    {
        public static void insertar(c_dtl_compra_detalle cdet)
        {
            SCIR_SistemaInventarioEntities scri = new SCIR_SistemaInventarioEntities();

            var ultimate = scri.c_dtl_compra_detalle.OrderByDescending(u => u.c_dtl_id).FirstOrDefault();
            cdet.c_dtl_id = ultimate.c_dtl_id + 1;
            try
            {
                scri.sp_insert_c_dtlCompra(cdet.c_dtl_id, cdet.c_dtl_id_c, cdet.c_dtl_id_mp, cdet.c_dtl_cantidad);
                var id = scri.c_dtl_compra_detalle.OrderByDescending(w => w.c_dtl_id).FirstOrDefault();
            }catch(Exception e){
                Console.Write(e.Message);
            }

        }

        public static void GetUpdate(c_dtl_compra_detalle cdet)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
           
            var fila = scir.c_dtl_compra_detalle.Where(w => w.c_dtl_id_c == cdet.c_dtl_id_c).FirstOrDefault();
           
            if (fila != null)
            {

                //  scir.c_compra.
                //    scir.SaveChanges();
                
                fila.c_dtl_id_mp = cdet.c_dtl_id_mp;
                fila.c_dtl_cantidad = cdet.c_dtl_cantidad;

                scir.SaveChanges();
                
            }
            
            // var edicion = scir

        }

        public static Boolean eliminar(c_dtl_compra_detalle ctd)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            //  var fila = scir.sp_compra_select_where_CompraporID(compra.c_id_i).FirstOrDefault();
            var fila = scir.c_dtl_compra_detalle.Where(w => w.c_dtl_id_c == ctd.c_dtl_id_c).FirstOrDefault();

            if (fila != null)
            {
                scir.c_dtl_compra_detalle.Remove(fila);
                scir.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //funcion q obtiene los datos de los registros de acuerdo al id compra
        public static List<c_dtl_compra_detalle> GetFila(c_dtl_compra_detalle compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();

            // var fila = scir.sp_compra_select_where_CompraporID(id).FirstOrDefault();
            var fila = scir.Database.SqlQuery<c_dtl_compra_detalle>("sp_c_dtl_select_where_CompraID @c_dtl_id_c", new SqlParameter("@c_dtl_id_c", compra.c_dtl_id_c)).ToList<c_dtl_compra_detalle>();
            if (fila != null)
            {
                return fila;
            }
            return null;
        }


    }
}
