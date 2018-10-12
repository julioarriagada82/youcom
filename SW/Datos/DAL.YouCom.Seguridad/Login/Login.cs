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
    public class Login
    {
        bool existe = false;
        protected Object mobjUsuarioHandler = null;
        protected string mvarTrustedUser = "N";
        protected string mvarFechaProceso = DateTime.Now.ToString();
        protected StringCollection mcolRol = new StringCollection();
        List<YouCom.DTO.Seguridad.OperadorDTO> operador = new List<YouCom.DTO.Seguridad.OperadorDTO>();
        YouCom.DTO.Seguridad.OperadorDTO theOperadorDTO = new YouCom.DTO.Seguridad.OperadorDTO();

        IList<YouCom.DTO.DirectivaDTO> theDirectivaDTO = new List<YouCom.DTO.DirectivaDTO>();
        IList<YouCom.DTO.PorteriaDTO> thePorteriaDTO = new List<YouCom.DTO.PorteriaDTO>();

        public List<YouCom.DTO.Seguridad.OperadorDTO> LoginUsuario(string mvarUsuarioCod, string mvarPassword)
        {

            YouCom.DTO.Seguridad.OperadorDTO theOperador = new YouCom.DTO.Seguridad.OperadorDTO();
            try
            {
                if (!string.IsNullOrEmpty(mvarUsuarioCod))
                {
                    theOperadorDTO = AuntetificaUsuario(mvarUsuarioCod, mvarPassword);

                    if (theOperadorDTO.ThePerfilDTO.IdPerfil == 1)
                    {
                        theDirectivaDTO = getListadoDirectiva().Where(x => x.Estado == "1").ToList();

                        if (theDirectivaDTO.Any())
                        {
                            theDirectivaDTO = theDirectivaDTO.Where(x => x.RutDirectiva == mvarUsuarioCod).ToList();
                            if (theDirectivaDTO.Any())
                            {
                                existe = true;
                            }
                        }
                    }
                    else if (theOperadorDTO.ThePerfilDTO.IdPerfil == 2)
                    {
                        thePorteriaDTO = getListadoPorteria().Where(x => x.Estado == "1").ToList();

                        if (thePorteriaDTO.Any())
                        {
                            thePorteriaDTO = thePorteriaDTO.Where(x => x.RutPorteria == mvarUsuarioCod).ToList();
                            if (thePorteriaDTO.Any())
                            {
                                existe = true;
                            }
                        }
                    }
                    else if (theOperadorDTO.ThePerfilDTO.IdPerfil == 4)
                    {
                        existe = true;
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

                    if (theOperadorDTO.ThePerfilDTO.IdPerfil == 1)
                    {
                        theOperador.TheComunidadDTO = theDirectivaDTO.First().TheComunidadDTO;
                        theOperador.TheCondominioDTO = theDirectivaDTO.First().TheCondominioDTO;
                    }
                    else if (theOperadorDTO.ThePerfilDTO.IdPerfil == 2)
                    {
                        theOperador.TheComunidadDTO = thePorteriaDTO.First().TheComunidadDTO;
                        theOperador.TheCondominioDTO = thePorteriaDTO.First().TheCondominioDTO;
                    }
                    else if (theOperadorDTO.ThePerfilDTO.IdPerfil == 4)
                    {
                        theOperador.TheComunidadDTO = theOperadorDTO.TheComunidadDTO;
                        theOperador.TheCondominioDTO = theOperadorDTO.TheCondominioDTO;
                    }

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
                        theOperadorDTO.FechaPassword = !string.IsNullOrEmpty(wobjDataRow["Fecha_Password"].ToString()) ? Convert.ToDateTime(wobjDataRow["Fecha_Password"].ToString()): DateTime.MinValue;
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

        public static IList<YouCom.DTO.DirectivaDTO> getListadoDirectiva()
        {
            IList<YouCom.DTO.DirectivaDTO> IDirectiva = new List<YouCom.DTO.DirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.DirectivaDAL.getListadoDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.DirectivaDTO directiva = new YouCom.DTO.DirectivaDTO();

                    directiva.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());

                    YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
                    myCargoDTO.IdCargo = decimal.Parse(wobjDataRow["idCargo"].ToString());
                    myCargoDTO.NombreCargo = wobjDataRow["nombreCargo"].ToString();
                    directiva.TheCargoDTO = myCargoDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    directiva.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    directiva.TheComunidadDTO = myComunidadDTO;
                    directiva.RutDirectiva = wobjDataRow["rutDirectiva"].ToString();
                    directiva.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
                    directiva.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
                    directiva.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
                    directiva.TelefonoDirectiva = wobjDataRow["telefonoDirectiva"].ToString();
                    directiva.ImagenDirectiva = wobjDataRow["imagenDirectiva"].ToString();
                    directiva.EmailDirectiva = wobjDataRow["correoDirectiva"].ToString();
                    directiva.FechaNacimientoDirectiva = Convert.ToDateTime(wobjDataRow["fechaNacimientoDirectiva"].ToString());

                    directiva.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    directiva.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    directiva.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    directiva.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    directiva.Estado = wobjDataRow["estado"].ToString();

                    IDirectiva.Add(directiva);
                }
            }

            return IDirectiva;

        }

        public static IList<YouCom.DTO.PorteriaDTO> getListadoPorteria()
        {
            IList<YouCom.DTO.PorteriaDTO> IPorteria = new List<YouCom.DTO.PorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.PorteriaDAL.getListadoPorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.PorteriaDTO portero = new YouCom.DTO.PorteriaDTO();

                    portero.IdPorteria = decimal.Parse(wobjDataRow["IdPorteria"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    portero.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    portero.TheComunidadDTO = myComunidadDTO;

                    portero.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    portero.ApellidoPaternoPorteria = wobjDataRow["apellidoPaternoPorteria"].ToString();
                    portero.ApellidoMaternoPorteria = wobjDataRow["apellidoMaternoPorteria"].ToString();
                    portero.RutPorteria = wobjDataRow["rutPorteria"].ToString();
                    portero.TelefonoPorteria = wobjDataRow["telefonoPorteria"].ToString();
                    portero.EmailPorteria = wobjDataRow["emailPorteria"].ToString();
                    portero.FechaNacimientoPorteria = Convert.ToDateTime(wobjDataRow["fechaNacimientoPorteria"].ToString());

                    portero.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    portero.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    portero.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    portero.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    portero.Estado = wobjDataRow["estado"].ToString();

                    IPorteria.Add(portero);
                }
            }

            return IPorteria;

        }



    }
}





