using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using YouCom.Service.BD;

namespace YouCom.Service.Accesos
{
    public class AccesoLogin
    {
        public static Boolean updAccesoLogin(YouCom.DTO.AccesoLoginDTO IAccesoLogin)
        {
            Boolean retorno = false;

            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAccesoLogin",
                                           SqlDbType.Decimal,
                                           -1,
                                           IAccesoLogin.IdAccesoLogin);

                wobjSQLHelper.SetParametro("@pFecha",
                                           SqlDbType.DateTime,
                                           -1,
                                           IAccesoLogin.Fecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_AccesoLogin", "KTF"))
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
                //SystemLog.Ejecutar(eobjException, EventLogEntryType.Error);
                retorno = false;
            }
            #endregion

            return retorno;
        }

        public static Boolean insAccesoLogin(YouCom.DTO.AccesoLoginDTO IAccesoLogin)
        {
            Boolean retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRutLogin",
                                           SqlDbType.VarChar,
                                           -1,
                                           IAccesoLogin.RutLogin);

                wobjSQLHelper.SetParametro("@pRutCondominio",
                                           SqlDbType.VarChar,
                                           -1,
                                           IAccesoLogin.RutCondominio);

                wobjSQLHelper.SetParametro("@pIp",
                                           SqlDbType.VarChar,
                                           -1,
                                           IAccesoLogin.Ip);

                wobjSQLHelper.SetParametro("@pFecha",
                                           SqlDbType.DateTime,
                                           -1,
                                           IAccesoLogin.Fecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_AccesoLogin", "KTF"))
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
                //SystemLog.Ejecutar(eobjException, EventLogEntryType.Error);
                retorno = false;
            }
            #endregion

            return retorno;
        }

        public static Boolean insHistoricoAccesoLogin(YouCom.DTO.AccesoLoginDTO IAccesoLogin)
        {
            Boolean retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRutLogin",
                                           SqlDbType.VarChar,
                                           -1,
                                           IAccesoLogin.RutLogin);

                wobjSQLHelper.SetParametro("@pRutCondominio",
                                           SqlDbType.VarChar,
                                           -1,
                                           IAccesoLogin.RutCondominio);

                wobjSQLHelper.SetParametro("@pIp",
                                           SqlDbType.VarChar,
                                           -1,
                                           IAccesoLogin.Ip);

                wobjSQLHelper.SetParametro("@pFecha",
                                           SqlDbType.DateTime,
                                           -1,
                                           IAccesoLogin.Fecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_HistoriaAccesoLogin", "KTF"))
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
                //SystemLog.Ejecutar(eobjException, EventLogEntryType.Error);
                retorno = false;
            }
            #endregion

            return retorno;
        }

        #region Consulta Acceso Login
        private static Boolean GetConsultaAccesoLogin(string mvarRutLogin, DataTable pobjDataTable)
        {
            bool retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRutLogin",
                                           SqlDbType.VarChar,
                                           -1,
                                           mvarRutLogin);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_AccesoLogin1",
                                           "KTF",
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
        public static IList<YouCom.DTO.AccesoLoginDTO> getConsultaAccesoLogin(string rut_login)
        {
            IList<YouCom.DTO.AccesoLoginDTO> IAccesoLogin = new List<YouCom.DTO.AccesoLoginDTO>();

            DataTable wobjConsulta = new DataTable();

            if (GetConsultaAccesoLogin(rut_login, wobjConsulta))
            {
                foreach (DataRow wobjDataRow in wobjConsulta.Rows)
                {
                    YouCom.DTO.AccesoLoginDTO acceso = new YouCom.DTO.AccesoLoginDTO();

                    acceso.IdAccesoLogin = decimal.Parse(wobjDataRow["IdAccesoLogin"].ToString());
                    acceso.RutLogin = wobjDataRow["RutLogin"].ToString();
                    acceso.RutCondominio = wobjDataRow["RutCondominio"].ToString();
                    acceso.Ip = wobjDataRow["IP"].ToString();
                    acceso.Fecha = Convert.ToDateTime(wobjDataRow["Fecha"].ToString());
                    IAccesoLogin.Add(acceso);
                }
            }
            return IAccesoLogin;
        }

        private static Boolean GetConsultaAccesoLogin(string mvarRutLogin, string mvarRutCondominio, DataTable pobjDataTable)
        {
            bool retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRutLogin",
                                           SqlDbType.VarChar,
                                           -1,
                                           mvarRutLogin);

                wobjSQLHelper.SetParametro("@pRutCondominio",
                                           SqlDbType.VarChar,
                                           -1,
                                           mvarRutCondominio);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_AccesoLogin",
                                           "KTF",
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
        public static IList<YouCom.DTO.AccesoLoginDTO> getConsultaAccesoLogin(string rut_login, string rut_empresa)
        {
            IList<YouCom.DTO.AccesoLoginDTO> IAccesoLogin = new List<YouCom.DTO.AccesoLoginDTO>();

            DataTable wobjConsulta = new DataTable();

            if (GetConsultaAccesoLogin(rut_login,rut_empresa, wobjConsulta))
            {
                foreach (DataRow wobjDataRow in wobjConsulta.Rows)
                {
                    YouCom.DTO.AccesoLoginDTO acceso = new YouCom.DTO.AccesoLoginDTO();

                    acceso.IdAccesoLogin = decimal.Parse(wobjDataRow["IdAccesoLogin"].ToString());
                    acceso.RutLogin = wobjDataRow["RutLogin"].ToString();
                    acceso.RutCondominio = wobjDataRow["RutCondominio"].ToString();
                    acceso.Ip = wobjDataRow["IP"].ToString();
                    acceso.Fecha = Convert.ToDateTime(wobjDataRow["Fecha"].ToString());
                    IAccesoLogin.Add(acceso);
                }
            }
            return IAccesoLogin;
        }
        #endregion
    }
}
