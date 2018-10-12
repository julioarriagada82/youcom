using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using YouCom.Service.BD;
using System.Web;
using System.Xml.Serialization;
using System.Threading;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace YouCom.Service.Parametrizacion
{
   public class Parametros:IParametros
    {
        public static YouCom.DTO.ParametrosDTO GetConsultaParametros1(string concepto, string codigo)
        {
            IList<YouCom.DTO.ParametrosDTO> myParametros = new List<YouCom.DTO.ParametrosDTO>();
            YouCom.DTO.ParametrosDTO IParametros = new YouCom.DTO.ParametrosDTO();
            myParametros = (IList<YouCom.DTO.ParametrosDTO>)HttpContext.Current.Session["datos_parametros"];

            if (myParametros.Where(x => x.Codigo == codigo && x.Concepto == concepto).Any())
            {
                IParametros = myParametros.Where(x => x.Codigo == codigo && x.Concepto == concepto).FirstOrDefault();
            }
            return IParametros;
        }

       public static string GetConsultaParametros(string concepto, string codigo)
        {
            string retorno = string.Empty;
            XmlDocument xmlResponse = new XmlDocument();

            if (ConsultaDescripcionParametros(concepto.Trim(), codigo.Trim(), ref xmlResponse))
            {
                if (xmlResponse.SelectSingleNode("KTFResponse").HasChildNodes)
                {
                    XmlNode xmlMod = xmlResponse.SelectSingleNode("KTFResponse/Datos/Respuesta");
                    retorno = xmlMod.SelectSingleNode("Descripcion").InnerText;
                }
                else
                {
                    retorno = "INFORMACIÓN NO CARGADA";
                }
            }
            else
            {
                retorno = "INFORMACIÓN NO CARGADA";
            }

            return retorno;
        }

       public static string getDescripcionParametros(string codigo, string concepto)
       {
           string retorno = string.Empty;

           XmlDocument xmlResponse = new XmlDocument();

            if (ConsultaDescripcionParametros(concepto.Trim(), codigo.Trim(), ref xmlResponse))
            {
               if (xmlResponse.SelectSingleNode("KTFResponse").HasChildNodes)
               {
                   XmlNode xmlMod = xmlResponse.SelectSingleNode("KTFResponse/Datos/Respuesta");
                   retorno = xmlMod.SelectSingleNode("Descripcion").InnerText;
               }
               else
               {
                   retorno = "INFORMACIÓN NO CARGADA";
               }
           }
           else
           {
               retorno = "INFORMACIÓN NO CARGADA";
           }

           return retorno;
       }
       public static Boolean ConsultaDescripcionParametros(string pConcepto, string pCodigo, ref XmlDocument pdomResponse)
       {
           bool retorno = false;
           DataTable wobjParametros = new DataTable();

           try
           {
               if (GetConsultaDescripcion(pConcepto, pCodigo, wobjParametros))
               {
                   ArmoXMLRespuesta(wobjParametros, pdomResponse);
                   retorno = true;
               }
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
       private static bool GetConsultaDescripcion(string pConcepto, string pCodigo, DataTable pobjDataTable)
       {
           bool retorno = false;
           SQLHelper wobjSQLHelper = new SQLHelper();

           try
           {
               //Seteo Parámetros.
               //====================================================================================
               wobjSQLHelper.SetParametro("@Concepto",
                                          SqlDbType.VarChar,
                                          -1,
                                          pConcepto);

               wobjSQLHelper.SetParametro("@Codigo",
                                          SqlDbType.VarChar,
                                          -1,
                                          pCodigo);
               //====================================================================================


               //Ejecuto SP.
               //====================================================================================
               if (wobjSQLHelper.Ejecutar("wp_parametro_get_by_codigo_and_concepto",
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
       private static void ArmoXMLRespuesta(DataTable pobjDataTable, XmlDocument pdomResponse)
       {
           StringBuilder builder = new StringBuilder("");

           try
           {
               builder.Append("<KTFResponse>");
               builder.Append("<Datos>");

               foreach (DataRow wobjDataRow in pobjDataTable.Rows)
               {
                   builder.Append("<Respuesta>");
                   builder.Append("<Descripcion>" + "<![CDATA[" + wobjDataRow["Descripcion"].ToString() + "]]>" + "</Descripcion>");
                   builder.Append("<DescripcionCorta>" + wobjDataRow["DescripcionCorta"].ToString() + "</DescripcionCorta>");
                   builder.Append("</Respuesta>");
               }

               builder.Append("</Datos>");
               builder.Append("</KTFResponse>");

               pdomResponse.LoadXml(builder.ToString());

           }

           #region Catch
           catch (Exception eobjException)
           {
               throw eobjException;
           }
           #endregion
       }
       public static String getPageName(bool full)
       {
           string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
           String result = arrResult[arrResult.GetUpperBound(0)];
           arrResult = result.Split('?');
           if (full)
               return arrResult[arrResult.GetLowerBound(0)];
           else
               return arrResult[arrResult.GetLowerBound(0)].Substring(0, arrResult[arrResult.GetLowerBound(0)].Length - 5);
       }
       public static Boolean ConsultaConcepto(string pConcepto, ref DataTable pobjDataTable)
       {
           bool retorno = false;
           SQLHelper wobjSQLHelper = new SQLHelper();
           
           try
           {
               //Seteo Parámetros.
               //====================================================================================
               wobjSQLHelper.SetParametro("@Concepto",
                                          SqlDbType.VarChar,
                                          -1,
                                          pConcepto);
               //====================================================================================


               //Ejecuto SP.
               //====================================================================================
               if (wobjSQLHelper.Ejecutar("wp_parametro_get_by_concepto",
                                          "YouCom",
                                          pobjDataTable) <= 0)
               {
                   throw new Exception("Error en la Consulta.");
               }

               retorno = true;
               //====================================================================================
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

       public static YouCom.DTO.ParametrosDTO getParametro(string pParametroId)
       {
           string statesKey = "ConsDetPar";

            YouCom.DTO.ParametrosDTO IParametros = new YouCom.DTO.ParametrosDTO();

           XmlDocument xmlResponse = new XmlDocument();
           String[,] aparams = new String[1, 2];

           aparams[0, 0] = "ParametroId"; aparams[0, 1] = pParametroId;

           if (ConsultaParametro(decimal.Parse(pParametroId), ref xmlResponse))
           {
               if (xmlResponse.SelectSingleNode("KTFResponse/Datos").HasChildNodes)
               {
                   XmlNode xmlMod = xmlResponse.SelectSingleNode("KTFResponse/Datos/Respuesta/Parametros/Parametro");

                   IParametros.IdParametro = decimal.Parse(xmlMod.SelectSingleNode("Id").InnerText);
                   IParametros.Concepto = xmlMod.SelectSingleNode("Concepto").InnerText;
                   IParametros.Codigo = xmlMod.SelectSingleNode("Codigo").InnerText;
                   IParametros.Descripcion = xmlMod.SelectSingleNode("Descripcion").InnerText;
                   IParametros.DescripcionCorta = xmlMod.SelectSingleNode("DescripcionCorta").InnerText;
                   IParametros.Orden = int.Parse(xmlMod.SelectSingleNode("Orden").InnerText);
                   IParametros.Estado = xmlMod.SelectSingleNode("Estado").InnerText;
               }
           }
           return IParametros;
       }
       public static Boolean ConsultaParametro(decimal pParametroId, ref XmlDocument pdomResponse)
       {
           bool retorno = false;
           DataTable wobjParametros = new DataTable();

           try
           {
               //Consulto Descripcion.
               //====================================================================================
               if (GetConsultaParametro(pParametroId, wobjParametros))
               {
                   pdomResponse.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlResponse());

                   YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                      "KTFResponse/Datos",
                                      "Respuesta",
                                      null);

                   YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                      "KTFResponse/Datos/Respuesta",
                                      "Parametros",
                                      null);

                   foreach (DataRow wobjDataRow in wobjParametros.Rows)
                   {

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros",
                                          "Parametro",
                                          null);

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "Id",
                                          wobjDataRow["IdParametro"].ToString());

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "Concepto",
                                          wobjDataRow["Concepto"].ToString());

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "Codigo",
                                          wobjDataRow["Codigo"].ToString());

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "Descripcion",
                                          wobjDataRow["Descripcion"].ToString());

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "DescripcionCorta",
                                          wobjDataRow["DescripcionCorta"].ToString());

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "Orden",
                                          wobjDataRow["Orden"].ToString());

                       YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Respuesta/Parametros/Parametro[last()]",
                                          "Estado",
                                          wobjDataRow["Estado"].ToString());

                   }

                   retorno = true;
               }
               //====================================================================================

               //Armo Xml de respuesta.
               //====================================================================================
               //====================================================================================
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
       private static bool GetConsultaParametro(decimal mvarParametroId, DataTable pobjDataTable)
       {
           Boolean retorno = false;
           SQLHelper wobjSQLHelper = new SQLHelper();

           try
           {
               //Seteo Parámetros.
               //====================================================================================
               wobjSQLHelper.SetParametro("@pIdParametro",
                                          SqlDbType.Decimal,
                                          -1,
                                          mvarParametroId);

               //====================================================================================
               //Ejecuto SP.
               //====================================================================================
               if (wobjSQLHelper.Ejecutar("QRY_Parametro",
                                          "YouCom",
                                          pobjDataTable) <= 0)
               {
                   throw new Exception("Error en la Consulta.");
               }

               retorno = true;
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

       public static void setParametro(YouCom.DTO.ParametrosDTO IParametros)
       {
            insParametros(IParametros);
       }

       private static bool insParametros(YouCom.DTO.ParametrosDTO IParametros)
       {
           bool retorno = false;
           SQLHelper wobjSQLHelper = new SQLHelper();

           try
           {
               //Seteo Parámetros.
               //====================================================================================
               wobjSQLHelper.SetParametro("@pParametroId",
                                          SqlDbType.Decimal,
                                          -1,
                                          IParametros.IdParametro);

               wobjSQLHelper.SetParametro("@pConcepto",
                                          SqlDbType.VarChar,
                                          -1,
                                          IParametros.Concepto);

               wobjSQLHelper.SetParametro("@pCodigo",
                                          SqlDbType.VarChar,
                                          -1,
                                          IParametros.Codigo);

               wobjSQLHelper.SetParametro("@pDescripcionLarga",
                                          SqlDbType.VarChar,
                                          -1,
                                          IParametros.Descripcion);

               wobjSQLHelper.SetParametro("@pDescripcionCorta",
                                          SqlDbType.VarChar,
                                          -1,
                                          IParametros.DescripcionCorta);

               wobjSQLHelper.SetParametro("@pOrden",
                                          SqlDbType.VarChar,
                                          -1,
                                          IParametros.Orden);

               wobjSQLHelper.SetParametro("@pEstado",
                                          SqlDbType.VarChar,
                                          -1,
                                          IParametros.Estado);
               //====================================================================================
               //Ejecuto SP.
               //====================================================================================
               switch (wobjSQLHelper.EjecutarNQ("INS_Parametros", "YouCom"))
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

       public static bool delParametro(string mvarParametroId)
       {
           bool retorno = false;
           SQLHelper wobjSQLHelper = new SQLHelper();

           try
           {
               //Seteo Parámetros.
               //====================================================================================
               wobjSQLHelper.SetParametro("@pIdParametro",
                                          SqlDbType.Decimal,
                                          -1,
                                          decimal.Parse(mvarParametroId));
               //====================================================================================
               //Ejecuto SP.
               //====================================================================================
               switch (wobjSQLHelper.EjecutarNQ("DEL_Parametro", "YouCom"))
               {
                   case 0:
                       throw new Exception("No se pudo eliminar.");
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

       #region IParametros Members

       public static IList<YouCom.DTO.ParametrosDTO> getParametros(string pConcepto)
       {
           string retorno = string.Empty;

           IList<YouCom.DTO.ParametrosDTO> IParametros = new List<YouCom.DTO.ParametrosDTO>();

           XmlDocument xmlResponse = new XmlDocument();

           DataTable pobjDataTable = new DataTable();

           if (ConsultaConcepto(pConcepto, ref pobjDataTable))
           {
               foreach (DataRow wobjDataRow in pobjDataTable.Rows)
               {
                    YouCom.DTO.ParametrosDTO par = new YouCom.DTO.ParametrosDTO();

                   par.Codigo = wobjDataRow["Codigo"].ToString();
                   par.Descripcion = wobjDataRow["Descripcion"].ToString();
                   par.DescripcionCorta = wobjDataRow["DescripcionCorta"].ToString();
                   IParametros.Add(par);
               }
           }
           return IParametros;

       }
       bool IParametros.GetConsultaDescripcion(string pConcepto, string pCodigo, DataTable pobjDataTable)
       {
           throw new NotImplementedException();
       }

       void IParametros.ArmoXMLRespuesta(DataTable pobjDataTable, XmlDocument pdomResponse)
       {
           throw new NotImplementedException();
       }

       #endregion

       #region IParametros Members

       string IParametros.getDescripcionParametros(string codigo, string concepto)
       {
           string retorno = string.Empty;

           XmlDocument xmlResponse = new XmlDocument();

           if (Parametros.ConsultaDescripcionParametros(concepto.Trim(), codigo.Trim(), ref xmlResponse))
           {
               if (xmlResponse.SelectSingleNode("KTFResponse").HasChildNodes)
               {
                   XmlNode xmlMod = xmlResponse.SelectSingleNode("KTFResponse/Datos/Respuesta");
                   retorno = xmlMod.SelectSingleNode("Descripcion").InnerText;
               }
               else
                   retorno = "INFORMACIÓN NO CARGADA";
           }
           else
               retorno = "INFORMACIÓN NO CARGADA";

           return retorno;
       }

       bool IParametros.ConsultaDescripcionParametros(string pConcepto, string pCodigo, ref XmlDocument pdomResponse)
       {
           throw new NotImplementedException();
       }

       string IParametros.getPageName(bool full)
       {
           throw new NotImplementedException();
       }

       public static YouCom.DTO.ParametrosDTO getDescripcionParametros2(string codigo, string concepto)
       {
            YouCom.DTO.ParametrosDTO IParametros = new YouCom.DTO.ParametrosDTO();

           XmlDocument xmlResponse = new XmlDocument();

           if (ConsultaDescripcionParametros(concepto, codigo, ref xmlResponse))
           {
               if (xmlResponse.SelectSingleNode("KTFResponse").HasChildNodes)
               {
                   XmlNode xmlMod = xmlResponse.SelectSingleNode("KTFResponse/Datos/Respuesta");

                   IParametros.Descripcion = xmlMod.SelectSingleNode("Descripcion").InnerText;
                   IParametros.DescripcionCorta = xmlMod.SelectSingleNode("DescripcionCorta").InnerText;
               }
           }

           return IParametros;
       }

       #endregion
    }
}
