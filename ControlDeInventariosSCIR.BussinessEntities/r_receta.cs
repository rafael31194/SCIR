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
    
    public partial class r_receta
    {
        public r_receta()
        {
            this.p_producto = new HashSet<p_producto>();
            this.r_dtl_recetaDetalle = new HashSet<r_dtl_recetaDetalle>();
        }
    
        public int r_id { get; set; }
        public int r_tipo { get; set; }
        public Nullable<System.DateTime> r_fechaCreacion { get; set; }
        public string r_descripcion { get; set; }
        public Nullable<int> r_id_usuarioCreacion { get; set; }
    
        public virtual ICollection<p_producto> p_producto { get; set; }
        public virtual ICollection<r_dtl_recetaDetalle> r_dtl_recetaDetalle { get; set; }
        public virtual tir_tipoReceta tir_tipoReceta { get; set; }
    }
}
