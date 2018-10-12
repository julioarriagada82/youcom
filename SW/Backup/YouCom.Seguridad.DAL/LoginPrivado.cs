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
        List<YouCom.DTO.Seguridad.UsuarioDTO> operador = new List<YouCom.DTO.Seguridad.UsuarioDTO>();
        YouCom.DTO.Seguridad.UsuarioDTO theOperadorDTO = new YouCom.DTO.Seguridad.UsuarioDTO();

        public List<YouCom.DTO.Seguridad.UsuarioDTO> LoginPrivado(string mvarUsuarioCod, string mvarPassword)
        {

            YouCom.DTO.Seguridad.UsuarioDTO theOperador = new YouCom.DTO.Seguridad.UsuarioDTO();
            try
            {
                if (!string.IsNullOrEmpty(mvarUsuarioCod))
                {
                    theOperadorDTO = AuntetificaUsuario(mvarUsuarioCod, mvarPassword);

                    IList<YouCom.DTO.FamiliaDTO> familia = new List<YouCom.DTO.FamiliaDTO>();

                    familia = YouCom.bll.FamiliaBLL.listaFamiliaActivo();

                    familia = familia.Where(x => x.RutFamilia == mvarUsuarioCod).ToList();
                    if (familia.Any())
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
                            theFuncionDTO.Url = opciones.Url;

                            theFuncionGrupoDTO.Funciones.Add(theFuncionDTO);
                        }
                    }

                    theOperador.Usuario = theOperadorDTO.Usuario;
                    theOperador.Nombres = theOperadorDTO.Nombres;
                    theOperador.Paterno = theOperadorDTO.Paterno;
                    theOperador.Materno = theOperadorDTO.Materno;
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
        public static YouCom.DTO.Seguridad.UsuarioDTO AuntetificaUsuario(string usuario, string password)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_Operador", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            YouCom.DTO.Seguridad.UsuarioDTO theOperadorDTO = new YouCom.DTO.Seguridad.UsuarioDTO();
            string idEmpleado = string.Empty;
            myCommand.Parameters.Add("@pUsuario", SqlDbType.VarChar).Value = usuario;

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    if (!datos.IsDBNull(0))
                    {
                        theOperadorDTO.OperadorNro = int.Parse(datos.GetString(0).ToString().Substring(0, datos.GetString(0).ToString().Length - 1));
                        theOperadorDTO.Usuario = datos.GetString(0).ToString();
                    }

                    if (!datos.IsDBNull(1))
                    {
                        theOperadorDTO.Password = datos.GetString(1);
                    }
                    if (!datos.IsDBNull(2))
                    {
                        theOperadorDTO.Fechapass = datos.GetDateTime(2);
                    }

                    if (!datos.IsDBNull(3))
                    {
                        theOperadorDTO.IntentoFallidoFecha = datos.GetDateTime(3);
                    }
                    if (!datos.IsDBNull(4))
                    {
                        theOperadorDTO.IntentoFallidoCant = datos.GetInt32(4);
                    }

                    if (!datos.IsDBNull(5))
                    {
                        theOperadorDTO.Nombres = datos.GetString(5).ToString();
                    }

                    if (!datos.IsDBNull(6))
                    {
                        theOperadorDTO.Paterno = datos.GetString(6).ToString();
                    }

                    if (!datos.IsDBNull(7))
                    {
                        theOperadorDTO.Materno = datos.GetString(7).ToString();
                    }

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

            return theOperadorDTO;
        }
        public static YouCom.DTO.Seguridad.UsuarioDTO GetGrupos(string pvarUsuarioCod)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_Permiso3", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            List<FuncionGrupoDTO> ListfuncionGrupo = new List<FuncionGrupoDTO>();
            FuncionGrupoDTO theFuncionGrupo;
            FuncionDTO theFuncionDTO;
            YouCom.DTO.Seguridad.UsuarioDTO theOperador = new YouCom.DTO.Seguridad.UsuarioDTO();
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
                    theFuncionDTO.FuncionNombre = datos.GetString(3);
                    theFuncionDTO.Url = datos.GetString(4);
                    theFuncionDTO.FuncionalidadNegocio = datos.GetString(5);
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
    }
}