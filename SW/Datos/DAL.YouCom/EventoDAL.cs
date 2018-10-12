using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class EventoDAL
    {
        #region " Metodo getListadoEvento "
        public static bool getListadoEvento(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEvento",
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
        public static bool Insert(YouCom.DTO.EventoDTO myEventoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myEventoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myEventoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myEventoDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pEventoTitulo", SqlDbType.VarChar, 200, myEventoDTO.EventoTitulo);
                wobjSQLHelper.SetParametro("@pEventoResumen", SqlDbType.VarChar, 500, myEventoDTO.EventoResumen);
                wobjSQLHelper.SetParametro("@pEventoDetalle", SqlDbType.Text, -1, myEventoDTO.EventoDetalle);
                wobjSQLHelper.SetParametro("@pEventoPublicacion", SqlDbType.DateTime, -1, myEventoDTO.EventoPublicacion);
                wobjSQLHelper.SetParametro("@pEventoInicio", SqlDbType.DateTime, -1, myEventoDTO.EventoInicio);
                wobjSQLHelper.SetParametro("@pEventoExpiracion", SqlDbType.DateTime, -1, myEventoDTO.EventoExpiracion);
                wobjSQLHelper.SetParametro("@pEventoAutor", SqlDbType.VarChar, 200, myEventoDTO.EventoAutor);
                wobjSQLHelper.SetParametro("@pEventoImagen", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myEventoDTO.EventoImagen) ? myEventoDTO.EventoImagen : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myEventoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Evento", "YouCom"))
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
        public static bool Update(YouCom.DTO.EventoDTO myEventoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pEventoId", SqlDbType.Decimal, -1, myEventoDTO.EventoId);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myEventoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myEventoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myEventoDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pEventoTitulo", SqlDbType.VarChar, 200, myEventoDTO.EventoTitulo);
                wobjSQLHelper.SetParametro("@pEventoResumen", SqlDbType.VarChar, 500, myEventoDTO.EventoResumen);
                wobjSQLHelper.SetParametro("@pEventoDetalle", SqlDbType.Text, -1, myEventoDTO.EventoDetalle);
                wobjSQLHelper.SetParametro("@pEventoPublicacion", SqlDbType.DateTime, -1, myEventoDTO.EventoPublicacion);
                wobjSQLHelper.SetParametro("@pEventoInicio", SqlDbType.DateTime, -1, myEventoDTO.EventoInicio);
                wobjSQLHelper.SetParametro("@pEventoExpiracion", SqlDbType.DateTime, -1, myEventoDTO.EventoExpiracion);
                wobjSQLHelper.SetParametro("@pEventoAutor", SqlDbType.VarChar, 20, myEventoDTO.EventoAutor);
                wobjSQLHelper.SetParametro("@pEventoImagen", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myEventoDTO.EventoImagen) ? myEventoDTO.EventoImagen : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myEventoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Evento", "YouCom"))
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
        public static bool Delete(YouCom.DTO.EventoDTO myEventoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pEventoId", SqlDbType.Decimal, -1, myEventoDTO.EventoId);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myEventoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Evento", "YouCom"))
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

        public static bool ActivaEvento(YouCom.DTO.EventoDTO theEventoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theEventoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdEvento", SqlDbType.VarChar, 20, theEventoDTO.EventoId);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Evento", "YouCom"))
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

        public static bool ValidaEliminacionEvento(DTO.EventoDTO theEventoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idEvento", SqlDbType.VarChar, 20, theEventoDTO.EventoId);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionEvento", "YouCom", pobjDatatable) <= 0)
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
