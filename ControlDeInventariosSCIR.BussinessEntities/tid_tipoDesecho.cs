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
    
    public partial class tid_tipoDesecho
    {
        public tid_tipoDesecho()
        {
            this.d_desecho = new HashSet<d_desecho>();
        }
    
        public int tid_id { get; set; }
        public string tid_descripcion { get; set; }
    
        public virtual ICollection<d_desecho> d_desecho { get; set; }
    }
}
