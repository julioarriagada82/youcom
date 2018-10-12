using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class MensajeTipoBLL
    {
        public static IList<MensajeTipoDTO> getListadoMensajeTipo()
        {
            var mensaje_tipo = YouCom.facade.Mensajeria.MensajeTipo.getListadoMensajeTipo();
            return mensaje_tipo;
        }

        public static MensajeTipoDTO detalleMensajeTipo(decimal idMensajeTipo)
        {
            var mensaje_tipo = getListadoMensajeTipo().Where(x => x.IdMensajeTipo == idMensajeTipo).SingleOrDefault();
            return mensaje_tipo;
        }

        public static IList<MensajeTipoDTO> listaMensajeTipoActivo()
        {
            IList<MensajeTipoDTO> mensaje_tipo;
            mensaje_tipo = facade.Mensajeria.MensajeTipo.getListadoMensajeTipo().Where(x => x.Estado == "1").ToList();
            return mensaje_tipo;
        }

        public static IList<MensajeTipoDTO> listaMensajeTipoInactivo()
        {
            IList<MensajeTipoDTO> mensaje_tipo;
            mensaje_tipo = facade.Mensajeria.MensajeTipo.getListadoMensajeTipo().Where(x => x.Estado == "2").ToList();
            return mensaje_tipo;
        }

        public static bool Delete(MensajeTipoDTO myMensajeTipoDTO)
        {
            bool mensaje_tipo = YouCom.Mensajeria.DAL.Mensajeria.MensajeTipoDAL.Delete(myMensajeTipoDTO);
            return mensaje_tipo;
        }

        public static bool Insert(MensajeTipoDTO myMensajeTipoDTO)
        {
            bool mensaje_tipo = YouCom.Mensajeria.DAL.Mensajeria.MensajeTipoDAL.Insert(myMensajeTipoDTO);
            return mensaje_tipo;
        }

        public static bool Update(MensajeTipoDTO myMensajeTipoDTO)
        {
            bool mensaje_tipo = YouCom.Mensajeria.DAL.Mensajeria.MensajeTipoDAL.Update(myMensajeTipoDTO);
            return mensaje_tipo;
        }

        public static bool ActivaMensajePropietario(MensajeTipoDTO theMensajeTipoDTO)
        {
            bool mensaje_tipo = YouCom.Mensajeria.DAL.Mensajeria.MensajeTipoDAL.ActivaNotificaciones(theMensajeTipoDTO);
            return mensaje_tipo;
        }

        public static bool ValidaEliminacionMensajePropietario(MensajeTipoDTO theMensajeTipoDTO)
        {
            bool mensaje_tipo = facade.Mensajeria.MensajeTipo.ValidaEliminacionMensajeTipo(theMensajeTipoDTO);
            return mensaje_tipo;
        }
    }
}
