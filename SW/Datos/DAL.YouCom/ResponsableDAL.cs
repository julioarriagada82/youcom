using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class ResponsableDAL
    {
        #region " Metodo getResponsable "
        public static bool getListadoResponsable(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoResponsable",
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
        public static bool Insert(YouCom.DTO.Servicio.ResponsableDTO myResponsableDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myResponsableDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myResponsableDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCargo", SqlDbType.Decimal, -1, myResponsableDTO.TheCargoDTO.IdCargo);
                wobjSQLHelper.SetParametro("@pNombreResponsable", SqlDbType.VarChar, 300, myResponsableDTO.NombreResponsable);
                wobjSQLHelper.SetParametro("@pApellidoPaternoResponsable", SqlDbType.VarChar, 20, myResponsableDTO.ApellidoPaternoResponsable);
                wobjSQLHelper.SetParametro("@pApellidoMaternoResponsable", SqlDbType.VarChar, 500, myResponsableDTO.ApellidoMaternoResponsable);
                wobjSQLHelper.SetParametro("@pRutResponsable", SqlDbType.VarChar, 500, myResponsableDTO.RutResponsable);
                wobjSQLHelper.SetParametro("@pTelefonoResponsable", SqlDbType.VarChar, 20, myResponsableDTO.TelefonoResponsable);
                wobjSQLHelper.SetParametro("@pCelularResponsable", SqlDbType.VarChar, 20, myResponsableDTO.CelularResponsable);
                wobjSQLHelper.SetParametro("@pEmailResponsable", SqlDbType.VarChar, 300, myResponsableDTO.EmailResponsable);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myResponsableDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Responsable", "YouCom"))
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
        public static bool Update(YouCom.DTO.Servicio.ResponsableDTO myResponsableDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdResponsable", SqlDbType.Decimal, -1, myResponsableDTO.IdResponsable);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myResponsableDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myResponsableDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCargo", SqlDbType.Decimal, -1, myResponsableDTO.TheCargoDTO.IdCargo);
                wobjSQLHelper.SetParametro("@pNombreResponsable", SqlDbType.VarChar, 300, myResponsableDTO.NombreResponsable);
                wobjSQLHelper.SetParametro("@pApellidoPaternoResponsable", SqlDbType.VarChar, 20, myResponsableDTO.ApellidoPaternoResponsable);
                wobjSQLHelper.SetParametro("@pApellidoMaternoResponsable", SqlDbType.VarChar, 500, myResponsableDTO.ApellidoMaternoResponsable);
                wobjSQLHelper.SetParametro("@pRutResponsable", SqlDbType.VarChar, 500, myResponsableDTO.RutResponsable);
                wobjSQLHelper.SetParametro("@pTelefonoResponsable", SqlDbType.VarChar, 20, myResponsableDTO.TelefonoResponsable);
                wobjSQLHelper.SetParametro("@pCelularResponsable", SqlDbType.VarChar, 20, myResponsableDTO.CelularResponsable);
                wobjSQLHelper.SetParametro("@pEmailResponsable", SqlDbType.VarChar, 300, myResponsableDTO.EmailResponsable);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myResponsableDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Responsable", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Servicio.ResponsableDTO myResponsableDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdResponsable", SqlDbType.Decimal, -1, myResponsableDTO.IdResponsable);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myResponsableDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Responsable", "YouCom"))
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

        public static bool ActivaResponsable(YouCom.DTO.Servicio.ResponsableDTO theResponsableDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theResponsableDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdResponsable", SqlDbType.VarChar, 20, theResponsableDTO.IdResponsable);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Responsable", "YouCom"))
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

        public static bool ValidaEliminacionResponsable(DTO.Servicio.ResponsableDTO theResponsableDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idResponsable", SqlDbType.VarChar, 20, theResponsableDTO.IdResponsable);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionResponsable", "YouCom", pobjDatatable) <= 0)
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
