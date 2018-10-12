using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ArchivoDAL
    {
        #region " Metodo getListadoArchivo "
        public static bool getListadoArchivo(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoArchivo",
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
        public static bool Insert(YouCom.DTO.ArchivoDTO myArchivoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pTituloArchivo", SqlDbType.VarChar, 200, myArchivoDTO.ArchivoTitulo);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myArchivoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myArchivoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myArchivoDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pDescripcionArchivo", SqlDbType.VarChar, 500, myArchivoDTO.ArchivoDescripcion);
                wobjSQLHelper.SetParametro("@pNombreArchivo", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myArchivoDTO.ArchivoNombre) ? myArchivoDTO.ArchivoNombre : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myArchivoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Archivo", "YouCom"))
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
        public static bool Update(YouCom.DTO.ArchivoDTO myArchivoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdArchivo", SqlDbType.Decimal, -1, myArchivoDTO.ArchivoId);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myArchivoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myArchivoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myArchivoDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pTituloArchivo", SqlDbType.VarChar, 200, myArchivoDTO.ArchivoTitulo);
                wobjSQLHelper.SetParametro("@pDescripcionArchivo", SqlDbType.VarChar, 500, myArchivoDTO.ArchivoDescripcion);
                wobjSQLHelper.SetParametro("@pNombreArchivo", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myArchivoDTO.ArchivoNombre) ? myArchivoDTO.ArchivoNombre : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myArchivoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Archivo", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ArchivoDTO myArchivoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdArchivo", SqlDbType.Decimal, -1, myArchivoDTO.ArchivoId);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myArchivoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Archivo", "YouCom"))
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

        public static bool ActivaArchivo(YouCom.DTO.ArchivoDTO theArchivoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theArchivoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdArchivo", SqlDbType.VarChar, 20, theArchivoDTO.ArchivoId);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Archivo", "YouCom"))
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

        public static bool ValidaEliminacionArchivo(DTO.ArchivoDTO theArchivoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idArchivo", SqlDbType.VarChar, 20, theArchivoDTO.ArchivoId);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionArchivo", "YouCom", pobjDatatable) <= 0)
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
