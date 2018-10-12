
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
    public class Region
    {


        #region " Metodo LoadRow "
        public static RegionDTO LoadRow(SqlDataReader myDataReader)
        {
            RegionDTO theRegionDTO = new RegionDTO();
            try
            {
                if (myDataReader != null)
                {
                    // categoria_id
                    try
                    {
                        if (!myDataReader.IsDBNull(0))
                            theRegionDTO.IdRegion = myDataReader.GetInt32(0).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    // cate_descripcion
                    try
                    {
                        if (!myDataReader.IsDBNull(1))
                            theRegionDTO.Descripcion = myDataReader.GetString(1);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(2))
                            theRegionDTO.IdPais = myDataReader.GetInt32(2).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            theRegionDTO.UsuarioIngreso = myDataReader.GetString(3);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(4))
                            theRegionDTO.FechaIngreso = myDataReader.GetDateTime(4).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(5))
                            theRegionDTO.UsuarioModificacion = myDataReader.GetString(5);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(6))
                            theRegionDTO.FechaModificacion = myDataReader.GetDateTime(6).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(7))
                            theRegionDTO.IdCondominio = myDataReader.GetDecimal(7);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(8))
                            theRegionDTO.Estado = myDataReader.GetInt32(8).ToString();
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
            return theRegionDTO;
        }
        #endregion // Constructor con Llave Primaria

        #region " Metodo ElementsPersistencePortal "
        public static bool ListadoRegiones( ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaRegion",
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
        #endregion // ElementsPersistencePortal
    }
}
