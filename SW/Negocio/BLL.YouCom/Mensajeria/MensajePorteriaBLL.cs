using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;
using YouCom.Mensajeria.DAL;

namespace YouCom.bll.Mensajeria
{
    public class MensajePorteriaBLL
    {

        public static IList<MensajePorteriaDTO> getListadoMensajePorteriaByPadre(decimal idPadre)
        {
            var mensajes = listaMensajePorteriaActivo().Where(x => x.IdPadre == idPadre).ToList();
            return mensajes;
        }
        public static IList<MensajePorteriaDTO> getListadoMensajePorteria()
        {
            var MensajePorteria = YouCom.facade.Mensajeria.MensajePorteria.getListadoMensajePorteria();
            return MensajePorteria;
        }

        public static MensajePorteriaDTO detalleMensajePorteria(decimal idMensajePorteria)
        {
            IList<MensajePorteriaDTO> collMensajePorteria;
            MensajePorteriaDTO MensajePorteria = new MensajePorteriaDTO();

            collMensajePorteria = getListadoMensajePorteria();

            if (collMensajePorteria.Any())
            {
                MensajePorteria = collMensajePorteria.Where(x => x.IdMensajePorteria == idMensajePorteria).First();
            }

            return MensajePorteria;
        }

        public static IList<MensajePorteriaDTO> getListadoMensajePorteriaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaMensajePorteriaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<MensajePorteriaDTO> listaMensajePorteriaActivo()
        {
            IList<MensajePorteriaDTO> MensajePorterias;
            MensajePorterias = facade.Mensajeria.MensajePorteria.getListadoMensajePorteria().Where(x => x.Estado == "1").ToList();
            return MensajePorterias;
        }

        public static IList<MensajePorteriaDTO> listaMensajePorteriaInactivo()
        {
            IList<MensajePorteriaDTO> MensajePorterias;
            MensajePorterias = facade.Mensajeria.MensajePorteria.getListadoMensajePorteria().Where(x => x.Estado == "2").ToList();
            return MensajePorterias;
        }

        public static bool Delete(MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePorteriaDAL.Delete(myMensajePorteriaDTO);
            return resultado;
        }

        public static bool Insert(MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePorteriaDAL.Insert(myMensajePorteriaDTO);
            return resultado;
        }

        public static bool Update(MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePorteriaDAL.Update(myMensajePorteriaDTO);
            return resultado;
        }

        public static bool ActivaMensajePorteria(MensajePorteriaDTO theMensajePorteriaDTO)
        {
            bool respuesta = YouCom.Mensajeria.DAL.MensajePorteriaDAL.ActivaMensajePorteria(theMensajePorteriaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionMensajePorteria(MensajePorteriaDTO theMensajePorteriaDTO)
        {
            bool respuesta = facade.Mensajeria.MensajePorteria.ValidaEliminacionMensajePorteria(theMensajePorteriaDTO);
            return respuesta;
        }
    }
}
