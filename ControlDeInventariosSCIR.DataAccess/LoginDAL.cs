using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace ControlDeInventariosSCIR.DataAccess
{
    public static class LoginDAL
    {
        public static usr_usuarios GetLogin(usr_usuarios user){

            usr_usuarios nu = new usr_usuarios();
            ComunDB con = new ComunDB();
            SCIR_SistemaInventarioEntities entiti = new SCIR_SistemaInventarioEntities();
            //var rs=entiti.sp_Login(user.usr_nombre, user.usr_password);

            //foreach (usr_usuarios userActual in rs)
            //{
            //    nu.per_premisosXrol = userActual.per_premisosXrol;
               
            //}
            //return rs as DataSet;
            
            
            var FILAS=entiti.Database.SqlQuery<usr_usuarios>("sp_Login @username ,@password",new SqlParameter ("@username",user.usr_nombre),new SqlParameter("@password",user.usr_password)).ToArray<usr_usuarios>().FirstOrDefault();
            if (FILAS != null)
            {

                user.per_premisosXrol = entiti.Database.SqlQuery<per_premisosXrol>("sp_LoginPermisosXRol @id_rol", new SqlParameter("@id_rol", FILAS.usr_id)).ToArray<per_premisosXrol>();
                user.usr_id_rol = FILAS.usr_id_rol;
                user.usr_id = FILAS.usr_id;
                return user;
                
            }
            
            //ObjectResult ob = new ObjectResult();
            return null;

        }

    }
}
