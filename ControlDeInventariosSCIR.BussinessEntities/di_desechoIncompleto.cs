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
    
    public partial class di_desechoIncompleto
    {
        public int di_id { get; set; }
        public int di_id_d { get; set; }
        public int di_id_mp { get; set; }
        public double di_cantidad { get; set; }
    
        public virtual d_desecho d_desecho { get; set; }
    }
}