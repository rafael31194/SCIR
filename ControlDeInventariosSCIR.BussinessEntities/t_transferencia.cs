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
    
    public partial class t_transferencia
    {
        public t_transferencia()
        {
            this.te_transferenciaEntrada = new HashSet<te_transferenciaEntrada>();
            this.ts_transferenciaSalida = new HashSet<ts_transferenciaSalida>();
        }
    
        public int t_id { get; set; }
        public int t_id_i { get; set; }
        public System.DateTime t_fecha { get; set; }
        public string t_descripcion { get; set; }
        public int t_tipo { get; set; }
        public Nullable<int> t_id_usuarioCreacion { get; set; }
        public Nullable<int> t_id_ope { get; set; }
    
        public virtual i_inventario i_inventario { get; set; }
        public virtual ope_operacion ope_operacion { get; set; }
        public virtual ICollection<te_transferenciaEntrada> te_transferenciaEntrada { get; set; }
        public virtual ICollection<ts_transferenciaSalida> ts_transferenciaSalida { get; set; }
    }
}
