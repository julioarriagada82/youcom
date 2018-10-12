using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class ForoComunidadEstadoDAL
    {
        #region " Metodo getForoComunidadEstado "
        public static bool getListadoForoComunidadEstado(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoForoComunidadEstado",
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
        public static bool Insert(YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pNombreForoComunidadEstado", SqlDbType.VarChar, 200, myForoComunidadEstadoDTO.NombreForoComunidadEstado);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, -1, myForoComunidadEstadoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myForoComunidadEstadoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ForoComunidadEstado", "YouCom"))
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
        public static bool Update(YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdForoComunidadEstado", SqlDbType.Decimal, -1, myForoComunidadEstadoDTO.IdForoComunidadEstado);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, -1, myForoComunidadEstadoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pNombreForoComunidadEstado", SqlDbType.VarChar, 200, myForoComunidadEstadoDTO.NombreForoComunidadEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myForoComunidadEstadoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ForoComunidadEstado", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdForoComunidadEstado", SqlDbType.Decimal, -1, myForoComunidadEstadoDTO.IdForoComunidadEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myForoComunidadEstadoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ForoComunidadEstado", "YouCom"))
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

        public static bool ActivaForoComunidadEstado(YouCom.DTO.Foro.ForoComunidadEstadoDTO theForoComunidadEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theForoComunidadEstadoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdForoComunidadEstado", SqlDbType.VarChar, 20, theForoComunidadEstadoDTO.IdForoComunidadEstado);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_ForoComunidadEstado", "YouCom"))
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

        public static bool ValidaEliminacionForoComunidadEstado(YouCom.DTO.Foro.ForoComunidadEstadoDTO theForoComunidadEstadoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idForoComunidadEstado", SqlDbType.VarChar, 20, theForoComunidadEstadoDTO.IdForoComunidadEstado);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionForoComunidadEstado", "YouCom", pobjDatatable) <= 0)
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
