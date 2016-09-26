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
    public static class ComprasDAL
    {

        public static List<c_compra> GetDatos(c_compra compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<c_compra> com = new List<c_compra>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<c_compra>("sp_compras_select_all").ToList<c_compra>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }
        public static c_compra GetFila(c_compra compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            
            // var fila = scir.sp_compra_select_where_CompraporID(id).FirstOrDefault();
            var fila = scir.Database.SqlQuery<c_compra>("sp_compra_select_where_CompraporID @c_id", new SqlParameter("@c_id", compra.c_id)).ToArray<c_compra>().FirstOrDefault();
            if (fila != null)
            {
                return fila;
            }
            return null;
        }

        public static int  Actualizar(c_compra compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            //  var fila = scir.sp_compra_select_where_CompraporID(compra.c_id_i).FirstOrDefault();
            var fila = scir.c_compra.Where(w => w.c_id_i == compra.c_id).FirstOrDefault();
            //var fila = scir.Database.SqlQuery<c_compra>("sp_compra_select_where_CompraporID @c_id", new SqlParameter("@c_id", compra.c_id)).ToArray<c_compra>().FirstOrDefault();
            // var filas = scir.Database.SqlQuery<c_compra>("sp_c_compra_Update_ @c_id,@c_id_i," +
            //   "@c_codigoFactura,@c_descripcion,@c_id_usuarioCreacion,@c_id_ope", new SqlParameter("@c_id", compra.c_id), new SqlParameter("@c_id_i", compra.c_id_i), new SqlParameter("@c_codigoFactura", compra.c_codigoFactura), new SqlParameter("@c_descripcion", compra.c_descripcion), new SqlParameter("@c_id_usuarioCreacion", compra.c_id_usuarioCreacion), new SqlParameter("@c_id_ope", compra.c_id_ope)).ToArray<c_compra>().FirstOrDefault();
            if (fila != null)
            {

                //  scir.c_compra.
                //    scir.SaveChanges();
                
                fila.c_codigoFactura = compra.c_codigoFactura;
                fila.c_descripcion = compra.c_descripcion;
                fila.c_id_usuarioCreacion = 1;
                fila.c_id_ope = 1;

                scir.SaveChanges();
                return fila.c_id;
            }
            return 0;
            // var edicion = scir.Database.SqlQuery<c_compra>("sp_compra_update_compra @c_id_i,@c_codigoFactura,"+ 
            /* "@c_descripcion,@c_id_usuarioCreacion,@c_id_ope", new SqlParameter("@c_id_i", compra.c_id)).ToArray<c_compra>().FirstOrDefault();
             scir.SaveChanges();
             return compra;*/
        }

        public static int insertar(c_compra compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            var ultimo = scir.c_compra.OrderByDescending(u => u.c_id).FirstOrDefault();
            compra.c_id = ultimo.c_id + 1;
           
            try
            {
                Console.Write(compra.c_id);
                scir.sp_c_compra_insert(compra.c_id, 1, compra.c_fecha, compra.c_codigoFactura, compra.c_descripcion, 1, 1);
                var ultimoid = scir.c_compra.OrderByDescending(u => u.c_id).FirstOrDefault();
                return ultimoid.c_id;

            }catch(Exception ex){
                Console.Write(ex.Message);
                return -1;
            }
        }
        //funcion para obtener datos 
        public static List<c_compra> Buscar(c_compra compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            //  var fila = scir.sp_compra_select_where_CompraporID(compra.c_id_i).FirstOrDefault();
           
                var fila = scir.c_compra.Where(w => w.c_fecha == compra.c_fecha || w.c_codigoFactura == compra.c_codigoFactura).ToList<c_compra>();
           
           
            if (fila != null)
            {
                return fila;
            }
            else
                return null;
        }


        //funcion para eliminar datos 
        public static int Eliminar(c_compra compra)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            //  var fila = scir.sp_compra_select_where_CompraporID(compra.c_id_i).FirstOrDefault();
            var fila = scir.c_compra.Where(w => w.c_id == compra.c_id).FirstOrDefault();
           
            if (fila != null)
            {
                scir.c_compra.Remove(fila);
                scir.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

