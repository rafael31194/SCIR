using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class t_transferencia_BLL
    {
        public static void insertar_t_transferencia_BLL(t_transferencia t_BLL)
        {
            //Mandarlo a la capa DAL
            t_transferencia_DAL.insertar(t_BLL);
        }
        public List<t_transferencia> Gestion(t_transferencia trans)
        {
            return t_transferencia_DAL .GetDatos(trans);
        }
        public t_transferencia Editar(t_transferencia trans)
        {
            return t_transferencia_DAL.GetFila(trans);
        }
    }
}
