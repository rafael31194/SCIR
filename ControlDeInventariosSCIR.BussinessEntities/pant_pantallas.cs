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
    
    public partial class pant_pantallas
    {
        public pant_pantallas()
        {
            this.per_premisosXrol = new HashSet<per_premisosXrol>();
        }
    
        public string pant_id { get; set; }
        public string pant_descripcion { get; set; }
    
        public virtual ICollection<per_premisosXrol> per_premisosXrol { get; set; }
    }
}
