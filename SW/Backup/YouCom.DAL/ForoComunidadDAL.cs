using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ForoComunidadDAL
    {
        #region " Metodo getListadoForoComunidad "
        public static bool getListadoForoComunidad(ref DataTable pobjDataTable)
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
        public static bool Insert(YouCom.DTO.ForoComunidadDTO myForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myForoComunidadDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pTitulo", SqlDbType.VarChar, 200, myForoComunidadDTO.TituloForoComunidad);
                wobjSQLHelper.SetParametro("@pDescripcion", SqlDbType.VarChar, 200, myForoComunidadDTO.DescripcionForoComunidad);
                wobjSQLHelper.SetParametro("@pIdTipo", SqlDbType.Decimal, -1, myForoComunidadDTO.IdTipo);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myForoComunidadDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pFechaPublicacion", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaPublicacion);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myForoComunidadDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ForoComunidad", "YouCom"))
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
        public static bool Update(YouCom.DTO.ForoComunidadDTO myForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdForoComunidad", SqlDbType.Decimal, -1, myForoComunidadDTO.IdForoComunidad);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myForoComunidadDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pTitulo", SqlDbType.VarChar, 200, myForoComunidadDTO.TituloForoComunidad);
                wobjSQLHelper.SetParametro("@pDescripcion", SqlDbType.VarChar, 200, myForoComunidadDTO.DescripcionForoComunidad);
                wobjSQLHelper.SetParametro("@pIdTipoAviso", SqlDbType.Decimal, -1, myForoComunidadDTO.IdTipo);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myForoComunidadDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pFechaPublicacion", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaPublicacion);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myForoComunidadDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ForoComunidad", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ForoComunidadDTO myForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdForoComunidad", SqlDbType.Decimal, -1, myForoComunidadDTO.IdForoComunidad);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myForoComunidadDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ForoComunidad", "YouCom"))
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

        public static bool ActivaAviso(YouCom.DTO.ForoComunidadDTO theForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theForoComunidadDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdAviso", SqlDbType.VarChar, 20, theForoComunidadDTO.IdForoComunidad);

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

        public static bool ValidaEliminacionAviso(YouCom.DTO.ForoComunidadDTO theForoComunidadDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idAviso", SqlDbType.VarChar, 20, theForoComunidadDTO.IdForoComunidad);

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
