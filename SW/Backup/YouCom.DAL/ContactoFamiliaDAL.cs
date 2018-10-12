using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ContactoFamiliaDAL
    {
        #region " Metodo getContactoFamilia "
        public static bool getListadoContactoFamilia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoContactoFamilia",
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
        public static bool Insert(YouCom.DTO.ContactoFamiliaDTO myContactoFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.VarChar, 200, myContactoFamiliaDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pNombreContacto", SqlDbType.VarChar, 200, myContactoFamiliaDTO.NombreContacto);
                wobjSQLHelper.SetParametro("@pTelefonoContacto", SqlDbType.VarChar, 200, myContactoFamiliaDTO.TelefonoContacto);
                wobjSQLHelper.SetParametro("@pEmailContacto", SqlDbType.VarChar, 200, myContactoFamiliaDTO.EmailContacto);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myContactoFamiliaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ContactoFamilia", "YouCom"))
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
        public static bool Update(YouCom.DTO.ContactoFamiliaDTO myContactoFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdContactoFamilia", SqlDbType.Decimal, -1, myContactoFamiliaDTO.IdContactoFamilia);
                wobjSQLHelper.SetParametro("@pIdCasa", SqlDbType.VarChar, 200, myContactoFamiliaDTO.IdCasa);
                wobjSQLHelper.SetParametro("@pNombreContacto", SqlDbType.VarChar, 200, myContactoFamiliaDTO.NombreContacto);
                wobjSQLHelper.SetParametro("@pTelefonoContacto", SqlDbType.VarChar, 200, myContactoFamiliaDTO.TelefonoContacto);
                wobjSQLHelper.SetParametro("@pEmailContacto", SqlDbType.VarChar, 200, myContactoFamiliaDTO.EmailContacto);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myContactoFamiliaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ContactoFamilia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ContactoFamiliaDTO myContactoFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdContactoFamilia", SqlDbType.Decimal, -1, myContactoFamiliaDTO.IdContactoFamilia);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myContactoFamiliaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ContactoFamilia", "YouCom"))
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

        public static bool ActivaContactoFamilia(YouCom.DTO.ContactoFamiliaDTO theContactoFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theContactoFamiliaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdContactoFamilia", SqlDbType.VarChar, 20, theContactoFamiliaDTO.IdContactoFamilia);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_ContactoFamilia", "YouCom"))
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

        public static bool ValidaEliminacionContactoFamilia(DTO.ContactoFamiliaDTO theContactoFamiliaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idContactoFamilia", SqlDbType.VarChar, 20, theContactoFamiliaDTO.IdContactoFamilia);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionContactoFamilia", "YouCom", pobjDatatable) <= 0)
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
