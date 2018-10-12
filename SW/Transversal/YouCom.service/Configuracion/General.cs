using BI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using YouCom.Service.BD;

namespace YouCom.Service.Configuracion
{
    public static class General
    {
        public static string getGeneraClave(int largo)
        {
            string retorno = string.Empty;
            Guid guid = Guid.NewGuid();

            retorno = guid.ToString().Replace("-", "");

            retorno = retorno.Substring(0, largo);

            return retorno;
        }
        
        static private string sKTFError = "No se ha podido establecer conexión. Intente más tarde.";

        public static byte[] ReadFully(Stream input, int inicio)
        {
            for (int i = 0; i < inicio; i++)
            {
                input.ReadByte();
            }

            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static Boolean Authenticate(string UserName, string Password, ref string sXmlResponse)
        {
            XmlDocument xmlRequest = new XmlDocument();
            XmlDocument xmlResponse = new XmlDocument();

            xmlRequest = Xml.armaXMLLogin(UserName, "****");

            try
            {
                YouCom.Service.Seguridad.Login login = new YouCom.Service.Seguridad.Login();
                login.LoginUsuario(UserName, Password, ref xmlResponse);

                cargaDatosUsuario(UserName, xmlResponse);

                return true;
            }
            catch (Exception ex)
            {
                char[] separador = { '|' };
                string[] words = ex.Message.Split(separador);
                sXmlResponse = "<Error><ErrorCod>" + words[0] + "</ErrorCod><ErrorDes>" + words[1] + "</ErrorDes></Error>";
                return false;
            }
        }
        public static Boolean AuthenticateEmpresa(string UserName, string UserEmpresa, string Password, bool pass, ref string sXmlResponse)
        {
            XmlDocument xmlRequest = new XmlDocument();
            XmlDocument xmlResponse = new XmlDocument();

            xmlRequest = Xml.armaXMLLogin(UserName, "****");

            try
            {
                YouCom.Service.Seguridad.Login login = new YouCom.Service.Seguridad.Login();

                login.LoginUsuario(UserName, Password, pass, ref xmlResponse);

                cargaDatosCondominio(UserName, UserEmpresa, xmlResponse);

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("TrSegConGrpRut"))
                {
                    sXmlResponse = "<Error><ErrorCod>2</ErrorCod><ErrorDes>Estimado Cliente, el rut ingresado no es un cliente persona.</ErrorDes></Error>";
                    return false;
                }
                else
                {
                    if (ex.Message.Contains("|"))
                    {
                        char[] separador = { '|' };
                        string[] words = ex.Message.Split(separador);
                        sXmlResponse = "<Error><ErrorCod>" + words[0] + "</ErrorCod><ErrorDes>" + words[1] + "</ErrorDes></Error>";
                        return false;
                    }
                    else
                    {
                        sXmlResponse = "<Error><ErrorCod>9999</ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
                        return false;
                    }
                }
            }
        }

        public static Boolean AuthenticateEmpresa(string UserName, string UserEmpresa, string Password, ref string sXmlResponse)
        {
            XmlDocument xmlRequest = new XmlDocument();
            XmlDocument xmlResponse = new XmlDocument();

            xmlRequest = Xml.armaXMLLogin(UserName, "****");

            try
            {
                YouCom.Service.Seguridad.Login login = new YouCom.Service.Seguridad.Login();

                login.LoginUsuario(UserName, UserEmpresa, Password, ref xmlResponse);

                cargaDatosCondominio(UserName, UserEmpresa, xmlResponse);
                YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();

                return true;
            }
            catch (Exception ex)
            {

                EventLog("Login.aspx", "", ex);

                if (ex.Message.Contains("TrSegConGrpRut"))
                {
                    sXmlResponse = "<Error><ErrorCod>2</ErrorCod><ErrorDes>Estimado Cliente, el rut ingresado no es un cliente persona.</ErrorDes></Error>";
                    return false;
                }
                else
                {
                    if (ex.Message.Contains("|"))
                    {
                        char[] separador = { '|' };
                        string[] words = ex.Message.Split(separador);
                        sXmlResponse = "<Error><ErrorCod>" + words[0] + "</ErrorCod><ErrorDes>" + words[1] + "</ErrorDes></Error>";
                        return false;
                    }
                    else
                    {
                        sXmlResponse = "<Error><ErrorCod>9999</ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";
                        return false;
                    }
                }
            }
        }

        public static Boolean AuthenticateAdmin(string UserName, string Password, ref string sXmlResponse)
        {
            XmlDocument xmlRequest = new XmlDocument();
            XmlDocument xmlResponse = new XmlDocument();

            xmlRequest = YouCom.Service.Configuracion.Xml.armaXMLLogin(UserName, "****");

            try
            {
                YouCom.Service.Seguridad.Login login = new YouCom.Service.Seguridad.Login();

                login.LoginUsuarioAdmin(UserName, Password, ref xmlResponse);

                cargaDatosAdmin(UserName, xmlResponse);

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("TrSegConGrpRut"))
                {
                    sXmlResponse = "<Error><ErrorCod>2</ErrorCod><ErrorDes>Estimado Cliente, el rut ingresado no es un cliente persona.</ErrorDes></Error>";
                    return false;
                }
                else
                {
                    char[] separador = { '|' };
                    string[] words = ex.Message.Split(separador);
                    sXmlResponse = "<Error><ErrorCod>" + words[0] + "</ErrorCod><ErrorDes>" + words[1] + "</ErrorDes></Error>";
                    return false;
                }
            }
        }

