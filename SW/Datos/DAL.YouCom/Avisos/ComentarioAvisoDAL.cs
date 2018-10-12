using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ComentarioAvisoDAL
    {
        #region " Metodo getListadoAvisos "
        public static bool getListadoComentarioAviso(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoComentarioAviso",
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
        public static bool Insert(YouCom.DTO.Avisos.ComentarioAvisoDTO myComentarioAvisoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAviso", SqlDbType.Decimal, -1, myComentarioAvisoDTO.TheAvisosDTO.IdAviso);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myComentarioAvisoDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myComentarioAvisoDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEmailComentarioAviso", SqlDbType.VarChar, 200, myComentarioAvisoDTO.EmailComentarioAviso);
                wobjSQLHelper.SetParametro("@pComentarioAviso", SqlDbType.Text, -1, myComentarioAvisoDTO.ComentarioAviso);
                wobjSQLHelper.SetParametro("@pFechaComentarioAviso", SqlDbType.DateTime, -1, myComentarioAvisoDTO.FechaComentarioAviso);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myComentarioAvisoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myComentarioAvisoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myComentarioAvisoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ComentarioAviso", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Avisos.ComentarioAvisoDTO myComentarioAvisoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdComentarioAviso", SqlDbType.Decimal, -1, myComentarioAvisoDTO.IdComentarioAviso);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myComentarioAvisoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ComentarioAviso", "YouCom"))
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

        public static bool ActivaComentarioAviso(YouCom.DTO.Avisos.ComentarioAvisoDTO theComentarioAvisoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theComentarioAvisoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdComentarioAviso", SqlDbType.VarChar, 20, theComentarioAvisoDTO.IdComentarioAviso);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_ComentarioAviso", "YouCom"))
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

        public static bool ValidaEliminacionComentarioAviso(YouCom.DTO.Avisos.ComentarioAvisoDTO theComentarioAvisoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdComentarioAviso", SqlDbType.VarChar, 20, theComentarioAvisoDTO.IdComentarioAviso);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionComentarioAviso", "YouCom", pobjDatatable) <= 0)
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
