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
        public DataSet SelectMateriaPrimaAll(int mp_id)
        {
            using (SqlConnection _conn = ComunDB.ObtenerConnSql())
            {

                SqlConnection oConn = ComunDB.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("sp_mp_select_all", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idmp = new SqlParameter("@idMP", mp_id); 
                oCmd.Parameters.Add(idmp);
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

    }
}
