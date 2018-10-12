using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;

namespace YouCom.Service.Configuracion
{
   public static class Xml
    {


       public static string RemueveCaracteresInvalidos(string str)
       {
           return Regex.Replace(str, "[^a-zA-Z0-9_.- ]+", "", RegexOptions.Compiled);
       }

        //Para el manejo de los errores
        //====================================================================================
        const string MODULO = "KtCommon";
        const string TIPO = "FunXml";
        //====================================================================================

        public static void ArmoXMLRespuestaConsultaPeriodo(DataTable pobjDataTable, XmlDocument pdomResponse)
        {
            StringBuilder builder = new StringBuilder("");

            try
            {
                builder.Append("<KTFResponse>");
                builder.Append("<Datos>");
                builder.Append("<Respuesta>");
                builder.Append("<Parametros>");

                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    builder.Append("<Salida>");
                    builder.Append("<Codigo>" + wobjDataRow["MES"].ToString() + "</Codigo>");
                    builder.Append("<Descripcion>" + wobjDataRow["MES"].ToString() + "</Descripcion>");
                    builder.Append("</Salida>");
                }

                builder.Append("</Parametros>");
                builder.Append("</Respuesta>");
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
        public static bool getArmaXMLError(Exception ex, ref XmlDocument pdomResponse)
        {
            bool retorno = false;

            try
            {
                pdomResponse.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlError());
                pdomResponse.SelectSingleNode("KTFResponse/FechaProceso").InnerXml = DateTime.Now.ToString();
                pdomResponse.SelectSingleNode("KTFResponse/Errores/Error/ErrorCod").InnerXml = "999";
                pdomResponse.SelectSingleNode("KTFResponse/Errores/Error/ErrorDes").InnerXml = ex.Message;

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
        public static XmlDocument armaXMLLogin(string UserName, string Password)
        {
            XmlDocument xmlRequest = new XmlDocument();
            string sXmlResponse = "";

            try
            {
                xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlLogin());

                xmlRequest.SelectSingleNode("KTFRequest/TransaccionCod").InnerText = "Login";

                xmlRequest.SelectSingleNode("KTFRequest/Contexto/UsuarioCod").InnerText = UserName;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/Password").InnerText = Password;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/GrupoCod").InnerText = "0";
                //xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = HttpContext.Current.Request.UserHostAddress;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = YouCom.Service.Generales.General.getObtieneIP();
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/CanalCod").InnerText = YouCom.Service.Configuracion.Config.GetPropiedad("CanalCod");
            }
            catch (Exception ex)
            {
                sXmlResponse = "<Error><ErrorCod></ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
            }

            return xmlRequest;
        }

