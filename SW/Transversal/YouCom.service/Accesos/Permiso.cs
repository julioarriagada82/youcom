using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using System.Xml;
using YouCom.Service.BD;

namespace YouCom.Service.Accesos
{
    public class Permiso
    {
        public static bool getPermiso(YouCom.DTO.Seguridad.UsuarioDTO myUsuario, string idCondominio, string wvarProducto, string wvarFuncionalidad)
        {
            bool wvarExiste = false;

            foreach (YouCom.DTO.Seguridad.CondominioDTO condominio in myUsuario.TheCondominioDTO)
            {
                if (idCondominio.Equals(condominio.IdCondominio))
                {
                    foreach (YouCom.DTO.ProductoDTO producto in condominio.Productos)
                    {
                        if (producto.Codigo.Equals(wvarProducto))
                        {
                            foreach (YouCom.DTO.Item funciones in producto.Funciones)
                            {
                                if (funciones.Codigo.Equals(wvarFuncionalidad))
                                    wvarExiste = true;
                            }
                        }
                    }
                }
            }

            return wvarExiste;
        }

        public static bool getPermiso(YouCom.DTO.Seguridad.UsuarioDTO myUsuario, string wvarProducto, string wvarFuncionalidad)
        {
            bool wvarExiste = false;

            foreach (YouCom.DTO.Seguridad.CondominioDTO condominio in myUsuario.TheCondominioDTO)
            {
                foreach (YouCom.DTO.ProductoDTO producto in condominio.Productos)
                {
                    if (producto.Codigo.Equals(wvarProducto))
                    {
                        foreach (YouCom.DTO.Item funciones in producto.Funciones)
                        {
                            if (funciones.Codigo.Equals(wvarFuncionalidad))
                                wvarExiste = true;
                        }
                    }
                }
            }

            return wvarExiste;
        }

        public static YouCom.DTO.ProductoDTO getPermisos(string grupo_cod)
        {
            string statesKey = "SegConPerComAdm";

            YouCom.DTO.ProductoDTO IProducto = new YouCom.DTO.ProductoDTO();

            XmlDocument xmlResponse = new XmlDocument();
            String[,] aparams = new String[2, 2];

            aparams[0, 0] = "GrupoCod"; aparams[0, 1] = YouCom.Service.Configuracion.Formato.LimpiaParametro(grupo_cod);
            aparams[1, 0] = "RolCod"; aparams[1, 1] = "0";

            if (!ConsultaPermiso(int.Parse(YouCom.Service.Configuracion.Formato.LimpiaParametro(grupo_cod)), 0, ref xmlResponse))
                //if (!General.callTrx(statesKey, aparams, ref xmlResponse, true))
                throw new Exception(xmlResponse.SelectSingleNode("Error").InnerText);

            if (xmlResponse.SelectSingleNode("KTFResponse").HasChildNodes)
            {
                foreach (XmlNode xmlProducto in xmlResponse.SelectNodes("KTFResponse/Funciones/Asignadas/FuncionGrp"))
                {
                    if (xmlProducto.SelectSingleNode("FuncionGrpCod").InnerText.Equals("TEF"))
                    {
                        IProducto.Codigo = xmlProducto.SelectSingleNode("FuncionGrpCod").InnerText;
                        IProducto.Descripcion = xmlProducto.SelectSingleNode("FuncionGrpNom").InnerText;

                        foreach (XmlNode xmlFuncion in xmlProducto.SelectNodes("Funcion"))
                        {
                            YouCom.DTO.Item func = new YouCom.DTO.Item();

                            func.Codigo = xmlFuncion.SelectSingleNode("FuncionCod").InnerText;
                            func.Descripcion = xmlFuncion.SelectSingleNode("FuncionNom").InnerText;

                            IProducto.Funciones.Add(func);
                        }
                    }
                }
            }
            return IProducto;
        }

        public static void getPermiso(string pvarFuncionCod, ref DataTable pobjDataTable)
        {

            if (string.IsNullOrEmpty(pvarFuncionCod))
            {
                pobjDataTable.Clear();
                return;
            }
            int wvarPaso = 0;


            SQLHelper wobjSQLHelper = new SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wvarPaso = 40;
                wobjSQLHelper.SetParametro("@pFuncionCod",
                                           SqlDbType.SmallInt,
                                           -1,
                                           Convert.ToInt32(pvarFuncionCod));


                //====================================================================================
                //Ejecuto SP.
                //====================================================================================
                wvarPaso = 60;
                if (wobjSQLHelper.Ejecutar("QRY_GetFuncionCod",
                                           "MiniSitio_IB",
                                           pobjDataTable) <= 0)
                {
                    pobjDataTable.Clear();
                    return;
                }
                //====================================================================================

            }

            #region Catch
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion
        }

