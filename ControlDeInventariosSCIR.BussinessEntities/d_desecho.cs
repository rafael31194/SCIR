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
    
    public partial class d_desecho
    {
        public d_desecho()
        {
            this.dc_desechoCompleto = new HashSet<dc_desechoCompleto>();
            this.di_desechoIncompleto = new HashSet<di_desechoIncompleto>();
        }
    
        public int d_id { get; set; }
        public int d_id_i { get; set; }
        public System.DateTime d_fecha { get; set; }
        public string d_descripcion { get; set; }
        public Nullable<int> d_id_usuarioCreacion { get; set; }
        public Nullable<int> d_id_ope { get; set; }
        public Nullable<int> id_tipoDesecho { get; set; }
    
        public virtual i_inventario i_inventario { get; set; }
        public virtual ope_operacion ope_operacion { get; set; }
        public virtual ICollection<dc_desechoCompleto> dc_desechoCompleto { get; set; }
        public virtual ICollection<di_desechoIncompleto> di_desechoIncompleto { get; set; }
        public virtual tid_tipoDesecho tid_tipoDesecho { get; set; }
    }
}
