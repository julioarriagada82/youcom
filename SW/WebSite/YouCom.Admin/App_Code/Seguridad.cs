using Intermedia.IMSystem.IMFile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Seguridad
/// </summary>
public class Seguridad : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        if (Session["InformacionUsuario"] == null)
        {
            //Login.paginaAnterior = string.Empty;
            Response.Redirect("~/index.aspx");
        }
        base.OnInit(e);
    }

    public YouCom.DTO.Seguridad.OperadorDTO Informacionusuario()
    {
        List<YouCom.DTO.Seguridad.OperadorDTO> operador = new List<YouCom.DTO.Seguridad.OperadorDTO>();
        operador = (Session["InformacionUsuario"] as List<YouCom.DTO.Seguridad.OperadorDTO>);

        YouCom.DTO.Seguridad.OperadorDTO theOperadorDTO = new YouCom.DTO.Seguridad.OperadorDTO();

        foreach (var item in operador)
        {
            theOperadorDTO.Usuario = item.Usuario;
            theOperadorDTO.Nombres = item.Nombres;
            theOperadorDTO.Paterno = item.Paterno;
            theOperadorDTO.Materno = item.Materno;
            theOperadorDTO.TheComunidadDTO = item.TheComunidadDTO;
            theOperadorDTO.TheCondominioDTO = item.TheCondominioDTO;
            theOperadorDTO.TheCasaDTO = item.TheCasaDTO;
        }
        return theOperadorDTO;
        {

        }
    }

    public string ProcessOtherFile(System.Web.UI.WebControls.FileUpload file, System.Web.UI.WebControls.CheckBox eliminarImagen, string ruta)
    {
        string retorno = "";
        if (!string.IsNullOrEmpty(file.PostedFile.FileName))
        {
            Random myRandom = new Random();
            string xName = myRandom.Next(1, 1000000).ToString();
            if (IMFile.GetNameFile(file.PostedFile.FileName).Length > 16)
                retorno = xName + "_" + IMFile.GetNameFile(file.PostedFile.FileName).Substring(0, 16) + IMFile.GetExtensionFile(file.PostedFile.FileName);
            else
                retorno = xName + "_" + IMFile.GetNameFile(file.PostedFile.FileName).Substring(0, IMFile.GetNameFile(file.PostedFile.FileName).Length) + IMFile.GetExtensionFile(file.PostedFile.FileName);
            file.PostedFile.SaveAs(Server.MapPath(ruta + retorno));
        }
        if (eliminarImagen != null)
        {
            if (eliminarImagen.Checked)
            {
                IMFile.Delete(Server.MapPath(ruta + retorno));
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

