using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class DirectivaDAL
    {
        #region " Metodo getListadoDirectiva "
        public static bool getListadoDirectiva(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoDirectiva",
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
        public static bool Insert(YouCom.DTO.DirectivaDTO myDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCargo", SqlDbType.Decimal, -1, myDirectivaDTO.TheCargoDTO.IdCargo);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myDirectivaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myDirectivaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pRutDirectiva", SqlDbType.VarChar, 20, myDirectivaDTO.RutDirectiva);
                wobjSQLHelper.SetParametro("@pNombreDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.NombreDirectiva);
                wobjSQLHelper.SetParametro("@pApellidoPaternoDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.ApellidoPaternoDirectiva);
                wobjSQLHelper.SetParametro("@pApellidoMaternoDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.ApellidoMaternoDirectiva);
                wobjSQLHelper.SetParametro("@pFechaNacimientoDirectiva", SqlDbType.DateTime, -1, myDirectivaDTO.FechaNacimientoDirectiva);
                wobjSQLHelper.SetParametro("@pTelefonoDirectiva", SqlDbType.VarChar, 20, myDirectivaDTO.TelefonoDirectiva);
                wobjSQLHelper.SetParametro("@pImagenDirectiva", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myDirectivaDTO.ImagenDirectiva) ? myDirectivaDTO.ImagenDirectiva : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pEmailDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.EmailDirectiva);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myDirectivaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Directiva", "YouCom"))
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
        public static bool Update(YouCom.DTO.DirectivaDTO myDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdDirectiva", SqlDbType.Decimal, -1, myDirectivaDTO.IdDirectiva);
                wobjSQLHelper.SetParametro("@pIdCargo", SqlDbType.Decimal, -1, myDirectivaDTO.TheCargoDTO.IdCargo);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myDirectivaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myDirectivaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pRutDirectiva", SqlDbType.VarChar, 20, myDirectivaDTO.RutDirectiva);
                wobjSQLHelper.SetParametro("@pNombreDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.NombreDirectiva);
                wobjSQLHelper.SetParametro("@pApellidoPaternoDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.ApellidoPaternoDirectiva);
                wobjSQLHelper.SetParametro("@pApellidoMaternoDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.ApellidoMaternoDirectiva);
                wobjSQLHelper.SetParametro("@pFechaNacimientoDirectiva", SqlDbType.DateTime, -1, myDirectivaDTO.FechaNacimientoDirectiva);
                wobjSQLHelper.SetParametro("@pTelefonoDirectiva", SqlDbType.VarChar, 20, myDirectivaDTO.TelefonoDirectiva);
                wobjSQLHelper.SetParametro("@pImagenDirectiva", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myDirectivaDTO.ImagenDirectiva) ? myDirectivaDTO.ImagenDirectiva : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pEmailDirectiva", SqlDbType.VarChar, 200, myDirectivaDTO.EmailDirectiva);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myDirectivaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Directiva", "YouCom"))
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
        public static bool Delete(YouCom.DTO.DirectivaDTO myDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdDirectiva", SqlDbType.Decimal, -1, myDirectivaDTO.IdDirectiva);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myDirectivaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Directiva", "YouCom"))
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

        public static bool ActivaDirectiva(YouCom.DTO.DirectivaDTO theDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theDirectivaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdDirectiva", SqlDbType.VarChar, 20, theDirectivaDTO.IdDirectiva);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Directiva", "YouCom"))
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

        public static bool ValidaEliminacionDirectiva(DTO.DirectivaDTO theDirectivaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idDirectiva", SqlDbType.VarChar, 20, theDirectivaDTO.IdDirectiva);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionDirectiva", "YouCom", pobjDatatable) <= 0)
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
