using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.BLL
{
    public class UsuarioBLL
    {
        public static bool Insert(OperadorDTO myUsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.UsuarioDAL.Insert(myUsuarioDTO);
            return resultado;
        }

        public static bool Update(OperadorDTO myUsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.UsuarioDAL.Update(myUsuarioDTO);
            return resultado;
        }

        public static bool ActivaDesactivaUsuario(OperadorDTO UsuarioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.UsuarioDAL.ActivaUsuario(UsuarioDTO);
            return resultado;
        }

        public static IList<OperadorDTO> getListadoUsuario()
        {
            var resultado = YouCom.facade.Seguridad .Usuario.getListadoUsuario();
            return resultado;
        }
    }
}
