using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.DataAccess;
using ControlDeInventariosSCIR.BussinessEntities;
using System.Data;


namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class LoginBLL
    {
        //LoginDAL lda = new LoginDAL();
        public   usr_usuarios login(usr_usuarios user)
        {
            return LoginDAL.GetLogin(user);



        }


    }
}
