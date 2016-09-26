using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ControlDeInventariosSCIR.BussinessEntities;

namespace ControlDeInventariosSCIR.DataAccess
{
   public class MateriaPrimaDAL
    {
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
       public static mp_materiaPrima GetDatosMp(int mp)
       {
           SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
           var datos = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_where_MateriaPrimaPorID @mp_id", new SqlParameter("@mp_id", mp)).ToArray<mp_materiaPrima>().FirstOrDefault();
           try
           {
               if (datos != null)
                   return datos;
               else
                   return null;
           }
           catch (Exception e)
           {
               Console.Write(e);
               return null;
           }
       }


    }
}