        #region IParametros Members
        public static Boolean ConsultaPermiso(int mvarGrupoCod, int wvarRolCod, ref XmlDocument pdomResponse)
        {
            bool retorno = false;
            DataTable wobjConsulta = new DataTable();

            string wvarFuncionGrpCodAux1 = "";
            string wvarFuncionGrpCodAux2 = "";

            try
            {
                //Consulto Solicitud.
                //====================================================================================
                if (getConsultaPermiso(mvarGrupoCod, wvarRolCod, wobjConsulta))
                {
                    pdomResponse.LoadXml(YouCom.Service.Configuracion.Xml.GetXmlResponse());

                    //Recorro la tabla y armo el response diferenciando disponibles de asignadas.
                    //====================================================================================
                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                       "KTFResponse/Datos",
                                       "Funciones",
                                       null);

                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                       "KTFResponse/Datos/Funciones",
                                       "Disponibles",
                                       null);

                    YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                       "KTFResponse/Datos/Funciones",
                                       "Asignadas",
                                       null);

                    foreach (DataRow wobjDataRow in wobjConsulta.Rows)
                    {

                        if ((short)wobjDataRow["Disponible"] == -100)
                        {
                            if ((string)wobjDataRow["FuncionGrpCod"] != wvarFuncionGrpCodAux1)
                            {
                                wvarFuncionGrpCodAux1 = (string)wobjDataRow["FuncionGrpCod"];

                                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                                   "KTFResponse/Datos/Funciones/Disponibles",
                                                   "FuncionGrp",
                                                   null);

                                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                                   "KTFResponse/Datos/Funciones/Disponibles/FuncionGrp[last()]",
                                                   "FuncionGrpCod",
                                                   wobjDataRow["FuncionGrpCod"]);

                                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                                   "KTFResponse/Datos/Funciones/Disponibles/FuncionGrp[last()]",
                                                   "FuncionGrpNom",
                                                   wobjDataRow["FuncionGrpNom"]);
                            }

                            YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                               "KTFResponse/Datos/Funciones/Disponibles/FuncionGrp[last()]",
                                               "Funcion",
                                               null);

                            YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                               "KTFResponse/Datos/Funciones/Disponibles/FuncionGrp[last()]/Funcion[last()]",
                                               "FuncionCod",
                                               wobjDataRow["FuncionCod"].ToString());

                            YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                               "KTFResponse/Datos/Funciones/Disponibles/FuncionGrp[last()]/Funcion[last()]",
                                               "FuncionNom",
                                               wobjDataRow["FuncionNom"].ToString());
                        }
                        else
                        {
                            if ((string)wobjDataRow["FuncionGrpCod"] != wvarFuncionGrpCodAux2)
                            {
                                wvarFuncionGrpCodAux2 = (string)wobjDataRow["FuncionGrpCod"];

                                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                                   "KTFResponse/Datos/Funciones/Asignadas",
                                                   "FuncionGrp",
                                                   null);

                                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                                   "KTFResponse/Datos/Funciones/Asignadas/FuncionGrp[last()]",
                                                   "FuncionGrpCod",
                                                   wobjDataRow["FuncionGrpCod"]);

                                YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                                   "KTFResponse/Datos/Funciones/Asignadas/FuncionGrp[last()]",
                                                   "FuncionGrpNom",
                                                   wobjDataRow["FuncionGrpNom"]);
                            }

                            YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                               "KTFResponse/Datos/Funciones/Asignadas/FuncionGrp[last()]",
                                               "Funcion",
                                               null);

                            YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                               "KTFResponse/Datos/Funciones/Asignadas/FuncionGrp[last()]/Funcion[last()]",
                                               "FuncionCod",
                                               wobjDataRow["FuncionCod"].ToString());

                            YouCom.Service.Configuracion.Xml.AgregarNodo(pdomResponse,
                                               "KTFResponse/Datos/Funciones/Asignadas/FuncionGrp[last()]/Funcion[last()]",
                                               "FuncionNom",
                                               wobjDataRow["FuncionNom"].ToString());
                        }
                    }
                    //====================================================================================

                    retorno = true;
                }
                //====================================================================================
            }

            #region Catch

            catch (Exception eobjException)
            {
                YouCom.Service.Configuracion.Xml.getArmaXMLError(eobjException, ref pdomResponse);
            }
            #endregion

            return retorno;
        }
        private static bool getConsultaPermiso(int mvarGrupoCod, int wvarRolCod, DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pGrupoCod",
                                           SqlDbType.Int,
                                           -1,
                                           mvarGrupoCod);

                wobjSQLHelper.SetParametro("@pRolCod",
                                           SqlDbType.Int,
                                           -1,
                                           wvarRolCod);
                //====================================================================================


                //Ejecuto SP (Consulto tabla para funciones).
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_Permiso1",
                                           "KTF",
                                           pobjDataTable) <= 0)
                {
                    //wvarPaso = 230;
                    //SetFuncionalException(ERR_NO_HAY_PERMISOS);
                }
                //====================================================================================
                retorno = true;
                //====================================================================================
            }

            #region Catch
            catch (Exception eobjException)
            {
                throw eobjException;
                retorno = false;
            }
            #endregion

            return retorno;
        }
        #endregion
    }
}
