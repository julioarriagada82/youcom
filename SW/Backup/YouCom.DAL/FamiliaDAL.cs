using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class FamiliaDAL
    {
        #region " Metodo getListadoFamilia "
        public static bool getListadoFamilia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoFamilia",
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
        public static bool Insert(YouCom.DTO.FamiliaDTO myFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdOcupacion", SqlDbType.Decimal, -1, myFamiliaDTO.IdOcupacion);
                wobjSQLHelper.SetParametro("@pRutFamilia", SqlDbType.VarChar, 12, myFamiliaDTO.RutFamilia);
                wobjSQLHelper.SetParametro("@pNombreFamilia", SqlDbType.VarChar, 200, myFamiliaDTO.NombreFamilia);
                wobjSQLHelper.SetParametro("@pApellidoPaternoFamilia", SqlDbType.VarChar, 200, myFamiliaDTO.ApellidoPaternoFamilia);
                wobjSQLHelper.SetParametro("@pApellidoMaternoFamilia", SqlDbType.VarChar, 200, myFamiliaDTO.ApellidoMaternoFamilia);
                wobjSQLHelper.SetParametro("@pIdParentesco", SqlDbType.Decimal, -1, myFamiliaDTO.IdParentescoFamilia);
                wobjSQLHelper.SetParametro("@pCelularFamilia", SqlDbType.VarChar, 20, myFamiliaDTO.CelularFamilia);
                wobjSQLHelper.SetParametro("@pTelefonoFamilia", SqlDbType.VarChar, 20, myFamiliaDTO.TelefonoFamilia);
                wobjSQLHelper.SetParametro("@pEmailFamilia", SqlDbType.VarChar, 20, myFamiliaDTO.EmailFamilia);

                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myFamiliaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Familia", "YouCom"))
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
        public static bool Update(YouCom.DTO.FamiliaDTO myFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pIdOcupacion", SqlDbType.Decimal, -1, myFamiliaDTO.IdOcupacion);
                wobjSQLHelper.SetParametro("@pRutFamilia", SqlDbType.VarChar, 12, myFamiliaDTO.RutFamilia);
                wobjSQLHelper.SetParametro("@pNombreFamilia", SqlDbType.VarChar, 200, myFamiliaDTO.NombreFamilia);
                wobjSQLHelper.SetParametro("@pApellidoPaternoFamilia", SqlDbType.VarChar, 200, myFamiliaDTO.ApellidoPaternoFamilia);
                wobjSQLHelper.SetParametro("@pApellidoMaternoFamilia", SqlDbType.VarChar, 200, myFamiliaDTO.ApellidoMaternoFamilia);
                wobjSQLHelper.SetParametro("@pIdParentesco", SqlDbType.Decimal, -1, myFamiliaDTO.IdParentescoFamilia);
                wobjSQLHelper.SetParametro("@pCelularFamilia", SqlDbType.VarChar, 20, myFamiliaDTO.CelularFamilia);
                wobjSQLHelper.SetParametro("@pTelefonoFamilia", SqlDbType.VarChar, 20, myFamiliaDTO.TelefonoFamilia);
                wobjSQLHelper.SetParametro("@pEmailFamilia", SqlDbType.VarChar, 20, myFamiliaDTO.EmailFamilia);

                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myFamiliaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Familia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.FamiliaDTO myFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myFamiliaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Familia", "YouCom"))
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

        public static bool ActivaFamilia(YouCom.DTO.FamiliaDTO theFamiliaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theFamiliaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, theFamiliaDTO.IdFamilia);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Familia", "YouCom"))
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

        public static bool ValidaEliminacionFamilia(DTO.FamiliaDTO theFamiliaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idFamilia", SqlDbType.Decimal, -1, theFamiliaDTO.IdFamilia);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionFamilia", "YouCom", pobjDatatable) <= 0)
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
