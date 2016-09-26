using ControlDeInventariosSCIR.DataAccess;
using ControlDeInventariosSCIR.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class d_desechoBLL
    {
        public static List<d_desecho> selectDesechoBLL(int tipo)
        {
            return d_desechoDAL.selectDesechoDAL(tipo);
        }

        public static bool insertDesechoBLL(d_desecho desecho, List<di_desechoIncompleto> registros)
        {
            int id = d_desechoDAL.insertDesechoDAL(desecho);
            if(id==-1)
            {
                return false;
            }
            else
            {
                bool res2 = false;
                foreach(di_desechoIncompleto di in registros)
                {
                    di.di_id_d = id;
                    res2 = di_desechoIncompletoDAL.insertDesechoIncompletoDAL(di);
                }
                return res2;
            }
        }

        public static d_desecho selectDesechoBLLxID(int idDesecho)
        {
            return d_desechoDAL.selectDesechoDALxID(idDesecho);
        }

        public static void deleteDesechoBLL(int idDesecho)
        {
            d_desechoDAL.deleteDesechoDAL(idDesecho);
        }

        public static int updateDesechoBLL(d_desecho desecho)
        {
            return d_desechoDAL.updateDesechoDAL(desecho);
        }
    }
}
