using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace SeguridadBLL
{
    public class Seguridad
    {
        public static List<OperadorDTO> LoginPrivado(string mvarUsuarioCod, string mvarPassword)
        {
            YouCom.Seguridad.DAL.LoginCasa theLogin = new YouCom.Seguridad.DAL.LoginCasa();
            List<OperadorDTO> theOperadorDTO = new List<OperadorDTO>();
            theOperadorDTO = theLogin.LoginPrivado(mvarUsuarioCod, mvarPassword);

            return theOperadorDTO;
        }

        public static List<OperadorDTO> LoginUsuario(string mvarUsuarioCod, string mvarPassword)
        {
            YouCom.Seguridad.DAL.Login theLogin = new YouCom.Seguridad.DAL.Login();
            List<OperadorDTO> theOperadorDTO = new List<OperadorDTO>();
            theOperadorDTO = theLogin.LoginUsuario(mvarUsuarioCod, mvarPassword);

            return theOperadorDTO;
        }
    }
}
