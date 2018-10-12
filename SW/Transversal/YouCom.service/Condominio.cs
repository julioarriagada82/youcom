using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using YouCom.Service.BD;
using System.Data;
using System.Xml;

namespace YouCom.Service
{
    public class Condominio
    {
        #region " Metodo Consulta Datos de la Empresa "
        public static Boolean GetConsultaEmpresa(string mvarRutCondominio, ref XmlDocument pdomResponse)
        {
            Boolean retorno = false;
            DataTable wobjCondominio = new DataTable();

            try
            {
                //Consulta datos de Grupo.
                //====================================================================================
                if (GetCondominio(mvarRutCondominio, wobjCondominio))
                {
                    //Armo Xml de respuesta.
                    //====================================================================================
                    ArmoXMLRespuesta(wobjCondominio,
                                     pdomResponse);

                    retorno = true;
                    //====================================================================================	
                }
            }

            #region Catch
            catch (Exception eobjException)
            {
                YouCom.Service.Configuracion.Xml.getArmaXMLError(eobjException, ref pdomResponse);
                retorno = false;
            }
            #endregion

            return retorno;
        }
        private static Boolean GetCondominio(string mvarRutCondominio, DataTable pobjDataTable)
        {
            Boolean retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pRutCondominio",
                                           SqlDbType.VarChar,
                                           20,
                                           mvarRutCondominio);

                //====================================================================================
                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_ExisteCondominio",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    throw new Exception("Estimado cliente, rut no Existe");
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
        private static void ArmoXMLRespuesta(DataTable pobjCondominios,
                                      XmlDocument pdomResponse)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            pdomResponse.LoadXml(YouCom.Service.Configuracion.Config.GetXmlResponse());

            try
            {
                wvarPaso = 200;
                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                   "KTFResponse/Datos",
                                   "IdCondominio",
                                   pobjCondominios.Rows[0]["idCondominio"].ToString());

                wvarPaso = 210;
                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                   "KTFResponse/Datos",
                                   "NombreCondominio",
                                   pobjCondominios.Rows[0]["nombreCondominio"].ToString());
            }

            #region Catch
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion
        }
        #endregion // Metodo Consulta Datos de la Empresa
    }
}
