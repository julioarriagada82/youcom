﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.Mensajeria.DAL
{
    public class MensajePorteriaDAL
    {
        #region " Metodo getMensajePorteria "
        public static bool getListadoMensajePorteria(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoMensajePorteria",
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
        public static bool Insert(YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajePorteriaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia > 0 ? myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdPorteria", SqlDbType.Decimal, -1, myMensajePorteriaDTO.ThePorteriaDTO.IdPorteria > 0 ? myMensajePorteriaDTO.ThePorteriaDTO.IdPorteria : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdMensajeTipoEnvio", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheMensajeTipoEnvioDTO.IdMensajeTipoEnvio);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajePorteriaDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajePorteriaDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajePorteriaDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myMensajePorteriaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_MensajePorteria", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajePorteriaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia > 0 ? myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdPorteria", SqlDbType.Decimal, -1, myMensajePorteriaDTO.ThePorteriaDTO.IdPorteria > 0 ? myMensajePorteriaDTO.ThePorteriaDTO.IdPorteria : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdMensajeTipoEnvio", SqlDbType.Decimal, -1, myMensajePorteriaDTO.TheMensajeTipoEnvioDTO.IdMensajeTipoEnvio);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajePorteriaDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajePorteriaDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajePorteriaDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myMensajePorteriaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_MensajePorteria", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myMensajePorteriaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_MensajePorteria", "YouCom"))
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

        public static bool ActivaMensajePorteria(YouCom.DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theMensajePorteriaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.VarChar, 20, theMensajePorteriaDTO.IdMensajePorteria);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_MensajePorteria", "YouCom"))
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

        public static bool ValidaEliminacionMensajePorteria(DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idMensajePorteria", SqlDbType.VarChar, 20, theMensajePorteriaDTO.IdMensajePorteria);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionMensajePorteria", "YouCom", pobjDatatable) <= 0)
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