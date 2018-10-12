using System;

using System.Collections.Generic;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using YouCom.Service.BD;
using BI;

namespace YouCom.Service.Seguridad
{
    public class Login
    {
        protected Object mobjUsuarioHandler = null;
        protected string mvarTrustedUser = "N";
        protected string mvarFechaProceso = DateTime.Now.ToString();

        //Para los roles si es que se guardan.
        //====================================================================================
        protected StringCollection mcolRol = new StringCollection();
        //====================================================================================

        /// <summary>
        /// Login. 
        /// Devuelve información del Usuario.
        /// Devuelve Funciones habilitadas del Usuario.
        /// Autentica que el Usuario es quien dice ser a través de la Password,
        /// si el canal no trabaja con Trusted User, en caso contrario toma el
        /// Usuario por válido.
        /// Devuelve Token encriptado.
        /// </summary>
        public void LoginUsuario(string mvarUsuarioCod, string mvarPassword, ref  XmlDocument pdomResponse)
        {

            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "Login";
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                pdomResponse.LoadXml(YouCom.Service.Configuracion.Config.GetXmlResponse());

                //Autentico.
                //=================================================================================
                wvarPaso = 10;
                if (mvarUsuarioCod != "")
                {
                    wvarPaso = 20;
                    AutenticarUsuario(mvarUsuarioCod, mvarPassword);
                }
                else
                {
                    wvarPaso = 30;
                    throw new Exception("Debe indicarse UsuarioCod");
                }
                //=================================================================================


                //Armo el Token.
                //=================================================================================
                wvarPaso = 100;
                ArmoToken(mvarUsuarioCod, pdomResponse);
                //=================================================================================


                //Busco datos.
                //=================================================================================
                wvarPaso = 110;
                GetDatos(pdomResponse);
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw new Exception(eobjException.Message);
            }
        }