        private static void cargaDatosAdmin(string UserName, XmlDocument xmlResponse)
        {
            if (xmlResponse.SelectSingleNode("KTFResponse/Datos").HasChildNodes)
            {
                YouCom.DTO.Seguridad.UsuarioDTO user = new YouCom.DTO.Seguridad.UsuarioDTO();

                //DATOS USUARIO
                user.Token = xmlResponse.SelectSingleNode("KTFResponse/Datos/Token").InnerText;
                user.Rut = UserName.Trim();
                user.RutSinDV = UserName.Substring(0, UserName.Length - 1).Trim();
                user.DV = UserName.Substring(UserName.Length - 1, 1).Trim();
                user.NombreCompleto = xmlResponse.SelectSingleNode("KTFResponse/Datos/PersonaDescripcion").InnerText;
                //user.Email = IDatos.EMail.ToString();

                string strTipo = string.Empty;

                XmlDocument xmlCondominio1 = new XmlDocument();
                xmlCondominio1.LoadXml(xmlResponse.SelectSingleNode("KTFResponse/Datos/Condominios/Condominio/IdCondominio").InnerText);

                foreach (XmlNode xmlCondominio in xmlCondominio1.SelectNodes("Condominios1/Condominio"))
                {
                    YouCom.DTO.Seguridad.CondominioDTO cond = new YouCom.DTO.Seguridad.CondominioDTO();

                    if (xmlCondominio.SelectSingleNode("RolCod").InnerText == "0" || xmlCondominio.SelectSingleNode("RolCod").InnerText == "1"
                        || xmlCondominio.SelectSingleNode("RolCod").InnerText == "2")
                    {
                        cond.IdCondominio = decimal.Parse(xmlCondominio.SelectSingleNode("idCondominio").InnerText);
                        cond.RutCondominio = xmlCondominio.SelectSingleNode("rutCondominio").InnerText;
                        cond.NombreCondominio = xmlCondominio.SelectSingleNode("nombreCondominio").InnerText;

                        user.IndexCondominio = decimal.Parse(xmlCondominio.SelectSingleNode("idCondominio").InnerText);
                        user.IndexComunidad = decimal.Parse(xmlCondominio.SelectSingleNode("idComunidad").InnerText);

                        YouCom.DTO.Seguridad.ComunidadDTO comu = new YouCom.DTO.Seguridad.ComunidadDTO();

                        comu.IdComunidad = decimal.Parse(xmlCondominio.SelectSingleNode("idComunidad").InnerText);
                        comu.NombreComunidad = xmlCondominio.SelectSingleNode("nombreComunidad").InnerText;

                        cond.TheComunidadDTO.Add(comu);

                        //Datos Empresa
                        user.RutCondominio = xmlCondominio.SelectSingleNode("rutCondominio").InnerText;
                        user.RutCondominioSinDv = user.RutCondominio.Substring(0, user.RutCondominio.Length - 1);
                        user.DVCondominio = user.RutCondominio.Substring(user.RutCondominio.Length - 1, 1);
                        user.NombreCompletoCondominio = cond.NombreCondominio;

                        cond.TheRolDTO.CodRol = decimal.Parse(xmlCondominio.SelectSingleNode("RolCod").InnerText);

                        foreach (XmlNode xmlProducto in xmlCondominio.SelectNodes("Funciones/FuncionGrp"))
                        {
                            YouCom.DTO.ProductoDTO prod = new YouCom.DTO.ProductoDTO();

                            prod.Codigo = xmlProducto.SelectSingleNode("FuncionGrpCod").InnerText;
                            prod.Descripcion = xmlProducto.SelectSingleNode("FuncionGrpNom").InnerText;

                            foreach (XmlNode xmlFuncion in xmlProducto.SelectNodes("Funcion"))
                            {
                                YouCom.DTO.Item func = new YouCom.DTO.Item();

                                func.Codigo = xmlFuncion.SelectSingleNode("FuncionCod").InnerText;
                                func.Descripcion = xmlFuncion.SelectSingleNode("FuncionNom").InnerText;

                                prod.Funciones.Add(func);
                            }

                            cond.Productos.Add(prod);
                        }

                        user.TheCondominioDTO.Add(cond);
                    }                    
                }
                HttpContext.Current.Session["usuario"] = user;
            }
        }

