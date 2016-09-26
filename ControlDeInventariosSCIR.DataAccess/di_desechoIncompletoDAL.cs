using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using System.Data.SqlClient;

namespace ControlDeInventariosSCIR.DataAccess
{
    public class di_desechoIncompletoDAL
    {
        public static bool insertDesechoIncompletoDAL(BussinessEntities.di_desechoIncompleto di)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            try
            {
                db.sp_di_insert_DesechoIncompleto(di.di_id_d, di.di_id_mp, di.di_cantidad);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static List<di_desechoIncompleto> selectAll(int idDesecho)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            List<di_desechoIncompleto> lista = new List<di_desechoIncompleto>();
            try
            {
                lista = db.Database.SqlQuery<di_desechoIncompleto>("SELECT * FROM di_desechoIncompleto WHERE di_id_d = @idDesecho", new SqlParameter("@idDesecho",idDesecho)).ToList<di_desechoIncompleto>();
                if (lista != null)
                    return lista;
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static void deleteDesechoIncompletoDAL(di_desechoIncompleto di)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            try
            {
                db.sp_di_delete_DesechoIncompleto(di.di_id, di.di_id_d);
            }
            catch(Exception ex)
            {
                //
            }
            finally
            {
                db.Dispose();
            }
        }

        public static void updateDesechoIncompletoDAL(di_desechoIncompleto di)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            try
            {
                db.sp_di_update_DesechoIncompleto(di.di_id, di.di_id_d, di.di_id_mp, di.di_cantidad);
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
