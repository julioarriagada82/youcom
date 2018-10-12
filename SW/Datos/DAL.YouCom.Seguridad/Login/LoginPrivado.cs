using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections.Specialized;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using YouCom.Service.IMDB;
using YouCom.DTO;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.DAL
{
    public class LoginCasa
    {
        bool existe = false;
        protected Object mobjUsuarioHandler = null;
        protected string mvarTrustedUser = "N";
        protected string mvarFechaProceso = DateTime.Now.ToString();
        protected StringCollection mcolRol = new StringCollection();
        List<YouCom.DTO.Seguridad.OperadorDTO> operador = new List<YouCom.DTO.Seguridad.OperadorDTO>();
        YouCom.DTO.Seguridad.OperadorDTO theOperadorDTO = new YouCom.DTO.Seguridad.OperadorDTO();
        IList<YouCom.DTO.Propietario.FamiliaDTO> familia = new List<YouCom.DTO.Propietario.FamiliaDTO>();

        public List<YouCom.DTO.Seguridad.OperadorDTO> LoginPrivado(string mvarUsuarioCod, string mvarPassword)
        {

            YouCom.DTO.Seguridad.OperadorDTO theOperador = new YouCom.DTO.Seguridad.OperadorDTO();
            try
            {
                if (!string.IsNullOrEmpty(mvarUsuarioCod))
                {
                    theOperadorDTO = AuntetificaUsuario(mvarUsuarioCod, mvarPassword);

                    if(theOperadorDTO.ThePerfilDTO.IdPerfil == 3)
                    {
                        familia = getListadoFamilia().Where(x => x.Estado == "1").ToList();
                        
                        if(familia.Any())
                        {
                            familia = familia.Where(x => x.RutFamilia == mvarUsuarioCod).ToList();
                            if (familia.Any())
                            {
                                existe = true;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Debe indicarse UsuarioCod");
                }

                if (existe)
                {

                    List<FuncionGrupoDTO> grupos = new List<FuncionGrupoDTO>();
                    FuncionGrupoDTO theFuncionGrupoDTO = new FuncionGrupoDTO();
                    FuncionDTO theFuncionDTO;
                    theOperador.Grupo = new List<FuncionGrupoDTO>();
                    theOperador = GetGrupos(theOperadorDTO.Usuario.ToString());

                    foreach (var item in grupos)
                    {
                        ///Carga Funciones de Menu General
                        theFuncionGrupoDTO.FuncionGrupoCod = item.FuncionGrupoCod;
                        theFuncionGrupoDTO.FuncionGrupoNombre = item.FuncionGrupoNombre;
                        theFuncionGrupoDTO.FuncionGrupoTipo = item.FuncionGrupoTipo;


                        theFuncionGrupoDTO.Funciones = new List<FuncionDTO>();
                        ///Carga Opciones de Menu y Configuracion de Negocio
                        foreach (var opciones in item.Funciones)
                        {
                            theFuncionDTO = new FuncionDTO();
                            theFuncionDTO.FuncionGrupoCod = opciones.FuncionGrupoCod;
                            theFuncionDTO.FuncionNombre = opciones.FuncionNombre;
                            theFuncionDTO.FuncionTipoCod = opciones.FuncionTipoCod;
                            theFuncionDTO.FuncionalidadNegocio = opciones.FuncionalidadNegocio;
                            theFuncionDTO.PadreCod = opciones.PadreCod;
                            theFuncionDTO.Url = opciones.Url;

                            theFuncionGrupoDTO.Funciones.Add(theFuncionDTO);
                        }
                    }

                    theOperador.Usuario = theOperadorDTO.Usuario;
                    theOperador.Nombres = theOperadorDTO.Nombres;
                    theOperador.Paterno = theOperadorDTO.Paterno;
                    theOperador.Materno = theOperadorDTO.Materno;

                    theOperador.TheComunidadDTO = familia.First().TheComunidadDTO;
                    theOperador.TheCondominioDTO = familia.First().TheCondominioDTO;
                    theOperador.TheCasaDTO = familia.First().TheCasaDTO;

                    theOperador.Grupo.Add(theFuncionGrupoDTO);

                    operador.Add(theOperador);
                }
                else
                {
                    throw new Exception("El usuario ingresado no pertenece a una comunidad");
                }
            }
            catch (Exception eobjException)
            {

                throw new Exception(eobjException.Message);

            }

            return operador;
        }
        public static YouCom.DTO.Seguridad.OperadorDTO AuntetificaUsuario(string usuario, string password)
        {
            YouCom.DTO.Seguridad.OperadorDTO theOperadorDTO = new YouCom.DTO.Seguridad.OperadorDTO();
            DataTable pobjDataTable = new DataTable();
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@pUsuario", SqlDbType.VarChar, 50, usuario);

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_Operador",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {

                }
                else
                {
                    string operador_nro = string.Empty;
                    foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                    {
                        operador_nro = wobjDataRow["USU_RUT"].ToString();

                        theOperadorDTO.OperadorNro = int.Parse(operador_nro.ToString().Substring(0, operador_nro.ToString().Length - 1));
                        theOperadorDTO.Usuario = wobjDataRow["USU_RUT"].ToString();
                        theOperadorDTO.Password = wobjDataRow["Password"].ToString();
                        theOperadorDTO.FechaPassword = !string.IsNullOrEmpty(wobjDataRow["Fecha_Password"].ToString()) ? Convert.ToDateTime(wobjDataRow["Fecha_Password"].ToString()) : DateTime.MinValue;
                        theOperadorDTO.IntentoFallidoFecha = !string.IsNullOrEmpty(wobjDataRow["Intento_Fallido_Fecha"].ToString()) ? Convert.ToDateTime(wobjDataRow["Intento_Fallido_Fecha"].ToString()) : DateTime.MinValue;
                        theOperadorDTO.IntentoFallidoCant = !string.IsNullOrEmpty(wobjDataRow["Intento_Fallido_Cant"].ToString()) ? Int32.Parse(wobjDataRow["Intento_Fallido_Cant"].ToString()) : 0;
                        theOperadorDTO.Nombres = wobjDataRow["nombre_usuario"].ToString();
                        theOperadorDTO.Paterno = wobjDataRow["paterno_usuario"].ToString();
                        theOperadorDTO.Materno = wobjDataRow["materno_usuario"].ToString();

                        YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                        myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                        theOperadorDTO.TheCondominioDTO = myCondominio;

                        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                        theOperadorDTO.TheComunidadDTO = myComunidadDTO;

                        YouCom.DTO.Seguridad.PerfilDTO myPerfilDTO = new YouCom.DTO.Seguridad.PerfilDTO();
                        myPerfilDTO.IdPerfil = decimal.Parse(wobjDataRow["idPerfil"].ToString());
                        theOperadorDTO.ThePerfilDTO = myPerfilDTO;
                    }

                    if (theOperadorDTO.Password == password)
                    {
                        if (theOperadorDTO.IntentoFallidoCant >= 3)
                        {
                            throw new Exception("4|Estimado Cliente, Supero reintentos permitidos Usuario Bloqueado");
                        }
                        else
                        {
                            ActIntentoFallidos(usuario, 0);

                        }
                    }
                    else
                    {
                        theOperadorDTO.IntentoFallidoCant = theOperadorDTO.IntentoFallidoCant + 1;
                        ActIntentoFallidos(usuario, Convert.ToInt16(theOperadorDTO.IntentoFallidoCant));
                        throw new Exception("2|El usuario o la contraseña son incorrectos.");
                        ///usuario pass erroneas
                        //return false
                    }
                    //====================================================================================
                }
            }
            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return theOperadorDTO;
        }
        public static YouCom.DTO.Seguridad.OperadorDTO GetGrupos(string pvarUsuarioCod)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_Permiso3", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            List<FuncionGrupoDTO> ListfuncionGrupo = new List<FuncionGrupoDTO>();
            FuncionGrupoDTO theFuncionGrupo;
            FuncionDTO theFuncionDTO;
            YouCom.DTO.Seguridad.OperadorDTO theOperador = new YouCom.DTO.Seguridad.OperadorDTO();
            theOperador.Grupo = new List<FuncionGrupoDTO>();

            myCommand.Parameters.Add("@pUSU_RUT", SqlDbType.VarChar).Value = pvarUsuarioCod;

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theFuncionDTO = new FuncionDTO();
                    theFuncionGrupo = new FuncionGrupoDTO();
                    theFuncionGrupo.Funciones = new List<FuncionDTO>();
                    ListfuncionGrupo = new List<FuncionGrupoDTO>();
                    ///Carga Grupo
                    theFuncionGrupo.FuncionGrupoCod = datos.GetInt32(0).ToString();
                    theFuncionGrupo.FuncionGrupoNombre = datos.GetString(1);
                    theFuncionGrupo.FuncionGrupoTipo = datos.GetString(5);

                    ///Carga Funcionalidades de Grupo y Funcionalidades Internas del Negocio
                    theFuncionDTO.FuncionCod = datos.GetInt32(2).ToString();

                    if (!datos.IsDBNull(3))
                        theFuncionDTO.PadreCod = datos.GetInt32(3);

                    theFuncionDTO.FuncionNombre = datos.GetString(4);
                    theFuncionDTO.Url = datos.GetString(5);
                    theFuncionDTO.FuncionalidadNegocio = datos.GetString(6);
                    theFuncionGrupo.Funciones.Add(theFuncionDTO);

                    //  ListfuncionGrupo.Add(theFuncionGrupo);
                    theOperador.Grupo.Add(theFuncionGrupo);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return theOperador;
        }


        /// <summary>
        /// Actualiza Intentos Fallidos
        /// </summary>
        /// <param name="mvarUsuarioCod"></param>
        /// <param name="pvarIntentoFallidoCant"></param>
        private static void ActIntentoFallidos(string mvarUsuarioCod, short pvarIntentoFallidoCant)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("UPD_Operador1", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            string idEmpleado = string.Empty;

            myCommand.Parameters.Add("@pUsu_Rut", SqlDbType.VarChar).Value = mvarUsuarioCod;
            myCommand.Parameters.Add("@pIntentoFallidoFecha", SqlDbType.VarChar).Value = "";
            myCommand.Parameters.Add("@pIntentoFallidoCant", SqlDbType.VarChar).Value = pvarIntentoFallidoCant;

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    idEmpleado = datos.GetString(0);

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static IList<YouCom.DTO.Propietario.FamiliaDTO> getListadoFamilia()
        {
            IList<YouCom.DTO.Propietario.FamiliaDTO> IFamilia = new List<YouCom.DTO.Propietario.FamiliaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Propietario.FamiliaDAL.getListadoFamilia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propietario.FamiliaDTO familia = new YouCom.DTO.Propietario.FamiliaDTO();

                    familia.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    familia.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    familia.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
                    myCasaDTO.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    myCasaDTO.NombreCasa = wobjDataRow["nombreCasa"].ToString();
                    familia.TheCasaDTO = myCasaDTO;

                    YouCom.DTO.Propietario.OcupacionDTO myOcupacionDTO = new YouCom.DTO.Propietario.OcupacionDTO();
                    myOcupacionDTO.IdOcupacion = decimal.Parse(wobjDataRow["idOcupacion"].ToString());
                    myOcupacionDTO.NombreOcupacion = wobjDataRow["nombreOcupacion"].ToString();
                    familia.TheOcupacionDTO = myOcupacionDTO;

                    familia.RutFamilia = wobjDataRow["rutFamilia"].ToString();
                    familia.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    familia.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    familia.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();

                    YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
                    myParentescoDTO.IdParentesco = decimal.Parse(wobjDataRow["idParentesco"].ToString());
                    myParentescoDTO.NombreParentesco = wobjDataRow["nombreParentesco"].ToString();
                    familia.TheParentescoDTO = myParentescoDTO;

                    familia.CelularFamilia = wobjDataRow["celularFamilia"].ToString();
                    familia.TelefonoFamilia = wobjDataRow["telefonoFamilia"].ToString();
                    familia.EmailFamilia = wobjDataRow["emailFamilia"].ToString();

                    familia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    familia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    familia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    familia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();
                    familia.Estado = wobjDataRow["estado"].ToString();

                    IFamilia.Add(familia);
                }
            }

            return IFamilia;

        }
    }
}