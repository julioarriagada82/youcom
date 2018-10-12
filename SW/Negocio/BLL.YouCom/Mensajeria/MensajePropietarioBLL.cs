using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class MensajePropietarioBLL
    {
        public static MensajePropietarioDTO getObtenerUltimoMensaje()
        {
            var mensajes = listaMensajePropietarioActivo().OrderByDescending(x => x.IdMensajePropietario).First();
            return mensajes;
        }

        public static IList<MensajePropietarioDTO> getListadoMensajePropietarioByPadre(decimal idPadre)
        {
            var mensajes = listaMensajePropietarioActivo().Where(x => x.IdPadre == idPadre).OrderByDescending(x => x.MensajeFecha).ToList();
            return mensajes;
        }
        public static IList<MensajePropietarioDTO> getListadoMensajePropietario()
        {
            var MensajePropietario = YouCom.facade.Mensajeria.MensajePropietario.getListadoMensajePropietario();
            return MensajePropietario;
        }

        public static MensajePropietarioDTO detalleMensajePropietario(decimal idMensajePropietario)
        {
            IList<MensajePropietarioDTO> collMensajePropietarios;
            MensajePropietarioDTO MensajePropietarios = new MensajePropietarioDTO();

            collMensajePropietarios = getListadoMensajePropietario();

            if(collMensajePropietarios.Any())
            {
                MensajePropietarios = collMensajePropietarios.Where(x => x.IdMensajePropietario == idMensajePropietario).First();
            }

            return MensajePropietarios;
        }

        public static IList<MensajePropietarioDTO> getListadoMensajePropietarioByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaMensajePropietarioActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<MensajePropietarioDTO> listaMensajePropietarioActivo()
        {
            IList<MensajePropietarioDTO> MensajePropietarios;
            MensajePropietarios = facade.Mensajeria.MensajePropietario.getListadoMensajePropietario().Where(x => x.Estado == "1").ToList();
            return MensajePropietarios;
        }

        public static IList<MensajePropietarioDTO> listaMensajePropietarioInactivo()
        {
            IList<MensajePropietarioDTO> MensajePropietarios;
            MensajePropietarios = facade.Mensajeria.MensajePropietario.getListadoMensajePropietario().Where(x => x.Estado == "2").ToList();
            return MensajePropietarios;
        }

        public static bool Delete(MensajePropietarioDTO myMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePropietarioDAL.Delete(myMensajePropietarioDTO);
            return resultado;
        }

        public static bool Insert(MensajePropietarioDTO myMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePropietarioDAL.Insert(myMensajePropietarioDTO);
            return resultado;
        }

        public static bool Update(MensajePropietarioDTO myMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePropietarioDAL.Update(myMensajePropietarioDTO);
            return resultado;
        }

        public static bool ActivaMensajePropietario(MensajePropietarioDTO theMensajePropietarioDTO)
        {
            bool respuesta = YouCom.Mensajeria.DAL.MensajePropietarioDAL.ActivaMensajePropietario(theMensajePropietarioDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionMensajePropietario(MensajePropietarioDTO theMensajePropietarioDTO)
        {
            bool respuesta = facade.Mensajeria.MensajePropietario.ValidaEliminacionMensajePropietario(theMensajePropietarioDTO);
            return respuesta;
        }
    }
}
