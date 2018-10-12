using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using YouCom.DTO;
using System.Data;
using Intermedia.IMSystem.IMUtil;

namespace YouCom.Comun.DAL.Accesos
{
   public  class Pais
    {
        public static PaisDTO LoadRow(SqlDataReader myDataReader)
        {
            PaisDTO thePaisDTO = new PaisDTO();

            try
            {
                if (myDataReader != null)
                {
                    // idCargo
                    try
                    {
                        if (!myDataReader.IsDBNull(0))
                            thePaisDTO.IdPais = myDataReader.GetInt32(0).ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(1))
                            thePaisDTO.Descripcion = myDataReader.GetString(1);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    // descripcion

                    try
                    {
                        if (!myDataReader.IsDBNull(2))
                            thePaisDTO.UsuarioIngreso = myDataReader.GetString(2);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            thePaisDTO.FechaIngreso = myDataReader.GetDateTime(3).ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(4))
                            thePaisDTO.UsuarioModificacion = myDataReader.GetString(4);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(5))
                            thePaisDTO.FechaModificacion = myDataReader.GetDateTime(5).ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(6))
                            thePaisDTO.IdCondominio = myDataReader.GetDecimal(6);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(7))
                            thePaisDTO.Estado = myDataReader.GetInt32(7).ToString();
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
            return thePaisDTO;
        }
        public static bool ListadoPais(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {


                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaPais",
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
