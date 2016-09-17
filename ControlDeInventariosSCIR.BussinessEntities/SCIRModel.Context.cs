﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class SCIR_SistemaInventarioEntities : DbContext
    {
        public SCIR_SistemaInventarioEntities()
            : base("name=SCIR_SistemaInventarioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<c_compra> c_compra { get; set; }
        public DbSet<c_dtl_compra_detalle> c_dtl_compra_detalle { get; set; }
        public DbSet<carg_cargoInventario> carg_cargoInventario { get; set; }
        public DbSet<ce_comidaEmpleado> ce_comidaEmpleado { get; set; }
        public DbSet<ce_dtl_comidaEmpleado_detalle> ce_dtl_comidaEmpleado_detalle { get; set; }
        public DbSet<d_desecho> d_desecho { get; set; }
        public DbSet<dc_desechoCompleto> dc_desechoCompleto { get; set; }
        public DbSet<deg_degustacion> deg_degustacion { get; set; }
        public DbSet<deg_dtl_degustacion_detalle> deg_dtl_degustacion_detalle { get; set; }
        public DbSet<desc_descargoInventario> desc_descargoInventario { get; set; }
        public DbSet<di_desechoIncompleto> di_desechoIncompleto { get; set; }
        public DbSet<i_inventario> i_inventario { get; set; }
        public DbSet<ii_inventarioInterno> ii_inventarioInterno { get; set; }
        public DbSet<ir_inventarioReal> ir_inventarioReal { get; set; }
        public DbSet<mp_materiaPrima> mp_materiaPrima { get; set; }
        public DbSet<ope_operacion> ope_operacion { get; set; }
        public DbSet<p_producto> p_producto { get; set; }
        public DbSet<pant_pantallas> pant_pantallas { get; set; }
        public DbSet<pc_productoCombo> pc_productoCombo { get; set; }
        public DbSet<per_premisosXrol> per_premisosXrol { get; set; }
        public DbSet<pmx_dtl_productMix_detalle> pmx_dtl_productMix_detalle { get; set; }
        public DbSet<pmx_productMix> pmx_productMix { get; set; }
        public DbSet<ps_productoSimple> ps_productoSimple { get; set; }
        public DbSet<r_dtl_recetaDetalle> r_dtl_recetaDetalle { get; set; }
        public DbSet<r_receta> r_receta { get; set; }
        public DbSet<rol_roles> rol_roles { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<t_transferencia> t_transferencia { get; set; }
        public DbSet<te_transferenciaEntrada> te_transferenciaEntrada { get; set; }
        public DbSet<tid_tipoDesecho> tid_tipoDesecho { get; set; }
        public DbSet<tir_tipoReceta> tir_tipoReceta { get; set; }
        public DbSet<tope_tipoOperacion> tope_tipoOperacion { get; set; }
        public DbSet<ts_transferenciaSalida> ts_transferenciaSalida { get; set; }
        public DbSet<usr_usuarios> usr_usuarios { get; set; }
        public DbSet<vin_variacionInventario> vin_variacionInventario { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<string> sp_Login(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_Login", usernameParameter, passwordParameter);
        }
    
        public virtual int sp_mp_insert_NuevaMateriaPrima(string mp_codigo, string mp_nombre, string mp_unidadMedida, Nullable<double> mp_cantidadMinima, Nullable<bool> mp_estado)
        {
            var mp_codigoParameter = mp_codigo != null ?
                new ObjectParameter("mp_codigo", mp_codigo) :
                new ObjectParameter("mp_codigo", typeof(string));
    
            var mp_nombreParameter = mp_nombre != null ?
                new ObjectParameter("mp_nombre", mp_nombre) :
                new ObjectParameter("mp_nombre", typeof(string));
    
            var mp_unidadMedidaParameter = mp_unidadMedida != null ?
                new ObjectParameter("mp_unidadMedida", mp_unidadMedida) :
                new ObjectParameter("mp_unidadMedida", typeof(string));
    
            var mp_cantidadMinimaParameter = mp_cantidadMinima.HasValue ?
                new ObjectParameter("mp_cantidadMinima", mp_cantidadMinima) :
                new ObjectParameter("mp_cantidadMinima", typeof(double));
    
            var mp_estadoParameter = mp_estado.HasValue ?
                new ObjectParameter("mp_estado", mp_estado) :
                new ObjectParameter("mp_estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_mp_insert_NuevaMateriaPrima", mp_codigoParameter, mp_nombreParameter, mp_unidadMedidaParameter, mp_cantidadMinimaParameter, mp_estadoParameter);
        }
    
        public virtual ObjectResult<sp_mp_select_all_Result> sp_mp_select_all()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_mp_select_all_Result>("sp_mp_select_all");
        }
    
        public virtual ObjectResult<sp_mp_select_where_MateriaPrimaPorID_Result> sp_mp_select_where_MateriaPrimaPorID(Nullable<int> mp_id)
        {
            var mp_idParameter = mp_id.HasValue ?
                new ObjectParameter("mp_id", mp_id) :
                new ObjectParameter("mp_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_mp_select_where_MateriaPrimaPorID_Result>("sp_mp_select_where_MateriaPrimaPorID", mp_idParameter);
        }
    
        public virtual ObjectResult<sp_mp_select_where_MateriaPrimaPorNombre_Result> sp_mp_select_where_MateriaPrimaPorNombre(string mp_nombre)
        {
            var mp_nombreParameter = mp_nombre != null ?
                new ObjectParameter("mp_nombre", mp_nombre) :
                new ObjectParameter("mp_nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_mp_select_where_MateriaPrimaPorNombre_Result>("sp_mp_select_where_MateriaPrimaPorNombre", mp_nombreParameter);
        }
    
        public virtual int sp_mp_update_MateriaPrima(Nullable<int> mp_id, Nullable<int> mp_codigo, string mp_nombre, string mp_unidadMedida, Nullable<double> mp_cantidadMinima, Nullable<bool> mp_estado)
        {
            var mp_idParameter = mp_id.HasValue ?
                new ObjectParameter("mp_id", mp_id) :
                new ObjectParameter("mp_id", typeof(int));
    
            var mp_codigoParameter = mp_codigo.HasValue ?
                new ObjectParameter("mp_codigo", mp_codigo) :
                new ObjectParameter("mp_codigo", typeof(int));
    
            var mp_nombreParameter = mp_nombre != null ?
                new ObjectParameter("mp_nombre", mp_nombre) :
                new ObjectParameter("mp_nombre", typeof(string));
    
            var mp_unidadMedidaParameter = mp_unidadMedida != null ?
                new ObjectParameter("mp_unidadMedida", mp_unidadMedida) :
                new ObjectParameter("mp_unidadMedida", typeof(string));
    
            var mp_cantidadMinimaParameter = mp_cantidadMinima.HasValue ?
                new ObjectParameter("mp_cantidadMinima", mp_cantidadMinima) :
                new ObjectParameter("mp_cantidadMinima", typeof(double));
    
            var mp_estadoParameter = mp_estado.HasValue ?
                new ObjectParameter("mp_estado", mp_estado) :
                new ObjectParameter("mp_estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_mp_update_MateriaPrima", mp_idParameter, mp_codigoParameter, mp_nombreParameter, mp_unidadMedidaParameter, mp_cantidadMinimaParameter, mp_estadoParameter);
        }
    
        public virtual int sp_trans_delete_TransferenciaEntradaSalida(Nullable<int> t_id, Nullable<int> t_tipo)
        {
            var t_idParameter = t_id.HasValue ?
                new ObjectParameter("t_id", t_id) :
                new ObjectParameter("t_id", typeof(int));
    
            var t_tipoParameter = t_tipo.HasValue ?
                new ObjectParameter("t_tipo", t_tipo) :
                new ObjectParameter("t_tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_trans_delete_TransferenciaEntradaSalida", t_idParameter, t_tipoParameter);
        }
    
        public virtual int sp_trans_insert_NuevaTransferencia(Nullable<int> t_id_i, Nullable<System.DateTime> t_fecha, string t_descripcion, Nullable<int> t_tipo, Nullable<int> t_id_usuarioCreacion, Nullable<int> t_id_ope)
        {
            var t_id_iParameter = t_id_i.HasValue ?
                new ObjectParameter("t_id_i", t_id_i) :
                new ObjectParameter("t_id_i", typeof(int));
    
            var t_fechaParameter = t_fecha.HasValue ?
                new ObjectParameter("t_fecha", t_fecha) :
                new ObjectParameter("t_fecha", typeof(System.DateTime));
    
            var t_descripcionParameter = t_descripcion != null ?
                new ObjectParameter("t_descripcion", t_descripcion) :
                new ObjectParameter("t_descripcion", typeof(string));
    
            var t_tipoParameter = t_tipo.HasValue ?
                new ObjectParameter("t_tipo", t_tipo) :
                new ObjectParameter("t_tipo", typeof(int));
    
            var t_id_usuarioCreacionParameter = t_id_usuarioCreacion.HasValue ?
                new ObjectParameter("t_id_usuarioCreacion", t_id_usuarioCreacion) :
                new ObjectParameter("t_id_usuarioCreacion", typeof(int));
    
            var t_id_opeParameter = t_id_ope.HasValue ?
                new ObjectParameter("t_id_ope", t_id_ope) :
                new ObjectParameter("t_id_ope", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_trans_insert_NuevaTransferencia", t_id_iParameter, t_fechaParameter, t_descripcionParameter, t_tipoParameter, t_id_usuarioCreacionParameter, t_id_opeParameter);
        }
    
        public virtual int sp_trans_insert_TransferenciaEntradas(Nullable<int> t_id, Nullable<int> t_mp_id, Nullable<double> t_mp_cantidad)
        {
            var t_idParameter = t_id.HasValue ?
                new ObjectParameter("t_id", t_id) :
                new ObjectParameter("t_id", typeof(int));
    
            var t_mp_idParameter = t_mp_id.HasValue ?
                new ObjectParameter("t_mp_id", t_mp_id) :
                new ObjectParameter("t_mp_id", typeof(int));
    
            var t_mp_cantidadParameter = t_mp_cantidad.HasValue ?
                new ObjectParameter("t_mp_cantidad", t_mp_cantidad) :
                new ObjectParameter("t_mp_cantidad", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_trans_insert_TransferenciaEntradas", t_idParameter, t_mp_idParameter, t_mp_cantidadParameter);
        }
    
        public virtual int sp_trans_insert_TransferenciaSalida(Nullable<int> t_id, Nullable<int> t_mp_id, Nullable<double> t_mp_cantidad)
        {
            var t_idParameter = t_id.HasValue ?
                new ObjectParameter("t_id", t_id) :
                new ObjectParameter("t_id", typeof(int));
    
            var t_mp_idParameter = t_mp_id.HasValue ?
                new ObjectParameter("t_mp_id", t_mp_id) :
                new ObjectParameter("t_mp_id", typeof(int));
    
            var t_mp_cantidadParameter = t_mp_cantidad.HasValue ?
                new ObjectParameter("t_mp_cantidad", t_mp_cantidad) :
                new ObjectParameter("t_mp_cantidad", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_trans_insert_TransferenciaSalida", t_idParameter, t_mp_idParameter, t_mp_cantidadParameter);
        }
    
        public virtual ObjectResult<sp_trans_select_all_EntradasSalidas_Result> sp_trans_select_all_EntradasSalidas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_trans_select_all_EntradasSalidas_Result>("sp_trans_select_all_EntradasSalidas");
        }
    
        public virtual ObjectResult<sp_trans_select_where_EntradasSalidas_Result> sp_trans_select_where_EntradasSalidas(Nullable<int> t_id, Nullable<int> t_tipo)
        {
            var t_idParameter = t_id.HasValue ?
                new ObjectParameter("t_id", t_id) :
                new ObjectParameter("t_id", typeof(int));
    
            var t_tipoParameter = t_tipo.HasValue ?
                new ObjectParameter("t_tipo", t_tipo) :
                new ObjectParameter("t_tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_trans_select_where_EntradasSalidas_Result>("sp_trans_select_where_EntradasSalidas", t_idParameter, t_tipoParameter);
        }
    
        public virtual int sp_trans_update_TransferenciaEntrada(Nullable<int> t_id, Nullable<int> t_mp_id, Nullable<double> t_mp_cantidad, Nullable<int> t_mp_idNuevo, Nullable<double> t_mp_cantidadNuevo)
        {
            var t_idParameter = t_id.HasValue ?
                new ObjectParameter("t_id", t_id) :
                new ObjectParameter("t_id", typeof(int));
    
            var t_mp_idParameter = t_mp_id.HasValue ?
                new ObjectParameter("t_mp_id", t_mp_id) :
                new ObjectParameter("t_mp_id", typeof(int));
    
            var t_mp_cantidadParameter = t_mp_cantidad.HasValue ?
                new ObjectParameter("t_mp_cantidad", t_mp_cantidad) :
                new ObjectParameter("t_mp_cantidad", typeof(double));
    
            var t_mp_idNuevoParameter = t_mp_idNuevo.HasValue ?
                new ObjectParameter("t_mp_idNuevo", t_mp_idNuevo) :
                new ObjectParameter("t_mp_idNuevo", typeof(int));
    
            var t_mp_cantidadNuevoParameter = t_mp_cantidadNuevo.HasValue ?
                new ObjectParameter("t_mp_cantidadNuevo", t_mp_cantidadNuevo) :
                new ObjectParameter("t_mp_cantidadNuevo", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_trans_update_TransferenciaEntrada", t_idParameter, t_mp_idParameter, t_mp_cantidadParameter, t_mp_idNuevoParameter, t_mp_cantidadNuevoParameter);
        }
    
        public virtual int sp_trans_update_TransferenciaSalida(Nullable<int> t_id, Nullable<int> t_mp_id, Nullable<double> t_mp_cantidad, Nullable<int> t_mp_idNuevo, Nullable<double> t_mp_cantidadNuevo)
        {
            var t_idParameter = t_id.HasValue ?
                new ObjectParameter("t_id", t_id) :
                new ObjectParameter("t_id", typeof(int));
    
            var t_mp_idParameter = t_mp_id.HasValue ?
                new ObjectParameter("t_mp_id", t_mp_id) :
                new ObjectParameter("t_mp_id", typeof(int));
    
            var t_mp_cantidadParameter = t_mp_cantidad.HasValue ?
                new ObjectParameter("t_mp_cantidad", t_mp_cantidad) :
                new ObjectParameter("t_mp_cantidad", typeof(double));
    
            var t_mp_idNuevoParameter = t_mp_idNuevo.HasValue ?
                new ObjectParameter("t_mp_idNuevo", t_mp_idNuevo) :
                new ObjectParameter("t_mp_idNuevo", typeof(int));
    
            var t_mp_cantidadNuevoParameter = t_mp_cantidadNuevo.HasValue ?
                new ObjectParameter("t_mp_cantidadNuevo", t_mp_cantidadNuevo) :
                new ObjectParameter("t_mp_cantidadNuevo", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_trans_update_TransferenciaSalida", t_idParameter, t_mp_idParameter, t_mp_cantidadParameter, t_mp_idNuevoParameter, t_mp_cantidadNuevoParameter);
        }
    
        public virtual ObjectResult<sp_LoginPermisosXRol_Result> sp_LoginPermisosXRol(Nullable<int> id_rol)
        {
            var id_rolParameter = id_rol.HasValue ?
                new ObjectParameter("id_rol", id_rol) :
                new ObjectParameter("id_rol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LoginPermisosXRol_Result>("sp_LoginPermisosXRol", id_rolParameter);
        }
    
        public virtual ObjectResult<sp_trans_select_where_fechatipo_Result> sp_trans_select_where_fechatipo(Nullable<System.DateTime> p_fecha, Nullable<int> p_tipo)
        {
            var p_fechaParameter = p_fecha.HasValue ?
                new ObjectParameter("p_fecha", p_fecha) :
                new ObjectParameter("p_fecha", typeof(System.DateTime));
    
            var p_tipoParameter = p_tipo.HasValue ?
                new ObjectParameter("p_tipo", p_tipo) :
                new ObjectParameter("p_tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_trans_select_where_fechatipo_Result>("sp_trans_select_where_fechatipo", p_fechaParameter, p_tipoParameter);
        }
    
        public virtual ObjectResult<sp_compras_select_all_Result> sp_compras_select_all()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_compras_select_all_Result>("sp_compras_select_all");
        }
    
        public virtual ObjectResult<sp_compra_select_where_CompraporID_Result> sp_compra_select_where_CompraporID(Nullable<int> c_id)
        {
            var c_idParameter = c_id.HasValue ?
                new ObjectParameter("c_id", c_id) :
                new ObjectParameter("c_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_compra_select_where_CompraporID_Result>("sp_compra_select_where_CompraporID", c_idParameter);
        }
    
        public virtual int sp_compra_update_compra(Nullable<int> c_id, Nullable<int> c_id_i, string c_codigoFactura, string c_descripcion, Nullable<int> c_id_usuarioCreacion, Nullable<int> c_id_ope)
        {
            var c_idParameter = c_id.HasValue ?
                new ObjectParameter("c_id", c_id) :
                new ObjectParameter("c_id", typeof(int));
    
            var c_id_iParameter = c_id_i.HasValue ?
                new ObjectParameter("c_id_i", c_id_i) :
                new ObjectParameter("c_id_i", typeof(int));
    
            var c_codigoFacturaParameter = c_codigoFactura != null ?
                new ObjectParameter("c_codigoFactura", c_codigoFactura) :
                new ObjectParameter("c_codigoFactura", typeof(string));
    
            var c_descripcionParameter = c_descripcion != null ?
                new ObjectParameter("c_descripcion", c_descripcion) :
                new ObjectParameter("c_descripcion", typeof(string));
    
            var c_id_usuarioCreacionParameter = c_id_usuarioCreacion.HasValue ?
                new ObjectParameter("c_id_usuarioCreacion", c_id_usuarioCreacion) :
                new ObjectParameter("c_id_usuarioCreacion", typeof(int));
    
            var c_id_opeParameter = c_id_ope.HasValue ?
                new ObjectParameter("c_id_ope", c_id_ope) :
                new ObjectParameter("c_id_ope", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_compra_update_compra", c_idParameter, c_id_iParameter, c_codigoFacturaParameter, c_descripcionParameter, c_id_usuarioCreacionParameter, c_id_opeParameter);
        }
    
        public virtual int sp_c_compra_Update_(Nullable<int> c_id, Nullable<int> c_id_i, string c_codigoFactura, string c_descripcion, Nullable<int> c_id_usuarioCreacion, Nullable<int> c_id_ope)
        {
            var c_idParameter = c_id.HasValue ?
                new ObjectParameter("c_id", c_id) :
                new ObjectParameter("c_id", typeof(int));
    
            var c_id_iParameter = c_id_i.HasValue ?
                new ObjectParameter("c_id_i", c_id_i) :
                new ObjectParameter("c_id_i", typeof(int));
    
            var c_codigoFacturaParameter = c_codigoFactura != null ?
                new ObjectParameter("c_codigoFactura", c_codigoFactura) :
                new ObjectParameter("c_codigoFactura", typeof(string));
    
            var c_descripcionParameter = c_descripcion != null ?
                new ObjectParameter("c_descripcion", c_descripcion) :
                new ObjectParameter("c_descripcion", typeof(string));
    
            var c_id_usuarioCreacionParameter = c_id_usuarioCreacion.HasValue ?
                new ObjectParameter("c_id_usuarioCreacion", c_id_usuarioCreacion) :
                new ObjectParameter("c_id_usuarioCreacion", typeof(int));
    
            var c_id_opeParameter = c_id_ope.HasValue ?
                new ObjectParameter("c_id_ope", c_id_ope) :
                new ObjectParameter("c_id_ope", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_c_compra_Update_", c_idParameter, c_id_iParameter, c_codigoFacturaParameter, c_descripcionParameter, c_id_usuarioCreacionParameter, c_id_opeParameter);
        }
    }
}
