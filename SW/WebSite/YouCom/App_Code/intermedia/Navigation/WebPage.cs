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
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

using System.Text.RegularExpressions;

using System.Net;
using System.Text;

using Intermedia.IMSystem.IMFile;
 
namespace Intermedia.IMSystem.Navigation.Page
{
    /// <summary>
    /// Summary description for WebPage
    /// </summary>
    public class WebPage : System.Web.UI.Page
    {
        public YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
        protected string _empresa = "Banco Internacional";
        protected string _titulo = "Informativo Banco Internacioal";

        protected override void OnInit(EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)Session["usuario"];
                base.OnInit(e);
            }
            else
            {
                Logout("http://" + Request.Url.Authority + ResolveUrl("~/") + "index.aspx");
            }
        }

        void Logout(string pag)
        {
            GC.Collect();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            Response.Redirect(pag, true); // CAMBIAR
        }
     
        public WebPage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected string replace(String tag, String reemplazo, String html)
        {
            return html.Replace(tag, reemplazo);
        }

        public String getPageName()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
            String result = arrResult[arrResult.GetUpperBound(0)];
            arrResult = result.Split('?');
            return arrResult[arrResult.GetLowerBound(0)];
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