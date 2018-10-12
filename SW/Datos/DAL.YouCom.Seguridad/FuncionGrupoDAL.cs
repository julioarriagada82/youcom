using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.DAL
{
    public class FuncionGrupoDAL
    {
        public static bool ListaGruposSistema(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("getFuncionGrupoSistema",
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



            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;

        }

        #region CRUD FuncionGrupo

        public static bool ListadoFuncionGrupo(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("Qry_ListaFuncionGrupo",
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



            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;

        }
        public static bool InsertFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionGrupo", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoNombre);

            try
            {
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_FuncionGrupo", "YouCom"))
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
        public static bool ActivaFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);

            try
            {
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("ActivaFuncionGrupo", "YouCom"))
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
        public static bool UpdateFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionNombre", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoNombre);
            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);


            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_FuncionGrupo", "YouCom"))
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
        public static bool DeleteFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);

            try
            {

                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_FuncionGrupo", "YouCom"))
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
        public static bool ValidaEliminacionFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO, ref DataTable pobjDatable)
        {

            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionFuncionGrupo", "YouCom", pobjDatable) <= 0)
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
        #endregion FuncionGrupo
    }
}
