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
    
    public partial class ir_inventarioReal
    {
        public int ir_id { get; set; }
        public int ir_id_i { get; set; }
        public int ir_id_mp { get; set; }
        public Nullable<int> ir_mp_descripcion { get; set; }
        public Nullable<double> ir_existencia { get; set; }
        public Nullable<bool> ir_activo { get; set; }
        public string ir_fechaIngreso { get; set; }
        public string ir_id_usuacioCreacion { get; set; }
    
        public virtual i_inventario i_inventario { get; set; }
    }
}