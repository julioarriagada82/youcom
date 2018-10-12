using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class NoticiaDAL
    {
        #region " Metodo getListadoNoticia "
        public static bool getListadoNoticia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoNoticia",
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
        public static bool Insert(YouCom.DTO.NoticiaDTO myNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNoticiaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNoticiaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myNoticiaDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pNoticiaTitulo", SqlDbType.VarChar, 200, myNoticiaDTO.NotiTitulo);
                wobjSQLHelper.SetParametro("@pNoticiaResumen", SqlDbType.VarChar, 500, myNoticiaDTO.NotiResumen);
                wobjSQLHelper.SetParametro("@pNoticiaDetalle", SqlDbType.Text, -1, myNoticiaDTO.NotiDetalle);
                wobjSQLHelper.SetParametro("@pNoticiaPublicacion", SqlDbType.DateTime, -1, myNoticiaDTO.NotiPublicacion);
                wobjSQLHelper.SetParametro("@pNoticiaInicio", SqlDbType.DateTime, -1, myNoticiaDTO.NotiInicio);
                wobjSQLHelper.SetParametro("@pNoticiaExpira", SqlDbType.Char, 1, myNoticiaDTO.NotiExpira);
                wobjSQLHelper.SetParametro("@pNoticiaExpiracion", SqlDbType.DateTime, -1, myNoticiaDTO.NotiExpiracion);
                wobjSQLHelper.SetParametro("@pNoticiaAutor", SqlDbType.VarChar, 200, myNoticiaDTO.NotiAutor);
                wobjSQLHelper.SetParametro("@pNoticiaImagen", SqlDbType.VarChar, 200, myNoticiaDTO.NotiImagen);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myNoticiaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Noticia", "YouCom"))
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
        public static bool Update(YouCom.DTO.NoticiaDTO myNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pNoticiaId", SqlDbType.Decimal, -1, myNoticiaDTO.NoticiaId);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNoticiaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNoticiaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myNoticiaDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pNoticiaTitulo", SqlDbType.VarChar, 200, myNoticiaDTO.NotiTitulo);
                wobjSQLHelper.SetParametro("@pNoticiaResumen", SqlDbType.VarChar, 500, myNoticiaDTO.NotiResumen);
                wobjSQLHelper.SetParametro("@pNoticiaDetalle", SqlDbType.Text, -1, myNoticiaDTO.NotiDetalle);
                wobjSQLHelper.SetParametro("@pNoticiaPublicacion", SqlDbType.DateTime, -1, myNoticiaDTO.NotiPublicacion);
                wobjSQLHelper.SetParametro("@pNoticiaInicio", SqlDbType.DateTime, -1, myNoticiaDTO.NotiInicio);
                wobjSQLHelper.SetParametro("@pNoticiaExpira", SqlDbType.Char, 1, myNoticiaDTO.NotiExpira);
                wobjSQLHelper.SetParametro("@pNoticiaExpiracion", SqlDbType.DateTime, -1, myNoticiaDTO.NotiExpiracion);
                wobjSQLHelper.SetParametro("@pNoticiaAutor", SqlDbType.VarChar, 200, myNoticiaDTO.NotiAutor);
                wobjSQLHelper.SetParametro("@pNoticiaImagen", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myNoticiaDTO.NotiImagen) ? myNoticiaDTO.NotiImagen : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myNoticiaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Noticia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.NoticiaDTO theNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pNoticiaId", SqlDbType.Decimal, -1, theNoticiaDTO.NoticiaId);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theNoticiaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Noticia", "YouCom"))
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

        public static bool ActivaNoticia(YouCom.DTO.NoticiaDTO theNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theNoticiaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdNoticia", SqlDbType.VarChar, 20, theNoticiaDTO.NoticiaId);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Noticia", "YouCom"))
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

        public static bool ValidaEliminacionNoticia(DTO.NoticiaDTO theNoticiaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idNoticia", SqlDbType.VarChar, 20, theNoticiaDTO.NoticiaId);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionNoticia", "YouCom", pobjDatatable) <= 0)
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
