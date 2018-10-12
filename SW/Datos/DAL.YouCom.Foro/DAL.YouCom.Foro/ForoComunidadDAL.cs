using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCom.Foro.DAL
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoForoComunidad",
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
        public static bool Insert(YouCom.DTO.Foro.ForoComunidadDTO myForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myForoComunidadDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myForoComunidadDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myForoComunidadDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myForoComunidadDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pIdTipoForo", SqlDbType.Decimal, -1, myForoComunidadDTO.TheTipoForoDTO.IdTipoForo);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myForoComunidadDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdForoEstado", SqlDbType.Decimal, -1, myForoComunidadDTO.TheForoComunidadEstadoDTO.IdForoComunidadEstado);
                wobjSQLHelper.SetParametro("@pMotivoForoEstado", SqlDbType.DateTime, -1, myForoComunidadDTO.MotivoEstadoForoComunidad);
                wobjSQLHelper.SetParametro("@pFechaForo", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaForoComunidad);
                wobjSQLHelper.SetParametro("@pFechaPublicidadForo", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaPublicacion);
                wobjSQLHelper.SetParametro("@pFechaTerminoForo", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pTituloForo", SqlDbType.VarChar, 500, myForoComunidadDTO.TituloForoComunidad);
                wobjSQLHelper.SetParametro("@pResumenForo", SqlDbType.VarChar, 500, myForoComunidadDTO.ResumenForoComunidad);
                wobjSQLHelper.SetParametro("@pDescripcionForo", SqlDbType.Text, -1, myForoComunidadDTO.DescripcionForoComunidad);
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
        public static bool Update(YouCom.DTO.Foro.ForoComunidadDTO myForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdForoComunidad", SqlDbType.Decimal, -1, myForoComunidadDTO.IdForoComunidad);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myForoComunidadDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myForoComunidadDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myForoComunidadDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myForoComunidadDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pIdTipoForo", SqlDbType.Decimal, -1, myForoComunidadDTO.TheTipoForoDTO.IdTipoForo);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myForoComunidadDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pIdForoEstado", SqlDbType.Decimal, -1, myForoComunidadDTO.TheForoComunidadEstadoDTO.IdForoComunidadEstado);
                wobjSQLHelper.SetParametro("@pMotivoForoEstado", SqlDbType.DateTime, -1, myForoComunidadDTO.MotivoEstadoForoComunidad);
                wobjSQLHelper.SetParametro("@pFechaForo", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaForoComunidad);
                wobjSQLHelper.SetParametro("@pFechaPublicidadForo", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaPublicacion);
                wobjSQLHelper.SetParametro("@pFechaTerminoForo", SqlDbType.DateTime, -1, myForoComunidadDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pTituloForo", SqlDbType.VarChar, 500, myForoComunidadDTO.TituloForoComunidad);
                wobjSQLHelper.SetParametro("@pResumenForo", SqlDbType.VarChar, 500, myForoComunidadDTO.ResumenForoComunidad);
                wobjSQLHelper.SetParametro("@pDescripcionForo", SqlDbType.Text, -1, myForoComunidadDTO.DescripcionForoComunidad);
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
        public static bool Delete(YouCom.DTO.Foro.ForoComunidadDTO myForoComunidadDTO)
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

        public static bool ActivaForoComunidad(YouCom.DTO.Foro.ForoComunidadDTO theForoComunidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theForoComunidadDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdForoComunidad", SqlDbType.VarChar, 20, theForoComunidadDTO.IdForoComunidad);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_ForoComunidad", "YouCom"))
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

        public static bool ValidaEliminacionForoComunidad(DTO.Foro.ForoComunidadDTO theForoComunidadDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdForoComunidad", SqlDbType.VarChar, 20, theForoComunidadDTO.IdForoComunidad);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionForoComunidad", "YouCom", pobjDatatable) <= 0)
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
