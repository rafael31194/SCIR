using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;

namespace ControlDeInventariosSCIR.DataAccess
{
    public static class usr_UsuariosDAL
    {
        static SCIR_SistemaInventarioEntities db;
        public static bool agregarUsuario(usr_usuarios user)
        {
             db=new SCIR_SistemaInventarioEntities();
            var ultimo = db.usr_usuarios.OrderByDescending(u => u.usr_id).FirstOrDefault();
            user.usr_id = ultimo.usr_id + 1;
            db.usr_usuarios.Add(user);
            try{
                db.SaveChanges();
                return true;
            }catch(Exception ex){
                Console.Write(ex.Message);
                return false;
            }

        }

        public static bool modificarUsuario(usr_usuarios user)
        {
            try
            {
                db = new SCIR_SistemaInventarioEntities();


                var userEdit = db.usr_usuarios.Where(w => w.usr_id == user.usr_id).FirstOrDefault();
                if (userEdit != null)
                {
                    userEdit.usr_id_rol = user.usr_id_rol;
                    if(user.usr_password!=null)
                    {
                        userEdit.usr_password = user.usr_password;
                    }
                    
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }



        public static bool eliminarUsuario(usr_usuarios user)
        {
             try
            {
                db = new SCIR_SistemaInventarioEntities();


                var userEdit = db.usr_usuarios.Where(w => w.usr_id == user.usr_id).FirstOrDefault();
                if (userEdit != null)
                {
                    db.usr_usuarios.Remove(userEdit);
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
             catch (Exception ex)
             {
                 Console.Write(ex.Message);
                 return false;
             }
        }
    }
}
