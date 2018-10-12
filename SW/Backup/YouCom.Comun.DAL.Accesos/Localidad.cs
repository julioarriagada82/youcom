/**
 * (c)1996-2006 Inter Media S.A. Todos los Derechos Reservados.
 *
 * El uso de este programa y/o la documentación asociada, ya sea en forma
 * de fuentes o archivos binarios, con o sin modificaciones,
 * esta sujeto a la licencia descrita en LICENCIA.TXT.
 **/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Intermedia.IMSystem.IMUtil;
using YouCom.DTO;

namespace YouCom.Comun.DAL.Accesos
{
    public class Localidad
    {

        #region " Metodo LoadRow "
        public static LocalidadDTO LoadRow(SqlDataReader myDataReader)
        {
            LocalidadDTO theLocalidadDTO = new LocalidadDTO();
            try
            {
                if (myDataReader != null)
                {
                    // categoria_id
                    try
                    {
                        if (!myDataReader.IsDBNull(0))
                            theLocalidadDTO.IdLocalidad = myDataReader.GetInt32(0).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    // categoria_id
                    try
                    {
                        if (!myDataReader.IsDBNull(1))
                            theLocalidadDTO.IdRegion = myDataReader.GetInt32(1).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    // cate_descripcion
                    try
                    {
                        if (!myDataReader.IsDBNull(2))
                            theLocalidadDTO.Descripcion = myDataReader.GetString(2);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            theLocalidadDTO.UsuarioIngreso = myDataReader.GetString(3);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(4))
                            theLocalidadDTO.FechaIngreso = myDataReader.GetDateTime(4).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(5))
                            theLocalidadDTO.UsuarioModificacion = myDataReader.GetString(5);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(6))
                            theLocalidadDTO.FechaModificacion = myDataReader.GetDateTime(6).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(7))
                            theLocalidadDTO.Estado = myDataReader.GetInt32(7).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
            }
            return theLocalidadDTO;
        }
        #endregion // Constructor con Llave Primaria

       
        public static bool ListadoLocalidadByRegion(int idRegion, ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                wobjSQLHelper.SetParametro("@id_reg", SqlDbType.Int, 12, idRegion);

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_ListadoLocalidadByRegion",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
                //====================================================================================
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
            #endregion


        }
        public static bool ListadoLocalidad(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {


                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_ListadoLocalidad",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
                //====================================================================================
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
            #endregion

        }
    }
}
