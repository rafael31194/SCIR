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
      
        public static int  insertar_t_transferencia_BLL(t_transferencia t_BLL)
        {
            //Mandarlo a la capa DAL
           return  t_transferencia_DAL.insertar(t_BLL);
        }
        public static void eliminar_t_transferencia_BLL(int t_BLL)
        {
            //Mandarlo a la capa DAL
            t_transferencia_DAL.eliminar(t_BLL);
        }
        public static void eliminar_te_transferencia_BLL(int t_BLL)
        {
            //Mandarlo a la capa DAL
            t_transferencia_DAL.eliminarte(t_BLL);
        }
        public List<t_transferencia> Gestion(t_transferencia trans)
        {
            return t_transferencia_DAL.GetDatos(trans);
        }
        //public List<t_transferencia> Gestiona(DateTime fecha1,DateTime fecha2)
        //{
        //    return t_transferencia_DAL.GetDato(fecha1,fecha2);
        //}
        public t_transferencia Editar(t_transferencia trans)
        {
            return t_transferencia_DAL.GetFila(trans);
        }
        public List<t_transferencia> transferenciaedit { get; set; }
        public List<t_transferencia> Buscar(t_transferencia transferencia)
        {
            return t_transferencia_DAL.Buscar(transferencia);
        }


    }
}
