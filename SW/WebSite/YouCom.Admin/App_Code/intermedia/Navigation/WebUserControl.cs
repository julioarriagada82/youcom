using Intermedia.IMSystem.IMFile;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using System.Web.Caching;

using System.Linq;

using System.Xml;
using System.Text;

using System.IO;

using System.Globalization;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;

namespace Intermedia.IMSystem.Navigation.UserControl
{
    /// <summary>
    /// Summary description for WebUserControl
    /// </summary>
    public class WebUserControl : System.Web.UI.UserControl
    {
        public YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
        protected string _empresa = "Banco Internacional";
        protected string _titulo = "Informativo Banco Internacioal";
        protected HSSFWorkbook hssfworkbook;

        public WebUserControl()
        {
        }

        public string GetUserRut()
        {
            if (Session["SessionRut"] != null)
            {
                return Session["SessionRut"].ToString();
            }
            else
            {
                return "";
            }
        }

        public String getPageName()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
            String result = arrResult[arrResult.GetUpperBound(0)];
            arrResult = result.Split('?');
            return arrResult[arrResult.GetLowerBound(0)];
        }
        public void muestraError(Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ERROR", script, true);
        }
        private static string GetXml()
        {
            return "<KTFRequest>" +
                   "</KTFRequest>";
        }
        protected string replace(String tag, String reemplazo, String html)
        {
            return html.Replace(tag, reemplazo);
        }
        
        //protected bool EnviaCorreoError(string subject, string motivo, string trace, string parametros)
        //{
        //    bool retorno = false;
        //    bool ip_existe = false;

        //    string[] _to;
        //    try
        //    {
        //        IList<BI.DTO.Parametros> IParametros = new List<BI.DTO.Parametros>();
        //        IParametros = BI.Service.Parametrizacion.Parametros.getParametros("IPMONITOREO");

        //        foreach (BI.DTO.Parametros para in IParametros)
        //        {
        //            if (para.Codigo.Equals(HttpContext.Current.Request.UserHostAddress))
        //            {
        //                ip_existe = true;
        //            }
        //        }

        //        if (subject.Contains("Error Servicio BUS -"))
        //            _to = Config.GetPropiedad("EmailErrorBUS").Split(new Char[] { ';' });
        //        else
        //            _to = Config.GetPropiedad("EmailErrorServicio").Split(new Char[] { ';' });

        //        string bcc = string.Empty;
        //        string cc = string.Empty;
        //        int contador = 0;
        //        foreach (string s in _to)
        //        {
        //            if (contador > 2)
        //                cc = cc + s + ";";

        //            contador += 1;
        //        }

        //        if (!ip_existe)
        //        {
        //            System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress("bancointernacional@bancointernacional.cl", "Banco Internacional");
        //            System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(_to[0], _to[1]);
        //            BI.Service.Mensajeria.Mensajes.SendEmail(subject, CuerpoCorreoError(_to[1], motivo, trace, parametros), to, from, cc.Substring(0, cc.Length - 1), bcc, "mailing_header.jpg");
        //        }
        //        retorno = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return retorno;
        //}

        //protected string CuerpoCorreoError(string nombre_envia, string motivo, string trace, string parametros)
        //{
        //    String result = string.Empty;
        //    myUsuario = (BI.DTO.Usuario)Session["usuario"];
        //    try
        //    {
        //        String dir = Server.MapPath("~/App_Data/Archivos");
        //        result = System.IO.File.ReadAllText(dir + "/mailing_error_servicio.html");

        //        result = replace("[SERVER]", "http://" + Request.Url.Authority + ResolveUrl("~/"), result);
        //        if (myUsuario.Rut.Equals(myUsuario.RutCondominio))
        //            result = replace("[TIPO_CLI]", "Cliente Persona", result);
        //        else
        //        result = replace("[TIPO_CLI]", "Cliente Empresa", result);
        //        result = replace("[nombre]", nombre_envia, result);
        //        result = replace("[FECHA]", System.DateTime.Now.ToString(), result);
        //        result = replace("[RUT_CLIENTE]", myUsuario.Rut, result);
        //        result = replace("[RUT_EMPRESA]", myUsuario.RutCondominio, result);
        //        result = replace("[NOMBRE_CLIENTE]", myUsuario.NombreCompleto, result);
        //        result = replace("[ERROR]", motivo, result);
        //        result = replace("[TRACE]", trace, result);
        //        result = replace("[PAGINA]", General.getPageName(), result);
        //        result = replace("[IP]", BI.Service.Configuracion.General.getObtieneIP(), result);
        //        //result = replace("[IP]", HttpContext.Current.Request.UserHostAddress, result);
        //        result = replace("[PARAMETROS]", parametros, result);
        //    }
        //    #region Catch
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    #endregion