        public static XmlDocument armaXMLLogin(string UserName, string UserEmpresa, string TipoIngreso, string Password)
        {
            XmlDocument xmlRequest = new XmlDocument();
            string sXmlResponse = "";

            try
            {
                xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlLogin());

                xmlRequest.SelectSingleNode("KTFRequest/TransaccionCod").InnerText = "Login";

                xmlRequest.SelectSingleNode("KTFRequest/Contexto/UsuarioCod").InnerText = UserName;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/EmpresaCod").InnerText = UserEmpresa;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/TipoIngreso").InnerText = TipoIngreso;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/Password").InnerText = Password;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/GrupoCod").InnerText = "0";
                //xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = HttpContext.Current.Request.UserHostAddress;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = YouCom.Service.Generales.General.getObtieneIP();
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/CanalCod").InnerText = YouCom.Service.Configuracion.Config.GetPropiedad("CanalCod");
            }
            catch (Exception ex)
            {
                sXmlResponse = "<Error><ErrorCod></ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
            }

            return xmlRequest;
        }

        public static XmlDocument armaXMLServicio(string[,] trxParams)
        {
            XmlDocument xmlRequest = new XmlDocument();
            string sXmlResponse = "";

            try
            {
                xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlRequestParametro());
                for (int i = 0; i < trxParams.GetLength(0); i++)
                {
                    string xpath = "";
                    foreach (string nodo in trxParams[i, 0].Split(new Char[] { '/' }))
                    {
                        if (xmlRequest.SelectNodes("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath) + "/" + nodo).Count == 0)
                            xmlRequest.SelectSingleNode("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath)).InnerXml += "<" + Formato.LimpiaParametro(nodo) + "/>";

                        xpath += "/" + nodo;
                    }
                    xmlRequest.SelectSingleNode("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath)).InnerXml = Formato.LimpiaParametro(trxParams[i, 1]);
                }
            }
            catch (Exception ex)
            {
                sXmlResponse = "<Error><ErrorCod></ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
            }

            return xmlRequest;
        }

        public static XmlDocument armaXML(string trxName, string[,] trxParams)
        {
            YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();

            if (HttpContext.Current.Session != null)
            {
                myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)HttpContext.Current.Session["usuario"];
            }

            XmlDocument xmlRequest = new XmlDocument();
            string sXmlResponse = "";

            try
            {
                if (HttpContext.Current.Session != null)
                {
                    xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlRequest());
                    xmlRequest.SelectSingleNode("KTFRequest/TransaccionCod").InnerText = trxName;

                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/Token").InnerText = myUsuario.Token;
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/UsuarioCod").InnerText = myUsuario.Rut;
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/GrupoCod").InnerText = myUsuario.IndexCondominio.ToString();
                    //xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = HttpContext.Current.Request.UserHostAddress;
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = YouCom.Service.Generales.General.getObtieneIP();
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/CanalCod").InnerText = YouCom.Service.Configuracion.Config.GetPropiedad("CanalCod");
                }
                else
                {
                    xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlRequest());
                    xmlRequest.SelectSingleNode("KTFRequest/TransaccionCod").InnerText = trxName;

                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/Token").InnerText = "";
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/UsuarioCod").InnerText = "";
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/GrupoCod").InnerText = "0";
                    //xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = HttpContext.Current.Request.UserHostAddress;
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = YouCom.Service.Generales.General.getObtieneIP();
                    xmlRequest.SelectSingleNode("KTFRequest/Contexto/CanalCod").InnerText = YouCom.Service.Configuracion.Config.GetPropiedad("CanalCod");
                }

                for (int i = 0; i < trxParams.GetLength(0); i++)
                {
                    string xpath = "";
                    foreach (string nodo in trxParams[i, 0].Split(new Char[] { '/' }))
                    {
                        if (xmlRequest.SelectNodes("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath) + "/" + nodo).Count == 0)
                            xmlRequest.SelectSingleNode("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath)).InnerXml += "<" + Formato.LimpiaParametro(nodo) + "/>";

                        xpath += "/" + nodo;
                    }
                    xmlRequest.SelectSingleNode("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath)).InnerXml = Formato.LimpiaParametro(trxParams[i, 1]);
                }
            }
            catch (Exception ex)
            {
                sXmlResponse = "<Error><ErrorCod></ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
            }

            return xmlRequest;
        }

        public static XmlDocument armaXMLPublico(string trxName, string[,] trxParams)
        {
            XmlDocument xmlRequest = new XmlDocument();
            string sXmlResponse = "";

            try
            {
                xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlRequest());
                xmlRequest.SelectSingleNode("KTFRequest/TransaccionCod").InnerText = trxName;

                xmlRequest.SelectSingleNode("KTFRequest/Contexto/Token").InnerText = "";
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/UsuarioCod").InnerText = "";
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/GrupoCod").InnerText = "0";
                //xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = HttpContext.Current.Request.UserHostAddress;
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/TerminalID").InnerText = YouCom.Service.Generales.General.getObtieneIP();
                xmlRequest.SelectSingleNode("KTFRequest/Contexto/CanalCod").InnerText = YouCom.Service.Configuracion.Config.GetPropiedad("CanalCod");

                for (int i = 0; i < trxParams.GetLength(0); i++)
                {
                    string xpath = "";
                    foreach (string nodo in trxParams[i, 0].Split(new Char[] { '/' }))
                    {
                        if (xmlRequest.SelectNodes("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath) + "/" + nodo).Count == 0)
                            xmlRequest.SelectSingleNode("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath)).InnerXml += "<" + Formato.LimpiaParametro(nodo) + "/>";

                        xpath += "/" + nodo;
                    }
                    xmlRequest.SelectSingleNode("KTFRequest/Parametros" + Formato.LimpiaParametro(xpath)).InnerXml = Formato.LimpiaParametro(trxParams[i, 1]);
                }
            }
            catch (Exception ex)
            {
                sXmlResponse = "<Error><ErrorCod></ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
            }

            return xmlRequest;
        }

        public static void AgregarNodo(XmlDocument pdomXmlDocument,
                                       string pvarNodo,
                                       string pvarNuevo,
                                       object pvarValor)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "AgregarNodo";
            int wvarPaso = 0;
            //====================================================================================


            XmlElement wdomElement;

            try
            {
                //Creo nuevo elemento.
                //====================================================================================
                wvarPaso = 10;
                wdomElement = pdomXmlDocument.CreateElement(pvarNuevo);
                //====================================================================================


                //Si vino un valor se lo asigno.
                //====================================================================================
                wvarPaso = 20;
                if (pvarValor != null &&
                    pvarValor.ToString() != "")
                {
                    wvarPaso = 30;
                    wdomElement.InnerText = pvarValor.ToString();
                }
                //====================================================================================


                //Agrego nuevo nodo al dom.
                //====================================================================================
                wvarPaso = 40;
                pdomXmlDocument.SelectSingleNode(pvarNodo).AppendChild(wdomElement);
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }


        public static XmlNode GetCtxNodo(XmlDocument pdomRequest,
                                         string pvarPathRel)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetCtxNodo";
            int wvarPaso = 0;
            //====================================================================================

            const string PAR_PATH = "KTFRequest/Contexto/";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                return pdomRequest.SelectSingleNode(PAR_PATH + pvarPathRel);
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }


        public static XmlNode GetParNodo(XmlDocument pdomRequest,
                                         string pvarPathRel)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParNodo";
            int wvarPaso = 0;
            //====================================================================================

            const string PAR_PATH = "KTFRequest/Parametros/";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                return pdomRequest.SelectSingleNode(PAR_PATH + pvarPathRel);
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }


        public static XmlNodeList GetParNodos(XmlDocument pdomRequest,
                                              string pvarPathRel)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParNodos";
            int wvarPaso = 0;
            //====================================================================================

            const string PAR_PATH = "KTFRequest/Parametros/";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                return pdomRequest.SelectNodes(PAR_PATH + pvarPathRel);
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static string GetParString(XmlDocument pdomRequest,
                                          string pvarPathRel)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParString";
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                return GetParNodo(pdomRequest,
                                  pvarPathRel).InnerText;
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static Boolean GetParDateTime(XmlDocument pdomRequest,
                                             string pvarPathRel,
                                         ref DateTime pvarVariable)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParDateTime-S1";
            int wvarPaso = 0;
            //====================================================================================

            string wvarParametro = "";

            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                wvarParametro = GetParString(pdomRequest, pvarPathRel);
                //====================================================================================


                //Cargo Variable.
                //====================================================================================
                try
                {
                    wvarPaso = 20;
                    pvarVariable = DateTime.Parse(wvarParametro);
                }
                catch
                {
                    return false;
                }
                //====================================================================================

                return true;
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static Boolean GetParDateTime(XmlDocument pdomRequest,
                                             string pvarPathRel,
                                         ref DateTime pvarVariable,
                                             string pvarFormat)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParDateTime-S2";
            int wvarPaso = 0;
            //====================================================================================

            string wvarParametro = "";

            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                wvarParametro = GetParString(pdomRequest, pvarPathRel);
                //====================================================================================


                //Cargo Variable.
                //====================================================================================
                try
                {
                    wvarPaso = 20;
                    pvarVariable = DateTime.ParseExact(wvarParametro,
                                                       pvarFormat,
                                                       DateTimeFormatInfo.InvariantInfo);
                }
                catch
                {
                    return false;
                }
                //====================================================================================

                return true;
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static Boolean GetParShort(XmlDocument pdomRequest,
                                          string pvarPathRel,
                                      ref short pvarVariable)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParShort";
            int wvarPaso = 0;
            //====================================================================================

            string wvarParametro = "";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                wvarParametro = GetParString(pdomRequest, pvarPathRel);
                //====================================================================================


                //Cargo Variable.
                //====================================================================================
                try
                {
                    wvarPaso = 20;
                    pvarVariable = short.Parse(wvarParametro);
                }
                catch
                {
                    return false;
                }
                //====================================================================================

                return true;


            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static Boolean GetParInt(XmlDocument pdomRequest,
                                        string pvarPathRel,
                                    ref int pvarVariable)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParInt";
            int wvarPaso = 0;
            //====================================================================================

            string wvarParametro = "";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                wvarParametro = GetParString(pdomRequest, pvarPathRel);
                //====================================================================================


                //Cargo Variable.
                //====================================================================================
                try
                {
                    wvarPaso = 20;
                    pvarVariable = int.Parse(wvarParametro);
                }
                catch
                {
                    return false;
                }
                //====================================================================================

                return true;


            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static Boolean GetParDecimal(XmlDocument pdomRequest,
                                            string pvarPathRel,
                                        ref decimal pvarVariable)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParDecimal";
            int wvarPaso = 0;
            //====================================================================================

            string wvarParametro = "";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                wvarParametro = GetParString(pdomRequest, pvarPathRel);
                //====================================================================================


                //Cargo Variable.
                //====================================================================================
                try
                {
                    wvarPaso = 20;
                    pvarVariable = decimal.Parse(wvarParametro);
                }
                catch
                {
                    return false;
                }
                //====================================================================================

                return true;


            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static Boolean GetParFloat(XmlDocument pdomRequest,
                                          string pvarPathRel,
                                      ref float pvarVariable)
        {
            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "GetParFloat";
            int wvarPaso = 0;
            //====================================================================================

            string wvarParametro = "";


            try
            {
                //Busco el nodo.
                //====================================================================================
                wvarPaso = 10;
                wvarParametro = GetParString(pdomRequest, pvarPathRel);
                //====================================================================================


                //Cargo Variable.
                //====================================================================================
                try
                {
                    wvarPaso = 20;
                    pvarVariable = float.Parse(wvarParametro);
                }
                catch
                {
                    return false;
                }
                //====================================================================================

                return true;


            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }
        public static string GetXmlCuentaCorriente()
        {
            return "<Respuesta>" +
                      "</Respuesta>";
        }
        public static string GetXmlRequest()
        {
            return "<KTFRequest>" +
                    "<TransaccionCod />" +
                    "<Contexto>" +
                    "   <AmbienteId />" +
                    "   <GrupoCod />" +
                    "   <Token />" +
                    "   <UsuarioCod />" +
                    "   <TerminalID />" +
                    "   <TerminalUbicacion />" +
                    "   <CanalCod />" +
                    "</Contexto>" +
                    "<Parametros/>" +
                    "</KTFRequest>";
        }
        public static string GetPatPassXmlRequest()
        {
            return "<TBKPatData>" +
                   "<Perfil>" +
                   "       <NombreUsuario/>" +
                   "       <ContrasenaUsuario/>" +
                   "</Perfil>" +
                   "<DuracionToken/>" +
                   "<DatosUsuario>" +
                   "   <RutUsuario/>" +
                   "   <DataAuditoriaUsuario/>" +
                   "</DatosUsuario>" +
                   "<DatosTarjetas/>" +
                   "<IP/>" +
                   "</TBKPatData>";
        }
        public static string GetXmlLogin()
        {
            return "<KTFRequest>" +
                   "<TransaccionCod />" +
                   " <Contexto>" +
                   "   <UsuarioCod />" +
                   "   <EmpresaCod />" +
                   "   <TipoIngreso />" +
                   "   <Password />" +
                   "   <GrupoCod />" +
                   "   <TerminalID />" +
                   "   <TerminalUbicacion />" +
                   "   <CanalCod />" +
                   " </Contexto>" +
                   "</KTFRequest>";
        }
        public static string GetXmlResponseIndexa()
        {
            return "<PAGOSONLINE>" +
                   " <RESPUESTASOLICITUDAUTORIZACION>" +
                   " </RESPUESTASOLICITUDAUTORIZACION>" +
                   "</PAGOSONLINE>";
        }
        public static string GetXmlResponse1()
        {
            return "<KTF_Response>" +
                   "</KTF_Response>";
        }
        public static string GetXmlResponse()
        {
            return "<KTFResponse>" +
                   " <Datos>" +
                   " <Token/>" +
                   " </Datos>" +
                   "</KTFResponse>";
        }
        public static string GetXmlErrorServicio()
        {
            return "<ERROR>" +
                    "<ENTRADA />" +
                    "<MENSAJE />" +
                    "<EXCEPTION />" +
                    "<SERVICIO />" +
                    "<METODO />" +
                    "<CodError />" +
                    "</ERROR>";
        }
        public static string GetXmlRequestParametro()
        {
            return "<KTFRequest>" +
                    "<Parametros/>" +
                    "</KTFRequest>";
        }
        public static string GetXmlError()
        {
            return "<KTFResponse>" +
                    "<FechaProceso/>" +
                    "<Datos />" +
                    "<Errores>" +
                    "<Error>" +
                    "<ErrorCod />" +
                    "<ErrorDes />" +
                    "</Error>" +
                    "</Errores>" +
                    "</KTFResponse>";
        }

        public static XmlDocument obtieneXMLSalida(XmlDocument xmlResponse)
        {
            xmlResponse.LoadXml(GetXmlResponse());

            return xmlResponse;
        }
    }
}
