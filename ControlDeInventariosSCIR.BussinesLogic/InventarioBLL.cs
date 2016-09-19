using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class InventarioBLL
    {
        public List<i_inventario> Gestion(i_inventario inv)
        {
            return InventarioDAL.GetDatos(inv);
        }

        public List<i_inventario> inventarioI { get; set; }
    
    }
}
