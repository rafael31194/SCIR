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
    
    public partial class ps_productoSimple
    {
        public ps_productoSimple()
        {
            this.pc_productoCombo = new HashSet<pc_productoCombo>();
        }
    
        public int ps_id { get; set; }
        public int ps_id_p { get; set; }
        public int ps_id_ps_mp { get; set; }
        public string ps_cantidad_mp { get; set; }
    
        public virtual p_producto p_producto { get; set; }
        public virtual ICollection<pc_productoCombo> pc_productoCombo { get; set; }
    }
}
