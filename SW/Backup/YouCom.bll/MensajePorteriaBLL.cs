using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class MensajePorteriaBLL
    {
        public static IList<MensajePorteriaDTO> getListadoMensajePorteria()
        {
            YouCom.facade.MensajePorteria MensajePorteriaFA = new YouCom.facade.MensajePorteria();
            var MensajePorteria = YouCom.facade.MensajePorteria.getListadoMensajePorteria();
            return MensajePorteria;
        }

        public static MensajePorteriaDTO detalleMensajePorteria(decimal idMensajePorteria)
        {
            MensajePorteriaDTO MensajePorterias;
            MensajePorterias = facade.MensajePorteria.getListadoMensajePorteria().Where(x => x.IdMensajePorteria == idMensajePorteria).First();
            return MensajePorterias;
        }

        public static IList<MensajePorteriaDTO> listaMensajePorteriaActivo()
        {
            IList<MensajePorteriaDTO> MensajePorterias;
            MensajePorterias = facade.MensajePorteria.getListadoMensajePorteria().Where(x => x.Estado == "1").ToList();
            return MensajePorterias;
        }

        public static IList<MensajePorteriaDTO> listaMensajePorteriaInactivo()
        {
            IList<MensajePorteriaDTO> MensajePorterias;
            MensajePorterias = facade.MensajePorteria.getListadoMensajePorteria().Where(x => x.Estado == "2").ToList();
            return MensajePorterias;
        }

        public static bool Delete(DTO.MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePorteriaDAL.Delete(myMensajePorteriaDTO);
            return resultado;
        }

        public static bool Insert(DTO.MensajePorteriaDTO myMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajePorteriaDAL.Insert(myMensajePorteriaDTO);
            return resultado;
        }

        public static bool Update(DTO.MensajePorteriaDTO myMensajePorteriaDTO)
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
            bool respuesta = facade.MensajePorteria.ValidaEliminacionMensajePorteria(theMensajePorteriaDTO);
            return respuesta;
        }
    }
}
