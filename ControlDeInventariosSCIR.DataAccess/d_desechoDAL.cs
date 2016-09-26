using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.DataAccess
{
    public class d_desechoDAL
    {
        public static List<d_desecho> selectDesechoDAL(int tipo)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            List<d_desecho> desechos = new List<d_desecho>();
            try
            {
                desechos = db.Database.SqlQuery<d_desecho>("sp_d_select_where_IncompletoCompleto @id_tipoDesecho", new SqlParameter("@id_tipoDesecho", tipo)).ToList<d_desecho>();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                desechos = null;
            }
            finally
            {
                db.Dispose();
            }
            if(desechos!=null)
            {
                foreach(d_desecho i in desechos)
                {
                    i.d_fecha = i.d_fecha.Date;
                    Debug.WriteLine(i.d_fecha);
                }
            }
            return desechos;
        }

        public static int insertDesechoDAL(d_desecho desecho)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            int? id = -1;
            List<SqlParameter> pms = new List<SqlParameter>();
            pms.Add(new SqlParameter("@d_id_i",desecho.d_id_i));
            pms.Add(new SqlParameter("@d_fecha",desecho.d_fecha));
            pms.Add(new SqlParameter("@d_descripcion",desecho.d_descripcion));
            pms.Add(new SqlParameter("@d_id_usuarioCreacion",desecho.d_id_usuarioCreacion));
            pms.Add(new SqlParameter("@d_id_ope", desecho.d_id_ope));
            pms.Add(new SqlParameter("@id_tipoDesecho", desecho.id_tipoDesecho));
            try
            {

                var x = (IEnumerable<int?>)db.sp_d_insert_Desecho(desecho.d_id_i, desecho.d_fecha, desecho.d_descripcion, desecho.d_id_usuarioCreacion, desecho.d_id_ope, desecho.id_tipoDesecho);
                id = x.FirstOrDefault();
                //var retorno = db.Database.SqlQuery(id.GetType(), "sp_d_insert_Desecho @d_id_i @d_fecha @d_descripcion @d_id_usuarioCreacion @d_id_ope @id_tipoDesecho", pms);
                //id = Int32.Parse(retorno.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                id = -1;
            }
            finally
            {
                db.Dispose();
                //Debug.WriteLine(id);
            }
            return (int)id;
        }

        public static d_desecho selectDesechoDALxID(int idDesecho)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            try
            {
                var retorno = db.Database.SqlQuery<d_desecho>("SELECT * FROM d_desecho WHERE d_id = @d_id", new SqlParameter("d_id", idDesecho)).FirstOrDefault<d_desecho>();
                if (retorno != null)
                    return retorno;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static void deleteDesechoDAL(int idDesecho)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            try
            {
                db.sp_d_deleteChildrenIncompleto_Desecho(idDesecho);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int updateDesechoDAL(d_desecho desecho)
        {
            SCIR_SistemaInventarioEntities db = new SCIR_SistemaInventarioEntities();
            int res = -1;
            try
            {
                res = db.sp_d_update_Desecho(desecho.d_id, desecho.d_fecha, desecho.d_descripcion);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                db.Dispose();
            }
            return res;
        }
    }
}
