using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class EmpresaContratistaDAL
    {
        #region " Metodo getEmpresaContratista "
        public static bool getListadoEmpresaContratista(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEmpresaContratista",
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
        public static bool Insert(YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdGiro", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheGiroDTO.IdGiro);
                wobjSQLHelper.SetParametro("@pRazonSocialContratista", SqlDbType.VarChar, 300, myEmpresaContratistaDTO.RazonSocialEmpresaContratista);
                wobjSQLHelper.SetParametro("@pRutCondominioContratista", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.RutCondominioContratista);
                wobjSQLHelper.SetParametro("@pDireccionEmpresaContratista", SqlDbType.VarChar, 500, myEmpresaContratistaDTO.DireccionEmpresaContratista);
                wobjSQLHelper.SetParametro("@pIdPais", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO.IdPais);
                wobjSQLHelper.SetParametro("@pIdRegion", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion);
                wobjSQLHelper.SetParametro("@pIdCiudad", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.IdCiudad);
                wobjSQLHelper.SetParametro("@pIdComuna", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.IdComuna);
                wobjSQLHelper.SetParametro("@pTelefonoEmpresaContratista", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.TelefonoEmpresaContratista);
                wobjSQLHelper.SetParametro("@pCelularEmpresaContratista", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.CelularEmpresaContratista);
                wobjSQLHelper.SetParametro("@pEmailEmpresaContratista", SqlDbType.VarChar, 300, myEmpresaContratistaDTO.EmailEmpresaContratista);
                wobjSQLHelper.SetParametro("@pLogoEmpresaContratista", SqlDbType.VarChar, 300, myEmpresaContratistaDTO.LogoEmpresaContratista);
                wobjSQLHelper.SetParametro("@pUrlEmpresaContratista", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myEmpresaContratistaDTO.LogoEmpresaContratista) ? myEmpresaContratistaDTO.LogoEmpresaContratista : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_EmpresaContratista", "YouCom"))
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
        public static bool Update(YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdEmpresaContratista", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.IdEmpresaContratista);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdGiro", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheGiroDTO.IdGiro);
                wobjSQLHelper.SetParametro("@pRazonSocialContratista", SqlDbType.VarChar, 300, myEmpresaContratistaDTO.RazonSocialEmpresaContratista);
                wobjSQLHelper.SetParametro("@pRutCondominioContratista", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.RutCondominioContratista);
                wobjSQLHelper.SetParametro("@pDireccionEmpresaContratista", SqlDbType.VarChar, 500, myEmpresaContratistaDTO.DireccionEmpresaContratista);
                wobjSQLHelper.SetParametro("@pIdPais", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO.IdPais);
                wobjSQLHelper.SetParametro("@pIdRegion", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion);
                wobjSQLHelper.SetParametro("@pIdCiudad", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.IdCiudad);
                wobjSQLHelper.SetParametro("@pIdComuna", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.TheComunaDTO.IdComuna);
                wobjSQLHelper.SetParametro("@pTelefonoEmpresaContratista", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.TelefonoEmpresaContratista);
                wobjSQLHelper.SetParametro("@pCelularEmpresaContratista", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.CelularEmpresaContratista);
                wobjSQLHelper.SetParametro("@pEmailEmpresaContratista", SqlDbType.VarChar, 300, myEmpresaContratistaDTO.EmailEmpresaContratista);
                wobjSQLHelper.SetParametro("@pUrlEmpresaContratista", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myEmpresaContratistaDTO.LogoEmpresaContratista) ? myEmpresaContratistaDTO.LogoEmpresaContratista : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUrlEmpresaContratista", SqlDbType.VarChar, 200, myEmpresaContratistaDTO.UrlEmpresaContratista);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_EmpresaContratista", "YouCom"))
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
        public static bool Delete(YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdEmpresaContratista", SqlDbType.Decimal, -1, myEmpresaContratistaDTO.IdEmpresaContratista);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myEmpresaContratistaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_EmpresaContratista", "YouCom"))
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

        public static bool ActivaEmpresaContratista(YouCom.DTO.EmpresaContratistaDTO theEmpresaContratistaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theEmpresaContratistaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdEmpresaContratista", SqlDbType.VarChar, 20, theEmpresaContratistaDTO.IdEmpresaContratista);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_EmpresaContratista", "YouCom"))
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

        public static bool ValidaEliminacionEmpresaContratista(DTO.EmpresaContratistaDTO theEmpresaContratistaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idEmpresaContratista", SqlDbType.VarChar, 20, theEmpresaContratistaDTO.IdEmpresaContratista);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionEmpresaContratista", "YouCom", pobjDatatable) <= 0)
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
