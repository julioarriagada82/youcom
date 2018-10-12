using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class VacacionesDAL
    {
        #region " Metodo getVacaciones "
        public static bool getListadoVacaciones(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVacaciones",
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
        public static bool Insert(YouCom.DTO.VacacionesDTO myVacacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.Decimal, -1, myVacacionesDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pIdParentesco", SqlDbType.Decimal, -1, myVacacionesDTO.IdParentesco);
                wobjSQLHelper.SetParametro("@pFechaInicio", SqlDbType.DateTime, -1, myVacacionesDTO.FechaInicio);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myVacacionesDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pMotivo", SqlDbType.VarChar, 500, myVacacionesDTO.DestinoVacaciones);
                wobjSQLHelper.SetParametro("@pTelefonoContacto", SqlDbType.VarChar, 20, myVacacionesDTO.TelefonoContacto);
                wobjSQLHelper.SetParametro("@pNombreContacto", SqlDbType.VarChar, 200, myVacacionesDTO.NombreContacto);
                wobjSQLHelper.SetParametro("@pComentarios", SqlDbType.Text, -1, myVacacionesDTO.Comentario);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myVacacionesDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Vacaciones", "YouCom"))
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
        public static bool Update(YouCom.DTO.VacacionesDTO myVacacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVacaciones", SqlDbType.Decimal, -1, myVacacionesDTO.IdVacaciones);
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.Decimal, -1, myVacacionesDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pIdParentesco", SqlDbType.Decimal, -1, myVacacionesDTO.IdParentesco);
                wobjSQLHelper.SetParametro("@pFechaInicio", SqlDbType.DateTime, -1, myVacacionesDTO.FechaInicio);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myVacacionesDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pMotivo", SqlDbType.VarChar, 500, myVacacionesDTO.DestinoVacaciones);
                wobjSQLHelper.SetParametro("@pTelefonoContacto", SqlDbType.VarChar, 20, myVacacionesDTO.TelefonoContacto);
                wobjSQLHelper.SetParametro("@pNombreContacto", SqlDbType.VarChar, 200, myVacacionesDTO.NombreContacto);
                wobjSQLHelper.SetParametro("@pComentarios", SqlDbType.Text, -1, myVacacionesDTO.Comentario);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myVacacionesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Vacaciones", "YouCom"))
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
        public static bool Delete(YouCom.DTO.VacacionesDTO myVacacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVacaciones", SqlDbType.Decimal, -1, myVacacionesDTO.IdVacaciones);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myVacacionesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Vacaciones", "YouCom"))
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

        public static bool ActivaVacaciones(YouCom.DTO.VacacionesDTO theVacacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theVacacionesDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdVacaciones", SqlDbType.VarChar, 20, theVacacionesDTO.IdVacaciones);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Vacaciones", "YouCom"))
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

        public static bool ValidaEliminacionVacaciones(DTO.VacacionesDTO theVacacionesDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idVacaciones", SqlDbType.VarChar, 20, theVacacionesDTO.IdVacaciones);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionVacaciones", "YouCom", pobjDatatable) <= 0)
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
