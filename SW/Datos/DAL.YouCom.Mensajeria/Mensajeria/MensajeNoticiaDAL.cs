using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL
{
    public class MensajeNoticiaDAL
    {
        #region " Metodo getMensajeNoticia "
        public static bool getListadoMensajeNoticia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoMensajeNoticia",
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
        public static bool Insert(YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamiliaOrigen", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheFamiliaOrigenDTO.IdFamilia > 0 ? myMensajeNoticiaDTO.TheFamiliaOrigenDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamiliaDestino", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myMensajeNoticiaDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajeNoticiaDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajeNoticiaDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajeNoticiaDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myMensajeNoticiaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_MensajeNoticia", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamiliaOrigen", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheFamiliaOrigenDTO.IdFamilia > 0 ? myMensajeNoticiaDTO.TheFamiliaOrigenDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamiliaDestino", SqlDbType.Decimal, -1, myMensajeNoticiaDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myMensajeNoticiaDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajeNoticiaDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajeNoticiaDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajeNoticiaDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myMensajeNoticiaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_MensajeNoticia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, theMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theMensajeNoticiaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_MensajeNoticia", "YouCom"))
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

        public static bool ActivaMensajeNoticia(YouCom.DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theMensajeNoticiaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, theMensajeNoticiaDTO.IdMensajeNoticia);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_MensajeNoticia", "YouCom"))
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

        public static bool ValidaEliminacionMensajeNoticia(DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, theMensajeNoticiaDTO.IdMensajeNoticia);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionMensajeNoticia", "YouCom", pobjDatatable) <= 0)
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
