using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Intermedia.IMSystem.IMUtil;
using YouCom.DTO.Seguridad;
using System.Data;

namespace YouCom.Comun.DAL.Accesos
{
    public class FuncionGrupo
    {
        public static FuncionGrupoDTO LoadRow(SqlDataReader myDataReader)
        {
            FuncionGrupoDTO theFuncionGrupoDTO = new FuncionGrupoDTO();
            try
            {
                if (myDataReader != null)
                {
                    // categoria_id
                    try
                    {
                        if (!myDataReader.IsDBNull(0))
                            theFuncionGrupoDTO.FuncionGrupoCod = myDataReader.GetInt32(0).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    // cate_descripcion
                    try
                    {
                        if (!myDataReader.IsDBNull(1))
                            theFuncionGrupoDTO.FuncionGrupoNombre = myDataReader.GetString(1);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        if (!myDataReader.IsDBNull(2))
                            theFuncionGrupoDTO.UsuarioIngreso = myDataReader.GetString(2);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            theFuncionGrupoDTO.FechaIngreso = myDataReader.GetDateTime(3).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(4))
                            theFuncionGrupoDTO.UsuarioModificacion = myDataReader.GetString(4);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(5))
                            theFuncionGrupoDTO.FechaModificacion = myDataReader.GetDateTime(5).ToString();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(6))
                            theFuncionGrupoDTO.IdCondominio = myDataReader.GetDecimal(6);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!myDataReader.IsDBNull(7))
                            theFuncionGrupoDTO.Estado = myDataReader.GetInt32(7).ToString();
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
            return theFuncionGrupoDTO;
        }
       

        public static bool ListadoFuncionGrupo(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaFuncionGrupo",
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

         

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;

        }
    }

}