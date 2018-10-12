using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.DAL
{
    public class FuncionTipoDAL
    {
        #region CRUD FuncionTipo

        public static bool ListadoFuncionTipo(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaFuncionTipo",
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
            return retorno;
            #endregion


        }
        public static bool InsertFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@NombreTipoFuncion", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoNombre);


            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_TipoFuncion", "YouCom"))
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
        public static bool ActivaFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);
            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_FuncionTipo", "YouCom"))
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
        public static bool UpdateFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionNombre", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoNombre);
            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);



            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_TipoFuncion", "YouCom"))
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
        public static bool DeleteFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);


            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_TipoFuncion", "YouCom"))
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
        public static bool ValidaEliminacionFuncionTipo(FuncionTipoDTO theFuncionTipoDTO, ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionFuncionTipo", "YouCom", pobjDatable) <= 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
                //====================================================================================



            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        #endregion FuncionTipo
    }
}