        //    return result;
        //}

        //public void ErrorServicio(string error, string mensaje_error)
        //{
        //    try
        //    {
        //        string mensaje = string.Empty;
        //        string urlerror = string.Empty;
        //        string parametros = string.Empty;
        //        bool ip_existe = false;

        //        XmlDocument xmlError = new XmlDocument();

        //        IList<BI.DTO.Parametros> IParametros = new List<BI.DTO.Parametros>();
        //        IParametros = BI.Service.Parametrizacion.Parametros.getParametros("IPMONITOREO");

        //        foreach (BI.DTO.Parametros para in IParametros)
        //        {
        //            if (para.Codigo.Equals(HttpContext.Current.Request.UserHostAddress))
        //            {
        //                ip_existe = true;
        //            }
        //        }

        //        try
        //        {
        //            xmlError.LoadXml(error);

        //            mensaje = xmlError.SelectSingleNode("ERROR/MENSAJE").InnerText.ToString() + "   ";
        //            mensaje += "\r\n " + xmlError.SelectSingleNode("ERROR/EXCEPTION").InnerText.ToString();
        //            urlerror = "Error Servicio " + xmlError.SelectSingleNode("ERROR/SERVICIO").InnerText.ToString() + " <br/> Metodo " + xmlError.SelectSingleNode("ERROR/METODO").InnerText.ToString();
        //            parametros = xmlError.SelectSingleNode("ERROR/ENTRADA").OuterXml.Replace("<ENTRADA>", "").Replace("</ENTRADA>", "").Replace("<", "&lt;").Replace(">", "&gt;");
        //            parametros = "Parametros de Entrada:<br/>" + parametros.Replace("&gt;&lt;", "&gt;<br/>&lt;");
        //        }
        //        catch (Exception ex)
        //        {
        //            mensaje = error;
        //            urlerror = mensaje_error + error;
        //        }

        //        if (!ip_existe)
        //        {
        //            myUsuario = (BI.DTO.Usuario)Session["usuario"];
        //            EnviaCorreoError(mensaje_error, urlerror, mensaje, parametros);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static DateTimeFormatInfo getCultureFormatoFecha()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            culture = new CultureInfo("es-CL");
            DateTimeFormatInfo format = culture.DateTimeFormat;

