﻿using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.DataAccess
{
    public class t_transferencia_DAL
    {
        public static int insertar(t_transferencia tU)
        {
            SCIR_SistemaInventarioEntities DB = new SCIR_SistemaInventarioEntities();

            var ultimo = DB.t_transferencia.OrderByDescending(u => u.t_id).FirstOrDefault();
            tU.t_id = ultimo.t_id + 1;
            
            try
            {

                DB.sp_trans_insert_NuevaTransferencia(tU.t_id,1, tU.t_fecha, tU.t_descripcion, tU.t_tipo, 1, 1);  
                 var idUltimo = DB.t_transferencia.OrderByDescending(u => u.t_id).FirstOrDefault();
                 return idUltimo.t_id;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return -1; //por si da error
                
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
      
        public static void eliminarte(int ids)
        {
            SCIR_SistemaInventarioEntities DB = new SCIR_SistemaInventarioEntities();
            var remover = DB.te_transferenciaEntrada.Where(w => w.te_id_t== ids).FirstOrDefault();
            DB.te_transferenciaEntrada.Remove(remover);
            DB.SaveChanges();


        }
        public static List<t_transferencia> GetDatos(t_transferencia trans)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<t_transferencia> com = new List<t_transferencia>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<t_transferencia>("sp_trans_select_all_EntradasSalidas").ToList<t_transferencia>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }
        //public static List<t_transferencia> GetDato (DateTime fecha1,DateTime fecha2)
        //{
        //    SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
        //    List<t_transferencia> com = new List<t_transferencia>();
        //    scir.sp_t_select_fecha(fecha1,fecha2);
        //    var idUltimo = scir.t_transferencia.OrderByDescending(u => u.t_fecha).FirstOrDefault();
        //   var filas = scir.Database.SqlQuery<t_transferencia>("sp_t_select_fecha").ToList<t_transferencia>();
        //    //comprueba que sea diferente a null
        //    if (filas != null)
        //    {
        //        return filas;
        //    }
        //    return null;

        //}
        public static t_transferencia GetFila(t_transferencia trans)

        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();


           // var fila = scir.sp_compra_select_where_CompraporID(id).FirstOrDefault();
            var fila = scir.Database.SqlQuery<t_transferencia>("sp_t_select_where_TransferenciaID @t_id", new SqlParameter("@t_id", trans.t_id)).ToArray<t_transferencia>().FirstOrDefault();
            if (fila != null)
            {
                return fila;
            }
            return null;
        }
        public static List<t_transferencia> Buscar(t_transferencia transferencia)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            //  var fila = scir.sp_compra_select_where_CompraporID(compra.c_id_i).FirstOrDefault();

            var fila = scir.t_transferencia.Where(w => w.t_fecha== transferencia.t_fecha|| w.t_tipo== transferencia.t_tipo).ToList<t_transferencia>();


            if (fila != null)
            {
                return fila;
            }
            else
                return null;
        }

    }
}
