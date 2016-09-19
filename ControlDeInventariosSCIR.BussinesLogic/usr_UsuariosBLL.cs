using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public static class usr_UsuariosBLL
    {
        public static bool agregarUsuario(usr_usuarios user)
        {
            return usr_UsuariosDAL.agregarUsuario(user);
        }


        public static bool modificarUsuario(usr_usuarios user)
        {
            return usr_UsuariosDAL.modificarUsuario(user);
        }

        public static bool  eliminarUsuario(usr_usuarios user)
        {
            return usr_UsuariosDAL.eliminarUsuario(user);
        }
    }
}
