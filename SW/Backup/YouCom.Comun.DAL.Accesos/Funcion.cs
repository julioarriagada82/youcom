using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;
using System.Data.SqlClient;
using Intermedia.IMSystem.IMUtil;
using System.Data;
using YouCom.Comun.DAL.Accesos;

namespace YouCom.Comun.DAL.Accesos
{
    public class Funcion
    {

        #region " Metodo LoadRow "
        public static FuncionDTO LoadRow(SqlDataReader myDataReader)
        {
            FuncionDTO theFuncionDTO = new FuncionDTO();
            try
            {
                if (myDataReader != null)
                {
                    // categoria_id
                    try
                    {
                        if (!myDataReader.IsDBNull(0))
                            theFuncionDTO.FuncionCod = myDataReader.GetInt32(0).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    // cate_descripcion
                    try
                    {
                        if (!myDataReader.IsDBNull(1))
                            theFuncionDTO.FuncionNombre = myDataReader.GetString(1);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(2))
                            theFuncionDTO.FuncionTipoCod = myDataReader.GetInt32(2).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            theFuncionDTO.FuncionGrupoCod = myDataReader.GetInt32(3).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(4))
                            theFuncionDTO.Url = myDataReader.GetString(4);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(5))
                            theFuncionDTO.FuncionalidadNegocio = myDataReader.GetString(5);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(6))
                            theFuncionDTO.UsuarioIngreso = myDataReader.GetString(7); 
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(7))
                            theFuncionDTO.FechaIngreso = myDataReader.GetDateTime(6).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(8))
                            theFuncionDTO.UsuarioModificacion = myDataReader.GetString(8);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(9))
                            theFuncionDTO.FechaModificacion = myDataReader.GetDateTime(9).ToString();
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(10))
                            theFuncionDTO.IdCondominio = myDataReader.GetDecimal(10);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(11))
                            theFuncionDTO.Estado = myDataReader.GetInt32(11).ToString();
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
            return theFuncionDTO;
        }
        #endregion // Constructor con Llave Primaria

        
        public static bool ListadoFuncion(ref DataTable pobjDataTable)
        {
               bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaFuncion",
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