            return format;
        }
        
        //Envio Error Comunicacion con Indexa
        //public bool EnviaCorreoComunicacion(string cod_estado, string desc_estado, string msg_error, string comercio, string id_unico_banco)
        //{
        //    try
        //    {
        //        myUsuario = (BI.DTO.Usuario)Session["usuario"];

        //        string nombre_cliente = BI.Service.Configuracion.General.getNombreRutCliente(myUsuario);

        //        string[] _from = null;
        //        string[] _to = null;

        //        string MyParaFrom = BI.Service.Parametrizacion.Parametros.getDescripcionParametros("FROM", "CORREO");
        //        string MyParaTO = BI.Service.Parametrizacion.Parametros.getDescripcionParametros("TOERROR_INDEXA", "CORREO");

        //        if (MyParaFrom != "" && MyParaTO != "")
        //        {
        //            _from = MyParaFrom.ToString().Split(new Char[] { ';' });
        //            _to = MyParaTO.ToString().Split(new Char[] { ';' });

        //            System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(_from[0], _from[1]);
        //            System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(_to[0], _to[1]);

        //            if (BI.Service.Mensajeria.Mensajes.SendEmail("Error Comunicación Pago Servicio " + comercio, CuerpoCorreoErrorComunicacion(cod_estado, desc_estado, msg_error, id_unico_banco), to, from, "mailing_header.jpg"))
        //                return true;
        //            else
        //                return false;
        //        }
        //        else
        //            return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //private string CuerpoCorreoErrorComunicacion(string cod_estado, string desc_estado, string msg_error, string id_unico_banco)
        //{
        //    String result = "";

        //    try
        //    {
        //        myUsuario = (BI.DTO.Usuario)Session["usuario"];

        //        string rut_cliente = BI.Service.Configuracion.General.getRutCliente(myUsuario);
        //        string nombre_cliente = BI.Service.Configuracion.General.getNombreRutCliente(myUsuario);

        //        string MyParaTO = BI.Service.Parametrizacion.Parametros.getDescripcionParametros("TOERROR_INDEXA", "CORREO");
        //        string[] _to = MyParaTO.ToString().Split(new Char[] { ';' });

        //        String dir = Server.MapPath("~/" + Application.Get("TransactionResources"));

        //        result = System.IO.File.ReadAllText(dir + "/Archivos/mailing_error_comunicacion.html");

        //        result = replace("[SERVER]", "http://" + Request.Url.Authority + ResolveUrl("~/"), result);
        //        result = replace("[cod_estado]", cod_estado, result);
        //        result = replace("[nom_estado]", desc_estado, result);
        //        result = replace("[rut_cliente]", Formato.FormatoRut(rut_cliente), result);
        //        result = replace("[nombre_cliente]", nombre_cliente, result);
        //        result = replace("[id_unico_banco]", id_unico_banco, result);
        //        result = replace("[msg_error]", msg_error, result);
        //        result = replace("[nombre]", _to[1], result);
        //    }
        //    #region Catch
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //        return "";
        //    }
        //    #endregion
        //    return result;
        //}

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }
        public MemoryStream WriteToStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }

        public void InitializeWorkbook()
        {
            hssfworkbook = new  HSSFWorkbook();

            
            ////create a entry of DocumentSummaryInformation
             DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = _empresa;
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = _titulo;
            hssfworkbook.SummaryInformation = si;
        }
        public int LoadImage(string path, HSSFWorkbook wb)
        {
            FileStream file = new FileStream(Server.MapPath(path), FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, (int)file.Length);
            return wb.AddPicture(buffer,NPOI.SS.UserModel.PictureType.JPEG);
        }
        public string getGeneraMensajeValidacion()
        {
            string script = " function popupValidacion(){ \n";
            script += "     var ask = confirm(\"Estimado Cliente, antes de continuar por favor verifique el formato del celular, ¿está seguro que desea continuar?\");\n";
            script += "     if (!ask) return false;\n";
            script += "     else return true;\n";
            script += " }\n";

            return script;
        }

        public string ProcessOtherFile(System.Web.UI.WebControls.FileUpload file, System.Web.UI.WebControls.CheckBox eliminarImagen, string ruta)
        {
            string retorno = "";
            if (!string.IsNullOrEmpty(file.PostedFile.FileName))
            {
                Random myRandom = new Random();
                string xName = myRandom.Next(1, 1000000).ToString();
                if (IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Length > 16)
                    retorno = xName + "_" + IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Substring(0, 16) + IMFile.IMFile.GetExtensionFile(file.PostedFile.FileName);
                else
                    retorno = xName + "_" + IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Substring(0, IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Length) + IMFile.IMFile.GetExtensionFile(file.PostedFile.FileName);
                file.PostedFile.SaveAs(Server.MapPath(ruta + retorno));
            }
            if (eliminarImagen != null)
            {
                if (eliminarImagen.Checked)
                {
                    IMFile.IMFile.Delete(Server.MapPath(ruta + retorno));
                    retorno = "";
                    eliminarImagen.Checked = false;
                    eliminarImagen.Visible = false;
                }
            }
            return retorno;
        }


        public string GetMaxUploadMessage()
        {
            return ConfigurationManager.AppSettings["MaxUploadMessage"];
        }

        protected string GetBasePath()
        {
            string path = "~/fckeditor/";
            return path;
        }

        public long GetMaxUpload()
        {
            return long.Parse(ConfigurationManager.AppSettings["MaxUpload"]);
        }
    }
}
