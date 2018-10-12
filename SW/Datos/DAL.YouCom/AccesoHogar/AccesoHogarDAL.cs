using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL.AccesoHogar
{
    public class AccesoHogarDAL
    {
        #region " Metodo getListadoAccesoHogar "
        public static bool getListadoAccesoHogar(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoAccesoHogar",
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
        public static bool Insert(YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheCasaDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pIdTipoVisita", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheTipoVisitaDTO.IdTipoVisita);
                wobjSQLHelper.SetParametro("@pIdFrecuencia", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheFrecuenciaDTO.IdFrecuencia);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pFechaInicio", SqlDbType.DateTime, -1, myAccesoHogarDTO.FechaInicio);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myAccesoHogarDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pHoraInicio", SqlDbType.VarChar, -1, myAccesoHogarDTO.HoraInicio);
                wobjSQLHelper.SetParametro("@pHoraTermino", SqlDbType.VarChar, -1, myAccesoHogarDTO.HoraTermino);
                wobjSQLHelper.SetParametro("@pNombreVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.NombreVisita);
                wobjSQLHelper.SetParametro("@pApellidoPaternoVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.ApellidoPaternoVisita);
                wobjSQLHelper.SetParametro("@pApellidoMaternoVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.ApellidoMaternoVisita);
                wobjSQLHelper.SetParametro("@pRutVisita", SqlDbType.VarChar, 20, myAccesoHogarDTO.RutVisita);
                wobjSQLHelper.SetParametro("@pEmailVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.EmailVisita);
                wobjSQLHelper.SetParametro("@pAvisar", SqlDbType.Char, 2, myAccesoHogarDTO.Avisar);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myAccesoHogarDTO.UsuarioIngreso);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheComunidadDTO.IdComunidad);

                wobjSQLHelper.SetParametroOut("@identity", SqlDbType.Decimal, -1);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_AccesoHogar", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================

                myAccesoHogarDTO.IdAccesoHogar = decimal.Parse(wobjSQLHelper.GetParametro("@identity").ToString());

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
        public static bool Update(YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAccesoHogar", SqlDbType.Decimal, -1, myAccesoHogarDTO.IdAccesoHogar);
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheCasaDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pIdTipoVisita", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheTipoVisitaDTO.IdTipoVisita);
                wobjSQLHelper.SetParametro("@pIdFrecuencia", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheFrecuenciaDTO.IdFrecuencia);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pFechaInicio", SqlDbType.DateTime, -1, myAccesoHogarDTO.FechaInicio);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myAccesoHogarDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pHoraInicio", SqlDbType.VarChar, -1, myAccesoHogarDTO.HoraInicio);
                wobjSQLHelper.SetParametro("@pHoraTermino", SqlDbType.VarChar, -1, myAccesoHogarDTO.HoraTermino);
                wobjSQLHelper.SetParametro("@pNombreVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.NombreVisita);
                wobjSQLHelper.SetParametro("@pApellidoPaternoVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.ApellidoPaternoVisita);
                wobjSQLHelper.SetParametro("@pApellidoMaternoVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.ApellidoMaternoVisita);
                wobjSQLHelper.SetParametro("@pEmailVisita", SqlDbType.VarChar, 200, myAccesoHogarDTO.EmailVisita);
                wobjSQLHelper.SetParametro("@pRutVisita", SqlDbType.VarChar, 20, myAccesoHogarDTO.RutVisita);
                wobjSQLHelper.SetParametro("@pAvisar", SqlDbType.Char, 2, myAccesoHogarDTO.Avisar);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myAccesoHogarDTO.UsuarioModificacion);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myAccesoHogarDTO.TheComunidadDTO.IdComunidad);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_AccesoHogar", "YouCom"))
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
        public static bool Delete(YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAccesoHogar", SqlDbType.Decimal, -1, myAccesoHogarDTO.IdAccesoHogar);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myAccesoHogarDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_AccesoHogar", "YouCom"))
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

        public static bool ActivaAccesoHogar(YouCom.DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theAccesoHogarDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdAccesoHogar", SqlDbType.VarChar, 20, theAccesoHogarDTO.IdAccesoHogar);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_AccesoHogar", "YouCom"))
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

        public static bool ValidaEliminacionAccesoHogar(YouCom.DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idAccesoHogar", SqlDbType.VarChar, 20, theAccesoHogarDTO.IdAccesoHogar);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionAccesoHogar", "YouCom", pobjDatatable) <= 0)
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
