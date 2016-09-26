using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.DataAccess
{
    public class CompraDetalleDAL
    {
     

        public static List<c_dtl_compra_detalle> GetDatos(c_dtl_compra_detalle compradetalle)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<c_dtl_compra_detalle> com = new List<c_dtl_compra_detalle>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<c_dtl_compra_detalle>("sp_select_c_detalle_select_all").ToList<c_dtl_compra_detalle>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }
    }
}
