using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.DataAccess
{
    public static  class InventarioDAL
    {
        //funcion q obtiene todos los datos de las materias primas
        public static List<i_inventario> GetDatos(i_inventario inv)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<i_inventario> com = new List<i_inventario>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<i_inventario>("sp_i_inventario_select_all").ToList<i_inventario>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }
    }
}
