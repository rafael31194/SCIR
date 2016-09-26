﻿using System;
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
            public static int insertar(mp_materiaPrima t_BLL)
            {
                //Mandarlo a la capa DAL
                return MateriaPrimaDAL.insertar(t_BLL);
            }
            
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



    }
}
