﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeInventariosSCIR.BussinessEntities;
using ControlDeInventariosSCIR.DataAccess;
using System.Data.SqlClient;



namespace ControlDeInventariosSCIR.DataAccess
{
    public static class MateriaPrimaDAL
    {
        //No funciona da error
        //no funciona luego la eliminare
        //funcion que solo obtiene los nombre de las materias primas registradas
        /*  public static List<mp_materiaPrima> mpnombre(mp_materiaPrima mp){
              SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
              List<mp_materiaPrima> mpname = new List<mp_materiaPrima>();
              //llamado al sp de compras
              var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_nombre").ToList<mp_materiaPrima>();
              //comprueba que sea diferente a null
              if (filas != null)
              {
                  return filas;
              }
              return null;
          }
         */
        //funcion q obtiene todos los datos de las materias primas

        public static string GetNombre(mp_materiaPrima mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_buscar_mpnombre @mp_codigo",new SqlParameter("@mp_codigo",mp.mp_codigo)).ToArray<mp_materiaPrima>();
            string cad = filas.ToString();
            return cad;
        }
        public static List<mp_materiaPrima> GetDatos(mp_materiaPrima mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            List<mp_materiaPrima> com = new List<mp_materiaPrima>();
            //llamado al sp de compras
            var filas = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_all").ToList<mp_materiaPrima>();
            //comprueba que sea diferente a null
            if (filas != null)
            {
                return filas;
            }
            return null;

        }

        //funcion q obtiene los datos de materias primas por idmp
        public static mp_materiaPrima GetDatosMp(int mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            var datos = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_where_MateriaPrimaPorID @mp_id", new SqlParameter("@mp_id", mp)).ToArray<mp_materiaPrima>().FirstOrDefault();
            try
            {
                if (datos != null)
                    return datos;
                else
                    return null;
            }
            catch(Exception e)
            {
                Console.Write(e);
                return null;
            }
        }
        //funcion q obtiene datos a partir de la busqueda
        public static mp_materiaPrima GetResultado(mp_materiaPrima mp)
        {
            SCIR_SistemaInventarioEntities scir = new SCIR_SistemaInventarioEntities();
            if (mp.mp_nombre == null)
            {
                return null;
            }
            else
            {
                var registro = scir.Database.SqlQuery<mp_materiaPrima>("sp_mp_select_where_MateriaPrimaPorNombre  @mp_nombre ", new SqlParameter("@mp_nombre", mp.mp_nombre)).ToList<mp_materiaPrima>().FirstOrDefault() ;
                if (registro != null)
                {
                    return registro;
                }

                return null;

            }
        }
    }
}


