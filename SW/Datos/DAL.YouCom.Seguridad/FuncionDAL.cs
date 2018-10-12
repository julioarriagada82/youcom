using System;
using System.Data;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.DAL
{
    public class FuncionDAL
    {
        public static bool ListaFunciones(int FuncionGrupo, ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                wobjSQLHelper.SetParametro("@FuncionGrupoCod", SqlDbType.VarChar, 20, FuncionGrupo);

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_listaFuncionesGrupo",
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

        public static bool ListaFuncionGrupoSistema(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("GetFuncionalidadesSistema",
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

        public static bool InsertFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@NombreFuncion", SqlDbType.VarChar, 20, theFuncionDTO.FuncionNombre);
            wobjSQLHelper.SetParametro("@Tipo", SqlDbType.Int, 20, theFuncionDTO.FuncionTipoCod);
            wobjSQLHelper.SetParametro("@Grupo", SqlDbType.Int, 20, theFuncionDTO.FuncionGrupoCod);
            wobjSQLHelper.SetParametro("@Url", SqlDbType.VarChar, 20, theFuncionDTO.Url);
            wobjSQLHelper.SetParametro("@FuncionalidadNegocio", SqlDbType.VarChar, 20, theFuncionDTO.EnviaCorreo);
            wobjSQLHelper.SetParametro("@enviaCorreo", SqlDbType.VarChar, 20, theFuncionDTO.EnviaCorreo);



            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Funcion", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================
                retorno = true;


            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool ActivaFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);


            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Funcion", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================
                retorno = true;


            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool UpdateFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionNombre", SqlDbType.VarChar, 20, theFuncionDTO.FuncionNombre);
            wobjSQLHelper.SetParametro("@FuncionCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);
            wobjSQLHelper.SetParametro("@funcionTipoCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionTipoCod);
            wobjSQLHelper.SetParametro("@funcionGrpCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionGrupoCod);
            wobjSQLHelper.SetParametro("@url", SqlDbType.VarChar, 20, theFuncionDTO.Url);
            wobjSQLHelper.SetParametro("@funcionalidadNegocio", SqlDbType.VarChar, 20, theFuncionDTO.FuncionalidadNegocio);
            wobjSQLHelper.SetParametro("@envioCorreo", SqlDbType.VarChar, 20, theFuncionDTO.EnviaCorreo);

            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_Funcion", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================
                retorno = true;


            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool DeleteFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);

            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_Funcion", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================
                retorno = true;


            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool ValidaEliminacionFuncion(FuncionDTO theFuncionDTO, ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@idTipoTarea", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionTipoTarea", "YouCom", pobjDatable) <= 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;

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
