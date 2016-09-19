using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class mp_materiaPrimaBLL
    {

        public List<mp_materiaPrima> getnombre(mp_materiaPrima mp)
        {
            return MateriaPrimaDAL.mpnombre(mp);
        }
        public List<mp_materiaPrima> Gestion(mp_materiaPrima mp)
        {
            return MateriaPrimaDAL.GetDatos(mp);
        }

        public List<mp_materiaPrima> materiap { get; set; }
    }
}
