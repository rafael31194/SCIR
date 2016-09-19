using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.DataAccess
{
    public static class MateriaPrimaDAL
    {
        //no funciona luego la eliminare
        //funcion que solo obtiene los nombre de las materias primas registradas
        public static List<mp_materiaPrima> mpnombre(mp_materiaPrima mp){
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<mp_materiaPrima> mpname = new List<mp_materiaPrima>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_nombre").ToList<mp_materiaPrima>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;
        }

        //funcion q obtiene todos los datos de las materias primas
        public static List<mp_materiaPrima> GetDatos(mp_materiaPrima mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<mp_materiaPrima> com = new List<mp_materiaPrima>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_all").ToList<mp_materiaPrima>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }
    }
}
