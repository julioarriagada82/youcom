using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class NoticiaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<NoticiaDTO> getListadoNoticia()
        {
            var noticia = YouCom.facade.Noticia.getListadoNoticia();
            return noticia;
        }

        public static NoticiaDTO detalleNoticia(decimal idNoticia)
        {
            NoticiaDTO noticia;
            noticia = facade.Noticia.getListadoNoticia().Where(x => x.NoticiaId == idNoticia).First();
            return noticia;
        }

        public static IList<NoticiaDTO> getListadoNoticiaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var noticia = listaNoticiaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return noticia;
        }

        public static IList<NoticiaDTO> listaNoticiaActivo()
        {
            IList<NoticiaDTO> noticia;
            noticia = facade.Noticia.getListadoNoticia().Where(x => x.Estado == "1").ToList();
            return noticia;
        }

        public static IList<NoticiaDTO> listaNoticiaInactivo()
        {
            IList<NoticiaDTO> noticia;
            noticia = facade.Noticia.getListadoNoticia().Where(x => x.Estado == "2").ToList();
            return noticia;
        }

        public static bool Delete(DTO.NoticiaDTO myNoticiaDTO)
        {
            bool resultado = NoticiaDAL.Delete(myNoticiaDTO);
            return resultado;
        }

        public static bool Insert(DTO.NoticiaDTO myNoticiaDTO)
        {
            bool resultado = NoticiaDAL.Insert(myNoticiaDTO);
            return resultado;
        }

        public static bool Update(DTO.NoticiaDTO myNoticiaDTO)
        {
            bool resultado = NoticiaDAL.Update(myNoticiaDTO);
            return resultado;
        }

        public static bool ActivaNoticia(NoticiaDTO theNoticiaDTO)
        {
            bool respuesta = NoticiaDAL.ActivaNoticia(theNoticiaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionNoticia(NoticiaDTO theNoticiaDTO)
        {
            bool respuesta = facade.Noticia.ValidaEliminacionNoticia(theNoticiaDTO);
            return respuesta;
        }
    }
}