        public void LoginUsuarioAdmin(string mvarUsuarioCod, string mvarPassword, ref  XmlDocument pdomResponse)
        {

            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "Login";
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                pdomResponse.LoadXml(YouCom.Service.Configuracion.Config.GetXmlResponse());

                //Autentico.
                //=================================================================================
                wvarPaso = 10;
                if (mvarUsuarioCod != "")
                {
                    wvarPaso = 20;
                    AutenticarUsuarioAdmin(mvarUsuarioCod, mvarPassword);
                }
                else
                {
                    wvarPaso = 30;
                    throw new Exception("Debe indicarse UsuarioCod");
                }
                //=================================================================================


                //Armo el Token.
                //=================================================================================
                wvarPaso = 100;
                ArmoToken(mvarUsuarioCod, pdomResponse);
                //=================================================================================


                //Busco datos.
                //=================================================================================
                wvarPaso = 110;
                GetDatosAdmin(pdomResponse);
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw new Exception(eobjException.Message);
            }
        }

        public void LoginUsuario(string mvarUsuarioCod, string mvarPassword, bool pass, ref  XmlDocument pdomResponse)
        {

            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "Login";
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                pdomResponse.LoadXml(YouCom.Service.Configuracion.Config.GetXmlResponse());

                //Autentico.
                //=================================================================================
                wvarPaso = 10;
                if (mvarUsuarioCod != "")
                {
                    wvarPaso = 20;
                    AutenticarUsuario(mvarUsuarioCod, mvarPassword, pass);
                }
                else
                {
                    wvarPaso = 30;
                    throw new Exception("Debe indicarse UsuarioCod");
                }
                //=================================================================================


                //Armo el Token.
                //=================================================================================
                wvarPaso = 100;
                ArmoToken(mvarUsuarioCod, pdomResponse);
                //=================================================================================


                //Busco datos.
                //=================================================================================
                wvarPaso = 110;
                GetDatos(pdomResponse);
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw new Exception(eobjException.Message);
            }
        }

        public void LoginUsuario(string mvarUsuarioCod, string mvarRutCondominio, string mvarPassword, ref  XmlDocument pdomResponse)
        {

            //Para el manejo de los errores
            //====================================================================================
            const string METODO = "Login";
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                pdomResponse.LoadXml(YouCom.Service.Configuracion.Config.GetXmlResponse());

                //Autentico.
                //=================================================================================
                wvarPaso = 10;
                if (mvarUsuarioCod != "")
                {
                    wvarPaso = 20;
                    AutenticarUsuario(mvarUsuarioCod, mvarRutCondominio, mvarPassword);
                }
                else
                {
                    wvarPaso = 30;
                    throw new Exception("Debe indicarse UsuarioCod");
                }
                //=================================================================================


                //Armo el Token.
                //=================================================================================
                wvarPaso = 100;
                ArmoToken(mvarUsuarioCod, pdomResponse);
                //=================================================================================


                //Busco datos.
                //=================================================================================
                wvarPaso = 110;
                GetDatos(pdomResponse);
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw new Exception(eobjException.Message);
            }
        }

        protected void AutenticarUsuarioAdmin(string mvarUsuarioCod, string mvarPassword)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTableOperador = new DataTable();

            string wvarPasswordEnc = "";

            try
            {
                string pReintentoMax = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "ReintentoMax").First().Descripcion;
                string pDuracionPwd = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "DuracionPwd").First().Descripcion;
                string pValidaPass = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ValidaPass", "SEGURIDAD");

                //Seteo Parámetros
                //====================================================================================
                wvarPaso = 10;
                wobjSQLHelper.SetParametro("@pUsuario",
                                            SqlDbType.Char,
                                            20,
                                            mvarUsuarioCod);
                //====================================================================================


                //Ejecuto SP
                //====================================================================================
                wvarPaso = 200;
                if (wobjSQLHelper.Ejecutar("QRY_Operador",
                                           "YouCom",
                                           wobjDataTableOperador) == 0)
                {
                    wvarPaso = 210;
                    throw new Exception("2|El usuario o la contraseña son incorrectos.");
                }
                //====================================================================================


                //Si no es TrustedUser autentico.
                //=================================================================================
                wvarPaso = 290;
                if (mvarTrustedUser == "N")
                {
                    //Autentico.

                    //Verifico reintentos.
                    //====================================================================================
                    wvarPaso = 300;
                    if ((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD")))
                    {
                        wvarPaso = 310;
                        throw new Exception("4|Estimado Cliente, Supero reintentos permitidos");
                    }
                    //====================================================================================


                    //Encripto password.
                    //====================================================================================
                    wvarPaso = 320;
                    EncPwd.Ejecutar(mvarPassword,
                                    (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                                    ref wvarPasswordEnc);
                    //====================================================================================


                    //Verifico la password.
                    //====================================================================================

                    wvarPaso = 330;
                    if ((string)wobjDataTableOperador.Rows[0]["Password"] != wvarPasswordEnc)
                    {
                        //Actualizo fallidos.
                        wvarPaso = 340;
                        ActIntentoFallidos(mvarUsuarioCod, (short)((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] + 1));

                        wvarPaso = 360;
                        throw new Exception("2|El usuario o la contraseña son incorrectos.");
                    }
                    ////====================================================================================
                    ////Reseteo Fallidos.
                    ////====================================================================================
                    //wvarPaso = 340;
                    ActIntentoFallidos(mvarUsuarioCod, 0);
                    //====================================================================================


                    //Verifico fecha de expiración.
                    //====================================================================================
                    wvarPaso = 330;
                    if ((DateTime.Parse(mvarFechaProceso) - (DateTime)wobjDataTableOperador.Rows[0]["FechaPass"]).Days >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD")))
                    {
                        wvarPaso = 340;
                        throw new Exception("3|Debe cambiar su contraseña.");
                    }
                    //=================================================================================
                }


                //Dejo el resultado de la búsqueda en el handler global.
                //=================================================================================
                wvarPaso = 1000;
                mobjUsuarioHandler = wobjDataTableOperador;
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        protected void AutenticarUsuario(string mvarUsuarioCod, string mvarPassword)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTableOperador = new DataTable();

            string wvarPasswordEnc = "";

            try
            {
                string pReintentoMax = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "ReintentoMax").First().Descripcion;
                string pDuracionPwd = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "DuracionPwd").First().Descripcion;
                string pValidaPass = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ValidaPass", "SEGURIDAD");

                //Seteo Parámetros
                //====================================================================================
                wvarPaso = 10;
                wobjSQLHelper.SetParametro("@pUsuario",
                                            SqlDbType.Char,
                                            20,
                                            mvarUsuarioCod);
                //====================================================================================


                //Ejecuto SP
                //====================================================================================
                wvarPaso = 200;
                if (wobjSQLHelper.Ejecutar("QRY_Operador",
                                           "YouCom",
                                           wobjDataTableOperador) == 0)
                {
                    wvarPaso = 210;
                    throw new Exception("2|El usuario o la contraseña son incorrectos.");
                }
                //====================================================================================


                //Si no es TrustedUser autentico.
                //=================================================================================
                wvarPaso = 290;
                if (mvarTrustedUser == "N")
                {
                    //Autentico.

                    //Verifico reintentos.
                    //====================================================================================
                    wvarPaso = 300;
                    if ((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD")))
                    {
                        wvarPaso = 310;
                        throw new Exception("4|Estimado Cliente, Supero reintentos permitidos");
                    }
                    //====================================================================================


                    //Encripto password.
                    //====================================================================================
                    wvarPaso = 320;
                    EncPwd.Ejecutar(mvarPassword,
                                    (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                                    ref wvarPasswordEnc);
                    //====================================================================================


                    //Verifico la password.
                    //====================================================================================

                    //wvarPaso = 330;
                    //if ((string)wobjDataTableOperador.Rows[0]["Password"] != wvarPasswordEnc)
                    //{
                    //    //Actualizo fallidos.
                    //    wvarPaso = 340;
                    //    ActIntentoFallidos(mvarUsuarioCod, (short)((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] + 1));

                    //    wvarPaso = 360;
                    //    throw new Exception("2|El usuario o la contraseña son incorrectos.");
                    //}
                    ////====================================================================================
                    ////Reseteo Fallidos.
                    ////====================================================================================
                    //wvarPaso = 340;
                    //ActIntentoFallidos(mvarUsuarioCod, 0);
                    //====================================================================================


                    //Verifico fecha de expiración.
                    //====================================================================================

                    //Consulto Historia
                    IList<YouCom.DTO.AccesoLoginDTO> myAccesoLogin = new List<YouCom.DTO.AccesoLoginDTO>();
                    myAccesoLogin = YouCom.Service.Accesos.AccesoLogin.getConsultaAccesoLogin(mvarUsuarioCod);

                    if (myAccesoLogin.Any())
                    {
                        System.TimeSpan diffResultFecha = DateTime.Now - myAccesoLogin.First().Fecha;

                        if (diffResultFecha.Days > int.Parse(pDuracionPwd))
                        {
                            wvarPaso = 340;
                            throw new Exception("3|Debe cambiar su contraseña.");
                        }
                        else
                        {
                            YouCom.DTO.AccesoLoginDTO IAccesoLogin = new YouCom.DTO.AccesoLoginDTO();

                            IAccesoLogin.IdAccesoLogin = myAccesoLogin.First().IdAccesoLogin;
                            IAccesoLogin.RutLogin = mvarUsuarioCod;
                            IAccesoLogin.RutCondominio = mvarUsuarioCod;
                            //IAccesoLogin.Ip = HttpContext.Current.Request.UserHostAddress;
                            IAccesoLogin.Ip = IAccesoLogin.Ip = HttpContext.Current.Request.UserHostAddress;
                            IAccesoLogin.Fecha = DateTime.Now;

                            YouCom.Service.Accesos.AccesoLogin.updAccesoLogin(IAccesoLogin);

                            YouCom.Service.Accesos.AccesoLogin.insHistoricoAccesoLogin(IAccesoLogin);
                        }
                    }
                    else
                    {
                        YouCom.DTO.AccesoLoginDTO myAcceso = new YouCom.DTO.AccesoLoginDTO();

                        myAcceso.RutLogin = mvarUsuarioCod;
                        myAcceso.RutCondominio = mvarUsuarioCod;
                        myAcceso.Ip = YouCom.Service.Generales.General.getObtieneIP();//HttpContext.Current.Request.UserHostAddress;
                        myAcceso.Fecha = DateTime.Now;


                        YouCom.Service.Accesos.AccesoLogin.insAccesoLogin(myAcceso);

                        YouCom.Service.Accesos.AccesoLogin.insHistoricoAccesoLogin(myAcceso);
                    }

                    wvarPaso = 330;
                    if ((DateTime.Parse(mvarFechaProceso) - (DateTime)wobjDataTableOperador.Rows[0]["FechaPass"]).Days >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD")))
                    {
                        wvarPaso = 340;
                        throw new Exception("3|Debe cambiar su contraseña.");
                    }
                    //=================================================================================
                }


                //Dejo el resultado de la búsqueda en el handler global.
                //=================================================================================
                wvarPaso = 1000;
                mobjUsuarioHandler = wobjDataTableOperador;
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        protected void AutenticarUsuario(string mvarUsuarioCod, string mvarPassword, bool mvarPass)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTableOperador = new DataTable();

            string wvarPasswordEnc = "";

            try
            {
                string pReintentoMax = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "ReintentoMax").First().Descripcion;
                string pDuracionPwd = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "DuracionPwd").First().Descripcion;
                string pValidaPass = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ValidaPass", "SEGURIDAD");

                //Seteo Parámetros
                //====================================================================================
                wvarPaso = 10;
                wobjSQLHelper.SetParametro("@pUsuario",
                                            SqlDbType.Char,
                                            20,
                                            mvarUsuarioCod);
                //====================================================================================


                //Ejecuto SP
                //====================================================================================
                wvarPaso = 200;
                if (wobjSQLHelper.Ejecutar("QRY_Operador",
                                           "YouCom",
                                           wobjDataTableOperador) == 0)
                {
                    wvarPaso = 210;
                    throw new Exception("2|El usuario o la contraseña son incorrectos.");
                }
                //====================================================================================


                //Si no es TrustedUser autentico.
                //=================================================================================
                wvarPaso = 290;
                if (mvarTrustedUser == "N")
                {
                    //Autentico.

                    //Verifico reintentos.
                    //====================================================================================
                    wvarPaso = 300;
                    if ((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD")))
                    {
                        wvarPaso = 310;
                        throw new Exception("4|Estimado Cliente, Supero reintentos permitidos");
                    }
                    //====================================================================================

                    if (mvarPass)
                    {
                        //Encripto password.
                        //====================================================================================
                        wvarPaso = 320;
                        EncPwd.Ejecutar(mvarPassword,
                                        (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                                        ref wvarPasswordEnc);
                        //====================================================================================


                        //Verifico la password.
                        //====================================================================================

                        wvarPaso = 330;
                        if ((string)wobjDataTableOperador.Rows[0]["Password"] != wvarPasswordEnc)
                        {
                            //Actualizo fallidos.
                            wvarPaso = 340;
                            ActIntentoFallidos(mvarUsuarioCod, (short)((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] + 1));

                            wvarPaso = 360;
                            throw new Exception("2|El usuario o la contraseña son incorrectos.");
                        }
                        //====================================================================================
                        //Reseteo Fallidos.
                        //====================================================================================
                        wvarPaso = 340;
                        ActIntentoFallidos(mvarUsuarioCod, 0);
                        //====================================================================================


                        //Verifico fecha de expiración.
                        //====================================================================================

                        //Consulto Historia
                        IList<YouCom.DTO.AccesoLoginDTO> myAccesoLogin = new List<YouCom.DTO.AccesoLoginDTO>();
                        myAccesoLogin = YouCom.Service.Accesos.AccesoLogin.getConsultaAccesoLogin(mvarUsuarioCod);

                        if (myAccesoLogin.Any())
                        {
                            System.TimeSpan diffResultFecha = DateTime.Now - myAccesoLogin.First().Fecha;

                            if (diffResultFecha.Days > int.Parse(pDuracionPwd))
                            {
                                wvarPaso = 340;
                                throw new Exception("3|Debe cambiar su contraseña.");
                            }
                            else
                            {
                                YouCom.DTO.AccesoLoginDTO IAccesoLogin = new YouCom.DTO.AccesoLoginDTO();

                                IAccesoLogin.IdAccesoLogin = myAccesoLogin.First().IdAccesoLogin;
                                IAccesoLogin.RutLogin = mvarUsuarioCod;
                                IAccesoLogin.RutCondominio = mvarUsuarioCod;
                                //IAccesoLogin.Ip = HttpContext.Current.Request.UserHostAddress;
                                IAccesoLogin.Ip = IAccesoLogin.Ip = HttpContext.Current.Request.UserHostAddress;
                                IAccesoLogin.Fecha = DateTime.Now;

                                YouCom.Service.Accesos.AccesoLogin.updAccesoLogin(IAccesoLogin);

                                YouCom.Service.Accesos.AccesoLogin.insHistoricoAccesoLogin(IAccesoLogin);
                            }
                        }
                        else
                        {
                            YouCom.DTO.AccesoLoginDTO myAcceso = new YouCom.DTO.AccesoLoginDTO();

                            myAcceso.RutLogin = mvarUsuarioCod;
                            myAcceso.RutCondominio = mvarUsuarioCod;
                            myAcceso.Ip = YouCom.Service.Generales.General.getObtieneIP();//HttpContext.Current.Request.UserHostAddress;
                            myAcceso.Fecha = DateTime.Now;


                            YouCom.Service.Accesos.AccesoLogin.insAccesoLogin(myAcceso);

                            YouCom.Service.Accesos.AccesoLogin.insHistoricoAccesoLogin(myAcceso);
                        }

                        wvarPaso = 330;
                        if ((DateTime.Parse(mvarFechaProceso) - (DateTime)wobjDataTableOperador.Rows[0]["FechaPass"]).Days >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD")))
                        {
                            wvarPaso = 340;
                            throw new Exception("3|Debe cambiar su contraseña.");
                        }
                        //=================================================================================
                    }
                }


                //Dejo el resultado de la búsqueda en el handler global.
                //=================================================================================
                wvarPaso = 1000;
                mobjUsuarioHandler = wobjDataTableOperador;
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        protected void AutenticarUsuario(string mvarUsuarioCod, string mvarRutCondominio, string mvarPassword)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTableOperador = new DataTable();

            string wvarPasswordEnc = "";

            try
            {
                string pReintentoMax = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "ReintentoMax").First().Descripcion;
                string pDuracionPwd = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD");//myIAmbiente.Where(x => x.Codigo == "DuracionPwd").First().Descripcion;
                string pValidaPass = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ValidaPass", "SEGURIDAD");

                //Seteo Parámetros
                //====================================================================================
                wvarPaso = 10;
                wobjSQLHelper.SetParametro("@pUsuario",
                                            SqlDbType.Char,
                                            20,
                                            mvarUsuarioCod);
                //====================================================================================


                //Ejecuto SP
                //====================================================================================
                wvarPaso = 200;
                if (wobjSQLHelper.Ejecutar("QRY_Operador",
                                           "YouCom",
                                           wobjDataTableOperador) == 0)
                {
                    wvarPaso = 210;
                    throw new Exception("2|El usuario o la contraseña son incorrectos.");
                }
                //====================================================================================


                //Si no es TrustedUser autentico.
                //=================================================================================
                wvarPaso = 290;
                if (mvarTrustedUser == "N")
                {
                    //Autentico.

                    //Verifico reintentos.
                    //====================================================================================
                    wvarPaso = 300;
                    if ((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("ReintentoMax", "SEGURIDAD")))
                    {
                        wvarPaso = 310;
                        throw new Exception("4|Estimado Cliente, Supero reintentos permitidos");
                    }
                    //====================================================================================


                    //Encripto password.
                    //====================================================================================
                    wvarPaso = 320;
                    EncPwd.Ejecutar(mvarPassword,
                                    (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                                    ref wvarPasswordEnc);
                    //====================================================================================


                    //Verifico la password.
                    //====================================================================================
                    if (YouCom.Service.Configuracion.Config.GetPropiedad("ValidaClave").Equals("S"))
                    {
                        wvarPaso = 330;
                        if ((string)wobjDataTableOperador.Rows[0]["Password"] != wvarPasswordEnc)
                        {
                            //Actualizo fallidos.
                            wvarPaso = 340;
                            ActIntentoFallidos(mvarUsuarioCod, (short)((short)wobjDataTableOperador.Rows[0]["IntentoFallidoCant"] + 1));

                            wvarPaso = 360;
                            throw new Exception("2|El usuario o la contraseña son incorrectos.");
                        }
                    }
                    //====================================================================================
                    //Reseteo Fallidos.
                    //====================================================================================
                    wvarPaso = 340;
                    ActIntentoFallidos(mvarUsuarioCod, 0);
                    //====================================================================================


                    //Verifico fecha de expiración.
                    //====================================================================================

                    YouCom.DTO.NuevoClienteDTO myNuevoCliente = new YouCom.DTO.NuevoClienteDTO();
                    myNuevoCliente = YouCom.Service.Accesos.NuevoCliente.getConsultaNuevoCliente(mvarUsuarioCod);

                    if (myNuevoCliente.CodError == 0)
                    {
                        if (myNuevoCliente.CambiaClave == "NO")
                        {
                            throw new Exception("3|Debe cambiar su contraseña.");
                        }
                        else
                        {
                            getConsultaHistorico(mvarUsuarioCod, mvarRutCondominio);
                        }
                    }
                    else
                    {
                        getConsultaHistorico(mvarUsuarioCod, mvarRutCondominio);
                    }

                    //wvarPaso = 330;
                    //if ((DateTime.Parse(mvarFechaProceso) - (DateTime)wobjDataTableOperador.Rows[0]["FechaPass"]).Days >= int.Parse(YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD")))
                    //{
                    //    wvarPaso = 340;
                    //    throw new Exception("3|Debe cambiar su contraseña.");
                    //}
                    //=================================================================================
                }


                //Dejo el resultado de la búsqueda en el handler global.
                //=================================================================================
                wvarPaso = 1000;
                mobjUsuarioHandler = wobjDataTableOperador;
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        public void getConsultaHistorico(string rutLogin, string RutCondominio)
        {
            try
            {
                string pDuracionPwd = YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("DuracionPwd", "SEGURIDAD");

                //Consulto Historia
                IList<YouCom.DTO.AccesoLoginDTO> myAccesoLogin = new List<YouCom.DTO.AccesoLoginDTO>();
                myAccesoLogin = YouCom.Service.Accesos.AccesoLogin.getConsultaAccesoLogin(rutLogin);

                if (myAccesoLogin.Any())
                {
                    System.TimeSpan diffResultFecha = DateTime.Now - myAccesoLogin.Max(x => x.Fecha);

                    if (diffResultFecha.Days > int.Parse(pDuracionPwd))
                    {
                        throw new Exception("3|Debe cambiar su contraseña.");
                    }
                    else
                    {
                        YouCom.DTO.AccesoLoginDTO IAccesoLogin = new YouCom.DTO.AccesoLoginDTO();

                        IAccesoLogin.RutLogin = rutLogin;
                        IAccesoLogin.RutCondominio = RutCondominio;
                        IAccesoLogin.Ip = IAccesoLogin.Ip = HttpContext.Current.Request.UserHostAddress;
                        IAccesoLogin.Fecha = DateTime.Now;

                        myAccesoLogin = YouCom.Service.Accesos.AccesoLogin.getConsultaAccesoLogin(rutLogin, RutCondominio);

                        if (myAccesoLogin.Any())
                        {
                            IAccesoLogin.IdAccesoLogin = myAccesoLogin.First().IdAccesoLogin;
                            YouCom.Service.Accesos.AccesoLogin.updAccesoLogin(IAccesoLogin);
                        }
                        else
                        {
                            YouCom.Service.Accesos.AccesoLogin.insAccesoLogin(IAccesoLogin);
                        }

                        YouCom.Service.Accesos.AccesoLogin.insHistoricoAccesoLogin(IAccesoLogin);
                    }
                }
                else
                {
                    YouCom.DTO.AccesoLoginDTO myAcceso = new YouCom.DTO.AccesoLoginDTO();

                    myAcceso.RutLogin = rutLogin;
                    myAcceso.RutCondominio = RutCondominio;
                    myAcceso.Ip = HttpContext.Current.Request.UserHostAddress;
                    myAcceso.Fecha = DateTime.Now;

                    YouCom.Service.Accesos.AccesoLogin.insAccesoLogin(myAcceso);

                    YouCom.Service.Accesos.AccesoLogin.insHistoricoAccesoLogin(myAcceso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Arma Token.
        /// </summary>
        private void ArmoToken(string mvarUsuarioCod, XmlDocument pdomResponse)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            const string TOKEN = "<YouComToken>" +
                                    "<Fecha/>" +
                                    "<TransaccionCod/>" +
                                    "<Usuario>" +
                                        "<UsuarioCod/>" +
                                        "<Roles/>" +
                                    "</Usuario>" +
                                    "<TerminalId/>" +
                                    "<TerminalUbicacion/>" +
                                    "<CanalCod/>" +
                                    "<TrustedUser/>" +
                                 "</YouComToken>";

            XmlDocument wdomToken = new XmlDocument();
            string wvarToken = "";

            try
            {
                //Armo el Token.
                //=================================================================================
                wvarPaso = 10;
                wdomToken.LoadXml(TOKEN);


                wvarPaso = 100;
                wdomToken.SelectSingleNode("YouComToken/Fecha").InnerText = mvarFechaProceso;
                wvarPaso = 120;
                wdomToken.SelectSingleNode("YouComToken/TrustedUser").InnerText = mvarTrustedUser;
                wvarPaso = 130;
                wdomToken.SelectSingleNode("YouComToken/TerminalId").InnerText = HttpContext.Current.Request.UserHostAddress;
                wvarPaso = 140;
                wdomToken.SelectSingleNode("YouComToken/TerminalUbicacion").InnerText = "";
                wvarPaso = 160;
                wdomToken.SelectSingleNode("YouComToken/CanalCod").InnerText = YouCom.Service.Configuracion.Config.GetPropiedad("CanalCod");


                wvarPaso = 170;
                wdomToken.SelectSingleNode("YouComToken/Usuario/UsuarioCod").InnerText = mvarUsuarioCod;


                //Roles.
                wvarPaso = 190;
                foreach (string wvarRol in mcolRol)
                {
                    wvarPaso = 200;
                    YouCom.Service.Configuracion.Xml.AgregarNodo(wdomToken,
                                       "YouComToken/Usuario/Roles",
                                       "RolCod",
                                       wvarRol);
                }
                //=================================================================================


                //Encripto el Token.
                //=================================================================================
                wvarPaso = 210;
                wvarToken = YouCom.Service.Seguridad.Crypt.Encriptar(wdomToken.OuterXml,
                                               YouCom.Service.Configuracion.Config.GetPropiedad("TokenPwd"));
                //=================================================================================


                //Agrego Token a la salida.
                //=================================================================================
                wvarPaso = 220;
                pdomResponse.SelectSingleNode("KTFResponse/Datos/Token").InnerText = wvarToken;
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        public static void ActIntentoFallidos(string mvarUsuarioCod, short pvarIntentoFallidoCant)
        {
            //Para el manejo de los errores
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();


            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wvarPaso = 10;
                wobjSQLHelper.SetParametro("@pUsuario",
                                            SqlDbType.Char,
                                            20,
                                            mvarUsuarioCod);
                wvarPaso = 20;
                wobjSQLHelper.SetParametro("@pIntentoFallidoFecha",
                                            SqlDbType.DateTime,
                                            -1,
                                            DateTime.Now);
                wvarPaso = 30;
                wobjSQLHelper.SetParametro("@pIntentoFallidoCant",
                                            SqlDbType.SmallInt,
                                            -1,
                                            pvarIntentoFallidoCant);
                //====================================================================================


                //Ejecuto SP.
                //====================================================================================
                wvarPaso = 100;
                switch (wobjSQLHelper.EjecutarNQ("UPD_Operador1", "YouCom"))
                {
                    case 0:
                        wvarPaso = 110;
                        throw new Exception("No se pudo actualizar reintentos.");
                    case -1:
                        wvarPaso = 120;
                        throw new Exception("Se produjo un error de clave duplicada al actualizar reintentos.");
                    case -2:
                        wvarPaso = 130;
                        throw new Exception("Se produjo un error de integridad referencial al actualizar reintentos.");
                }
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        /// <summary>
        /// GetDatos. Devuelve información del usuario y las funciones
        /// que tiene habilitadas.
        /// </summary>
        protected void GetDatos(XmlDocument pdomResponse)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                //Armo Usuario.
                //=================================================================================
                wvarPaso = 10;
                GetUsuarioInfo(pdomResponse);
                //=================================================================================


                //Armo Funciones del Usuario.
                //=================================================================================
                wvarPaso = 20;
                GetCondominiosInfo(pdomResponse);
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        protected void GetDatosAdmin(XmlDocument pdomResponse)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                //Armo Usuario.
                //=================================================================================
                wvarPaso = 10;
                GetUsuarioInfo(pdomResponse);
                //=================================================================================


                //Armo Funciones del Usuario.
                //=================================================================================
                wvarPaso = 20;
                GetCondominiosInfoAdmin(pdomResponse);
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        /// <summary>
        /// GetUsuario. Devuelve información del usuario.
        /// </summary>
        private void GetUsuarioInfo(XmlDocument pdomResponse)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            DataTable wobjDataTableOperador = null;

            try
            {
                wvarPaso = 10;
                wobjDataTableOperador = (DataTable)mobjUsuarioHandler;


                //Agrego información del usuario.
                //=================================================================================
                wvarPaso = 100;
                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                   "KTFResponse/Datos",
                                   "PersonaDescripcion",
                                   wobjDataTableOperador.Rows[0]["OperadorDescripcion"].ToString());

                wvarPaso = 100;
                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                   "KTFResponse/Datos",
                                   "LargoMinimoPwd",
                                   YouCom.Service.Parametrizacion.Parametros.getDescripcionParametros("LargoMinimoPwd", "SEGURIDAD"));
                //=================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }

        /// <summary>
        /// GetGruposInfo. Devuelve Grupos con sus funciones y Rut's asociados.
        /// </summary>
        private void GetCondominiosInfo(XmlDocument pdomResponse)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            DataTable wobjDataTableOperador = null;
            DataTable wobjDataTableGrupo = new DataTable();

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTable = new DataTable();

            try
            {
                wvarPaso = 10;
                wobjDataTableOperador = (DataTable)mobjUsuarioHandler;


                //Agrego Tag Grupos.
                //====================================================================================
                wvarPaso = 20;
                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                   "KTFResponse/Datos",
                                   "Condominios",
                                   null);
                //====================================================================================


                //Obtengo Grupos.
                //====================================================================================
                wvarPaso = 100;
                GetCondominios((int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                          wobjDataTableGrupo);
                //====================================================================================



                int wvarIdCondominio = -1;

                //Recorro Grupos (Corte de control).
                //====================================================================================
                wvarPaso = 200;
                foreach (DataRow wobjDataRowGrupo in wobjDataTableGrupo.Rows)
                {


                    wvarPaso = 230;
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                           "KTFResponse/Datos/Condominios",
                                           "Condominio",
                                           null);

                    wvarPaso = 240;
                    XmlDocument permisos = new XmlDocument();
                    permisos.LoadXml(wobjDataRowGrupo["resultado"].ToString());
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Condominios/Condominio[last()]",
                                          "IdCondominio",
                                          permisos.InnerXml);
                    //wobjDataRowGrupo["resultado"].ToString());

                    //Empieza grupo nuevo.
                    //====================================================================================
                    //wvarPaso = 210;
                    //if ((int)wobjDataRowGrupo["GrupoCod"] != wvarGrupoCod)
                    //{
                    //    wvarPaso = 220;
                    //    wvarGrupoCod = (int)wobjDataRowGrupo["GrupoCod"];

                    //    wvarPaso = 230;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos",
                    //                       "Grupo",
                    //                       null);

                    //    wvarPaso = 240;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "GrupoCod",
                    //                       wobjDataRowGrupo["GrupoCod"].ToString());

                    //    wvarPaso = 260;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "GrupoNombre",
                    //                       wobjDataRowGrupo["GrupoNombre"].ToString());

                    //    wvarPaso = 270;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "Funciones",
                    //                       null);


                    //    //Obtengo Funciones.
                    //    //====================================================================================
                    //    wvarPaso = 280;
                    //    GetFunciones(pdomResponse,
                    //                 (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                    //                 (int)wobjDataRowGrupo["GrupoCod"]);
                    //    //====================================================================================


                    //    wvarPaso = 290;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "RUTsAsociados",
                    //                       null);
                    //}
                    //====================================================================================

                    //wvarPaso = 300;
                    //if (wobjDataRowGrupo["RUTAsoc"].ToString() != "-1")
                    //{
                    //    wvarPaso = 310;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]/RUTsAsociados",
                    //                       "RUT",
                    //                       wobjDataRowGrupo["RUTAsoc"].ToString());
                    //}
                }

                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

        }

        /// <summary>
        /// GetGruposInfo. Devuelve Grupos con sus funciones y Rut's asociados.
        /// </summary>
        private void GetCondominiosInfoAdmin(XmlDocument pdomResponse)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            DataTable wobjDataTableOperador = null;
            DataTable wobjDataTableCondominio = new DataTable();

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTable = new DataTable();

            try
            {
                wvarPaso = 10;
                wobjDataTableOperador = (DataTable)mobjUsuarioHandler;


                //Agrego Tag Grupos.
                //====================================================================================
                wvarPaso = 20;
                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                   "KTFResponse/Datos",
                                   "Condominios",
                                   null);
                //====================================================================================


                //Obtengo Grupos.
                //====================================================================================
                wvarPaso = 100;
                GetCondominiosAdmin((int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                          wobjDataTableCondominio);
                //====================================================================================



                int wvarIdCondominio = -1;

                //Recorro Grupos (Corte de control).
                //====================================================================================
                wvarPaso = 200;
                foreach (DataRow wobjDataRowGrupo in wobjDataTableCondominio.Rows)
                {


                    wvarPaso = 230;
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                           "KTFResponse/Datos/Condominios",
                                           "Condominio",
                                           null);

                    wvarPaso = 240;
                    XmlDocument permisos = new XmlDocument();
                    permisos.LoadXml(wobjDataRowGrupo["resultado"].ToString());
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                          "KTFResponse/Datos/Condominios/Condominio[last()]",
                                          "IdCondominio",
                                          permisos.InnerXml);
                    //wobjDataRowGrupo["resultado"].ToString());

                    //Empieza grupo nuevo.
                    //====================================================================================
                    //wvarPaso = 210;
                    //if ((int)wobjDataRowGrupo["GrupoCod"] != wvarGrupoCod)
                    //{
                    //    wvarPaso = 220;
                    //    wvarGrupoCod = (int)wobjDataRowGrupo["GrupoCod"];

                    //    wvarPaso = 230;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos",
                    //                       "Grupo",
                    //                       null);

                    //    wvarPaso = 240;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "GrupoCod",
                    //                       wobjDataRowGrupo["GrupoCod"].ToString());

                    //    wvarPaso = 260;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "GrupoNombre",
                    //                       wobjDataRowGrupo["GrupoNombre"].ToString());

                    //    wvarPaso = 270;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "Funciones",
                    //                       null);


                    //    //Obtengo Funciones.
                    //    //====================================================================================
                    //    wvarPaso = 280;
                    //    GetFunciones(pdomResponse,
                    //                 (int)wobjDataTableOperador.Rows[0]["OperadorNro"],
                    //                 (int)wobjDataRowGrupo["GrupoCod"]);
                    //    //====================================================================================


                    //    wvarPaso = 290;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]",
                    //                       "RUTsAsociados",
                    //                       null);
                    //}
                    //====================================================================================

                    //wvarPaso = 300;
                    //if (wobjDataRowGrupo["RUTAsoc"].ToString() != "-1")
                    //{
                    //    wvarPaso = 310;
                    //    FunXml.AgregarNodo(pdomResponse,
                    //                       "KTFResponse/Datos/Grupos/Grupo[last()]/RUTsAsociados",
                    //                       "RUT",
                    //                       wobjDataRowGrupo["RUTAsoc"].ToString());
                    //}
                }

                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

        }

        private void GetFunciones(XmlDocument pdomResponse,
                              int pvarOperadorNro,
                              int pvarIdCondominio)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();
            DataTable wobjDataTableOperadorRol = new DataTable();
            DataTable wobjDataTablePermiso = new DataTable();

            string wvarFuncionGrpCodAux = "";

            try
            {

                //Seteo Parámetros.
                //====================================================================================
                wvarPaso = 100;
                wobjSQLHelper.SetParametro("@pOperadorNro",
                                           SqlDbType.Int,
                                           -1,
                                           pvarOperadorNro);
                wvarPaso = 110;
                wobjSQLHelper.SetParametro("@pIdCondominio",
                                           SqlDbType.Decimal,
                                           -1,
                                           pvarIdCondominio);
                //====================================================================================
                //Ejecuto SP (Consulto tabla para funciones).
                //====================================================================================
                wvarPaso = 120;
                if (wobjSQLHelper.Ejecutar("QRY_OperadorRol",
                                           "YouCom",
                                           wobjDataTableOperadorRol) == 0)
                {
                    wvarPaso = 130;
                    throw new Exception("No se encontraron registros al ejecutar el SP QRY_OperadorRUTAsoc1");
                }
                //====================================================================================
                //Seteo Parámetros.
                //====================================================================================
                wvarPaso = 200;
                wobjSQLHelper.SetParametro("@pIdCondominio",
                                           SqlDbType.Int,
                                           -1,
                                           pvarIdCondominio);
                wvarPaso = 210;
                wobjSQLHelper.SetParametro("@pRolCod",
                                           SqlDbType.Int,
                                           -1,
                                           (int)wobjDataTableOperadorRol.Rows[0]["RolCod"]);
                //====================================================================================


                //Ejecuto SP (Consulto tabla para funciones).
                //====================================================================================
                wvarPaso = 220;
                if (wobjSQLHelper.Ejecutar("QRY_Permiso2",
                                           "YouCom",
                                           wobjDataTablePermiso) == 0)
                {
                    wvarPaso = 230;
                    return;
                }
                //====================================================================================


                wvarPaso = 300;
                foreach (DataRow wobjDataRow in wobjDataTablePermiso.Rows)
                {
                    wvarPaso = 310;
                    if ((string)wobjDataRow["FuncionGrpCod"] != wvarFuncionGrpCodAux)
                    {
                        wvarPaso = 320;
                        wvarFuncionGrpCodAux = (string)wobjDataRow["FuncionGrpCod"];

                        wvarPaso = 330;
                        YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                           "KTFResponse/Datos/Condominios/Condominio[last()]/Funciones",
                                           "FuncionGrp",
                                           null);

                        wvarPaso = 340;
                        YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                           "KTFResponse/Datos/Condominios/Condominio[last()]/Funciones/FuncionGrp[last()]",
                                           "FuncionGrpCod",
                                           wobjDataRow["FuncionGrpCod"]);

                        wvarPaso = 360;
                        YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                           "KTFResponse/Datos/Condominios/Condominio[last()]/Funciones/FuncionGrp[last()]",
                                           "FuncionGrpNom",
                                           wobjDataRow["FuncionGrpNom"]);
                    }


                    wvarPaso = 400;
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                       "KTFResponse/Datos/Condominios/Condominio[last()]/Funciones/FuncionGrp[last()]",
                                       "Funcion",
                                       null);

                    wvarPaso = 410;
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                       "KTFResponse/Datos/Condominios/Condominio[last()]/Funciones/FuncionGrp[last()]/Funcion[last()]",
                                       "FuncionCod",
                                       wobjDataRow["FuncionCod"].ToString());

                    wvarPaso = 420;
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                       "KTFResponse/Datos/Condominios/Condominio[last()]/Funciones/FuncionGrp[last()]/Funcion[last()]",
                                       "FuncionNom",
                                       wobjDataRow["FuncionNom"].ToString());
                }

            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

            finally
            {
                wobjSQLHelper = null;
                wobjDataTableOperadorRol = null;
                wobjDataTablePermiso = null;
            }
        }

        private void GetCondominios(int pvarOperador,
                           DataTable pobjDataTableCondominio)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {

                // Int64  grupo_cod = Convert.ToInt64(Funciones.getInfoEmpresaPublico(UserEmpresa));

                //Seteo Parámetros.
                //====================================================================================
                wvarPaso = 100;
                wobjSQLHelper.SetParametro("@pOperadorNro",
                                           SqlDbType.Int,
                                           -1,
                                           pvarOperador);

                //wvarPaso = 110;
                //wobjSQLHelper.SetParametro("@pGrupoCod",
                //                           SqlDbType.Int,
                //                           -1,
                //                           grupo_cod);
                //====================================================================================


                //Ejecuto SP (Consulto tabla para funciones).
                //====================================================================================
                wvarPaso = 200;
                //if (wobjSQLHelper.Ejecutar("QRY_OperadorRUTAsoc1",
                if (wobjSQLHelper.Ejecutar("QRY_Permiso3",
                                           "YouCom",
                                           pobjDataTableCondominio) == 0)
                {
                    wvarPaso = 210;
                    throw new Exception("No se encontraron registros al ejecutar el SP QRY_OperadorRUTAsoc1");
                }
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

            finally
            {
                wobjSQLHelper = null;
            }
        }

        private void GetCondominiosAdmin(int pvarOperador,
                           DataTable pobjDataTableCondominio)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {

                // Int64  grupo_cod = Convert.ToInt64(Funciones.getInfoEmpresaPublico(UserEmpresa));

                //Seteo Parámetros.
                //====================================================================================
                wvarPaso = 100;
                wobjSQLHelper.SetParametro("@pOperadorNro",
                                           SqlDbType.Int,
                                           -1,
                                           pvarOperador);

                //wvarPaso = 110;
                //wobjSQLHelper.SetParametro("@pGrupoCod",
                //                           SqlDbType.Int,
                //                           -1,
                //                           grupo_cod);
                //====================================================================================


                //Ejecuto SP (Consulto tabla para funciones).
                //====================================================================================
                wvarPaso = 200;
                //if (wobjSQLHelper.Ejecutar("QRY_OperadorRUTAsoc1",
                if (wobjSQLHelper.Ejecutar("QRY_Permiso3",
                                           "YouCom",
                                           pobjDataTableCondominio) == 0)
                {
                    wvarPaso = 210;
                    throw new Exception("No se encontraron registros al ejecutar el SP QRY_OperadorRUTAsoc1");
                }
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

            finally
            {
                wobjSQLHelper = null;
            }
        }
    }
}
