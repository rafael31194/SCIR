using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.DataAccess
{
    public class ts_transferencia_DAL
    {
        public static void insertar(ts_transferenciaSalida tU)
        {
            SCIR_SistemaInventarioEntities DB = new SCIR_SistemaInventarioEntities();

            var ultimo = DB.ts_transferenciaSalida.OrderByDescending(u => u.ts_id).FirstOrDefault();
            tU.ts_id = ultimo.ts_id + 1;

            try
            {
                DB.sp_trans_insert_TransferenciaSalidas1(tU.ts_id, tU.ts_id_t, tU.ts_id_mp, tU.ts_cantidad);
                var idUltimo = DB.ts_transferenciaSalida.OrderByDescending(u => u.ts_id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //por si da error

            }
           
        }
    }
}
