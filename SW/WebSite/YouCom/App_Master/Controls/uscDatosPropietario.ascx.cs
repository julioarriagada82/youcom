using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Controls_uscDatosPropietario : Intermedia.IMSystem.Navigation.UserControl.WebUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarDatosPropietario();
        }
    }

    protected void cargarDatosPropietario()
    {
        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

        this.TxtNombre.Text = myFamiliaDTO.NombreFamilia;
        this.TxtPaterno.Text = myFamiliaDTO.ApellidoPaternoFamilia;
        this.TxtMaterno.Text = myFamiliaDTO.ApellidoMaternoFamilia;

        this.TxtEmail.Text = myFamiliaDTO.EmailFamilia;
    }
}