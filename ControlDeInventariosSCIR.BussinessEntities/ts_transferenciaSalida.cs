//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlDeInventariosSCIR.BussinessEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ts_transferenciaSalida
    {
        public int ts_id { get; set; }
        public int ts_id_t { get; set; }
        public int ts_id_mp { get; set; }
        public double ts_cantidad { get; set; }
    
        public virtual mp_materiaPrima mp_materiaPrima { get; set; }
        public virtual t_transferencia t_transferencia { get; set; }
    }
}
