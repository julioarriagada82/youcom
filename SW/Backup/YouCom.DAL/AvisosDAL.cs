using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class AvisosDAL
    {
        #region " Metodo getListadoAvisos "
        public static bool getListadoAvisos(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoAviso",
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
        public static bool Insert(YouCom.DTO.AvisosDTO myAvisosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myAvisosDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pTitulo", SqlDbType.VarChar, 200, myAvisosDTO.TituloAviso);
                wobjSQLHelper.SetParametro("@pDescripcion", SqlDbType.VarChar, 200, myAvisosDTO.DescripcionAviso);
                wobjSQLHelper.SetParametro("@pIdTipo", SqlDbType.Decimal, -1, myAvisosDTO.IdTipo);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myAvisosDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pPrecio", SqlDbType.Decimal, -1, myAvisosDTO.Precio);
                wobjSQLHelper.SetParametro("@pIdMoneda", SqlDbType.Decimal, -1, myAvisosDTO.IdMoneda);
                wobjSQLHelper.SetParametro("@pFechaPublicacion", SqlDbType.DateTime, -1, myAvisosDTO.FechaPublicacion);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myAvisosDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myAvisosDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Avisos", "YouCom"))
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
        public static bool Update(YouCom.DTO.AvisosDTO myAvisosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAvisos", SqlDbType.Decimal, -1, myAvisosDTO.IdAviso);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myAvisosDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pTitulo", SqlDbType.VarChar, 200, myAvisosDTO.TituloAviso);
                wobjSQLHelper.SetParametro("@pDescripcion", SqlDbType.VarChar, 200, myAvisosDTO.DescripcionAviso);
                wobjSQLHelper.SetParametro("@pIdTipoAviso", SqlDbType.Decimal, -1, myAvisosDTO.IdTipo);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myAvisosDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pPrecio", SqlDbType.Decimal, -1, myAvisosDTO.Precio);
                wobjSQLHelper.SetParametro("@pIdMoneda", SqlDbType.Decimal, -1, myAvisosDTO.IdMoneda);
                wobjSQLHelper.SetParametro("@pFechaPublicacion", SqlDbType.DateTime, -1, myAvisosDTO.FechaPublicacion);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myAvisosDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myAvisosDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Avisos", "YouCom"))
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
        public static bool Delete(YouCom.DTO.AvisosDTO myAvisosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAvisos", SqlDbType.Decimal, -1, myAvisosDTO.IdAviso);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myAvisosDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Avisos", "YouCom"))
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

        public static bool ActivaAviso(YouCom.DTO.AvisosDTO theAvisosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theAvisosDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdAviso", SqlDbType.VarChar, 20, theAvisosDTO.IdAviso);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Aviso", "YouCom"))
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

        public static bool ValidaEliminacionAviso(YouCom.DTO.AvisosDTO theAvisosDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idAviso", SqlDbType.VarChar, 20, theAvisosDTO.IdAviso);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionAviso", "YouCom", pobjDatatable) <= 0)
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
