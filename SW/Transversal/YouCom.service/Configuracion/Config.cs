using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Collections.Specialized;

namespace YouCom.Service.Configuracion
{
    public class Config
    {
        public static string GetPropiedad(string pvarPropiedad)
        {
            AppSettingsReader appSettings = null;

            try
            {

                appSettings = new AppSettingsReader();
                return (string)appSettings.GetValue(pvarPropiedad, typeof(string));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
        public static String getPageName()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
            String result = arrResult[arrResult.GetUpperBound(0)];
            arrResult = result.Split('?');
            return arrResult[arrResult.GetLowerBound(0)].Substring(0, arrResult[arrResult.GetLowerBound(0)].Length - 5);
        }
        public static string getPageName(string[] pagina)
        {
            //string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
            string result = pagina[pagina.GetUpperBound(0)];
            pagina = result.Split('?');
            return pagina[pagina.GetLowerBound(0)];
        }

        public static string GetXmlResponse()
        {
            return "<KTFResponse>" +
                   " <Datos>" +
                   " <Token/>" +
                   " </Datos>" +
                   "</KTFResponse>";
        }
        public static string GetXmlRequest()
        {
            return "<KTFRequest>" +
                    "<TransaccionCod />" +
                    "<Contexto>" +
                    "   <AmbienteId />" +
                    "   <IdCondominio />" +
                    "   <Token />" +
                    "   <UsuarioCod />" +
                    "   <TerminalID />" +
                    "   <TerminalUbicacion />" +
                    "   <CanalCod />" +
                    "</Contexto>" +
                    "<Parametros/>" +
                    "</KTFRequest>";
        }
        public static string GetXmlErrorServicio()
        {
            return "<ERROR>" +
                    "<ENTRADA />" +
                    "<MENSAJE />" +
                    "<EXCEPTION />" +
                    "<SERVICIO />" +
                    "<METODO />" +
                    "</ERROR>";
        }
    }
}
