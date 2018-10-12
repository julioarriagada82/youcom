using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class MensajeNoticiaBLL
    {
        public static IList<MensajeNoticiaDTO> getListadoMensajeNoticiaByPadre(decimal idPadre)
        {
            var mensajes = listaMensajeNoticiaActivo().Where(x => x.IdPadre == idPadre).OrderByDescending(x => x.MensajeFecha).ToList();
            return mensajes;
        }
        public static IList<MensajeNoticiaDTO> getListadoMensajeNoticia()
        {
            var MensajeNoticia = YouCom.facade.Mensajeria.MensajeNoticia.getListadoMensajeNoticia();
            return MensajeNoticia;
        }

        public static MensajeNoticiaDTO detalleMensajeNoticia(decimal idMensajeNoticia)
        {
            IList<MensajeNoticiaDTO> collMensajeNoticia;
            MensajeNoticiaDTO MensajeNoticia = new MensajeNoticiaDTO();

            collMensajeNoticia = getListadoMensajeNoticia();

            if (collMensajeNoticia.Any())
            {
                MensajeNoticia = collMensajeNoticia.Where(x => x.IdMensajeNoticia == idMensajeNoticia).First();
            }

            return MensajeNoticia;
        }

        public static IList<MensajeNoticiaDTO> getListadoMensajeNoticiaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaMensajeNoticiaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<MensajeNoticiaDTO> listaMensajeNoticiaActivo()
        {
            IList<MensajeNoticiaDTO> MensajeNoticias;
            MensajeNoticias = facade.Mensajeria.MensajeNoticia.getListadoMensajeNoticia().Where(x => x.Estado == "1").ToList();
            return MensajeNoticias;
        }

        public static IList<MensajeNoticiaDTO> listaMensajeNoticiaInactivo()
        {
            IList<MensajeNoticiaDTO> MensajeNoticias;
            MensajeNoticias = facade.Mensajeria.MensajeNoticia.getListadoMensajeNoticia().Where(x => x.Estado == "2").ToList();
            return MensajeNoticias;
        }

        public static bool Delete(MensajeNoticiaDTO myMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajeNoticiaDAL.Delete(myMensajeNoticiaDTO);
            return resultado;
        }

        public static bool Insert(MensajeNoticiaDTO myMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajeNoticiaDAL.Insert(myMensajeNoticiaDTO);
            return resultado;
        }

        public static bool Update(MensajeNoticiaDTO myMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajeNoticiaDAL.Update(myMensajeNoticiaDTO);
            return resultado;
        }

        public static bool ActivaMensajeNoticia(MensajeNoticiaDTO theMensajeNoticiaDTO)
        {
            bool respuesta = YouCom.Mensajeria.DAL.MensajeNoticiaDAL.ActivaMensajeNoticia(theMensajeNoticiaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionMensajeNoticia(MensajeNoticiaDTO theMensajeNoticiaDTO)
        {
            bool respuesta = facade.Mensajeria.MensajeNoticia.ValidaEliminacionMensajeNoticia(theMensajeNoticiaDTO);
            return respuesta;
        }
    }
}
