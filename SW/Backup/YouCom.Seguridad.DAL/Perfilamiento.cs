using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using YouCom.Service.IMDB;
using System.Data;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.DAL
{
    public class Perfilamiento
    {

        public static List<FuncionGrupoDTO> ListaGruposSistema()
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("getFuncionGrupoSistema", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            FuncionGrupoDTO theFuncionGrupoDTO;
            List<FuncionGrupoDTO> grupos = new List<FuncionGrupoDTO>();
            string idEmpleado = string.Empty;

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theFuncionGrupoDTO = new FuncionGrupoDTO();
                    try
                    {
                        if (!datos.IsDBNull(0))
                        {
                            theFuncionGrupoDTO.FuncionGrupoCod = datos.GetInt32(0).ToString();
                        }
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!datos.IsDBNull(1))
                        {
                            theFuncionGrupoDTO.FuncionGrupoNombre = datos.GetString(1);
                        }
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    grupos.Add(theFuncionGrupoDTO);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return grupos;
        }

        public static List<FuncionDTO> ListaFuncionGrupoSistema()
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("GetFuncionalidadesSistema", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            FuncionDTO theFuncionDTO;
            List<FuncionDTO> funciones = new List<FuncionDTO>();
            string idEmpleado = string.Empty;

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theFuncionDTO = new FuncionDTO();
                    try
                    {
                        if (!datos.IsDBNull(0))
                        {
                            theFuncionDTO.FuncionCod = datos.GetInt32(0).ToString();
                        }
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    try
                    {
                        if (!datos.IsDBNull(1))
                        {
                            theFuncionDTO.FuncionNombre = datos.GetString(1);
                        }
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    funciones.Add(theFuncionDTO);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return funciones;
        }
        /// <summary>
        /// Inserta los permisos para las funcionalidades al Usuario asignado
        /// </summary>
        public static void InsertaPermisos(PermisoDTO thePermisoDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("INS_Permiso", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@pGrupoCod", SqlDbType.VarChar).Value = thePermisoDTO.Empresa;
            myCommand.Parameters.Add("@pRolCod", SqlDbType.VarChar).Value = thePermisoDTO.Usuario;
            myCommand.Parameters.Add("@pFuncionCod", SqlDbType.VarChar).Value = thePermisoDTO.Funcion;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


        }


        public static void DeletePermisos(PermisoDTO thePermisoDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("DEL_Permisos", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@usuario", SqlDbType.Int).Value = thePermisoDTO.Usuario;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Inserta una nueva Empresa
        /// </summary>
        /// <param name="theEmpresaDTO"></param>
        /// <returns></returns>
        public static int InsertarCondominio(CondominioDTO theCondominioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("INS_Condominio", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@pRutCondominio", SqlDbType.VarChar).Value = theCondominioDTO.RutCondominio;
            myCommand.Parameters.Add("@pNombreCondominio", SqlDbType.VarChar).Value = theCondominioDTO.NombreCondominio;
            myCommand.Parameters.Add("@pTelefonoCondominio", SqlDbType.VarChar).Value = theCondominioDTO.TelefonoCondominio;
            myCommand.Parameters.Add("@pCorreoCondominio", SqlDbType.VarChar).Value = theCondominioDTO.EmailCondominio;
            myCommand.Parameters.Add("@pDireccionCondominio", SqlDbType.VarChar).Value = theCondominioDTO.DireccionCondominio;
            myCommand.Parameters.Add("@pUsuarioIngreso", SqlDbType.VarChar).Value = theCondominioDTO.UsuarioIngreso;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }

        /// <summary>
        /// Actualiza datos de empresa existente
        /// </summary>
        /// <param name="theEmpresaDTO"></param>
        /// <returns></returns>
        public static int UpdateCondominio(CondominioDTO theCondominioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("UPD_CONDOMINIO", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@idCondominio", SqlDbType.Decimal).Value = theCondominioDTO.IdCondominio;
            myCommand.Parameters.Add("@idPorteria", SqlDbType.Decimal).Value = theCondominioDTO.IdPorteria;
            myCommand.Parameters.Add("@idAdministracion", SqlDbType.Decimal).Value = theCondominioDTO.IdAdministracion;
            myCommand.Parameters.Add("@nombreCondominio", SqlDbType.VarChar).Value = theCondominioDTO.NombreCondominio;
            myCommand.Parameters.Add("@telefonoCondominio", SqlDbType.VarChar).Value = theCondominioDTO.TelefonoCondominio;
            myCommand.Parameters.Add("@correoCondominio", SqlDbType.VarChar).Value = theCondominioDTO.EmailCondominio;
            myCommand.Parameters.Add("@direccionCondominio", SqlDbType.VarChar).Value = theCondominioDTO.DireccionCondominio;
            myCommand.Parameters.Add("@usuarioIngreso", SqlDbType.VarChar).Value = theCondominioDTO.UsuarioIngreso;
            myCommand.Parameters.Add("@fechaIngreso", SqlDbType.DateTime).Value = theCondominioDTO.FechaIngreso;
            myCommand.Parameters.Add("@usuarioModificacion", SqlDbType.VarChar).Value = theCondominioDTO.UsuarioModificacion;
            myCommand.Parameters.Add("@fechaModificacion", SqlDbType.DateTime).Value = theCondominioDTO.FechaModificacion;
            myCommand.Parameters.Add("@estado", SqlDbType.Int).Value = theCondominioDTO.Estado;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }
        /// <summary>
        /// Desactiva una empresa y todos los usuario asociados
        /// </summary>
        /// <param name="theEmpresaDTO"></param>
        /// <returns></returns>
        public static int DeleteCondominio(CondominioDTO theCondominioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("ACT_CONDOMINIO", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@idCondominio", SqlDbType.Int).Value = theCondominioDTO.IdCondominio;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }
        /// <summary>
        /// Lista todas las empresas creadas
        /// </summary>
        /// <returns></returns>
        public static List<CondominioDTO> ListaCondominios()
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_ListaCondominios", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            CondominioDTO theCondominioDTO;
            List<CondominioDTO> condominio = new List<CondominioDTO>();

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theCondominioDTO = new CondominioDTO();

                    if (!datos.IsDBNull(0))
                    {
                        theCondominioDTO.IdCondominio = datos.GetDecimal(0);
                    }
                    if (!datos.IsDBNull(1))
                    {
                        theCondominioDTO.RutCondominio = datos.GetString(1);
                    }
                    if (!datos.IsDBNull(2))
                    {
                        theCondominioDTO.NombreCondominio = datos.GetString(2);
                    }
                    if (!datos.IsDBNull(3))
                    {
                        theCondominioDTO.TelefonoCondominio = datos.GetString(3);
                    }
                    if (!datos.IsDBNull(4))
                    {
                        theCondominioDTO.EmailCondominio = datos.GetString(4);
                    }
                    if (!datos.IsDBNull(5))
                    {
                        theCondominioDTO.DireccionCondominio = datos.GetString(5);
                    }
                    if (!datos.IsDBNull(6))
                    {
                        theCondominioDTO.UsuarioIngreso = datos.GetString(6);
                    }
                    if (!datos.IsDBNull(7))
                    {
                        theCondominioDTO.FechaIngreso = datos.GetDateTime(7).ToShortDateString();
                    }
                    if (!datos.IsDBNull(8))
                    {
                        theCondominioDTO.UsuarioModificacion = datos.GetString(8);
                    }
                    if (!datos.IsDBNull(9))
                    {
                        theCondominioDTO.FechaModificacion = datos.GetDateTime(9).ToString();
                    }
                    if (!datos.IsDBNull(10))
                    {
                        theCondominioDTO.Estado = datos.GetInt32(10).ToString();
                    }
                    condominio.Add(theCondominioDTO);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }

            finally
            {
                myConnection.Close();
            }

            return condominio;
        }

        /// <summary>
        /// Activa o Desactiva Usuarios
        /// </summary>
        /// <param name="UsuarioDTO"></param>
        /// <returns></returns>
        public static int ActivaDesactivaUsuario(UsuarioDTO UsuarioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("activaDesactivaUsuario", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.Parameters.Add("@rut", SqlDbType.Int).Value = UsuarioDTO.Rut;
            //myCommand.Parameters.Add("@usuarioModificacion", SqlDbType.VarChar).Value = UsuarioDTO.UsuarioModificacion;
            //myCommand.Parameters.Add("@estado", SqlDbType.Int).Value = UsuarioDTO.Estado;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }

        /// <summary>
        /// Agregar un usuario
        /// </summary>
        /// <param name="UsuarioDTO"></param>
        /// <returns></returns>
        public static int InsertarUsuario(UsuarioDTO UsuarioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("ins_usuario", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@rut", SqlDbType.VarChar).Value = UsuarioDTO.Usuario;
            myCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = UsuarioDTO.Password;
            myCommand.Parameters.Add("@pNombreUsuario", SqlDbType.VarChar).Value = UsuarioDTO.Nombres;
            myCommand.Parameters.Add("@pPaternoUsuario", SqlDbType.VarChar).Value = UsuarioDTO.Paterno;
            myCommand.Parameters.Add("@pMaternoUsuario", SqlDbType.VarChar).Value = UsuarioDTO.Materno;
            myCommand.Parameters.Add("@pFechaNacimiento", SqlDbType.DateTime).Value = UsuarioDTO.FechaNacimiento;
            myCommand.Parameters.Add("@pMailUsuario", SqlDbType.VarChar).Value = UsuarioDTO.Mail;
            myCommand.Parameters.Add("@pIdCondominio", SqlDbType.Decimal).Value = UsuarioDTO.IdCondominio;
            myCommand.Parameters.Add("@usuarioIngreso", SqlDbType.VarChar).Value = UsuarioDTO.UsuarioIngreso;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }

        public static int InsertarAdministrador(UsuarioDTO UsuarioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("ins_administrador", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.Parameters.Add("@rut", SqlDbType.Int).Value = UsuarioDTO.Rut;
            //myCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = UsuarioDTO.Password;
            //myCommand.Parameters.Add("@nombres", SqlDbType.VarChar).Value = UsuarioDTO.Nombres;
            //myCommand.Parameters.Add("@paterno", SqlDbType.VarChar).Value = UsuarioDTO.Paterno;
            //myCommand.Parameters.Add("@materno", SqlDbType.VarChar).Value = UsuarioDTO.Materno;
            //myCommand.Parameters.Add("@usuarioIngreso", SqlDbType.VarChar).Value = UsuarioDTO.UsuarioIngreso;
            //myCommand.Parameters.Add("@empresa", SqlDbType.VarChar).Value = UsuarioDTO.Empresa;
            //myCommand.Parameters.Add("@mail", SqlDbType.VarChar).Value = UsuarioDTO.Mail;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }



        /// <summary>
        /// Actualiza Administrador
        /// </summary>
        /// <param name="theEmpresaDTO"></param>
        /// <returns></returns>
        public static int UpdateAdministrador(UsuarioDTO theUsuarioDTO)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("UDP_administrador", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.Parameters.Add("@paterno", SqlDbType.VarChar).Value = theUsuarioDTO.Paterno;
            //myCommand.Parameters.Add("@materno", SqlDbType.VarChar).Value = theUsuarioDTO.Materno;
            //myCommand.Parameters.Add("@nombres", SqlDbType.VarChar).Value = theUsuarioDTO.Nombres;
            //myCommand.Parameters.Add("@rut", SqlDbType.Int).Value = theUsuarioDTO.Rut;
            //myCommand.Parameters.Add("@mail", SqlDbType.VarChar).Value = theUsuarioDTO.Mail;
            //myCommand.Parameters.Add("@empresa", SqlDbType.Int).Value = theUsuarioDTO.Empresa;
            //myCommand.Parameters.Add("@usuarioIngreso", SqlDbType.Int).Value = theUsuarioDTO.UsuarioIngreso;


            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;

        }
        /// <summary>
        /// Lista usuarios
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioDTO> ListaUsuarios()
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_listaUsuarios", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            UsuarioDTO theUsuarioDTO;
            List<UsuarioDTO> usuario = new List<UsuarioDTO>();

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theUsuarioDTO = new UsuarioDTO();

                    if (!datos.IsDBNull(0))
                    {
                        theUsuarioDTO.Rut = datos.GetString(0);
                    }
                    if (!datos.IsDBNull(1))
                    {
                        theUsuarioDTO.Nombres = datos.GetString(1);
                    }
                    if (!datos.IsDBNull(2))
                    {
                        theUsuarioDTO.Paterno = datos.GetString(2);
                    }
                    if (!datos.IsDBNull(3))
                    {
                        theUsuarioDTO.Materno = datos.GetString(3);
                    }
                    if (!datos.IsDBNull(4))
                    {
                        theUsuarioDTO.Mail = datos.GetString(4);
                    }
                    if (!datos.IsDBNull(13))
                    {
                        theUsuarioDTO.Estado = datos.GetInt32(13).ToString();
                    }
                    usuario.Add(theUsuarioDTO);

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }

            finally
            {
                myConnection.Close();
            }

            return usuario;
        }
        /// <summary>
        /// Lista todos los administradores
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioDTO> ListaAdministradores()
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_listaAdministradores", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader datos;
            UsuarioDTO theUsuarioDTO;
            List<UsuarioDTO> usuario = new List<UsuarioDTO>();

            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theUsuarioDTO = new UsuarioDTO();

                    //if (!datos.IsDBNull(0))
                    //{
                    //    theUsuarioDTO.Rut = datos.GetInt32(0).ToString();
                    //}
                    //if (!datos.IsDBNull(1))
                    //{
                    //    theUsuarioDTO.UsuarioIngreso = datos.GetString(1);
                    //}
                    //if (!datos.IsDBNull(2))
                    //{
                    //    theUsuarioDTO.FechaIngreso = datos.GetDateTime(2).ToString();
                    //}
                    //if (!datos.IsDBNull(3))
                    //{
                    //    theUsuarioDTO.Estado = datos.GetString(3);
                    //}
                    //if (!datos.IsDBNull(4))
                    //{
                    //    theUsuarioDTO.Nombres = datos.GetString(4);
                    //}
                    //if (!datos.IsDBNull(5))
                    //{
                    //    theUsuarioDTO.Empresa = datos.GetInt32(5).ToString();
                    //}
                    //if (!datos.IsDBNull(6))
                    //{
                    //    theUsuarioDTO.OperadorDescripcion = datos.GetString(6);
                    //}
                    //if (!datos.IsDBNull(7))
                    //{
                    //    theUsuarioDTO.Paterno = datos.GetString(7);
                    //}
                    //if (!datos.IsDBNull(8))
                    //{
                    //    theUsuarioDTO.Materno = datos.GetString(8);
                    //}
                    //if (!datos.IsDBNull(9))
                    //{
                    //    theUsuarioDTO.Mail = datos.GetString(9);
                    //}
                    //if (!datos.IsDBNull(10))
                    //{
                    //    theUsuarioDTO.Password = datos.GetString(10);
                    //}
                    //if (!datos.IsDBNull(11))
                    //{
                    //    theUsuarioDTO.UsuarioModificacion = datos.GetString(11);
                    //}
                    //if (!datos.IsDBNull(12))
                    //{
                    //    theUsuarioDTO.FechaModificacion = datos.GetDateTime(12).ToString();
                    //}
                    //usuario.Add(theUsuarioDTO);

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }

            finally
            {
                myConnection.Close();
            }

            return usuario;
        }


        /// <summary>
        /// lista Funciones Asociadas a Grupo para el perfilamiento de usuario
        /// </summary>
        /// <returns></returns>
        public static List<FuncionDTO> ListaFunciones(int FuncionGrupo)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_listaFuncionesGrupo", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@FuncionGrupoCod", SqlDbType.Int).Value = FuncionGrupo;
            SqlDataReader datos;
            FuncionDTO theFuncionDTO;
            List<FuncionDTO> funciones = new List<FuncionDTO>();
            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theFuncionDTO = new FuncionDTO();

                    if (!datos.IsDBNull(0))
                    {
                        theFuncionDTO.FuncionCod = datos.GetInt32(0).ToString();
                    }
                    if (!datos.IsDBNull(1))
                    {
                        theFuncionDTO.FuncionNombre = datos.GetString(1);
                    }
                    funciones.Add(theFuncionDTO);

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }

            finally
            {
                myConnection.Close();
            }

            return funciones;
        }

        public static List<FuncionDTO> ListaPermisos(string Usuario)
        {
            SqlConnection myConnection = IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("PermisosUsuario", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Usuario;
            SqlDataReader datos;
            FuncionDTO theFuncionDTO;

            List<FuncionDTO> funciones = new List<FuncionDTO>();
            try
            {
                myConnection.Open();
                datos = myCommand.ExecuteReader();
                while (datos.Read())
                {
                    theFuncionDTO = new FuncionDTO();

                    if (!datos.IsDBNull(0))
                    {
                        theFuncionDTO.FuncionNombre = datos.GetString(0);
                    }
                    if (!datos.IsDBNull(1))
                    {
                        theFuncionDTO.FuncionCod = datos.GetInt32(1).ToString();
                    }
                    if (!datos.IsDBNull(2))
                    {
                        theFuncionDTO.EnviaCorreo = datos.GetString(2);
                    }
                    //if (!datos.IsDBNull(2))
                    //{
                    //    theFuncionDTO.Estado = datos.GetString(3);
                    //}
                    funciones.Add(theFuncionDTO);

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }

            finally
            {
                myConnection.Close();
            }

            return funciones;
        }
    }
}
