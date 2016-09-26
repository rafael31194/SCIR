using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.DataAccess;
using ControlDeInventariosSCIR.BussinessEntities;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class te_transferencia_BLL
    {
        public static void insertar_te_transferencia_BLL(te_transferenciaEntrada t_BLL)
        {
            //Mandarlo a la capa DAL
           te_transferencia_DAL.insertar(t_BLL);
        }

        //public List<te_transferenciaEntrada> editar(te_transferenciaEntrada cdtl)
        //{
        //    return te_transferencia_DAL.GetFila(cdtl);
        //}

    }
}
