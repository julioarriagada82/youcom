using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL.GastosComunes
{
    public class GastoComunDAL
    {
        #region " Metodo getListadoGastosComunes "
        public static bool getListadoGastosComunes(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoGastosComunes",
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
        public static bool Insert(YouCom.DTO.GastosComunes.GastoComunDTO myGastosComunesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.Decimal, -1, myGastosComunesDTO.TheCasaDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myGastosComunesDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pDescripcionGasto", SqlDbType.VarChar, 500, myGastosComunesDTO.DescripcionGasto);
                wobjSQLHelper.SetParametro("@pMontoGasto", SqlDbType.VarChar, 200, myGastosComunesDTO.MontoGasto);
                wobjSQLHelper.SetParametro("@pFechaGasto", SqlDbType.DateTime, -1, myGastosComunesDTO.FechaGasto);
                wobjSQLHelper.SetParametro("@pFechaVencimiento", SqlDbType.DateTime, -1, myGastosComunesDTO.FechaVencimiento);
                wobjSQLHelper.SetParametro("@pArchivoGasto", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myGastosComunesDTO.ArchivoGasto) ? myGastosComunesDTO.ArchivoGasto : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pIdGastoComunEstado", SqlDbType.VarChar, 10, myGastosComunesDTO.TheGastoComunEstadoDTO.IdGastoComunEstado);
                wobjSQLHelper.SetParametro("@pFechaPagoGasto", SqlDbType.DateTime, -1, myGastosComunesDTO.FechaPagoGasto);
                wobjSQLHelper.SetParametro("@pComentarioGasto", SqlDbType.VarChar, 500, !string.IsNullOrEmpty(myGastosComunesDTO.ComentarioGasto) ? myGastosComunesDTO.ComentarioGasto : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myGastosComunesDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_GastoComun", "YouCom"))
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
        public static bool Update(YouCom.DTO.GastosComunes.GastoComunDTO myGastosComunesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdGasto", SqlDbType.Decimal, -1, myGastosComunesDTO.IdGastoComun);
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.Decimal, -1, myGastosComunesDTO.TheCasaDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myGastosComunesDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pDescripcionGasto", SqlDbType.VarChar, 500, myGastosComunesDTO.DescripcionGasto);
                wobjSQLHelper.SetParametro("@pMontoGasto", SqlDbType.VarChar, 200, myGastosComunesDTO.MontoGasto);
                wobjSQLHelper.SetParametro("@pFechaGasto", SqlDbType.DateTime, -1, myGastosComunesDTO.FechaGasto);
                wobjSQLHelper.SetParametro("@pFechaVencimiento", SqlDbType.DateTime, -1, myGastosComunesDTO.FechaVencimiento);
                wobjSQLHelper.SetParametro("@pArchivoGasto", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myGastosComunesDTO.ArchivoGasto) ? myGastosComunesDTO.ArchivoGasto : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pIdGastoComunEstado", SqlDbType.VarChar, 10, myGastosComunesDTO.TheGastoComunEstadoDTO.IdGastoComunEstado);
                wobjSQLHelper.SetParametro("@pFechaPagoGasto", SqlDbType.DateTime, -1, myGastosComunesDTO.FechaPagoGasto);
                wobjSQLHelper.SetParametro("@pComentarioGasto", SqlDbType.VarChar, 500, !string.IsNullOrEmpty(myGastosComunesDTO.ComentarioGasto) ? myGastosComunesDTO.ComentarioGasto : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myGastosComunesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_GastoComun", "YouCom"))
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
        public static bool Delete(YouCom.DTO.GastosComunes.GastoComunDTO myGastosComunesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdGasto", SqlDbType.Decimal, -1, myGastosComunesDTO.IdGastoComun);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myGastosComunesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_GastoComun", "YouCom"))
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

        public static bool ActivaGastoComun(YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theGastosComunesDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdGasto", SqlDbType.VarChar, 20, theGastosComunesDTO.IdGastoComun);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_GastoComun", "YouCom"))
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

        public static bool ValidaEliminacionGastoComun(YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunesDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idGastoComun", SqlDbType.VarChar, 20, theGastosComunesDTO.IdGastoComun);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionGastoComun", "YouCom", pobjDatatable) <= 0)
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
