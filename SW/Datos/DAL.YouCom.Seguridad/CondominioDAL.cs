using System;
using System.Data;

namespace YouCom.Seguridad.DAL
{
    public class CondominioDAL
    {
        #region " Metodo getListadoCondominio "
        public static bool getListadoCondominio(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoCondominio",
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
        public static bool Insert(YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRutCondominio", SqlDbType.VarChar, 500, myCondominioDTO.RutCondominio);
                wobjSQLHelper.SetParametro("@pNombreCondominio", SqlDbType.VarChar, 500, myCondominioDTO.NombreCondominio);
                wobjSQLHelper.SetParametro("@pTelefonoCondominio", SqlDbType.VarChar, 200, myCondominioDTO.TelefonoCondominio);
                wobjSQLHelper.SetParametro("@pCorreoCondominio", SqlDbType.VarChar, 200, myCondominioDTO.EmailCondominio);
                wobjSQLHelper.SetParametro("@pDireccionCondominio", SqlDbType.VarChar, 200, myCondominioDTO.DireccionCondominio);
                wobjSQLHelper.SetParametro("@pIdRegion", SqlDbType.Decimal, -1, myCondominioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion);
                wobjSQLHelper.SetParametro("@pIdCiudad", SqlDbType.Decimal, -1, myCondominioDTO.TheComunaDTO.TheCiudadDTO.IdCiudad);
                wobjSQLHelper.SetParametro("@pIdComuna", SqlDbType.Decimal, -1, myCondominioDTO.TheComunaDTO.IdComuna);
                wobjSQLHelper.SetParametro("@pLatitudCondominio", SqlDbType.VarChar, 200, myCondominioDTO.LatitudCondominio);
                wobjSQLHelper.SetParametro("@pLongitudCondominio", SqlDbType.VarChar, 200, myCondominioDTO.LongitudCondominio);

                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myCondominioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Condominio", "YouCom"))
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
        public static bool Update(YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, 500, myCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pRutCondominio", SqlDbType.VarChar, 500, myCondominioDTO.RutCondominio);
                wobjSQLHelper.SetParametro("@pNombreCondominio", SqlDbType.VarChar, 500, myCondominioDTO.NombreCondominio);
                wobjSQLHelper.SetParametro("@pTelefonoCondominio", SqlDbType.VarChar, 200, myCondominioDTO.TelefonoCondominio);
                wobjSQLHelper.SetParametro("@pCorreoCondominio", SqlDbType.VarChar, 200, myCondominioDTO.EmailCondominio);
                wobjSQLHelper.SetParametro("@pDireccionCondominio", SqlDbType.VarChar, 200, myCondominioDTO.DireccionCondominio);
                wobjSQLHelper.SetParametro("@pIdRegion", SqlDbType.VarChar, 200, myCondominioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion);
                wobjSQLHelper.SetParametro("@pIdCiudad", SqlDbType.VarChar, 200, myCondominioDTO.TheComunaDTO.TheCiudadDTO.IdCiudad);
                wobjSQLHelper.SetParametro("@pIdComuna", SqlDbType.VarChar, 200, myCondominioDTO.TheComunaDTO.IdComuna);
                wobjSQLHelper.SetParametro("@pLatitudCondominio", SqlDbType.VarChar, 200, myCondominioDTO.LatitudCondominio);
                wobjSQLHelper.SetParametro("@pLongitudCondominio", SqlDbType.VarChar, 200, myCondominioDTO.LongitudCondominio);

                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myCondominioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Condominio", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myCondominioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Condominio", "YouCom"))
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

        public static bool ActivaCondominio(YouCom.DTO.Seguridad.CondominioDTO theCondominioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theCondominioDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, 20, theCondominioDTO.IdCondominio);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Condominio", "YouCom"))
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

        public static bool ValidaEliminacionCondominio(YouCom.DTO.Seguridad.CondominioDTO theCondominioDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idCondominio", SqlDbType.VarChar, 20, theCondominioDTO.IdCondominio);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionCondominio", "YouCom", pobjDatatable) <= 0)
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
