using System;
using System.Data;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.DAL
{
    public class UsuarioDAL
    {
        #region " Metodo getListadoUsuario "
        public static bool getListadoUsuario(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_listaUsuarios",
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
            #endregion

            return retorno;
        }
        #endregion // ElementsPersistence

        /// <summary>
        /// Agregar un usuario
        /// </summary>
        /// <param name="UsuarioDTO"></param>
        /// <returns></returns>
        public static bool Insert(OperadorDTO myUsuarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myUsuarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myUsuarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdPerfil", SqlDbType.Decimal, -1, myUsuarioDTO.ThePerfilDTO.IdPerfil);
                wobjSQLHelper.SetParametro("@pRut", SqlDbType.VarChar, 12, myUsuarioDTO.Rut);
                wobjSQLHelper.SetParametro("@pPassword", SqlDbType.VarChar, 12, myUsuarioDTO.Password);
                wobjSQLHelper.SetParametro("@pNombreUsuario", SqlDbType.VarChar, 200, myUsuarioDTO.Nombres);
                wobjSQLHelper.SetParametro("@pPaternoUsuario", SqlDbType.VarChar, 200, myUsuarioDTO.Paterno);
                wobjSQLHelper.SetParametro("@pMaternoUsuario", SqlDbType.VarChar, 200, myUsuarioDTO.Materno);
                wobjSQLHelper.SetParametro("@pFechaNacimiento", SqlDbType.DateTime, -1, myUsuarioDTO.FechaNacimiento);
                wobjSQLHelper.SetParametro("@pMailUsuario", SqlDbType.VarChar, 100, myUsuarioDTO.Mail);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 50, myUsuarioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("ins_usuario", "YouCom"))
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

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }

        public static bool Update(OperadorDTO myUsuarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myUsuarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myUsuarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdPerfil", SqlDbType.Decimal, -1, myUsuarioDTO.ThePerfilDTO.IdPerfil);
                wobjSQLHelper.SetParametro("@pRut", SqlDbType.VarChar, 12, myUsuarioDTO.Rut);
                wobjSQLHelper.SetParametro("@pPassword", SqlDbType.VarChar, 12, myUsuarioDTO.Password);
                wobjSQLHelper.SetParametro("@pNombreUsuario", SqlDbType.VarChar, 200, myUsuarioDTO.Nombres);
                wobjSQLHelper.SetParametro("@pPaternoUsuario", SqlDbType.VarChar, 200, myUsuarioDTO.Paterno);
                wobjSQLHelper.SetParametro("@pMaternoUsuario", SqlDbType.VarChar, 200, myUsuarioDTO.Materno);
                wobjSQLHelper.SetParametro("@pFechaNacimiento", SqlDbType.DateTime, -1, myUsuarioDTO.FechaNacimiento);
                wobjSQLHelper.SetParametro("@pMailUsuario", SqlDbType.VarChar, 100, myUsuarioDTO.Mail);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 50, myUsuarioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_USUARIO", "YouCom"))
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

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }

        #region " Metodo Delete "
        public static bool Delete(YouCom.DTO.Seguridad.OperadorDTO myUsuarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRut", SqlDbType.Decimal, -1, myUsuarioDTO.Rut);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myUsuarioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Usuario", "YouCom"))
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

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // Metodo SaveOrUpdatePersistence

        public static bool ActivaUsuario(YouCom.DTO.Seguridad.OperadorDTO theUsuarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theUsuarioDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pRut", SqlDbType.VarChar, 20, theUsuarioDTO.Rut);

            try
            {
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Usuario", "YouCom"))
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

        public static bool ValidaEliminacionUsuario(YouCom.DTO.Seguridad.OperadorDTO theUsuarioDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pRut", SqlDbType.VarChar, 20, theUsuarioDTO.Rut);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionUsuario", "YouCom", pobjDatatable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
    }
}
