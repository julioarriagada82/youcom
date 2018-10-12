using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Encriptacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnEncriptar_Click(object sender, EventArgs e)
    {
        this.TxtEncriptado.Text = YouCom.Service.Seguridad.Crypt.Encriptar(this.TxtInicial.Text, YouCom.Service.Configuracion.Config.GetPropiedad("TokenPwd"));
    }
    protected void BtnDesencriptar_Click(object sender, EventArgs e)
    {
        this.TxtFinal.Text = YouCom.Service.Seguridad.Crypt.Desencriptar(this.TxtEncriptado.Text, YouCom.Service.Configuracion.Config.GetPropiedad("TokenPwd"));
    }
}
