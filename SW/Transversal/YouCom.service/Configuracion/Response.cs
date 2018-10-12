using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.Service.Configuracion
{
    public class Response
    {
        public Response()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string xmlArmaRespuesta(string etiqueta, string valor, string cod_respuesta, string des_respuesta)
        {
            try
            {
                StringBuilder builder = new StringBuilder("");

                builder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                builder.Append("<KTFResponse>");
                builder.Append("<FechaProceso>" + DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToShortTimeString() + "</FechaProceso>");
                builder.Append("<Datos>");
                builder.Append("<" + etiqueta + ">" + valor + "</" + etiqueta + ">");
                builder.Append("</Datos>");
                builder.Append("<Errores>");
                builder.Append("<Error>");
                builder.Append("<ErrorCod>" + cod_respuesta + "</ErrorCod>");
                builder.Append("<ErrorDes>" + des_respuesta + "</ErrorDes>");
                builder.Append("</Error>");
                builder.Append("</Errores>");
                builder.Append("</KTFResponse>");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string xmlArmaRespuesta(string valor, string cod_respuesta, string des_respuesta)
        {
            try
            {
                StringBuilder builder = new StringBuilder("");

                builder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                builder.Append("<KTFResponse>");
                builder.Append("<FechaProceso>" + DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToShortTimeString() + "</FechaProceso>");
                builder.Append("<Datos>");
                builder.Append(valor);
                builder.Append("</Datos>");
                builder.Append("<Errores>");
                builder.Append("<Error>");
                builder.Append("<ErrorCod>" + cod_respuesta + "</ErrorCod>");
                builder.Append("<ErrorDes>" + des_respuesta + "</ErrorDes>");
                builder.Append("</Error>");
                builder.Append("</Errores>");
                builder.Append("</KTFResponse>");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string xmlArmaRespuesta(string cod_respuesta, string des_respuesta)
        {
            try
            {
                StringBuilder builder = new StringBuilder("");

                builder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                builder.Append("<KTFResponse>");
                builder.Append("<FechaProceso>" + DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToShortTimeString() + "</FechaProceso>");
                builder.Append("<Datos/>");
                builder.Append("<Errores>");
                builder.Append("<Error>");
                builder.Append("<ErrorCod>" + cod_respuesta + "</ErrorCod>");
                builder.Append("<ErrorDes>" + des_respuesta + "</ErrorDes>");
                builder.Append("</Error>");
                builder.Append("</Errores>");
                builder.Append("</KTFResponse>");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

