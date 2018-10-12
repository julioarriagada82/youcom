using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;
using System.Data.SqlClient;
using System.Data;
using Intermedia.IMSystem.IMUtil;

namespace YouCom.Comun.DAL.Accesos
{
    public class FuncionTipo
    {
        #region " Metodo LoadRow "
        public static FuncionTipoDTO LoadRow(SqlDataReader myDataReader)
        {
            FuncionTipoDTO theFuncionTipoDTO = new FuncionTipoDTO();
            try
            {
                if (myDataReader != null)
                {
                    // categoria_id
                    try
                    {
                        if (!myDataReader.IsDBNull(0))
                            theFuncionTipoDTO.FuncionTipoCod = myDataReader.GetInt32(0).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    // cate_descripcion
                    try
                    {
                        if (!myDataReader.IsDBNull(1))
                            theFuncionTipoDTO.FuncionTipoNombre = myDataReader.GetString(1);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(2))
                            theFuncionTipoDTO.UsuarioIngreso = myDataReader.GetString(2);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            theFuncionTipoDTO.FechaIngreso = myDataReader.GetDateTime(3).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(4))
                            theFuncionTipoDTO.UsuarioModificacion = myDataReader.GetString(4);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(5))
                            theFuncionTipoDTO.FechaModificacion = myDataReader.GetDateTime(5).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(6))
                            theFuncionTipoDTO.TheCondominioDTO.IdCondominio = myDataReader.GetDecimal(6);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(7))
                            theFuncionTipoDTO.Estado = myDataReader.GetInt32(7).ToString();
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
            return theFuncionTipoDTO;
        }
        #endregion // Constructor con Llave Primaria

       
        public static bool ListadoFuncionTipo(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaFuncionTipo",
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
