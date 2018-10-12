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
        public static bool Insert(YouCom.DTO.Avisos.AvisoDTO myAvisosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myAvisosDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myAvisosDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myAvisosDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pTituloAviso", SqlDbType.VarChar, 200, myAvisosDTO.TituloAviso);
                wobjSQLHelper.SetParametro("@pDescripcionAviso", SqlDbType.Text, -1, myAvisosDTO.DescripcionAviso);
                wobjSQLHelper.SetParametro("@pIdTipoAviso", SqlDbType.Decimal, -1, myAvisosDTO.TheTipoAvisoDTO.IdTipoAviso);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myAvisosDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pPrecio", SqlDbType.Decimal, -1, myAvisosDTO.PrecioAviso);
                wobjSQLHelper.SetParametro("@pIdMoneda", SqlDbType.Decimal, -1, myAvisosDTO.TheMonedaDTO.IdMoneda);
                wobjSQLHelper.SetParametro("@pImagenAviso", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myAvisosDTO.ImagenAviso) ? myAvisosDTO.ImagenAviso : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pFechaPublicacion", SqlDbType.DateTime, -1, myAvisosDTO.FechaPublicacion != DateTime.MinValue ? myAvisosDTO.FechaPublicacion : System.Data.SqlTypes.SqlDateTime.Null);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myAvisosDTO.FechaTermino != DateTime.MinValue ? myAvisosDTO.FechaTermino : System.Data.SqlTypes.SqlDateTime.Null);
                wobjSQLHelper.SetParametro("@pFechaCompra", SqlDbType.DateTime, -1, myAvisosDTO.FechaCompra != DateTime.MinValue ? myAvisosDTO.FechaCompra : System.Data.SqlTypes.SqlDateTime.Null);
                wobjSQLHelper.SetParametro("@pIdAvisoEstado", SqlDbType.Decimal, -1, myAvisosDTO.TheAvisosEstadoDTO.IdAvisoEstado);
                wobjSQLHelper.SetParametro("@pMotivoAvisoEstado", SqlDbType.Text, -1, !string.IsNullOrEmpty(myAvisosDTO.MotivoAvisoEstado) ? myAvisosDTO.MotivoAvisoEstado : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pRutComprador", SqlDbType.VarChar, 20, !string.IsNullOrEmpty(myAvisosDTO.RutComprador) ? myAvisosDTO.RutComprador : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myAvisosDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Aviso", "YouCom"))
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
        public static bool Update(YouCom.DTO.Avisos.AvisoDTO myAvisosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAvisos", SqlDbType.Decimal, -1, myAvisosDTO.IdAviso);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myAvisosDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myAvisosDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myAvisosDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pTituloAviso", SqlDbType.VarChar, 200, myAvisosDTO.TituloAviso);
                wobjSQLHelper.SetParametro("@pDescripcionAviso", SqlDbType.Text, -1, myAvisosDTO.DescripcionAviso);
                wobjSQLHelper.SetParametro("@pIdTipoAviso", SqlDbType.Decimal, -1, myAvisosDTO.TheTipoAvisoDTO.IdTipoAviso);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myAvisosDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pPrecio", SqlDbType.Decimal, -1, myAvisosDTO.PrecioAviso);
                wobjSQLHelper.SetParametro("@pIdMoneda", SqlDbType.Decimal, -1, myAvisosDTO.TheMonedaDTO.IdMoneda);
                wobjSQLHelper.SetParametro("@pImagenAviso", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myAvisosDTO.ImagenAviso) ? myAvisosDTO.ImagenAviso : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pFechaPublicacion", SqlDbType.DateTime, -1, myAvisosDTO.FechaPublicacion != DateTime.MinValue ? myAvisosDTO.FechaPublicacion : System.Data.SqlTypes.SqlDateTime.Null);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myAvisosDTO.FechaTermino != DateTime.MinValue ? myAvisosDTO.FechaTermino : System.Data.SqlTypes.SqlDateTime.Null);
                wobjSQLHelper.SetParametro("@pFechaCompra", SqlDbType.DateTime, -1, myAvisosDTO.FechaCompra != DateTime.MinValue ? myAvisosDTO.FechaCompra : System.Data.SqlTypes.SqlDateTime.Null);
                wobjSQLHelper.SetParametro("@pIdAvisoEstado", SqlDbType.Decimal, -1, myAvisosDTO.TheAvisosEstadoDTO.IdAvisoEstado);
                wobjSQLHelper.SetParametro("@pRutComprador", SqlDbType.VarChar, 20, !string.IsNullOrEmpty(myAvisosDTO.RutComprador) ? myAvisosDTO.RutComprador : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pMotivoAvisoEstado", SqlDbType.Text, -1, !string.IsNullOrEmpty(myAvisosDTO.MotivoAvisoEstado) ? myAvisosDTO.MotivoAvisoEstado : System.Data.SqlTypes.SqlString.Null);
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
        public static bool Delete(YouCom.DTO.Avisos.AvisoDTO myAvisosDTO)
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

        public static bool ActivaAviso(YouCom.DTO.Avisos.AvisoDTO theAvisosDTO)
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

        public static bool ValidaEliminacionAviso(YouCom.DTO.Avisos.AvisoDTO theAvisosDTO, ref DataTable pobjDatatable)
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
