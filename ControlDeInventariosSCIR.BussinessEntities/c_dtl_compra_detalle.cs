//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlDeInventariosSCIR.BussinessEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class c_dtl_compra_detalle
    {
        public int c_dtl_id { get; set; }
        public int c_dtl_id_c { get; set; }
        public int c_dtl_id_mp { get; set; }
        public double c_dtl_cantidad { get; set; }
    
        public virtual c_compra c_compra { get; set; }
        public virtual mp_materiaPrima mp_materiaPrima { get; set; }
    }
}
