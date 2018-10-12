using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Avisos;

public partial class Privado_Avisos_AgregarAviso : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Avisos.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //cargarDatosPropietario();
            cargarCategoria();
            cargarTipoAviso();
        }
    }

    protected void cargarTipoAviso()
    {
        ddlTipoAviso.DataSource = YouCom.bll.Avisos.TipoAvisoBLL.listaTipoAvisoActivo();
        ddlTipoAviso.DataTextField = "NombreTipoAviso";
        ddlTipoAviso.DataValueField = "IdTipoAviso";
        ddlTipoAviso.DataBind();
        ddlTipoAviso.Items.Insert(0, new ListItem("Seleccione Tipo Aviso", string.Empty));
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 8).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    //protected void cargarDatosPropietario()
    //{
    //    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

    //    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

    //    this.TxtNombre.Text = myFamiliaDTO.NombreFamilia;
    //    this.TxtPaterno.Text = myFamiliaDTO.ApellidoPaternoFamilia;
    //    this.TxtMaterno.Text = myFamiliaDTO.ApellidoMaternoFamilia;
    //}

    protected bool setEnviaAviso()
    {
        bool retorno = false;
        bool salida = false;

        AvisoDTO theAvisosDTO = new AvisoDTO();
        theAvisosDTO.TituloAviso = this.TxtTitulo.Text.ToUpper();
        theAvisosDTO.DescripcionAviso = this.TxtDescripcion.Text.ToUpper();
        theAvisosDTO.PrecioAviso = decimal.Parse(this.TxtPrecio.Text);

        theAvisosDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

        theAvisosDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theAvisosDTO.TheCategoriaDTO = myCategoriaDTO;

        YouCom.DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO = new YouCom.DTO.Avisos.TipoAvisoDTO();
        myTipoAvisoDTO.IdTipoAviso = decimal.Parse(ddlTipoAviso.SelectedValue);
        theAvisosDTO.TheTipoAvisoDTO = myTipoAvisoDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
        theAvisosDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.MonedaDTO myMonedaDTO = new YouCom.DTO.MonedaDTO();
        myMonedaDTO.IdMoneda = 1;
        theAvisosDTO.TheMonedaDTO = myMonedaDTO;

        YouCom.DTO.Avisos.AvisoEstadoDTO myAvisosEstadoDTO = new YouCom.DTO.Avisos.AvisoEstadoDTO();
        myAvisosEstadoDTO.IdAvisoEstado = 1;
        theAvisosDTO.TheAvisosEstadoDTO = myAvisosEstadoDTO;

        theAvisosDTO.FechaPublicacion = DateTime.Now;
        theAvisosDTO.FechaTermino = DateTime.Now.AddMonths(1);

        theAvisosDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenAviso.HasFile)
        {
            theAvisosDTO.ImagenAviso = this.ProcessOtherFile(FileImagenPrincipalAviso, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub"));
        }

        retorno = YouCom.bll.Avisos.AvisoBLL.Insert(theAvisosDTO);

        if (retorno)
        {
            string ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub");
            string valor_retorno = string.Empty;
            foreach (var file in FileImagenAviso.PostedFiles)
            {
                if(!string.IsNullOrEmpty(file.FileName))
                {
                    YouCom.DTO.Avisos.ImagenAvisoDTO myImagenAvisoDTO = new YouCom.DTO.Avisos.ImagenAvisoDTO();

                    Random myRandom = new Random();
                    string xName = myRandom.Next(1, 1000000).ToString();

                    if (Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Length > 16)
                        valor_retorno = xName + "_" + Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Substring(0, 16) + Intermedia.IMSystem.IMFile.IMFile.GetExtensionFile(file.FileName);
                    else
                        valor_retorno = xName + "_" + Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Substring(0, Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Length) + Intermedia.IMSystem.IMFile.IMFile.GetExtensionFile(file.FileName);

                    myImagenAvisoDTO.ThumbailImagenAviso = valor_retorno;
                    myImagenAvisoDTO.GrandeImagenAviso = valor_retorno;
                    myImagenAvisoDTO.TituloImagenAviso = this.TxtTitulo.Text;

                    YouCom.DTO.Avisos.AvisoDTO myAvisoDTO = new YouCom.DTO.Avisos.AvisoDTO();
                    myAvisoDTO.IdAviso = YouCom.bll.Avisos.AvisoBLL.getObtenerUltimoAviso().IdAviso;
                    myImagenAvisoDTO.TheAvisosDTO = myAvisoDTO;

                    YouCom.bll.Avisos.ImagenAvisoBLL.Insert(myImagenAvisoDTO);

                    file.SaveAs(Server.MapPath(ruta + valor_retorno));
                }
            }

            salida = true;
        }

        return salida;
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (setEnviaAviso())
                {
                    //if (enviarMail())
                    //{
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Estimado Cliente, hemos recibido su mensaje, en breve nos contactaremos con usted.');";
                        script += "parent.location = '" + retorno1 + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                    //}
                    //else
                    //{
                    //    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    //    {
                    //        string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                    //        script += "parent.location = '" + retorno1 + "';";
                    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    //    }
                    //}
                }
                else
                {
                    string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                    script += "parent.location = '" + retorno1 + "';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);

                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected bool enviarMail()
    {
        try
        {
            string[] _server = YouCom.Service.Generales.General.GetPropiedad("SMTP").Split(new Char[] { ';' });
            string[] _to = YouCom.Service.Generales.General.GetPropiedad("MAILTOCONTACTO").Split(new Char[] { ';' });
            string[] _from = YouCom.Service.Generales.General.GetPropiedad("MAILFROM").Split(new Char[] { ';' });

            System.Net.Mail.MailMessage _mail = new System.Net.Mail.MailMessage();

            _mail.From = new MailAddress(_from[0], _from[1], System.Text.Encoding.UTF8);
            _mail.To.Add(new MailAddress(_to[0], _to[1], System.Text.Encoding.UTF8));

            _mail.Subject = "Contacto " + " " + DateTime.Now.ToString("D");

            _mail.SubjectEncoding = System.Text.Encoding.UTF8;
            _mail.Body = this.creaCuerpo().Replace("ï»¿", "");

            _mail.BodyEncoding = System.Text.Encoding.UTF8;
            _mail.IsBodyHtml = true;

            SmtpClient _smtp = new SmtpClient();

            _smtp.Send(_mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    protected string creaCuerpo()
    {
        string Url = "http://" + Request.Url.Authority + "/mailing/plantilla_contacto_mailing.htm";

        System.Net.WebClient client = new System.Net.WebClient();
        String htmlCode = client.DownloadString(Url);
        string newhtmlCode = "";

        newhtmlCode = Regex.Replace(htmlCode, "src=\"images", "src=\"" + "http://" + Request.Url.Authority + "/mailing/images", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        //newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", this.TxtNombre.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Paterno}", this.TxtPaterno.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Materno}", this.TxtMaterno.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Telefono}", this.ddlTipoAviso.SelectedItem.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Celular}", this.TxtPrecio.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Titulo}", this.TxtTitulo.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtDescripcion.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }
}
