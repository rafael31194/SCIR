using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;

namespace ControlDeInventariosSCIR.BussinesLogic
{
    public class ComprasBLL
    {
        public List<c_compra> Gestion(c_compra compra)
        {
            return ComprasDAL.GetDatos(compra);
        }

        public c_compra Editar(c_compra compra)
        {
            //   ComprasDAL compras = new ComprasDAL();
            return ComprasDAL.GetFila(compra);
        }
        public static int GuadarEdicion(c_compra compra)
        {
            return ComprasDAL.Actualizar(compra);
        }

        public static int insertar_compra(c_compra compra)
        {
            return ComprasDAL.insertar(compra);
        }

        public static int eliminar(c_compra compra)
        {
            return ComprasDAL.Eliminar(compra);
        }

        public List<c_compra> Buscar(c_compra compra)
        {
            return ComprasDAL.Buscar(compra);
        }
    }
}
