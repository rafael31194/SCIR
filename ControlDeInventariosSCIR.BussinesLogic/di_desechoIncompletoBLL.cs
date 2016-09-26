using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class di_desechoIncompletoBLL
    {
        public static List<di_desechoIncompleto> selectAll(int idDesecho)
        {
            return di_desechoIncompletoDAL.selectAll(idDesecho);
        }

        public static void insertAll(List<di_desechoIncompleto> desechosIncompletos, int idDesecho)
        {
            foreach(di_desechoIncompleto di in desechosIncompletos)
            {
                di.di_id_d = idDesecho;
                di_desechoIncompletoDAL.insertDesechoIncompletoDAL(di);
            }
        }

        public static void deleteAll(List<di_desechoIncompleto> desechosIncompletos)
        {
            foreach(di_desechoIncompleto di in desechosIncompletos)
            {
                di_desechoIncompletoDAL.deleteDesechoIncompletoDAL(di);
            }
        }

        public static void updateAll(List<di_desechoIncompleto> desechosIncompletos)
        {
            foreach(di_desechoIncompleto di in desechosIncompletos)
            {
                di_desechoIncompletoDAL.updateDesechoIncompletoDAL(di);
            }
        }
    }
}
