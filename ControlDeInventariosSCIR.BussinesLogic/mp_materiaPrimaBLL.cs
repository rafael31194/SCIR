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

            
            public List<mp_materiaPrima> Gestion(mp_materiaPrima mp)
            {
                return MateriaPrimaDAL.GetDatos(mp);
            }

            //lista de materia prima
            public List<mp_materiaPrima> materiap { get; set; }

            public mp_materiaPrima Buscar(mp_materiaPrima mp)
            {
                return MateriaPrimaDAL.GetResultado(mp);
            }

            public string mpNombre(mp_materiaPrima mp)
            {
                return MateriaPrimaDAL.GetNombre(mp);
            }

            //obtener datos de acuerdo al idmateria prima
            public mp_materiaPrima NombreID(int mp)
            {
                return MateriaPrimaDAL.GetDatosMp(mp);
            }
    }
}
