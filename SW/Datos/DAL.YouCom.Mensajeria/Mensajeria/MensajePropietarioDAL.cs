using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL
{
    public class MensajePropietarioDAL
    {
        #region " Metodo getMensajePropietario "
        public static bool getListadoMensajePropietario(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoMensajePropietario",
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
        public static bool Insert(YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajePropietarioDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamiliaOrigen", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheFamiliaOrigenDTO.IdFamilia > 0 ? myMensajePropietarioDTO.TheFamiliaOrigenDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamiliaDestino", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myMensajePropietarioDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajePropietarioDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajePropietarioDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajePropietarioDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myMensajePropietarioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_MensajePropietario", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myMensajePropietarioDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdFamiliaOrigen", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheFamiliaOrigenDTO.IdFamilia > 0 ? myMensajePropietarioDTO.TheFamiliaOrigenDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamiliaDestino", SqlDbType.Decimal, -1, myMensajePropietarioDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myMensajePropietarioDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaMensaje", SqlDbType.DateTime, -1, myMensajePropietarioDTO.MensajeFecha);
                wobjSQLHelper.SetParametro("@pTituloMensaje", SqlDbType.Text, -1, myMensajePropietarioDTO.MensajeTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionMensaje", SqlDbType.Text, -1, myMensajePropietarioDTO.MensajeDescripcion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myMensajePropietarioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_MensajePropietario", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, theMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theMensajePropietarioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_MensajePropietario", "YouCom"))
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

        public static bool ActivaMensajePropietario(YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theMensajePropietarioDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, theMensajePropietarioDTO.IdMensajePropietario);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_MensajePropietario", "YouCom"))
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

        public static bool ValidaEliminacionMensajePropietario(DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, theMensajePropietarioDTO.IdMensajePropietario);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionMensajePropietario", "YouCom", pobjDatatable) <= 0)
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
