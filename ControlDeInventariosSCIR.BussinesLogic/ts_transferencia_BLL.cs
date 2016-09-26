using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class ts_transferencia_BLL
    {
        public static void insertar_ts_transferencia_BLL(ts_transferenciaSalida t_BLL)
        {
            //Mandarlo a la capa DAL
            ts_transferencia_DAL.insertar(t_BLL);
        }
    }
}
