using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for KtErrores
/// </summary>
/// 
namespace YouCom.Web
{
	public class KtErrores
	{
		public KtErrores()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        //Errores

        public static string MuestraError(YouCom.DTO.Seguridad.UsuarioDTO myUsuario, Exception ex, string pSistema, string pPagina)
        {

            System.Diagnostics.StackTrace wobjStackTrace = new System.Diagnostics.StackTrace();
            System.Diagnostics.StackFrame wobjStackFrame = wobjStackTrace.GetFrame(0);

            //if (ex.Message.Contains("Thread was being aborted."))
            //{
            EventLog(YouCom.Service.Configuracion.General.getPageName(true), wobjStackFrame.GetMethod().Name, ex);
            //}

            return YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ERROR", "MENSAJE");
        }
        public static string MuestraError(string pagina, string Procedure, Exception Exception)
		{
			EventLog(pagina, Procedure, Exception);

			return YouCom.Service.Configuracion.Config.GetPropiedad("ErrorGeneral").ToString();
		}

		public static void EventLog(string pagina, string Procedure, Exception Exception)
		{
			string NomFile = YouCom.Service.Configuracion.Config.GetPropiedad("EventLog");
			NomFile = NomFile + "_" + DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + ".log";
			System.IO.StreamWriter SW;
			try
			{
				SW = new System.IO.StreamWriter(NomFile, true);
				SW.WriteLine("*******************INICIO LOG ERRORES ********************");
				SW.WriteLine("Fecha:" + DateTime.Now);
				SW.WriteLine("Error Source:" + Exception.Source.Trim());
				SW.WriteLine("Error Menssage:" + Exception.Message.Trim());
				SW.WriteLine("Error Library: " + Exception.Data.ToString().Trim());
				SW.WriteLine("Error StackTrace: " + Exception.StackTrace.ToString().Trim());
				SW.WriteLine("Error Page: " + pagina.Trim());
				SW.WriteLine("Error Procedure: " + Procedure.Trim());
				SW.WriteLine("Error Location Client:" + System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].Trim());
				SW.WriteLine("*******************FIN LOG ERRORES ********************");
				SW.Close();
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}
	}
}
