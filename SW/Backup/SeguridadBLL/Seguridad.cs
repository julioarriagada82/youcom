using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace SeguridadBLL
{
    public class Seguridad
    {
        public static List<FuncionDTO> ListaPermisos(string Usuario)
        {
            List<FuncionDTO> Permisos = new List<FuncionDTO>();
            Permisos = YouCom.Seguridad.DAL.Perfilamiento.ListaPermisos(Usuario);
            return Permisos;

        }

        public static List<UsuarioDTO> LoginPrivado(string mvarUsuarioCod, string mvarPassword)
        {
            YouCom.Seguridad.DAL.LoginCasa theLogin = new YouCom.Seguridad.DAL.LoginCasa();
            List<UsuarioDTO> theOperadorDTO = new List<UsuarioDTO>();
            theOperadorDTO = theLogin.LoginPrivado(mvarUsuarioCod, mvarPassword);

            return theOperadorDTO;
        }

        public static List<UsuarioDTO> LoginUsuario(string mvarUsuarioCod, string mvarPassword)
        {
            YouCom.Seguridad.DAL.Login theLogin = new YouCom.Seguridad.DAL.Login();
            List<UsuarioDTO> theOperadorDTO = new List<UsuarioDTO>();
            theOperadorDTO = theLogin.LoginUsuario(mvarUsuarioCod, mvarPassword);

            return theOperadorDTO;
        }
        public static List<FuncionGrupoDTO> ListaGruposSistema()
        {
            List<FuncionGrupoDTO> grupos = new List<FuncionGrupoDTO>();
            grupos = YouCom.Seguridad.DAL.Perfilamiento.ListaGruposSistema();
            return grupos;
        }
        public static void InsertaPermisos(PermisoDTO thePermisoDTO)
        {
            YouCom.Seguridad.DAL.Perfilamiento.InsertaPermisos(thePermisoDTO);
        }

        public static void DeletePermisos(PermisoDTO thePermisoDTO)
        {
            YouCom.Seguridad.DAL.Perfilamiento.DeletePermisos(thePermisoDTO);
        }

        public static int InsertaCondominio(CondominioDTO theCondominioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.InsertarCondominio(theCondominioDTO);
            return resultado;
        }
        public static int updateCondominio(CondominioDTO theCondominioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.UpdateCondominio(theCondominioDTO);
            return resultado;
        }
        public static int deleteCondominio(CondominioDTO theCondominioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.DeleteCondominio(theCondominioDTO);
            return resultado;
        }
        public static List<CondominioDTO> ListaCondominios()
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.ListaCondominios();
            return resultado;
        }
        public static List<CondominioDTO> ListaCondominiosActivos()
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.ListaCondominios().Where(x => x.Estado == "Activo").ToList();
            return resultado;
        }

        public static int InsertarUsuario(UsuarioDTO UsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.InsertarUsuario(UsuarioDTO);
            return resultado;
        }
        public static int InsertarAdministrador(UsuarioDTO UsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.InsertarAdministrador(UsuarioDTO);
            return resultado;
        }
        public static int UpdateAdministrador(UsuarioDTO theUsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.UpdateAdministrador(theUsuarioDTO);
            return resultado;
        }
        public static List<UsuarioDTO> ListaAdministradores()
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.ListaAdministradores();
            return resultado;
        }
        public static int ActivaDesactivaUsuario(UsuarioDTO UsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.ActivaDesactivaUsuario(UsuarioDTO);
            return resultado;
        }

        public static List<UsuarioDTO> ListaUsuarios()
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.ListaUsuarios();
            return resultado;
        }
        public static List<FuncionDTO> ListaFunciones(int FuncionGrupo)
        {
            var resultado = YouCom.Seguridad.DAL.Perfilamiento.ListaFunciones(FuncionGrupo);
            return resultado;

        }

    }
}