        public static string getInfoEmpresaPublico(string rut)
        {
            string retorno = string.Empty;
            
            XmlDocument xmlResponse = new XmlDocument();
            String[,] aparams = new String[1, 2];

            aparams[0, 0] = "Rut"; aparams[0, 1] = Formato.LimpiaParametro(rut);

            if (!Condominio.GetConsultaEmpresa(rut, ref xmlResponse))
                throw new Exception(xmlResponse.SelectSingleNode("KTFResponse/Errores/Error/ErrorDes").InnerText);

            if (xmlResponse.SelectSingleNode("KTFResponse").HasChildNodes)
                retorno = xmlResponse.SelectSingleNode("KTFResponse/Datos/GrupoCod").InnerText;

            return retorno;
        }
        public static void cargaDatosCondominio(string UserName, string UserCondominio, XmlDocument xmlResponse)
        {

            //string idCondominio = YouCom.Service.Configuracion.General.getInfoEmpresaPublico(UserCondominio);

            if (xmlResponse.SelectSingleNode("KTFResponse/Datos").HasChildNodes)
            {
                YouCom.DTO.Seguridad.UsuarioDTO user = new YouCom.DTO.Seguridad.UsuarioDTO();
                user = (YouCom.DTO.Seguridad.UsuarioDTO)HttpContext.Current.Session["usuario"];
                //DATOS USUARIO
                user.Token = xmlResponse.SelectSingleNode("KTFResponse/Datos/Token").InnerText;
                user.Rut = UserName.Trim();
                user.RutSinDV = UserName.Substring(0, UserName.Length - 1).Trim();
                user.DV = UserName.Substring(UserName.Length - 1, 1).Trim();
                user.NombreCompleto = xmlResponse.SelectSingleNode("KTFResponse/Datos/PersonaDescripcion").InnerText;

                string strTipo = string.Empty;

                XmlDocument xmlCondominio1 = new XmlDocument();
                xmlCondominio1.LoadXml(xmlResponse.SelectSingleNode("KTFResponse/Datos/Condominios/Condominio/IdCondominio").InnerText);

                foreach (XmlNode xmlCondominio in xmlCondominio1.SelectNodes("Condominios1/Condominio"))
                {
                    YouCom.DTO.Seguridad.CondominioDTO cond = new YouCom.DTO.Seguridad.CondominioDTO();

                    if (xmlCondominio.SelectSingleNode("RolCod").InnerText == "3")
                    {
                        cond.IdCondominio = decimal.Parse(xmlCondominio.SelectSingleNode("idCondominio").InnerText);
                        cond.RutCondominio = xmlCondominio.SelectSingleNode("rutCondominio").InnerText;
                        cond.NombreCondominio = xmlCondominio.SelectSingleNode("nombreCondominio").InnerText;

                        user.IndexCondominio = decimal.Parse(xmlCondominio.SelectSingleNode("idCondominio").InnerText);
                        user.IndexComunidad = decimal.Parse(xmlCondominio.SelectSingleNode("idComunidad").InnerText);

                        YouCom.DTO.Seguridad.ComunidadDTO comu = new YouCom.DTO.Seguridad.ComunidadDTO();

                        comu.IdComunidad = decimal.Parse(xmlCondominio.SelectSingleNode("idComunidad").InnerText);
                        comu.NombreComunidad = xmlCondominio.SelectSingleNode("nombreComunidad").InnerText;

                        cond.TheComunidadDTO.Add(comu);

                        //Datos Empresa
                        user.RutCondominio = xmlCondominio.SelectSingleNode("rutCondominio").InnerText;
                        user.RutCondominioSinDv = user.RutCondominio.Substring(0, user.RutCondominio.Length - 1);
                        user.DVCondominio = user.RutCondominio.Substring(user.RutCondominio.Length - 1, 1);
                        user.NombreCompletoCondominio = cond.NombreCondominio;
                        user.Email = xmlCondominio.SelectSingleNode("correoCondominio").InnerText;

                        DTO.Propietario.FamiliaDTO myFamiliaDTO = new DTO.Propietario.FamiliaDTO();

                        myFamiliaDTO = Familia.getListadoFamilia().Where(x => x.RutFamilia == UserName).FirstOrDefault();

                        user.TheFamiliaDTO = myFamiliaDTO;

                        cond.TheRolDTO.CodRol = decimal.Parse(xmlCondominio.SelectSingleNode("RolCod").InnerText);

                        foreach (XmlNode xmlProducto in xmlCondominio.SelectNodes("Funciones/FuncionGrp"))
                        {
                            YouCom.DTO.ProductoDTO prod = new YouCom.DTO.ProductoDTO();

                            prod.Codigo = xmlProducto.SelectSingleNode("FuncionGrpCod").InnerText;
                            prod.Descripcion = xmlProducto.SelectSingleNode("FuncionGrpNom").InnerText;

                            foreach (XmlNode xmlFuncion in xmlProducto.SelectNodes("Funcion"))
                            {
                                YouCom.DTO.Item func = new YouCom.DTO.Item();

                                func.Codigo = xmlFuncion.SelectSingleNode("FuncionCod").InnerText;
                                func.Descripcion = xmlFuncion.SelectSingleNode("FuncionNom").InnerText;

                                prod.Funciones.Add(func);
                            }

                            cond.Productos.Add(prod);
                        }

                        user.TheCondominioDTO.Add(cond);

                        if(user.TheCondominioDTO.Count == 1)
                        {
                            user.TheCondominioSeleccionDTO.IdCondominio = user.TheCondominioDTO.First().IdCondominio;
                            user.TheCondominioSeleccionDTO.RutCondominio = user.TheCondominioDTO.First().RutCondominio;
                            user.TheCondominioSeleccionDTO.NombreCondominio = user.TheCondominioDTO.First().NombreCondominio;

                            user.TheComunidadSeleccionDTO.IdComunidad = user.TheCondominioDTO.First().TheComunidadDTO.First().IdComunidad;
                            user.TheComunidadSeleccionDTO.NombreComunidad = user.TheCondominioDTO.First().TheComunidadDTO.First().NombreComunidad;

                        }

                    }
                }
                HttpContext.Current.Session["usuario"] = user;
            }
        }


