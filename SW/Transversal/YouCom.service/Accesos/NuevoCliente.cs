using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.Service.BD;
using System.Data;

namespace YouCom.Service.Accesos
{
    public class NuevoCliente
    {
        public static Boolean insNuevoCliente(YouCom.DTO.NuevoClienteDTO INuevoCliente)
        {
            Boolean retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pFechaCreacion",
                                           SqlDbType.DateTime,
                                           -1,
                                           INuevoCliente.FechaCreacion);

                wobjSQLHelper.SetParametro("@pRutCondominio",
                                           SqlDbType.VarChar,
                                           -1,
                                           INuevoCliente.RutCondominio);

                wobjSQLHelper.SetParametro("@pRutLogin",
                                           SqlDbType.VarChar,
                                           -1,
                                           INuevoCliente.RutLogin);

                wobjSQLHelper.SetParametro("@pCambiaClave",
                                           SqlDbType.VarChar,
                                           -1,
                                           INuevoCliente.CambiaClave);

                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_NuevoCliente", "KTF"))
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

        public static Boolean updNuevoCliente(YouCom.DTO.NuevoClienteDTO INuevoCliente)
        {
            Boolean retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pFechaCambioClave",
                                           SqlDbType.DateTime,
                                           -1,
                                           INuevoCliente.FechaCambioClave);

                wobjSQLHelper.SetParametro("@pRutLogin",
                                           SqlDbType.VarChar,
                                           -1,
                                           INuevoCliente.RutLogin);

                wobjSQLHelper.SetParametro("@pCambiaClave",
                                           SqlDbType.VarChar,
                                           -1,
                                           INuevoCliente.CambiaClave);

                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_NuevoCliente", "KTF"))
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

        private static Boolean GetConsultaNuevoCliente(string mvarRutLogin, DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_NuevoCliente",
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

        public static YouCom.DTO.NuevoClienteDTO getConsultaNuevoCliente(string rut_login)
        {
            YouCom.DTO.NuevoClienteDTO INuevoCliente = new YouCom.DTO.NuevoClienteDTO();

            DataTable wobjConsulta = new DataTable();

            if (GetConsultaNuevoCliente(rut_login, wobjConsulta))
            {
                foreach (DataRow wobjDataRow in wobjConsulta.Rows)
                {
                    INuevoCliente.IdNuevoCliente = decimal.Parse(wobjDataRow["IdNuevoCliente"].ToString());
                    INuevoCliente.RutLogin = wobjDataRow["RutLogin"].ToString();
                    INuevoCliente.RutCondominio = wobjDataRow["RutCondominio"].ToString();
                    INuevoCliente.FechaCreacion = Convert.ToDateTime(wobjDataRow["FechaCreacion"].ToString());
                    INuevoCliente.CambiaClave = wobjDataRow["CambiaClave"].ToString();

                    INuevoCliente.CodError = 0;
                    INuevoCliente.DesError = "OK";
                }
            }
            return INuevoCliente;
        }
    }
}
