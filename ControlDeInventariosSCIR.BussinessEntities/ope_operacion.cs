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
    
    public partial class ope_operacion
    {
        public ope_operacion()
        {
            this.c_compra = new HashSet<c_compra>();
            this.carg_cargoInventario = new HashSet<carg_cargoInventario>();
            this.ce_comidaEmpleado = new HashSet<ce_comidaEmpleado>();
            this.d_desecho = new HashSet<d_desecho>();
            this.deg_degustacion = new HashSet<deg_degustacion>();
            this.desc_descargoInventario = new HashSet<desc_descargoInventario>();
            this.pmx_productMix = new HashSet<pmx_productMix>();
            this.t_transferencia = new HashSet<t_transferencia>();
        }
    
        public int ope_id { get; set; }
        public string ope_descripcion { get; set; }
        public Nullable<int> ope_tipo { get; set; }
    
        public virtual ICollection<c_compra> c_compra { get; set; }
        public virtual ICollection<carg_cargoInventario> carg_cargoInventario { get; set; }
        public virtual ICollection<ce_comidaEmpleado> ce_comidaEmpleado { get; set; }
        public virtual ICollection<d_desecho> d_desecho { get; set; }
        public virtual ICollection<deg_degustacion> deg_degustacion { get; set; }
        public virtual ICollection<desc_descargoInventario> desc_descargoInventario { get; set; }
        public virtual tope_tipoOperacion tope_tipoOperacion { get; set; }
        public virtual ICollection<pmx_productMix> pmx_productMix { get; set; }
        public virtual ICollection<t_transferencia> t_transferencia { get; set; }
    }
}