        public static Boolean GetConsultaDatosCondominio(int mvarIdCondominio, ref XmlDocument pdomResponse)
        {
            Boolean retorno = false;
            DataTable wobjGrupoEmpresa = new DataTable();
            DataTable wobjGrupo = new DataTable();

            try
            {
                //Consulta datos de Grupo.
                //====================================================================================
                if (GetCondominios(mvarIdCondominio, wobjGrupo))
                {
                    //Consulta datos de la Empresa.
                    //====================================================================================
                    if (GetCondominio(mvarIdCondominio, wobjGrupoEmpresa))
                    {
                        //Armo Xml de respuesta.
                        //====================================================================================
                        ArmoXMLRespuesta(wobjGrupo,
                                         wobjGrupoEmpresa,
                                         pdomResponse);

                        retorno = true;
                        //====================================================================================	
                    }
                    //====================================================================================
                }
            }

            #region Catch
            catch (Exception eobjException)
            {
                //SystemLog.Ejecutar(eobjException, EventLogEntryType.Error);
                retorno = false;
            }
            #endregion

            return retorno;
        }
        public static Boolean GetCondominio(decimal mvarIdCondominio, DataTable pobjDataTable)
        {
            Boolean retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio",
                                           SqlDbType.Decimal,
                                           -1,
                                           mvarIdCondominio);
                //====================================================================================


                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_CondominioDatos",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    throw new Exception("Condominio no Existe");
                }
                //====================================================================================

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
        public static Boolean GetCondominios(decimal mvarIdCondominio, DataTable pobjDataTable)
        {
            Boolean retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                if (mvarIdCondominio >= 0)
                {
                    wobjSQLHelper.SetParametro("@pIdCondominio",
                                               SqlDbType.Int,
                                               -1,
                                               mvarIdCondominio);
                }
                //====================================================================================


                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_Condominio",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    throw new Exception("Condominio no Existe");
                }
                //====================================================================================
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
        public static void ArmoXMLRespuesta(DataTable pobjGrupo,
                                                    DataTable pobjGrupoEmpresa,
                                                    XmlDocument pdomResponse)
        {
            StringBuilder builder = new StringBuilder("");

            try
            {
                builder.Append("<KTFResponse>");
                builder.Append("<Datos>");

                //Grupos.
                //====================================================================================
                foreach (DataRow wobjDataRow in pobjGrupo.Rows)
                {
                    builder.Append("<GrupoRUTAsoc>" + wobjDataRow["GrupoRUTAsoc"].ToString() + "</GrupoRUTAsoc>");
                }

                foreach (DataRow wobjDataRow in pobjGrupoEmpresa.Rows)
                {
                    builder.Append("<RazonSocial>" + wobjDataRow["GrupoRazonSocial"].ToString() + "</RazonSocial>");
                    builder.Append("<Direccion>" + wobjDataRow["GrupoDireccion"].ToString() + "</Direccion>");
                    builder.Append("<Telefono>" + wobjDataRow["GrupoFono"].ToString() + "</Telefono>");
                    builder.Append("<EMail>" + wobjDataRow["GrupoMail"].ToString() + "</EMail>");
                }
                //====================================================================================

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

        public static Boolean validarUsuario(string UserName, string Password)
        {
            XmlDocument xmlRequest = new XmlDocument(); ;
            XmlDocument xmlResponse = new XmlDocument();
            string sXmlResponse = string.Empty;

            xmlRequest = Xml.armaXMLLogin(UserName, Password);

            try
            {
                YouCom.Service.Seguridad.Login login = new YouCom.Service.Seguridad.Login();

                login.LoginUsuario(UserName, Password, ref xmlResponse);

                cargaDatosUsuario(UserName, xmlResponse);

                return true;
            }
            catch (Exception ex)
            {
                char[] separador = { '|' };
                string[] words = ex.Message.Split(separador);

                if (words != null)
                    sXmlResponse = "<Error><ErrorCod>" + words[0] + "</ErrorCod><ErrorDes>" + words[1] + "</ErrorDes></Error>";
                else
                    sXmlResponse = "<Error><ErrorCod>-1</ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";

                return false;
            }
        }

        public static Boolean validarUsuario(string UserName, string UserEmpresa, string pPassword)
        {
            XmlDocument xmlRequest = new XmlDocument(); ;
            XmlDocument xmlResponse = new XmlDocument();
            string sXmlResponse = string.Empty;

            string pass = string.Empty;

            if (pPassword.Length == 4)
                pass = pPassword.ToUpper();
            else
                pass = pPassword;

            xmlRequest = Xml.armaXMLLogin(UserName, pass);

            try
            {
                YouCom.Service.Seguridad.Login login = new YouCom.Service.Seguridad.Login();

                login.LoginUsuario(UserName, pass, ref xmlResponse);

                //****PARA VOLVER A REGENERAR EL TOKEN PARA SUCURSAL VIRTUAL****//
                string token = General.getGeneraToken(UserName, UserEmpresa, pass);

                YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();

                myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)HttpContext.Current.Session["usuario"];

                myUsuario.Token_Usr = token;

                HttpContext.Current.Session["usuario"] = myUsuario;
                //****PARA VOLVER A REGENERAR EL TOKEN PARA SUCURSAL VIRTUAL****//

                return true;
            }
            catch (Exception ex)
            {
                char[] separador = { '|' };
                string[] words = ex.Message.Split(separador);

                if (words != null)
                    sXmlResponse = "<Error><ErrorCod>" + words[0] + "</ErrorCod><ErrorDes>" + words[1] + "</ErrorDes></Error>";
                else
                    sXmlResponse = "<Error><ErrorCod>-1</ErrorCod><ErrorDes>" + ex.Message + "</ErrorDes></Error>";

                return false;
            }
        }

        public static void cargaDatosUsuario(string UserName, XmlDocument xmlResponse)
        {
            if (xmlResponse.SelectSingleNode("KTFResponse/Datos").HasChildNodes)
            {
                YouCom.DTO.Seguridad.UsuarioDTO user = new YouCom.DTO.Seguridad.UsuarioDTO();

                user.Token = xmlResponse.SelectSingleNode("KTFResponse/Datos/Token").InnerText;
                user.Rut = UserName;
                user.RutSinDV = UserName.Substring(0, UserName.Length - 1);
                user.DV = UserName.Substring(UserName.Length - 1, 1);
                user.NombreCompleto = xmlResponse.SelectSingleNode("KTFResponse/Datos/PersonaDescripcion").InnerText;

                string strTipo = string.Empty;

                foreach (XmlNode xmlCondominio in xmlResponse.SelectNodes("KTFResponse/Datos/Condominios/Condominio"))
                {
                    YouCom.DTO.Seguridad.CondominioDTO cond = new YouCom.DTO.Seguridad.CondominioDTO();

                    if (xmlCondominio.SelectSingleNode("IdCondominio").InnerText != "1")
                    {
                        cond.IdCondominio = decimal.Parse(xmlCondominio.SelectSingleNode("idCondominio").InnerText);
                        cond.RutCondominio = xmlCondominio.SelectSingleNode("rutCondominio").InnerText;
                        cond.NombreCondominio = xmlCondominio.SelectSingleNode("nombreCondominio").InnerText;

                        user.IndexCondominio = decimal.Parse(xmlCondominio.SelectSingleNode("idCondominio").InnerText);
                        user.IndexComunidad = decimal.Parse(xmlCondominio.SelectSingleNode("idComunidad").InnerText);

                        YouCom.DTO.Seguridad.ComunidadDTO comu = new YouCom.DTO.Seguridad.ComunidadDTO();

                        comu.IdComunidad = decimal.Parse(xmlCondominio.SelectSingleNode("idComunidad").InnerText);
                        comu.NombreComunidad = xmlCondominio.SelectSingleNode("nombreComunidad").InnerText;

                        cond.TheComunidadDTO.Add(comu);

                        foreach (XmlNode xmlProducto in xmlCondominio.SelectNodes("Funciones/FuncionGrp"))
                        {
                            YouCom.DTO.ProductoDTO prod = new YouCom.DTO.ProductoDTO();

                            prod.Codigo = xmlProducto.SelectSingleNode("FuncionGrpCod").InnerText;
                            prod.Descripcion = xmlProducto.SelectSingleNode("FuncionGrpNom").InnerText;

                            foreach (XmlNode xmlFuncion in xmlProducto.SelectNodes("Funcion"))
                            {
                                YouCom.DTO.Item func = new YouCom.DTO.Item();

                                if (xmlFuncion.SelectSingleNode("FuncionCod").InnerText.Equals("3"))
                                    strTipo = "Administrador";

                                if (xmlFuncion.SelectSingleNode("FuncionCod").InnerText.Equals("720"))
                                {
                                    if (strTipo != "")
                                        strTipo = "Administrador/Apoderado";
                                    else
                                        strTipo = "Apoderado";
                                }

                                func.Codigo = xmlFuncion.SelectSingleNode("FuncionCod").InnerText;
                                func.Descripcion = xmlFuncion.SelectSingleNode("FuncionNom").InnerText;

                                prod.Funciones.Add(func);
                            }

                            cond.Productos.Add(prod);
                        }

                        user.TheCondominioDTO.Add(cond);
                    }
                }
                HttpContext.Current.Session["usuario"] = user;
                //_usuario = user;
            }
        }

        public static void updateFechaPass(YouCom.DTO.Seguridad.UsuarioDTO myUsuario)
        {

            XmlDocument xmlResponse = new XmlDocument();
            XmlDocument xmlRequest = new XmlDocument();
            try
            {
                xmlRequest.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlRequest());
            }
            catch
            {
            }

        }

        public static String GetDevuelveMes(string Mes)
        {
            switch (Mes)
            {
                case "1": return "Enero";
                case "2": return "Febrero";
                case "3": return "Marzo";
                case "4": return "Abril";
                case "5": return "Mayo";
                case "6": return "Junio";
                case "7": return "Julio";
                case "8": return "Agosto";
                case "9": return "Septiembre";
                case "10": return "Octubre";
                case "11": return "Noviembre";
                case "12": return "Diciembre";
                default: return string.Empty;
            }
        }
        public static String GetDevuelveNumeroMes(string Mes)
        {
            switch (Mes)
            {
                case "JAN": return "01";
                case "FEB": return "02";
                case "MAR": return "03";
                case "APR": return "04";
                case "MAY": return "05";
                case "JUN": return "06";
                case "JUL": return "07";
                case "AUG": return "08";
                case "SEP": return "09";
                case "OCT": return "10";
                case "NOV": return "11";
                case "DEC": return "12";
                case "Enero": return "01";
                case "Febrero": return "02";
                case "Marzo": return "03";
                case "Abril": return "04";
                case "Mayo": return "05";
                case "Junio": return "06";
                case "Julio": return "07";
                case "Agosto": return "08";
                case "Septiembre": return "09";
                case "Octubre": return "10";
                case "Noviembre": return "11";
                case "Diciembre": return "12";
                default: return string.Empty;
            }
        }
        public static int GetDevuelveNumeroDiaSemana(string Dia)
        {
            switch (Dia)
            {
                case "Monday": return 1;
                case "Tuesday": return 2;
                case "Wednesday": return 3;
                case "Thursday": return 4;
                case "Friday": return 5;
                case "Saturday": return 6;
                case "Sunday": return 7;
                default: return 0;
            }
        }
        public static String GetDevuelveNombreMes(string Mes)
        {
            switch (Mes)
            {
                case "1": return "Enero";
                case "2": return "Febrero";
                case "3": return "Marzo";
                case "4": return "Abril";
                case "5": return "Mayo";
                case "6": return "Junio";
                case "7": return "Julio";
                case "8": return "Agosto";
                case "9": return "Septiembre";
                case "10": return "Octubre";
                case "11": return "Noviembre";
                case "12": return "Diciembre";
                default: return string.Empty;
            }
        }



        public static string digitoVerificador(Int64 rut)
        {
            Int64 Digito;
            int Contador;
            Int64 Multiplo;
            Int64 Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                    Contador = 2;
            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
                RutDigito = "K";
            if (Digito == 11)
                RutDigito = "0";

            return (RutDigito);
        }
        public static Boolean validaRut(Int64 rut, char dig)
        {
            if (digitoVerificador(rut) == dig.ToString().ToUpper())
                return true;
            else
                return false;
        }
        public static Boolean stringValidarut(string rut)
        {
            try
            {
                string[] rutD;
                long number = 0;
                rutD = rut.Split('-');
                rutD[0] = rutD[0].Replace(".", "");
                bool canConvert = long.TryParse(rutD[0], out number);
                if (canConvert)
                {
                    return validaRut(Convert.ToInt64(rutD[0]), Convert.ToChar(rutD[1]));
                }

            }
            catch (Exception ex)
            {
                return false;

            }
            return false;
        }
        public static string CerosRut(string rut)
        {
            int count;
            string padleftstring;
            count = rut.Length;
            if (count == 9)
            {
                count = count + 1;
            }
            else
            {
                count = count + 2;
            }
            padleftstring = rut.PadLeft(count, '0');
            return padleftstring;
        }



        public static Boolean ValidarClave(string valor)
        {
            string caracteresvalidos = "01234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int intLetra = 0;
            int intNumber = 0;

            // Verifica si tiene 2 caracteres iguales, ademas validar que exista a lo menos 1 letra y un numero
            for (int i = 0; i < valor.Length; i++)
            {
                if (i == 2)
                {
                    if (valor[0] == valor[i - 1] && valor[i - 1] == valor[i])
                        return false;
                }
                if (i > 2)
                {
                    if (valor[i - 2] == valor[i - 1] && valor[i - 1] == valor[i])
                        return false;
                }

                if (char.IsLetter(valor[i]))
                    intLetra += 1;

                if (char.IsNumber(valor[i]))
                    intNumber += 1;
            }

            if (intLetra == 0 || intNumber == 0)
                return false;

            //Verifica si tiene 3 numeros consecutivos y si tiene 3 letras consecutivas
            for (int i = 0; i < valor.Length; i++)
            {
                if (i == 2)
                {
                    int numero = valor[i];

                    if (char.IsDigit(valor[i - 2]) && char.IsDigit(valor[i - 1]) && char.IsDigit(valor[i]))
                    {
                        string numeros = valor[i - 2].ToString() + valor[i - 1].ToString() + valor[i].ToString();
                        if (caracteresvalidos.IndexOf(numeros) != -1)
                            return false;
                    }
                    if (char.IsLetter(valor[i - 2]) && char.IsLetter(valor[i - 1]) && char.IsLetter(valor[i]))
                    {
                        string letras = valor[i - 2].ToString() + valor[i - 1].ToString() + valor[i].ToString();
                        if (caracteresvalidos.IndexOf(letras) != -1)
                            return false;
                    }
                }
                else if (i > 2)
                {
                    int numero = valor[i];

                    if (char.IsDigit(valor[i - 2]) && char.IsDigit(valor[i - 1]) && char.IsDigit(valor[i]))
                    {
                        string numeros = valor[i - 2].ToString() + valor[i - 1].ToString() + valor[i].ToString();
                        if (caracteresvalidos.IndexOf(numeros) != -1)
                            return false;
                    }
                    if (char.IsLetter(valor[i - 2]) && char.IsLetter(valor[i - 1]) && char.IsLetter(valor[i]))
                    {
                        string letras = valor[i - 2].ToString() + valor[i - 1].ToString() + valor[i].ToString();
                        if (caracteresvalidos.IndexOf(letras) != -1)
                            return false;
                    }
                }
            }
            return (true);
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

        public static string getRutCliente(YouCom.DTO.Seguridad.UsuarioDTO myUsuario)
        {
            string rut_cliente = string.Empty;

            if (myUsuario.RutCondominio != null)
                rut_cliente = Formato.LimpiaParametro(string.Copy(Formato.RutConsultaCompleto(myUsuario.RutCondominio)));
            else
                rut_cliente = Formato.LimpiaParametro(string.Copy(Formato.RutConsultaCompleto(myUsuario.Rut)));

            return rut_cliente;
        }
        public static string getRutClienteSinFormato(YouCom.DTO.Seguridad.UsuarioDTO myUsuario)
        {
            string rut_cliente = string.Empty;

            if (myUsuario.RutCondominio != null)
                rut_cliente = string.Copy(myUsuario.RutCondominio);
            else
                rut_cliente = string.Copy(myUsuario.Rut);

            return rut_cliente;
        }
        public static string getNombreRutCliente(YouCom.DTO.Seguridad.UsuarioDTO myUsuario)
        {
            string nombre_cliente = string.Empty;

            if (myUsuario.RutCondominio != null)
                nombre_cliente = string.Copy(myUsuario.NombreCompletoCondominio);
            else
                nombre_cliente = string.Copy(myUsuario.NombreCompleto);

            return nombre_cliente;
        }
        
        public static string getGeneraToken(string rut, string rut_empresa, string pass)
        {
            string retorno = string.Empty;
            try
            {
                const string TOKEN = "<KTFToken>" +
                                        "<Fecha/>" +
                                        "<UsuarioCod/>" +
                                        "<Pass/>" +
                                        "<RutCondominio/>" +
                                        "<IndexEmpresa/>" +
                                     "</KTFToken>";

                XmlDocument wdomToken = new XmlDocument();

                wdomToken.LoadXml(TOKEN);

                wdomToken.SelectSingleNode("KTFToken/UsuarioCod").InnerText = rut;
                wdomToken.SelectSingleNode("KTFToken/RutCondominio").InnerText = rut_empresa;
                wdomToken.SelectSingleNode("KTFToken/IndexEmpresa").InnerText = "0";
                wdomToken.SelectSingleNode("KTFToken/Pass").InnerText = YouCom.Service.Seguridad.Crypt.Encriptar(pass, YouCom.Service.Configuracion.Config.GetPropiedad("TokenPwd"));
                wdomToken.SelectSingleNode("KTFToken/Fecha").InnerText = DateTime.Now.ToString();

                retorno = YouCom.Service.Seguridad.Crypt.Encriptar(wdomToken.OuterXml,
                                           YouCom.Service.Configuracion.Config.GetPropiedad("TokenPwd"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
        public static void getSleep(int time)
        {
            System.Threading.Thread.Sleep(time);
        }
        public static String FormatoMonto(string pvarMonto)
        {
            string valor = string.Empty;
            char[] separador = { '.' };

            string[] words = pvarMonto.Split(separador);

            return words[0];
        }
        public static string getDevuelveNroPagina(System.Web.UI.WebControls.HiddenField myHiddenField, bool incremento)
        {
            int pContador = 0;
            if (incremento)
                pContador = int.Parse(myHiddenField.Value) + 1;
            else
                pContador = int.Parse(myHiddenField.Value) - 1;

            return pContador.ToString();
        }

        public static string getObtieneIP()
        {
            string localIP = "";

            //IPHostEntry host;
            //host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (IPAddress ip in host.AddressList)
            //{
            //    if (ip.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        localIP = ip.ToString();
            //    }
            //}

            localIP = HttpContext.Current.Request.UserHostAddress;

            return localIP;
        }

        public static bool getValidaClaveUsuario(string mvarUsuarioCod, string mvarPassword)
        {
            string mvarTrustedUser = "N";
            bool retorno = false;
            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTableOperador = new DataTable();

            string wvarPasswordEnc = "";

            try
            {
                //Seteo Parámetros
                //====================================================================================
                wobjSQLHelper.SetParametro("@pUsuario",
                                            SqlDbType.Char,
                                            20,
                                            mvarUsuarioCod);
                //====================================================================================
                //Ejecuto SP
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_Operador",
                                           "YouCom",
                                           wobjDataTableOperador) == 0)
                {
                    retorno = false;
                }
                //====================================================================================


                //Si no es TrustedUser autentico.
                //=================================================================================
                if (mvarTrustedUser == "N")
                {
                    //====================================================================================
                    //Encripto password.
                    //====================================================================================
                    EncPwd.Ejecutar(mvarPassword,
                                    (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                                    ref wvarPasswordEnc);
                    //====================================================================================
                    //Verifico la password.
                    //====================================================================================
                    if ((string)wobjDataTableOperador.Rows[0]["Password"] != wvarPasswordEnc)
                    {
                        retorno = false;
                    }
                    else
                    {
                        retorno = true;
                    }
                    //=================================================================================
                }
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

            return retorno;
        }

        public static bool getValidaBisiesto(int anio)
        {
            bool retorno = false;

            if (anio % 4 == 0 && (anio % 100 != 0 || anio % 400 == 0))
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool ValidarUsuario(string rut_login, string rut_empresa, ref string sXmlResponse)
        {
            string pass = string.Empty;
            string rut = rut_login;

            if (YouCom.Service.Configuracion.General.AuthenticateEmpresa(rut, rut_empresa, "", false, ref sXmlResponse))
                return true;
            else
                return false;
        }

        public static bool ValidarClave(ref string sXmlResponse)
        {
            string pass = string.Empty;
            string rut = YouCom.Service.Configuracion.Formato.LimpiarRut(YouCom.Service.Configuracion.Config.GetPropiedad("User")).ToUpper();
            string pPassword = YouCom.Service.Configuracion.Config.GetPropiedad("Pass");

            if (pPassword.Length == 4)
                pass = pPassword.ToUpper();
            else
                pass = pPassword;

            if (YouCom.Service.Configuracion.General.AuthenticateEmpresa(rut, rut, pass, true, ref sXmlResponse))
                return true;
            else
                return false;
        }

        public static string GetBasePath()
        {
            string path = "~/fckeditor/";
            return path;
        }

        public static Boolean CheckReturnUrl(Boolean isSuperAdmin)
        {
            Boolean check = false;
            List<String> paginas = new List<string> { "Administrador.aspx", "AdministradorCrear.aspx", "AdministradorModificar.aspx", "superAdministrador.aspx", "SuperAdministradorCrear.aspx", "SuperAdministradorModificar.aspx", "ReporteAuditoria.aspx", "ReporteSuperAdministrador.aspx", "ConexionUsuario.aspx" };

            if (HttpContext.Current.Request.QueryString.Count > 0)
            {
                foreach (string key in HttpContext.Current.Request.QueryString.AllKeys)
                {
                    if (key.Equals("ReturnUrl"))
                    {
                        try
                        {
                            string url = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.Get("ReturnUrl"));
                            string[] urlparts = url.Split('/');
                            string page = urlparts[urlparts.Length - 1];
                            if (isSuperAdmin)
                            {
                                foreach (string pag in paginas)
                                {
                                    if (pag.Equals(page))
                                        return true;
                                }

                                //if (paginas.BinarySearch(page) < 0)
                                //    return true;
                            }
                            else
                            {
                                foreach (string pag in paginas)
                                {
                                    if (pag.Equals(page))
                                        return true;
                                }
                                //if (paginas.BinarySearch(page) >= 0)
                                //    return true;
                            }
                        }
                        catch
                        {
                            throw new NotSupportedException(@"No existe parametro ReturnUrl");
                        }

                    }
                }
            }
            else
                return true;

            return check;

        }

        public static void EventLog(string pagina, string procedure, Exception exception)
        {
            YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
            myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)HttpContext.Current.Session["usuario"];

            string NomFile = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("RUTA", "LOG");
            NomFile = NomFile + "_" + DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + ".log";

            System.IO.StreamWriter SW;

            SW = new System.IO.StreamWriter(NomFile, true);
            SW.WriteLine("*******************INICIO LOG ERRORES ********************");
            SW.WriteLine("Fecha:" + DateTime.Now);
            SW.WriteLine("Error Source:" + exception.Source.Trim());
            SW.WriteLine("Error Menssage:" + exception.Message.Trim());
            SW.WriteLine("Rut Empresa:" + myUsuario.RutCondominio);
            SW.WriteLine("Rut Apoderado:" + myUsuario.Rut);
            SW.WriteLine("Error Library: " + exception.Data.ToString().Trim());
            SW.WriteLine("Error StackTrace: " + exception.StackTrace.ToString().Trim());
            SW.WriteLine("Error Page: " + pagina.Trim());
            SW.WriteLine("Error Procedure: " + procedure.Trim());
            SW.WriteLine("Error Location Client:" + System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].Trim());
            SW.WriteLine("*******************FIN LOG ERRORES ********************");
            SW.Close();



            ///log

        }
    }
}
