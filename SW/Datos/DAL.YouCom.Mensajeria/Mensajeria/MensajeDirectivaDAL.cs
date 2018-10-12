using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL
{
    public class MensajeDirectivaDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoMensajeDirectiva(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoMensajeDirectiva",
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

        #region " Metodo Insert "
        public static bool Insert(YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeAdministradorDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdMensajeTipoEnvio", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheMensajeTipoEnvioDTO.IdMensajeTipoEnvio);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheFamiliaDTO.IdFamilia > 0 ? myMensajeAdministradorDTO.TheFamiliaDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdDirectiva", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheDirectivaDTO.IdDirectiva > 0 ? myMensajeAdministradorDTO.TheDirectivaDTO.IdDirectiva : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajeAdministradorDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajeAdministradorDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajeAdministradorDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myMensajeAdministradorDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_MensajeDirectiva", "YouCom"))
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

        #region " Metodo Update "
        public static bool Update(YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeAdministradorDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdMensajeTipoEnvio", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheMensajeTipoEnvioDTO.IdMensajeTipoEnvio);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheFamiliaDTO.IdFamilia > 0 ? myMensajeAdministradorDTO.TheFamiliaDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdDirectiva", SqlDbType.Decimal, -1, myMensajeAdministradorDTO.TheDirectivaDTO.IdDirectiva > 0 ? myMensajeAdministradorDTO.TheDirectivaDTO.IdDirectiva : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajeAdministradorDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajeAdministradorDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajeAdministradorDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myMensajeAdministradorDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_MensajeDirectiva", "YouCom"))
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

        #region " Metodo Delete "
        public static bool Delete(YouCom.DTO.Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, theMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theMensajeDirectivaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_MensajeAdministrador", "YouCom"))
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

        public static bool ActivaMensajeDirectiva(YouCom.DTO.Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theMensajeDirectivaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, theMensajeDirectivaDTO.IdMensajeDirectiva);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_MensajeAdministrador", "YouCom"))
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

        public static bool ValidaEliminacionMensajeDirectiva(DTO.Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, theMensajeDirectivaDTO.IdMensajeDirectiva);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionMensajeAdministrador", "YouCom", pobjDatatable) <= 0)
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
