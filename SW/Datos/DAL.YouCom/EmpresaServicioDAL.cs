using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class EmpresaServicioDAL
    {
        #region " Metodo getEmpresaServicio "
        public static bool getListadoEmpresaServicio(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEmpresaServicio",
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
        public static bool Insert(YouCom.DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdServicio", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheServiciosDTO.IdServicio);
                wobjSQLHelper.SetParametro("@pIdGiro", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheGiroDTO.IdGiro);
                wobjSQLHelper.SetParametro("@pRazonSocialEmpresaServicio", SqlDbType.VarChar, 300, myEmpresaServicioDTO.RazonSocialEmpresaServicio);
                wobjSQLHelper.SetParametro("@pRutEmpresaServicio", SqlDbType.VarChar, 20, myEmpresaServicioDTO.RutEmpresaServicio);
                wobjSQLHelper.SetParametro("@pDireccionEmpresaServicio", SqlDbType.VarChar, 500, myEmpresaServicioDTO.DireccionEmpresaServicio);
                wobjSQLHelper.SetParametro("@pIdPais", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO.IdPais);
                wobjSQLHelper.SetParametro("@pIdRegion", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion);
                wobjSQLHelper.SetParametro("@pIdCiudad", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.IdCiudad);
                wobjSQLHelper.SetParametro("@pIdComuna", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.IdComuna);
                wobjSQLHelper.SetParametro("@pTelefonoEmpresaServicio", SqlDbType.VarChar, 20, myEmpresaServicioDTO.TelefonoEmpresaServicio);
                wobjSQLHelper.SetParametro("@pCelularEmpresaServicio", SqlDbType.VarChar, 20, myEmpresaServicioDTO.CelularEmpresaServicio);
                wobjSQLHelper.SetParametro("@pEmailEmpresaServicio", SqlDbType.VarChar, 300, myEmpresaServicioDTO.EmailEmpresaServicio);
                wobjSQLHelper.SetParametro("@pUrlEmpresaServicio", SqlDbType.VarChar, 200, myEmpresaServicioDTO.UrlEmpresaServicio);
                wobjSQLHelper.SetParametro("@pLogoEmpresaServicio", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myEmpresaServicioDTO.LogoEmpresaServicio) ? myEmpresaServicioDTO.LogoEmpresaServicio : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myEmpresaServicioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_EmpresaServicio", "YouCom"))
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
        public static bool Update(YouCom.DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdEmpresaServicio", SqlDbType.Decimal, -1, myEmpresaServicioDTO.IdEmpresaServicio);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdServicio", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheServiciosDTO.IdServicio);
                wobjSQLHelper.SetParametro("@pIdGiro", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheGiroDTO.IdGiro);
                wobjSQLHelper.SetParametro("@pRazonSocialEmpresaServicio", SqlDbType.VarChar, 300, myEmpresaServicioDTO.RazonSocialEmpresaServicio);
                wobjSQLHelper.SetParametro("@pRutEmpresaServicio", SqlDbType.VarChar, 20, myEmpresaServicioDTO.RutEmpresaServicio);
                wobjSQLHelper.SetParametro("@pDireccionEmpresaServicio", SqlDbType.VarChar, 500, myEmpresaServicioDTO.DireccionEmpresaServicio);
                wobjSQLHelper.SetParametro("@pIdPais", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO.IdPais);
                wobjSQLHelper.SetParametro("@pIdRegion", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion);
                wobjSQLHelper.SetParametro("@pIdCiudad", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.IdCiudad);
                wobjSQLHelper.SetParametro("@pIdComuna", SqlDbType.Decimal, -1, myEmpresaServicioDTO.TheComunaDTO.IdComuna);
                wobjSQLHelper.SetParametro("@pTelefonoEmpresaServicio", SqlDbType.VarChar, 20, myEmpresaServicioDTO.TelefonoEmpresaServicio);
                wobjSQLHelper.SetParametro("@pCelularEmpresaServicio", SqlDbType.VarChar, 20, myEmpresaServicioDTO.CelularEmpresaServicio);
                wobjSQLHelper.SetParametro("@pEmailEmpresaServicio", SqlDbType.VarChar, 300, myEmpresaServicioDTO.EmailEmpresaServicio);
                wobjSQLHelper.SetParametro("@pUrlEmpresaServicio", SqlDbType.VarChar, 200, myEmpresaServicioDTO.UrlEmpresaServicio);
                wobjSQLHelper.SetParametro("@pLogoEmpresaServicio", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myEmpresaServicioDTO.LogoEmpresaServicio) ? myEmpresaServicioDTO.LogoEmpresaServicio : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myEmpresaServicioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_EmpresaServicio", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdEmpresaServicio", SqlDbType.Decimal, -1, myEmpresaServicioDTO.IdEmpresaServicio);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myEmpresaServicioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_EmpresaServicio", "YouCom"))
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

        public static bool ActivaEmpresaServicio(YouCom.DTO.Servicio.EmpresaServicioDTO theEmpresaServicioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 50, theEmpresaServicioDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdEmpresaServicio", SqlDbType.VarChar, 20, theEmpresaServicioDTO.IdEmpresaServicio);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_EmpresaServicio", "YouCom"))
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

        public static bool ValidaEliminacionEmpresaServicio(DTO.Servicio.EmpresaServicioDTO theEmpresaServicioDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idEmpresaServicio", SqlDbType.VarChar, 20, theEmpresaServicioDTO.IdEmpresaServicio);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionEmpresaServicio", "YouCom", pobjDatatable) <= 0)
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
